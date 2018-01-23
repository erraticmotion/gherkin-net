// <copyright file="LexerFeatureBehaviour.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin
{
    using System.Linq;
    using System.Text;

    using ErraticMotion.Test.Fixtures;
    using ErraticMotion.Test.Fixtures.Containers;

    using FluentAssertions;

    using NUnit.Framework;

    [TestFixture]
    public class LexerFeatureBehaviour : GivenWhenThen<IGherkinFeature>
    {
        /// <summary>
        /// Arrange all necessary preconditions and inputs.
        /// </summary>
        /// <param name="kernel">The <see cref="IFixtureKernel" /> Test Double IoC container.</param>
        /// <returns>
        /// The System/Software Under Test.
        /// </returns>
        protected override IGherkinFeature Given(IFixtureKernel kernel)
        {
            var f = new StringBuilder();
            f.AppendLine("Feature: Calculator");
            f.AppendLine("In order to avoid silly mistakes");
            f.AppendLine("as a math idiot");
            f.AppendLine("I want to be told the sum of two numbers");

            return LexerFeature.Create(f.ToString());
        }

        [Test]
        public void FeatureShouldBe()
        {
            Sut.Comments.Count().Should().Be(2);
            Sut.Keyword.Syntax.Should().Be(GherkinKeyword.Feature);
            Sut.Name.Should().Be("Calculator");
            Sut.Description.Should().Contain("In order to");
            Sut.Description.Should().Contain("as a math idiot");
            Sut.Description.Should().Contain("want to be told the sum of two");
        }
    }
}