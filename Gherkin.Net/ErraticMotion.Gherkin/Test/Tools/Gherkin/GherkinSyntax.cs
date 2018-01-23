// <copyright file="GherkinSyntax.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal static class GherkinSyntax
    {
        public static string DocString { get { return "\"\"\""; } }

        public static string Comment { get { return "#"; } }

        public static string Tag { get { return "@"; } }

        public static IEnumerable<GherkinKeyword> GetKeywords()
        {
            return Enum.GetValues(typeof(GherkinKeyword)).Cast<GherkinKeyword>();
        }

        public static IEnumerable<GherkinStep> GetSteps()
        {
            return Enum.GetValues(typeof(GherkinStep)).Cast<GherkinStep>(); 
        }

        public static bool IsComment(this string line)
        {
            return line.Is(Comment);
        }

        public static bool IsTag(this string line)
        {
            return line.Is(Tag);
        }

        public static bool IsDocString(this string line)
        {
            return line.Is(DocString);
        }

        private static bool Is(this string line, string gherkin)
        {
            return line.TrimStart().StartsWith(gherkin, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}