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
        /// <summary>
        /// Initializes a new instance of the <see cref="SupportedLanguage"/> class.
        /// </summary>
        /// <param name="info">The information.</param>
        public SupportedLanguage(ILanguageInfo info)
        {
            this.LanguageInfo = info;
        }

        /// <inheritdoc />
        public ILanguageInfo LanguageInfo { get; }

        /// <inheritdoc />
        public IEnumerable<ILanguageSyntax<GherkinKeyword>> Keywords => this.LanguageInfo.AllKeywords();

        /// <inheritdoc />
        public IEnumerable<ILanguageSyntax<GherkinStep>> Steps => this.LanguageInfo.AllSteps();
    }
}