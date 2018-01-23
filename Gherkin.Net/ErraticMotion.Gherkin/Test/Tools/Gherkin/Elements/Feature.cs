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

namespace ErraticMotion.Test.Tools.Gherkin.Elements
{
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Represents the AST root object returned from the Gherkin Lexer.
    /// </summary>
    public class Feature : GherkinKeywordBase, IGherkinFeature
    {
        public Feature(
            ILanguageInfo info,
            string name, 
            string description, 
            string ns,
            IGherkinBlock background, 
            IEnumerable<IGherkinScenario> scenarios, 
            IList<IGherkinComment> comments, 
            IList<IGherkinTag> tags,
            string sourceFile)
            : base(info, GherkinKeyword.Feature, name, description)
        {
            this.Background = background;
            this.Scenarios = new GherkinCollection<IGherkinScenario>(scenarios);
            this.Comments = new GherkinCollection<IGherkinComment>(comments);
            this.Tags = new GherkinCollection<IGherkinTag>(tags);
            this.SourceFile = sourceFile;
            this.Language = info.Code;
            this.Namespace = ns;
        }

        public string Language { get; private set; }

        public string Namespace { get; private set; }

        public string SourceFile { get; private set; }

        public IGherkinBlock Background { get; private set; }

        public IGherkinElements<IGherkinScenario> Scenarios { get; private set; }

        public IGherkinElements<IGherkinComment> Comments { get; private set; }

        public IGherkinElements<IGherkinTag> Tags { get; private set; }

        public IGherkinElements<string> Gherkin
        {
            get
            {
                var result = new GherkinCollectionString();
                foreach (var comment in this.Comments)
                {
                    result.AppendLine("#{0}", comment);
                }

                foreach (var tag in this.Tags)
                {
                    result.AppendLine("@{0}", tag);
                }

                result.AppendLine("{0}: {1}", this.Keyword.Format(), this.Name);
                result.AppendLine();
                if (!string.IsNullOrEmpty(this.Description))
                {
                    result.AppendLine("{0}", this.Description);
                    result.AppendLine();
                }

                if (this.Background != null)
                {
                    result.Append(this.Background);
                    result.AppendLine();
                }

                foreach (var scenario in this.Scenarios)
                {
                    result.Append(scenario);
                    result.AppendLine();
                }

                return result;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var element in this.Gherkin)
            {
                builder.AppendLine(element);
            }

            return builder.ToString();
        }
    }
}