// <copyright file="StringExtensions.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin
{
    /// <summary>
    /// Contains extension methods for the <see cref="string"/> type.
    /// </summary>
    internal static class StringExtensions
    {
        /// <summary>
        /// Trims the specified value based on the gherkin step keyword.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="step">The keyword.</param>
        /// <returns>A string representation of the value after the value has been trimmed.</returns>
        public static string Trim(this string value, ILanguageSyntax<GherkinStep> step)
        {
            var l = step.Localised.Length + 1;
            return value.TrimStart().Remove(0, l).TrimStart();
        }
    }
}