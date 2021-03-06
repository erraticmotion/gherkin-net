﻿// <copyright file="LexerScenarioFrBehaviour.cs" company="Erratic Motion Ltd">
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
    /// Lexer Scenario French.
    /// </summary>
    /// <seealso cref="Fixtures.GivenWhenThen{IGherkinFeature}" />
    [TestFixture]
    [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess", Justification = "Reviewed. Suppression is OK here.")]
    public class LexerScenarioFrBehaviour : GivenWhenThen<IGherkinFeature>
    {
        /// <inheritdoc />
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
        /// Scenario given should be.
        /// </summary>
        [Test]
        public void ScenarioGivenShouldBe()
        {
            var scenario = this.Sut.Scenarios.ElementAt(0);
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
            then.Description.Should().Contain("should have <result>:");
            then.TestCase.Should().NotBeNull();
            var testCase = then.TestCase;
            testCase.Parameters.ElementAt(0).Value.Should().Be("result");
            testCase.Values.ElementAt(0).ElementAt(0).Value.Should().Be("11");
            testCase.Values.ElementAt(1).ElementAt(0).Value.Should().Be("12");
        }
    }
}