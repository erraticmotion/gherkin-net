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

namespace ErraticMotion.Test.Tools
{
    using System.Collections.Generic;
    using System.Linq;

    using ErraticMotion.Test.Tools.Gherkin;

    public static class LanguageInfoExtensions
    {
        public static IEnumerable<ILanguageSyntax<GherkinKeyword>> All(
            this ILanguageInfo info,
            IEnumerable<GherkinKeyword> items)
        {
            return items.Select(info.Get);
        }

        public static IEnumerable<ILanguageSyntax<GherkinKeyword>> AllKeywords(this ILanguageInfo info)
        {
            return GherkinSyntax.GetKeywords().Select(info.Get);
        }

        public static IEnumerable<ILanguageSyntax<GherkinStep>> All(
            this ILanguageInfo info,
            IEnumerable<GherkinStep> items)
        {
            return items.Select(info.Get);
        }

        public static IEnumerable<ILanguageSyntax<GherkinStep>> AllSteps(this ILanguageInfo info)
        {
            return GherkinSyntax.GetSteps().Where(x => x != GherkinStep.None).Select(info.Get);
        }
    }
}