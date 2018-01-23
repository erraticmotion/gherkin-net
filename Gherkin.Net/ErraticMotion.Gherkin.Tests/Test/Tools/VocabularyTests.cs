// <copyright file="VocabularyTests.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools
{
    using System;

    using FluentAssertions;

    using NUnit.Framework;

    [TestFixture]
    public class VocabularyTests
    {
        [Test]
        public void Show()
        {
            var sut = Internationalization.Vocabularies.Find("fr");
            Should.NotThrow(() => Console.WriteLine("{0}", sut));
        }

        [Test]
        public void EnLanguageShouldBe()
        {
            var sut = Internationalization.Vocabularies.Find("en");
            var result = string.Format("{0:l}", sut);
            result.Should().Contain("# language: en");
        }

        [Test]
        public void FrLanguageShouldBe()
        {
            var sut = Internationalization.Vocabularies.Find("fr");
            var result = string.Format("{0:l}", sut);
            result.Should().Contain("# language: fr");
        }
    }
}