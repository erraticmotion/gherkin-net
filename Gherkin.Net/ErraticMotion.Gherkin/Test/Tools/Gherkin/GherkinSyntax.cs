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