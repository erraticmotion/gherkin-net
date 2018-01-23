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
    public class ScenarioOutlineBuilderBehaviour : GherkinStepBuilder<IGherkinBlockStep>
    {
        public ScenarioOutlineBuilderBehaviour()
            : base(Internationalization.Default, GherkinKeyword.ScenarioOutline)
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

        [Test]
        public void GherkinBlockShouldBe()
        {
            var sut = new ScenarioOutlineBuilder(Internationalization.Default, string.Empty);
            sut.Keyword.Syntax.Should().Be(GherkinKeyword.ScenarioOutline);
        }

        [Test]
        public void GherkinTitleShouldBe()
        {
            var sut = new ScenarioOutlineBuilder(Internationalization.Default, "method_description");
            var result = sut.Build();
            result.Name.Should().Contain("method_description");
        }

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