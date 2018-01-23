// <copyright file="SupportedLanguage.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools
{
    using System.Collections.Generic;

    using ErraticMotion.Test.Tools.Gherkin;

    internal class SupportedLanguage : ILanguageSupport
    {
        public SupportedLanguage(ILanguageInfo info)
        {
            this.LanguageInfo = info;
        }

        public ILanguageInfo LanguageInfo { get; private set; }

        public IEnumerable<ILanguageSyntax<GherkinKeyword>> Keywords { get { return this.LanguageInfo.AllKeywords(); } }

        public IEnumerable<ILanguageSyntax<GherkinStep>> Steps { get { return this.LanguageInfo.AllSteps(); } }
    }
}