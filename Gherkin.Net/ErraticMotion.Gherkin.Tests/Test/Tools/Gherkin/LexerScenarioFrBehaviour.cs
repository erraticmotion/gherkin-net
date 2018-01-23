// <copyright file="LexerScenarioFrBehaviour.cs" company="Erratic Motion Ltd">
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
    public class LexerScenarioFrBehaviour : GivenWhenThen<IGherkinFeature>
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
            f.AppendLine("# language: fr");
            f.AppendLine("Fonctionnalité: Calculator");
            f.AppendLine("Scénario: Add two numbers");
            f.AppendLine("Soit a <first>:");
            f.AppendLine("| first |");
            f.AppendLine("| 1 |");
            f.AppendLine("| 2 |");
            f.AppendLine("Quand add a 10");
            f.AppendLine("Alors should have <result>:");
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
        public void ScenarioShouldBe()
        {
            var scenario = Sut.Scenarios.ElementAt(0);
            scenario.Keyword.Syntax.Should().Be(GherkinKeyword.Scenario);
            scenario.Name.Should().Contain("Add two numbers");
            scenario.Description.Should().BeEmpty();
        }

        [Test]
        public void ScenarioGivenShouldBe()
        {
            var scenario = Sut.Scenarios.ElementAt(0);
            var given = scenario.Steps.Single(x => x.Step.Syntax == GherkinStep.Given);
            given.Should().NotBeNull();
            given.Parent.Should().Be(GherkinScenarioBlock.Given);
            given.Description.Should().Contain("a <first>");
            given.TestCase.Should().NotBeNull();
            var testCase = given.TestCase;
            testCase.Parameters.ElementAt(0).Value.Should().Be("first");
            testCase.Values.ElementAt(0).ElementAt(0).Value.Should().Be("1");
            testCase.Values.ElementAt(1).ElementAt(0).Value.Should().Be("2");
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
        }

        [Test]
        public void ScenarioThenShouldBe()
        {
            var scenario = Sut.Scenarios.ElementAt(0);
            var then = scenario.Steps.Single(x => x.Step.Syntax == GherkinStep.Then);
            then.Should().NotBeNull();
            then.Parent.Should().Be(GherkinScenarioBlock.Then);
            then.Description.Should().Contain("should have <result>:");
            then.TestCase.Should().NotBeNull();
            var testCase = then.TestCase;
            testCase.Parameters.ElementAt(0).Value.Should().Be("result");
            testCase.Values.ElementAt(0).ElementAt(0).Value.Should().Be("11");
            testCase.Values.ElementAt(1).ElementAt(0).Value.Should().Be("12");
        }
    }
}