// <copyright file="LexerFeatureFrBackgroundBehaviour.cs" company="Erratic Motion Ltd">
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
    /// Gherkin Feature with a Background element containing a description and two steps, a Given, and And Gherkin keyword.
    /// </summary>
    [TestFixture]
    [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess", Justification = "Reviewed. Suppression is OK here.")]
    public class LexerFeatureFrBackgroundBehaviour : GivenWhenThen<IGherkinFeature>
    {
        /// <summary>
        /// The background
        /// </summary>
        private IGherkinBlock background;

        /// <summary>
        /// The given
        /// </summary>
        private IGherkinBlockStep given;

        /// <summary>
        /// The and
        /// </summary>
        private IGherkinBlockStep and;

        /// <inheritdoc />
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

        /// <inheritdoc />
        protected override void When(IGherkinFeature sut)
        {
            this.background = this.Sut.Background;
            this.given = this.Sut.Background.Steps.ElementAt(0);
            this.and = this.Sut.Background.Steps.ElementAt(1);
        }

        /// <summary>
        /// Background should not be null.
        /// </summary>
        [Test]
        public void BackgroundShouldNotBeNull()
        {
            this.background.Should().NotBeNull();
        }

        /// <summary>
        /// Background keyword syntax should be.
        /// </summary>
        [Test]
        public void BackgroundKeywordSyntaxShouldBe()
        {
            this.background.Keyword.Syntax.Should().Be(GherkinKeyword.Background);
        }

        /// <summary>
        /// Background keyword localized should be.
        /// </summary>
        [Test]
        public void BackgroundKeywordLocalisedShouldBe()
        {
            this.background.Keyword.Localised.Should().Be("Contexte");
        }

        /// <summary>
        /// Background name should be.
        /// </summary>
        [Test]
        public void BackgroundNameShouldBe()
        {
            this.background.Name.Should().Contain("Set up initial state");
        }

        /// <summary>
        /// Background description should be.
        /// </summary>
        [Test]
        public void BackgroundDescriptionShouldBe()
        {
            this.background.Description.Should().Contain("Get the system in a state to do this");
        }

        /// <summary>
        /// Background step count should be.
        /// </summary>
        [Test]
        public void BackgroundStepCountShouldBe()
        {
            this.background.Steps.Count().Should().Be(2);
        }

        /// <summary>
        /// Background step given parent should be.
        /// </summary>
        [Test]
        public void BackgroundStepGivenParentShouldBe()
        {
            this.given.Parent.Should().Be(GherkinScenarioBlock.Given);
        }

        /// <summary>
        /// Background step given syntax should be.
        /// </summary>
        [Test]
        public void BackgroundStepGivenSyntaxShouldBe()
        {
            this.given.Step.Syntax.Should().Be(GherkinStep.Given);
        }

        /// <summary>
        /// Background step given localized should be.
        /// </summary>
        [Test]
        public void BackgroundStepGivenLocalisedShouldBe()
        {
            this.given.Step.Localised.Should().Be("Soit");
        }

        /// <summary>
        /// Background step given description should be.
        /// </summary>
        [Test]
        public void BackgroundStepGivenDescriptionShouldBe()
        {
            this.given.Description.Should().Contain("the system is this");
        }

        /// <summary>
        /// Background step and parent should be.
        /// </summary>
        [Test]
        public void BackgroundStepAndParentShouldBe()
        {
            this.and.Parent.Should().Be(GherkinScenarioBlock.Given);
        }

        /// <summary>
        /// Background step and syntax should be.
        /// </summary>
        [Test]
        public void BackgroundStepAndSyntaxShouldBe()
        {
            this.and.Step.Syntax.Should().Be(GherkinStep.And);
        }

        /// <summary>
        /// Background step and localized should be.
        /// </summary>
        [Test]
        public void BackgroundStepAndLocalisedShouldBe()
        {
            this.and.Step.Localised.Should().Be("Et");
        }

        /// <summary>
        /// Background step and description should be.
        /// </summary>
        [Test]
        public void BackgroundStepAndDescriptionShouldBe()
        {
            this.and.Description.Should().Contain("it is doing this");
        }
    }
}