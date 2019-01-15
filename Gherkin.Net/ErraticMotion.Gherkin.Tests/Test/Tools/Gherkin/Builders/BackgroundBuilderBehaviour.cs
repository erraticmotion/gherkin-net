// <copyright file="BackgroundBuilderBehaviour.cs" company="Erratic Motion Ltd">
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
    /// Background Builder Tests.
    /// </summary>
    /// <seealso cref="IGherkinBlockStep" />
    [TestFixture]
    public class BackgroundBuilderBehaviour : GherkinStepBuilder<IGherkinBlockStep>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BackgroundBuilderBehaviour"/> class.
        /// </summary>
        public BackgroundBuilderBehaviour()
            : base(Internationalization.Default, GherkinKeyword.Background)
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
        /// Carry out a self shunt, this test fixture is a sub-class of the Gherkin step builder type.
        /// </summary>
        [Test]
        public void BackgroundBuilderWithOneStep()
        {
            var sut = new BackgroundBuilder(Internationalization.Default, string.Empty);
            sut.AddStep(this);
            var result = sut.Build();
            result.Steps.Count().Should().Be(1);
            var step = result.Steps.ElementAt(0);
            step.Parent.Should().Be(GherkinScenarioBlock.Given);
            step.Step.Syntax.Should().Be(GherkinStep.Given);
            step.Description.Should().Contain("the system is in this state");
        }

        /// <summary>
        /// Gherkin block should be.
        /// </summary>
        [Test]
        public void GherkinBlockShouldBe()
        {
            var sut = new BackgroundBuilder(Internationalization.Default, string.Empty);
            sut.Keyword.Syntax.Should().Be(GherkinKeyword.Background);
        }

        /// <summary>
        /// Background builder build no steps.
        /// </summary>
        [Test]
        public void BackgroundBuilderBuildNoSteps()
        {
            var sut = new BackgroundBuilder(Internationalization.Default, string.Empty);
            sut.AddDescription("a description of the background");
            var result = sut.Build();
            result.Description.Should().Contain("a description of the background");
            result.Keyword.Syntax.Should().Be(GherkinKeyword.Background);
            result.Steps.Count().Should().Be(0);
        }
    }
}