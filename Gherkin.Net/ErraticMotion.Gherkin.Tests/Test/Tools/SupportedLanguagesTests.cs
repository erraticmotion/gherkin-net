// <copyright file="SupportedLanguagesTests.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools
{
    using FluentAssertions;

    using NUnit.Framework;

    public class SupportedLanguagesTests
    {
        [Test]
        public void ShouldSupportEnglish()
        {
            var item = SupportedLanguages.GetSupportedLanguage("en");
            item.Should().NotBeNull();
        }

        [Test]
        public void ShouldSupportEnglishUk()
        {
            var item = SupportedLanguages.GetSupportedLanguage("en-UK");
            item.Should().NotBeNull();
        }

        [Test]
        public void ShouldSupportFrench()
        {
            var item = SupportedLanguages.GetSupportedLanguage("fr");
            item.Should().NotBeNull();
        }

        [Test]
        public void ShouldNotSupportGerman()
        {
            Should.Throw<Gherkin.GherkinException>(() => SupportedLanguages.GetSupportedLanguage("de"));
        }
    }
}