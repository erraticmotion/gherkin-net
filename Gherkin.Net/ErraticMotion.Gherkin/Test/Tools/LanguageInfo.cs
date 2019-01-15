// <copyright file="LanguageInfo.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools
{
    using System;
    using System.Globalization;

    using ErraticMotion.Test.Tools.Gherkin;

    internal class LanguageInfo : ILanguageInfo
    {
        private readonly Func<GherkinKeyword, string, ILanguageSyntax<GherkinKeyword>> keyword;
        private readonly Func<GherkinStep, string, ILanguageSyntax<GherkinStep>> step;

        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageInfo"/> class.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="name">The name.</param>
        /// <param name="cultureInfo">The culture information.</param>
        /// <param name="specificCultueInfo">The specific cultue information.</param>
        /// <param name="find">The find.</param>
        public LanguageInfo(
            string code,
            string name,
            CultureInfo cultureInfo,
            CultureInfo specificCultueInfo,
            Func<string, string> find)
        {
            this.Code = code;
            this.EnglishName = name;
            this.CultureInfo = cultureInfo;
            this.SpecificCultureInfo = specificCultueInfo;
            this.keyword = (s, f) => new LocalisedKeyword
            {
                Syntax = s,
                Localised = find(f)
            };

            this.step = (s, f) => new LocalisedStep
            {
                Syntax = s,
                Localised = find(f)
            };
        }

        public string Code { get; }

        public string EnglishName { get; }

        public CultureInfo CultureInfo { get; }

        public CultureInfo SpecificCultureInfo { get; }

        public ILanguageSyntax<GherkinKeyword> Get(GherkinKeyword value)
        {
            switch (value)
            {
                case GherkinKeyword.Background:
                    return this.keyword(value, "Background");
                case GherkinKeyword.Feature:
                    return this.keyword(value, "Feature");
                case GherkinKeyword.Scenario:
                    return this.keyword(value, "Scenario");
                case GherkinKeyword.ScenarioOutline:
                    return this.keyword(value, "ScenarioOutline");
                case GherkinKeyword.Scenarios:
                    return this.keyword(value, "Scenarios");
                case GherkinKeyword.Examples:
                    return this.keyword(value, "Examples");
                case GherkinKeyword.Where:
                    return this.keyword(value, "Where");
            }

            return this.keyword(value, string.Empty);
        }

        public ILanguageSyntax<GherkinStep> Get(GherkinStep value)
        {
            switch (value)
            {
                case GherkinStep.Given:
                    return this.step(value, "Given");
                case GherkinStep.When:
                    return this.step(value, "When");
                case GherkinStep.Then:
                    return this.step(value, "Then");
                case GherkinStep.And:
                    return this.step(value, "And");
                case GherkinStep.But:
                    return this.step(value, "But");
            }

            return this.step(value, string.Empty);
        }

        private class LocalisedKeyword : ILanguageSyntax<GherkinKeyword>
        {
            public GherkinKeyword Syntax { get; set; }

            public string Localised { get; set; }
        }

        private class LocalisedStep : ILanguageSyntax<GherkinStep>
        {
            public GherkinStep Syntax { get; set; }

            public string Localised { get; set; }
        }
    }
}