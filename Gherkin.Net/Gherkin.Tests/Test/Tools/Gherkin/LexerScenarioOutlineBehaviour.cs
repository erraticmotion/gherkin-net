﻿// <copyright file="LexerScenarioOutlineBehaviour.cs" company="Erratic Motion Ltd">
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
    /// Lexer Scenario Outline.
    /// </summary>
    /// <seealso cref="Fixtures.GivenWhenThen{IGherkinFeature}" />
    [TestFixture]
    [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess", Justification = "Reviewed. Suppression is OK here.")]
    public class LexerScenarioOutlineBehaviour : GivenWhenThen<IGherkinFeature>
    {
        /// <inheritdoc />
        protected override IGherkinFeature Given(IFixtureKernel kernel)
        {
            var f = new StringBuilder();
            f.AppendLine("Feature: Calculator");
            f.AppendLine("Scenario Outline: Add two numbers");
            f.AppendLine("System should add two");
            f.AppendLine("numbers");
            f.AppendLine("Given a <first>");
            f.AppendLine("When add a <second>");
            f.AppendLine("Then should have <result>");
            f.AppendLine("Examples:");
            f.AppendLine("| first | second | result |");
            f.AppendLine("| 1 | 2 | 3 |");
            f.AppendLine("| 1 | 3 | 4 |");

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
            scenario.Keyword.Syntax.Should().Be(GherkinKeyword.Scenarios);
            scenario.Name.Should().Contain("Add two numbers");
            scenario.Description.Should().Contain("System should add two\r\nnumbers");
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
            given.TestCase.Should().BeNull();
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
            when.Description.Should().Contain("add a <second>");
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
            then.Description.Should().Contain("should have <result>");
            then.TestCase.Should().BeNull();
        }

        /// <summary>
        /// Scenario example should be.
        /// </summary>
        [Test]
        public void ScenarioExampleShouldBe()
        {
            var scenario = this.Sut.Scenarios.ElementAt(0);
            var example = scenario.Examples.ElementAt(0);
            example.Name.Should().BeEmpty();
            example.Description.Should().BeEmpty();
            example.Keyword.Syntax.Should().Be(GherkinKeyword.Where);
            example.TestCases.Parameters.ElementAt(0).Value.Should().Be("first");
            example.TestCases.Parameters.ElementAt(1).Value.Should().Be("second");
            example.TestCases.Parameters.ElementAt(2).Value.Should().Be("result");

            example.TestCases.Values.ElementAt(0).ElementAt(0).Value.Should().Be("1");
            example.TestCases.Values.ElementAt(0).ElementAt(1).Value.Should().Be("2");
            example.TestCases.Values.ElementAt(0).ElementAt(2).Value.Should().Be("3");

            example.TestCases.Values.ElementAt(1).ElementAt(0).Value.Should().Be("1");
            example.TestCases.Values.ElementAt(1).ElementAt(1).Value.Should().Be("3");
            example.TestCases.Values.ElementAt(1).ElementAt(2).Value.Should().Be("4");
        }
    }
}