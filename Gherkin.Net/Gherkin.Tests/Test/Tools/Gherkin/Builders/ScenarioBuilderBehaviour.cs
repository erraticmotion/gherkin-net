// <copyright file="ScenarioBuilderBehaviour.cs" company="Erratic Motion Ltd">
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
    /// Scenario Builder Tests.
    /// </summary>
    /// <seealso cref="Builders.GherkinStepBuilder{IGherkinBlockStep}" />
    [TestFixture]
    public class ScenarioBuilderBehaviour : GherkinStepBuilder<IGherkinBlockStep>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioBuilderBehaviour"/> class.
        /// </summary>
        public ScenarioBuilderBehaviour()
            : base(Internationalization.Default, GherkinKeyword.Scenario)
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
            new ScenarioBuilder(Internationalization.Default, string.Empty).Keyword.Syntax.Should().Be(GherkinKeyword.Scenario);
        }

        /// <summary>
        /// Gherkin title should be.
        /// </summary>
        [Test]
        public void GherkinTitleShouldBe()
        {
            var sut = new ScenarioBuilder(Internationalization.Default, "method_description");
            var result = sut.Build();
            result.Name.Should().Contain("method_description");
        }

        /// <summary>
        /// Scenario builder build no steps.
        /// </summary>
        [Test]
        public void ScenarioBuilderBuildNoSteps()
        {
            var sut = new ScenarioBuilder(Internationalization.Default, "test method name");
            sut.AddDescription("a description of the scenario");
            var result = sut.Build();
            result.Name.Should().Contain("test method name");
            result.Description.Should().Contain("a description of the scenario");
            result.Keyword.Syntax.Should().Be(GherkinKeyword.Scenario);
            result.Steps.Count().Should().Be(0);
        }

        /// <summary>
        /// Scenario builder with one step.
        /// </summary>
        [Test]
        public void ScenarioBuilderWithOneStep()
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