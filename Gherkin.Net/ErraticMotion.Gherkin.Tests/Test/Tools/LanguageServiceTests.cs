// <copyright file="LanguageServiceTests.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools
{
    using FluentAssertions;

    using NUnit.Framework;

    [TestFixture(Category = "Language")]
    public class LanguageServiceTests : LanguageServiceBase
    {
        [Test]
        public void GetLanguageFromEn()
        {
            this.AddLanguage("# language: en");
            var result = this.GetLanguage("fr");
            result.Code.Should().Be("en");
        }

        [Test]
        public void GetLanguageFromFr()
        {
            this.AddLanguage("# language: fr");
            var result = this.GetLanguage();
            result.Code.Should().Be("fr");
        }

        [Test]
        public void GetLanguageFrom()
        {
            this.AddLanguage(string.Empty);
            var result = this.GetLanguage();
            result.Code.Should().Be("en");
        }

        [Test]
        public void GetLanguageFromNo()
        {
            this.AddLanguage("# language: no");
            Should.Throw<Gherkin.GherkinException>(() => this.GetLanguage());
        }
    }
}