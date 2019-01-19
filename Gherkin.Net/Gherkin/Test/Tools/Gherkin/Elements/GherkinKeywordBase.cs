// <copyright file="GherkinKeywordBase.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

#define PREFER_GEHERKIN_PLUS

namespace ErraticMotion.Test.Tools.Gherkin.Elements
{
    internal abstract class GherkinKeywordBase : IGherkinKeyword
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

        public ILanguageSyntax<GherkinKeyword> Keyword { get; }

        public string Name { get; }

        public string Description { get; }
    }
}