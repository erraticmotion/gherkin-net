// <copyright file="LexerScenarioMultipleAndsBehaviour.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;

    using ErraticMotion.Test.Fixtures;
    using ErraticMotion.Test.Fixtures.Containers;

    using FluentAssertions;
    using NUnit.Framework;

    /// <summary>
    /// Lexer Scenario Multiple Ands.
    /// </summary>
    /// <seealso cref="Fixtures.GivenWhenThen{IGherkinFeature}" />
    [TestFixture]
    [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess", Justification = "Reviewed. Suppression is OK here.")]
    public class LexerScenarioMultipleAndsBehaviour : GivenWhenThen<IGherkinFeature>
    {
        /// <inheritdoc />
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

        /// <summary>
        /// Scenario with example test case.
        /// </summary>
        [Test]
        public void ScenarioWithExampleTestCase()
        {
            this.Sut.Background.Should().BeNull();
            this.Sut.Scenarios.Count().Should().Be(1);
        }

        /// <summary>
        /// Feature should have two comments.
        /// </summary>
        [Test]
        public void FeatureShouldHaveTwoComments()
        {
            this.Sut.Comments.Count().Should().Be(2);
        }

        /// <summary>
        /// Feature should have one tag.
        /// </summary>
        [Test]
        public void FeatureShouldHaveOneTag()
        {
            this.Sut.Tags.Count().Should().Be(1);
        }

        /// <summary>
        /// Scenario step given should have four steps.
        /// </summary>
        [Test]
        public void ScenarioStepGivenShouldHaveFourSteps()
        {
            this.Sut.Scenarios[0].Steps.Parent(GherkinScenarioBlock.Given).Count().Should().Be(3);
        }

        /// <summary>
        /// Scenario step when should have one step.
        /// </summary>
        [Test]
        public void ScenarioStepWhenShouldHaveOneStep()
        {
            this.Sut.Scenarios[0].Steps.Parent(GherkinScenarioBlock.When).Count().Should().Be(0);
        }

        /// <summary>
        /// Scenario step then should have one step.
        /// </summary>
        [Test]
        public void ScenarioStepThenShouldHaveOneStep()
        {
            this.Sut.Scenarios[0].Steps.Parent(GherkinScenarioBlock.Then).Count().Should().Be(0);
        }
    }
}