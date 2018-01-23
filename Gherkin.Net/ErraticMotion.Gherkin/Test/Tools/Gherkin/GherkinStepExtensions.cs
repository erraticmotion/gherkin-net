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