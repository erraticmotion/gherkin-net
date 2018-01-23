// ---------------------------------------------------------------------------
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

namespace ErraticMotion.Test.Tools.Gherkin
{
    using System.Globalization;

    public static class GherkinKeywordExtensions
    {
        /// <summary>
        /// Determines whether the beginning of the <paramref name="line"/> matches the <paramref name="keyword"/>.
        /// </summary>
        /// <param name="line">The line to match.</param>
        /// <param name="keyword">The gherkin keyword.</param>
        /// <returns><c>true</c> to indicate a match; otherwise <c>false</c>.</returns>
        public static bool StartsWith(this string line, GherkinKeyword keyword)
        {
            switch (keyword)
            {
                case GherkinKeyword.Where:
                    return line.TrimStart().StartsWith("where", true, CultureInfo.CurrentCulture);

                case GherkinKeyword.ScenarioOutline:
                    return line.TrimStart().StartsWith("scenario outline:", true, CultureInfo.CurrentCulture);

                default:
                    return line.TrimStart().StartsWith(keyword + ":", true, CultureInfo.CurrentCulture);
            }
        }

        public static bool StartsWith(this string line, ILanguageSyntax<GherkinKeyword> info)
        {
            switch (info.Syntax)
            {
                case GherkinKeyword.Where:
                    return line.TrimStart().StartsWith(info.Localised, true, CultureInfo.CurrentCulture);

                case GherkinKeyword.ScenarioOutline:
                    return line.TrimStart().StartsWith(info.Localised + ":", true, CultureInfo.CurrentCulture);

                default:
                    return line.TrimStart().StartsWith(info.Localised + ":", true, CultureInfo.CurrentCulture);   
            }
        }

        /// <summary>
        /// Returns the name part of the <paramref name="value"/> after matching the <paramref name="keyword"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="keyword">The gherkin keyword.</param>
        /// <returns>A string representation of the name value.</returns>
        public static string Name(this string value, GherkinKeyword keyword)
        {
            if (!value.Contains(":"))
            {
                if (keyword == GherkinKeyword.Where)
                {
                    return string.Empty;
                }

                var msg = string.Format(CultureInfo.CurrentCulture, "The Gherkin keyword {0} was not followed by a ':' character", keyword);
                throw new GherkinException(GherkinExceptionType.InvalidGherkin, msg);
            }

            return value.Split(':')[1]
                .Replace("-", " ")
                .Replace("'", " ")
                .Replace("/", " ")
                .Replace(">", " ")
                .Trim();
        }

        public static string Name(this string value, ILanguageSyntax<GherkinKeyword> info)
        {
            return value.Name(info.Syntax);
        }

        public static string Format(this GherkinKeyword keyword)
        {
            return keyword.Format("[", "]");
        }

        public static string Format(this ILanguageSyntax<GherkinKeyword> info)
        {
            return info.Format("[", "]");
        }

        public static string Format(this GherkinKeyword keyword, string start, string end)
        {
            return string.Format(CultureInfo.CurrentCulture, "{0}{1}{2}", start, keyword, end);
        }

        public static string Format(this ILanguageSyntax<GherkinKeyword> info, string start, string end)
        {
            return string.Format(CultureInfo.CurrentCulture, "{0}{1}{2}", start, info.Localised, end);
        }
    }
}