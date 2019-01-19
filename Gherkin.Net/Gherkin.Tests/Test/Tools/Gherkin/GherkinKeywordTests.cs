// <copyright file="GherkinKeywordTests.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin
{
    using FluentAssertions;
    using NUnit.Framework;

    /// <summary>
    /// Gherkin Keyword Tests.
    /// </summary>
    [TestFixture]
    public class GherkinKeywordTests
    {
        /// <summary>
        /// Should match feature keyword.
        /// </summary>
        /// <param name="value">The value.</param>
        [TestCase("feature:")]
        [TestCase("Feature:")]
        [TestCase("FEATURE:")]
        [TestCase(" feature:")]
        [TestCase(" feature: ")]
        public void ShouldMatchFeatureKeyword(string value)
        {
            value.StartsWith(GherkinKeyword.Feature).Should().BeTrue();
        }

        /// <summary>
        /// Should name of the return feature.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="expected">The expected.</param>
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

        /// <summary>
        /// Should raise exception when no name for keyword.
        /// </summary>
        /// <param name="value">The value.</param>
        [TestCase("Feature a feature")]
        public void ShouldRaiseExceptionWhenNoNameForKeyword(string value)
        {
            Assert.Throws<GherkinException>(() => value.Name(GherkinKeyword.Feature));
        }
    }
}