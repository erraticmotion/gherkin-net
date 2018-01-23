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

namespace ErraticMotion.Test.Tools.Gherkin.Builders
{
    using System.Linq;

    using FluentAssertions;

    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class BackgroundBuilderBehaviour : GherkinStepBuilder<IGherkinBlockStep>
    {
        public BackgroundBuilderBehaviour()
            : base(Internationalization.Default, GherkinKeyword.Background)
        {
        }

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

        [Test]
        public void GherkinBlockShouldBe()
        {
            var sut = new BackgroundBuilder(Internationalization.Default, string.Empty);
            sut.Keyword.Syntax.Should().Be(GherkinKeyword.Background);
        }

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