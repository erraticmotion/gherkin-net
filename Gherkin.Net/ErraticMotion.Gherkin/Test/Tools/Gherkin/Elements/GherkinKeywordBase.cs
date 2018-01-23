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

#define PREFER_GEHERKIN_PLUS

namespace ErraticMotion.Test.Tools.Gherkin.Elements
{
    public abstract class GherkinKeywordBase : IGherkinKeyword
    {
        protected GherkinKeywordBase(ILanguageInfo info, GherkinKeyword keyword, string name, string description)
        {
#if PREFER_GEHERKIN_PLUS
            switch (keyword)
            {
                case GherkinKeyword.ScenarioOutline:
                    this.Keyword = info.Get(GherkinKeyword.Scenarios);
                    break;

                case GherkinKeyword.Examples:
                    this.Keyword = info.Get(GherkinKeyword.Where);
                    break;

                default:
                    this.Keyword = info.Get(keyword);
                    break;
            }
#else
            Keyword = info.Get(keyword);
#endif
            this.Name = name ?? string.Empty;
            this.Description = description ?? string.Empty;
        }

        public ILanguageSyntax<GherkinKeyword> Keyword { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }
    }
}