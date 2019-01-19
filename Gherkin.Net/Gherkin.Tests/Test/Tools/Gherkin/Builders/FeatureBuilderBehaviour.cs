// <copyright file="FeatureBuilderBehaviour.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin.Builders
{
    using FluentAssertions;
    using NUnit.Framework;

    /// <summary>
    /// Feature Builder Tests.
    /// </summary>
    [TestFixture]
    public class FeatureBuilderBehaviour
    {
        /// <summary>
        /// Gherkin keyword should be.
        /// </summary>
        /// <param name="lang">The language.</param>
        /// <param name="expected">The expected.</param>
        [TestCase("en", "Feature")]
        [TestCase("en-GB", "Feature")]
        [TestCase("en-US", "Feature")]
        [TestCase("fr", "Fonctionnalité")]
        public void GherkinKeywordShouldBe(string lang, string expected)
        {
            var sut = new FeatureBuilder(Internationalization.For(lang), string.Empty);
            sut.Keyword.Syntax.Should().Be(GherkinKeyword.Feature);
            sut.Keyword.Localised.Should().Be(expected);
        }
    }
}