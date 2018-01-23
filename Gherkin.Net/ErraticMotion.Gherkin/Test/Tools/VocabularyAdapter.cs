// ---------------------------------------------------------------------------
// (C) 2016 Parkeon Limited.
// 
//  No part of this source code may be reproduced, digitised, stored in a 
//  retrieval system, communicated to the public or caused to be seen or heard 
//  in public, made publicly available or publicly performed, offered for sale 
//  or hire or exhibited by way of trade in public or distributed by way of trade 
//  in any form or by any means, electronic, mechanical or otherwise without the 
//  written permission of Parkeon Limited.
// 
// ---------------------------------------------------------------------------
namespace ErraticMotion.Test.Tools
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using ErraticMotion.Test.Tools.Gherkin;

    internal class VocabularyAdapter : IGherkinVocabulary
    {
        private readonly List<IGherkinSyntax> vocabulary = new List<IGherkinSyntax>();

        public VocabularyAdapter(ILanguageSupport item)
        {
            this.Code = item.LanguageInfo.Code;

            foreach (var keyword in item.Keywords)
            {
                this.vocabulary.Add(new GherkinSyntax(keyword));
            }

            foreach (var step in item.Steps)
            {
                this.vocabulary.Add(new GherkinSyntax(step));
            }
        }

        public string Code { get; private set; }

        public IEnumerable<IGherkinSyntax> Vocabulary { get { return this.vocabulary; } }

        public override string ToString()
        {
            return this.ToString("a", null);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "A";
            }

            switch (format.ToUpper())
            {
                case "L": // Language
                    return string.Format("# language: {0}", this.Code);

                case "V": // Vocabulary
                    var builder = new StringBuilder();
                    foreach (var syntax in this.Vocabulary)
                    {
                        builder.AppendLine(syntax.ToString());
                    }

                    return builder.ToString();

                default:
                    return string.Format("{0:l}\n{0:v}", this);
            }
        }

        private class GherkinSyntax : IGherkinSyntax
        {
            public GherkinSyntax(ILanguageSyntax<GherkinKeyword> item)
            {
                this.Keyword = item.Syntax.ToString();
                this.CultureSpecific = item.Localised;
            }

            public GherkinSyntax(ILanguageSyntax<GherkinStep> item)
            {
                this.Keyword = item.Syntax.ToString();
                this.CultureSpecific = item.Localised;
            }

            public string Keyword { get; private set; }

            public string CultureSpecific { get; private set; }

            public override string ToString()
            {
                return string.Format("   {0, 15}: {1}", this.Keyword, this.CultureSpecific);
            }
        }
    }
}