// <copyright file="LexerScenarioDocStringBehaviour.cs" company="Erratic Motion Ltd">
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
    public class LexerScenarioDocStringBehaviour : GivenWhenThen<IGherkinFeature>
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

        [Test]
        public void ScenarioWithExampleTestCase()
        {
            Sut.Background.Should().BeNull();
            Sut.Scenarios.Count().Should().Be(1);
        }

        [Test]
        public void ScenarioShouldBe()
        {
            var scenario = Sut.Scenarios.ElementAt(0);
            scenario.Keyword.Syntax.Should().Be(GherkinKeyword.Scenario);
            scenario.Name.Should().Contain("Add two numbers");
            scenario.Description.Should().BeEmpty();
        }

        [Test]
        public void ScenarioWhenShouldBe()
        {
            var scenario = Sut.Scenarios.ElementAt(0);
            var when = scenario.Steps.Single(x => x.Step.Syntax == GherkinStep.When);
            when.Should().NotBeNull();
            when.Parent.Should().Be(GherkinScenarioBlock.When);
            when.Description.Should().Contain("add a 10");
            when.TestCase.Should().BeNull();
            var testCase = when.DocString;
            testCase[0].Should().Be("some text");
            testCase[1].Should().Be("  here with spacing");
        }

        [Test]
        public void ScenarioThenShouldBe()
        {
            var scenario = Sut.Scenarios.ElementAt(0);
            var then = scenario.Steps.Single(x => x.Step.Syntax == GherkinStep.Then);
            then.Should().NotBeNull();
            then.Parent.Should().Be(GherkinScenarioBlock.Then);
            then.Description.Should().Contain("should have result");
            then.TestCase.Should().BeNull();
            then.DocString.Should().BeNull();
        }
    }
}