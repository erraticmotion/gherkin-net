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
namespace ErraticMotion.Test.Tools
{
    using System;

    using ErraticMotion.Test.Tools.Gherkin;

    using FluentAssertions;

    using NUnit.Framework;

    [TestFixture(Category = "Language")]
    public class EnglishLanguageServiceTests : LanguageServiceBase
    {
        protected override void Given()
        {
            this.AddLanguage("# language: en");
        }

        [Test]
        public void FeatureShouldBe()
        {
            this.GetLanguage().Get(GherkinKeyword.Feature).Localised.Should().Be("Feature");
        }

        [Test]
        public void BackgroundShouldBe()
        {
            this.GetLanguage().Get(GherkinKeyword.Background).Localised.Should().Be("Background");
        }

        [Test]
        public void ScenarioShouldBe()
        {
            this.GetLanguage().Get(GherkinKeyword.Scenario).Localised.Should().Be("Scenario");
        }

        [Test]
        public void ScenarioOutlineShouldBe()
        {
            this.GetLanguage().Get(GherkinKeyword.ScenarioOutline).Localised.Should().Be("Scenario Outline");
        }

        [Test]
        public void ScenariosShouldBe()
        {
            this.GetLanguage().Get(GherkinKeyword.Scenarios).Localised.Should().Be("Scenarios");
        }

        [Test]
        public void ExamplesShouldBe()
        {
            this.GetLanguage().Get(GherkinKeyword.Examples).Localised.Should().Be("Examples");
        }

        [Test]
        public void WhereShouldBe()
        {
            this.GetLanguage().Get(GherkinKeyword.Where).Localised.Should().Be("Where");
        }

        [Test]
        public void GivenShouldBe()
        {
            this.GetLanguage().Get(GherkinStep.Given).Localised.Should().Be("Given");
        }

        [Test]
        public void WhenShouldBe()
        {
            this.GetLanguage().Get(GherkinStep.When).Localised.Should().Be("When");
        }

        [Test]
        public void ThenShouldBe()
        {
            this.GetLanguage().Get(GherkinStep.Then).Localised.Should().Be("Then");
        }

        [Test]
        public void AndShouldBe()
        {
            this.GetLanguage().Get(GherkinStep.And).Localised.Should().Be("And");
        }

        [Test]
        public void ButShouldBe()
        {
            this.GetLanguage().Get(GherkinStep.But).Localised.Should().Be("But");
        }

        [Test]
        public void GetAllKeywords()
        {
            Should.NotThrow(() => this.GetLanguage().AllKeywords().ForAll(x => Console.WriteLine(x.Localised)));
        }

        [Test]
        public void GetAllSteps()
        {
            Should.NotThrow(() => this.GetLanguage().AllSteps().ForAll(x => Console.WriteLine(x.Localised)));
        }
    }
}