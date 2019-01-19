// <copyright file="ILanguageSupport.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools
{
    using System.Collections.Generic;

    using ErraticMotion.Test.Tools.Gherkin;

    /// <summary>
    /// Represents the culture specific Gherkin keywords and steps for a specific language.
    /// </summary>
    public interface ILanguageSupport
    {
        /// <summary>
        /// Gets the language information.
        /// </summary>
        ILanguageInfo LanguageInfo { get; }

        /// <summary>
        /// Gets the culture specific keywords.
        /// </summary>
        IEnumerable<ILanguageSyntax<GherkinKeyword>> Keywords { get; }

        /// <summary>
        /// Gets the culture specific steps.
        /// </summary>
        IEnumerable<ILanguageSyntax<GherkinStep>> Steps { get; }
    }
}