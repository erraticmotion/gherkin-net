﻿// ---------------------------------------------------------------------------
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
    using System.Globalization;

    using ErraticMotion.Test.Tools.Gherkin;

    internal class LanguageInfo : ILanguageInfo
    {
        private readonly Func<GherkinKeyword, string, ILanguageSyntax<GherkinKeyword>> keyword;
        private readonly Func<GherkinStep, string, ILanguageSyntax<GherkinStep>> step;

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

        public string Code { get; private set; }

        public string EnglishName { get; private set; }

        public CultureInfo CultureInfo { get; private set; }

        public CultureInfo SpecificCultureInfo { get; private set; }

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