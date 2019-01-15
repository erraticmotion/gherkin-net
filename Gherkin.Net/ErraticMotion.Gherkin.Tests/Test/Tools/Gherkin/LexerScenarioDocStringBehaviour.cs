// <copyright file="LexerScenarioDocStringBehaviour.cs" company="Erratic Motion Ltd">
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
    /// Lexer Scenario DocString.
    /// </summary>
    /// <seealso cref="Fixtures.GivenWhenThen{IGherkinFeature}" />
    [TestFixture]
    [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess", Justification = "Reviewed. Suppression is OK here.")]
    public class LexerScenarioDocStringBehaviour : GivenWhenThen<IGherkinFeature>
    {
        /// <inheritdoc />
        protected override IGherkinFeature Given(IFixtureKernel kernel)
        {
            var f = new StringBuilder();
            f.AppendLine("Feature: Calculator");
            f.AppendLine("Scenario: Add two numbers");
            f.AppendLine("Given a <first>:");
            f.AppendLine("| first |");
            f.AppendLine("| 1 |");
            f.AppendLine("| 2 |");
            f.AppendLine("When add a 10");
            f.AppendLine("    \"\"\"");
            f.AppendLine("    some text");
            f.AppendLine("      here with spacing");
            f.AppendLine("    \"\"\"");
            f.AppendLine("  And something else goes on");
            f.AppendLine("Then should have result");

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
        /// Scenario should be.
        /// </summary>
        [Test]
        public void ScenarioShouldBe()
        {
            var scenario = this.Sut.Scenarios.ElementAt(0);
            scenario.Keyword.Syntax.Should().Be(GherkinKeyword.Scenario);
            scenario.Name.Should().Contain("Add two numbers");
            scenario.Description.Should().BeEmpty();
        }

        /// <summary>
        /// Scenario when should be.
        /// </summary>
        [Test]
        public void ScenarioWhenShouldBe()
        {
            var scenario = this.Sut.Scenarios.ElementAt(0);
            var when = scenario.Steps.Single(x => x.Step.Syntax == GherkinStep.When);
            when.Should().NotBeNull();
            when.Parent.Should().Be(GherkinScenarioBlock.When);
            when.Description.Should().Contain("add a 10");
            when.TestCase.Should().BeNull();
            var testCase = when.DocString;
            testCase[0].Should().Be("some text");
            testCase[1].Should().Be("  here with spacing");
        }

        /// <summary>
        /// Scenario then should be.
        /// </summary>
        [Test]
        public void ScenarioThenShouldBe()
        {
            var scenario = this.Sut.Scenarios.ElementAt(0);
            var then = scenario.Steps.Single(x => x.Step.Syntax == GherkinStep.Then);
            then.Should().NotBeNull();
            then.Parent.Should().Be(GherkinScenarioBlock.Then);
            then.Description.Should().Contain("should have result");
            then.TestCase.Should().BeNull();
            then.DocString.Should().BeNull();
        }
    }
}