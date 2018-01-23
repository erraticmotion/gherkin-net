// <copyright file="GherkinStepExtensions.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin
{
    using System.Globalization;

    internal static class GherkinStepExtensions
    {
        public static bool StartsWith(this string line, GherkinStep step)
        {
            return line.TrimStart().StartsWith(step.ToString(), true, CultureInfo.CurrentCulture);
        }

        public static bool StartsWith(this string line, ILanguageSyntax<GherkinStep> info)
        {
            return line.TrimStart().StartsWith(info.Localised, true, CultureInfo.CurrentCulture);
        }

        public static string Format(this GherkinStep step)
        {
            return step.Format("[", "]");
        }

        public static string Format(this ILanguageSyntax<GherkinStep> info)
        {
            return info.Format("[", "]");
        }

        public static string Format(this GherkinStep step, string start, string end)
        {
            return string.Format(CultureInfo.CurrentCulture, "{0}{1}{2}", start, step, end);
        }

        public static string Format(this ILanguageSyntax<GherkinStep> info, string start, string end)
        {
            return string.Format(CultureInfo.CurrentCulture, "{0}{1}{2}", start, info.Localised, end);
        }
    }
}