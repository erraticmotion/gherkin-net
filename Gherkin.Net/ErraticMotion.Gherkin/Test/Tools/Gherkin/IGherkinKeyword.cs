// <copyright file="IGherkinKeyword.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin
{
    /// <summary>
    /// Represents a Gherkin keyword base interface.
    /// </summary>
    public interface IGherkinKeyword
    {
        /// <summary>
        /// Gets the gherkin keyword.
        /// </summary>
        ILanguageSyntax<GherkinKeyword> Keyword { get; }

        /// <summary>
        /// Gets an optional name related to this object.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets an optional description related to this object.
        /// </summary>
        string Description { get; }
    }
}