// <copyright file="ILanguageSyntax.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools
{
    /// <summary>
    /// Represents a Gherkin keyword with it's corresponding localised string version.
    /// </summary>
    /// <typeparam name="T">The type of syntax.</typeparam>
    public interface ILanguageSyntax<out T>
    {
        /// <summary>
        /// Gets the Gherkin keyword.
        /// </summary>
        T Syntax { get; }

        /// <summary>
        /// Gets the localized string value that matches the keyword.
        /// </summary>
        string Localised { get; }
    }
}