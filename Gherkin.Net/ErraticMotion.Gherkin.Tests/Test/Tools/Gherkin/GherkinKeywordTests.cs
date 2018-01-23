// <copyright file="GherkinKeywordTests.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin
{
    using FluentAssertions;

    using NUnit.Framework;

    [TestFixture]
    public class GherkinKeywordTests
    {
        [TestCase("feature:")]
        [TestCase("Feature:")]
        [TestCase("FEATURE:")]
        [TestCase(" feature:")]
        [TestCase(" feature: ")]
        public void ShouldMatchFeatureKeyword(string value)
        {
            value.StartsWith(GherkinKeyword.Feature).Should().BeTrue();
        }

        [TestCase("feature:", "")]
        [TestCase("Feature:", "")]
        [TestCase("FEATURE:", "")]
        [TestCase(" feature:", "")]
        [TestCase(" feature: ", "")]
        [TestCase("Feature: a feature", "a feature")]
        [TestCase("Feature: a feature  ", "a feature")]
        public void ShouldReturnFeatureName(string value, string expected)
        {
            value.Name(GherkinKeyword.Feature).Should().Be(expected);
        }

        [TestCase("Feature a feature")]
        public void ShouldRaiseExceptionWhenNoNameForKeyword(string value)
        {
            Assert.Throws<GherkinException>(() => value.Name(GherkinKeyword.Feature));
        }
    }
}