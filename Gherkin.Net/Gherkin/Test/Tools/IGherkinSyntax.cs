// <copyright file="IGherkinSyntax.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools
{
    /// <summary>
    /// Represents the Gherkin language keywords with their corresponding
    /// culture specific equivalents.
    /// </summary>
    public interface IGherkinSyntax
    {
        /// <summary>
        /// Gets the Gherkin keyword.
        /// </summary>
        string Keyword { get; }

        /// <summary>
        /// Gets the culture specific description of the <see cref="Keyword"/>.
        /// </summary>
        string CultureSpecific { get; }
    }
}