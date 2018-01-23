// <copyright file="LexerFeatureFrBackgroundBehaviour.cs" company="Erratic Motion Ltd">
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

    /// <summary>
    /// Gherkin Feature with a Background element containing a description and two steps, a Given, and And Gherkin keyword.
    /// </summary>
    [TestFixture]
    public class LexerFeatureFrBackgroundBehaviour : GivenWhenThen<IGherkinFeature>
    {
        private IGherkinBlock background;
        private IGherkinBlockStep given;
        private IGherkinBlockStep and;

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
            f.AppendLine("  Contexte: Set up initial state");
            f.AppendLine("  Get the system in a state to do this");
            f.AppendLine("    Soit the system is this");
            f.AppendLine("    Et it is doing this");

            return LexerFeature.Create(f.ToString());
        }

        protected override void When(IGherkinFeature sut)
        {
            this.background = Sut.Background;
            this.given = Sut.Background.Steps.ElementAt(0);
            this.and = Sut.Background.Steps.ElementAt(1);
        }

        [Test]
        public void BackgroundShouldNotBeNull()
        {
            this.background.Should().NotBeNull();
        }

        [Test]
        public void BackgroundKeywordSyntaxShouldBe()
        {
            this.background.Keyword.Syntax.Should().Be(GherkinKeyword.Background);
        }

        [Test]
        public void BackgroundKeywordLocalisedShouldBe()
        {
            this.background.Keyword.Localised.Should().Be("Contexte");
        }

        [Test]
        public void BackgroundNameShouldBe()
        {
            this.background.Name.Should().Contain("Set up initial state");
        }

        [Test]
        public void BackgroundDescriptionShouldBe()
        {
            this.background.Description.Should().Contain("Get the system in a state to do this");
        }

        [Test]
        public void BackgroundStepCountShoudBe()
        {
            this.background.Steps.Count().Should().Be(2);
        }

        [Test]
        public void BackgroundStepGivenParentShouldBe()
        {
            this.given.Parent.Should().Be(GherkinScenarioBlock.Given);
        }

        [Test]
        public void BackgroundStepGivenSyntaxShouldBe()
        {
            this.given.Step.Syntax.Should().Be(GherkinStep.Given);
        }

        [Test]
        public void BackgroundStepGivenLocalisedShouldBe()
        {
            this.given.Step.Localised.Should().Be("Soit");
        }

        [Test]
        public void BackgroundStepGivenDescriptionShouldBe()
        {
            this.given.Description.Should().Contain("the system is this");
        }

        [Test]
        public void BackgroundStepAndParentShouldBe()
        {
            this.and.Parent.Should().Be(GherkinScenarioBlock.Given);
        }

        [Test]
        public void BackgroundStepAndSyntaxShouldBe()
        {
            this.and.Step.Syntax.Should().Be(GherkinStep.And);
        }

        [Test]
        public void BackgroundStepAndLocalisedShouldBe()
        {
            this.and.Step.Localised.Should().Be("Et");
        }

        [Test]
        public void BackgroundStepAndDescriptionShouldBe()
        {
            this.and.Description.Should().Contain("it is doing this");
        }
    }
}