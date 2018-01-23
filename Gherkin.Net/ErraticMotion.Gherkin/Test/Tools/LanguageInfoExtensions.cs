// <copyright file="LanguageInfoExtensions.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

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