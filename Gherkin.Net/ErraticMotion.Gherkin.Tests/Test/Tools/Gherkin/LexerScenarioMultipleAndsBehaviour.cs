// <copyright file="LexerScenarioMultipleAndsBehaviour.cs" company="Erratic Motion Ltd">
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
    public class LexerScenarioMultipleAndsBehaviour : GivenWhenThen<IGherkinFeature>
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
            f.AppendLine("@ category: Integration");
            f.AppendLine("Feature: Calculator");
            f.AppendLine("Scenario: Add two numbers");
            f.AppendLine("Given a <first>:");
            f.AppendLine("| first |");
            f.AppendLine("| 1 |");
            f.AppendLine("| 2 |");
            f.AppendLine("And the system is in this state");
            f.AppendLine("# And this is commented out");
            f.AppendLine("And the system is also in this state");
            f.AppendLine("But not in this state");
            f.AppendLine("When add a 10");
            f.AppendLine("Then should have <result>:");
            f.AppendLine("| result |");
            f.AppendLine("| 11 |");
            f.AppendLine("| 12 |");

            return LexerFeature.Create(f.ToString());
        }

        [Test]
        public void ScenarioWithExampleTestCase()
        {
            Sut.Background.Should().BeNull();
            Sut.Scenarios.Count().Should().Be(1);
        }

        [Test]
        public void FeatureShouldHaveTwoComments()
        {
            Sut.Comments.Count().Should().Be(2);
        }

        [Test]
        public void FeatureShouldHaveOneTag()
        {
            Sut.Tags.Count().Should().Be(1);
        }

        [Test]
        public void ScenarioStepGivenShouldHaveFourSteps()
        {
            Sut.Scenarios[0].Steps.Parent(GherkinScenarioBlock.Given).Count().Should().Be(3);
        }

        [Test]
        public void ScenarioStepWhenShouldHaveOneStep()
        {
            Sut.Scenarios[0].Steps.Parent(GherkinScenarioBlock.When).Count().Should().Be(0);
        }

        [Test]
        public void ScenarioStepThenShouldHaveOneStep()
        {
            Sut.Scenarios[0].Steps.Parent(GherkinScenarioBlock.Then).Count().Should().Be(0);
        }
    }
}