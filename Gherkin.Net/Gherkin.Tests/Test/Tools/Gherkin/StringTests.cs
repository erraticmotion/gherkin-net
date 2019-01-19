// <copyright file="StringTests.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin
{
    using FluentAssertions;

    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class StringTests
    {
        [TestCase("And stuff", "stuff")]
        [TestCase(" And stuff", "stuff")]
        [TestCase(" and stuff", "stuff")]
        [TestCase("And  stuff", "stuff")]
        [TestCase("and   stuff", "stuff")]
        public void ShouldTrimAfterStep(string value, string expected)
        {
            var doc = new Mock<ILanguageSyntax<GherkinStep>>();
            doc.SetupGet(x => x.Localised).Returns("And");

            // TODO Enable
            //value.Trim(doc.Object).Should().Be(expected);
        }
    }
}