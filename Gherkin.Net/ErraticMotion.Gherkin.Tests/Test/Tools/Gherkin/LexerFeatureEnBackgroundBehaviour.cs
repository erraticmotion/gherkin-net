// ---------------------------------------------------------------------------
// (C) 2016 Parkeon Limited.
// 
//  No part of this source code may be reproduced, digitised, stored in a 
//  retrieval system, communicated to the public or caused to be seen or heard 
//  in public, made publicly available or publicly performed, offered for sale 
//  or hire or exhibited by way of trade in public or distributed by way of trade 
//  in any form or by any means, electronic, mechanical or otherwise without the 
//  written permission of Parkeon Limited.
// 
// ---------------------------------------------------------------------------

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
    public class LexerFeatureEnBackgroundBehaviour : GivenWhenThen<IGherkinFeature>
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
            f.AppendLine("# language: en");
            f.AppendLine("Feature: Calculator");
            f.AppendLine("  Background: Set up initial state");
            f.AppendLine("    Get the system in a state to do this");
            f.AppendLine("    Given the system is this");
            f.AppendLine("    And it is doing this");

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
            this.background.Keyword.Localised.Should().Be("Background");
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
            this.given.Step.Localised.Should().Be("Given");
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
            this.and.Step.Localised.Should().Be("And");
        }

        [Test]
        public void BackgroundStepAndDescriptionShouldBe()
        {
            this.and.Description.Should().Contain("it is doing this");
        }
    }
}