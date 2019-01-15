// <copyright file="ScenarioOutlineBuilderBehaviour.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin.Builders
{
    using System.Linq;

    using FluentAssertions;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Scenario Outline Builder Tests.
    /// </summary>
    /// <seealso cref="Builders.GherkinStepBuilder{IGherkinBlockStep}" />
    [TestFixture]
    public class ScenarioOutlineBuilderBehaviour : GherkinStepBuilder<IGherkinBlockStep>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioOutlineBuilderBehaviour"/> class.
        /// </summary>
        public ScenarioOutlineBuilderBehaviour()
            : base(Internationalization.Default, GherkinKeyword.ScenarioOutline)
        {
        }

        /// <inheritdoc />
        public override IGherkinBlockStep Build()
        {
            var doc = new Mock<ILanguageSyntax<GherkinStep>>();
            doc.SetupGet(x => x.Syntax).Returns(GherkinStep.Given);
            doc.SetupGet(x => x.Localised).Returns("Given");

            return new ScenarioStepBuilder(
                GherkinScenarioBlock.Given,
                doc.Object,
                "the system is in this state").Build();
        }

        /// <summary>
        /// Gherkin block should be.
        /// </summary>
        [Test]
        public void GherkinBlockShouldBe()
        {
            var sut = new ScenarioOutlineBuilder(Internationalization.Default, string.Empty);
            sut.Keyword.Syntax.Should().Be(GherkinKeyword.ScenarioOutline);
        }

        /// <summary>
        /// Gherkin title should be.
        /// </summary>
        [Test]
        public void GherkinTitleShouldBe()
        {
            var sut = new ScenarioOutlineBuilder(Internationalization.Default, "method_description");
            var result = sut.Build();
            result.Name.Should().Contain("method_description");
        }

        /// <summary>
        /// Scenario outline builder build no steps.
        /// </summary>
        [Test]
        public void ScenarioOutlineBuilderBuildNoSteps()
        {
            var sut = new ScenarioOutlineBuilder(Internationalization.Default, "test method name");
            sut.AddDescription("a description of the scenario outline");
            var result = sut.Build();
            result.Name.Should().Contain("test method name");
            result.Description.Should().Contain("a description of the scenario outline");
            result.Keyword.Syntax.Should().Be(GherkinKeyword.Scenarios);
            result.Steps.Count().Should().Be(0);
        }

        /// <summary>
        /// Scenario outline builder with one step.
        /// </summary>
        [Test]
        public void ScenarioOutlineBuilderWithOneStep()
        {
            var sut = new ScenarioBuilder(Internationalization.Default, string.Empty);
            sut.AddStep(this);
            var result = sut.Build();
            result.Steps.Count().Should().Be(1);
            var step = result.Steps.ElementAt(0);
            step.Parent.Should().Be(GherkinScenarioBlock.Given);
            step.Step.Syntax.Should().Be(GherkinStep.Given);
            step.Description.Should().Contain("the system is in this state");
        }
    }
}