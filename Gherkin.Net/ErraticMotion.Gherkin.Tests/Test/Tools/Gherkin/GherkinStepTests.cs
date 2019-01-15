// <copyright file="GherkinStepTests.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin
{
    using FluentAssertions;
    using NUnit.Framework;

    /// <summary>
    /// Gherkin Step Tests.
    /// </summary>
    [TestFixture]
    public class GherkinStepTests
    {
        /// <summary>
        /// Should match step keyword.
        /// </summary>
        /// <param name="value">The value.</param>
        [TestCase("and")]
        [TestCase("And")]
        [TestCase("AND")]
        [TestCase(" and")]
        [TestCase(" and ")]
        public void ShouldMatchStepKeyword(string value)
        {
            value.StartsWith(GherkinStep.And).Should().BeTrue();
        }
    }
}