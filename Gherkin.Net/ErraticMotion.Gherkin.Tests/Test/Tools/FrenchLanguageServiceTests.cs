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
    public class FrenchLanguageServiceTests : LanguageServiceBase
    {
        protected override void Given()
        {
            this.AddLanguage("# language: fr");
        }

        [Test]
        public void FeatureShouldBe()
        {
            this.GetLanguage().Get(GherkinKeyword.Feature).Localised.Should().Be("Fonctionnalité");
        }

        [Test]
        public void BackgroundShouldBe()
        {
            this.GetLanguage().Get(GherkinKeyword.Background).Localised.Should().Be("Contexte");
        }

        [Test]
        public void ScenarioShouldBe()
        {
            this.GetLanguage().Get(GherkinKeyword.Scenario).Localised.Should().Be("Scénario");
        }

        [Test]
        public void ScenarioOutlineShouldBe()
        {
            this.GetLanguage().Get(GherkinKeyword.ScenarioOutline).Localised.Should().Be("Plan du scénario");
        }

        [Test]
        public void ScenariosShouldBe()
        {
            this.GetLanguage().Get(GherkinKeyword.Scenarios).Localised.Should().Be("Scénarios");
        }

        [Test]
        public void ExamplesShouldBe()
        {
            this.GetLanguage().Get(GherkinKeyword.Examples).Localised.Should().Be("Exemples");
        }

        [Test]
        public void WhereShouldBe()
        {
            this.GetLanguage().Get(GherkinKeyword.Where).Localised.Should().Be("Ou");
        }

        [Test]
        public void GivenShouldBe()
        {
            this.GetLanguage().Get(GherkinStep.Given).Localised.Should().Be("Soit");
        }

        [Test]
        public void WhenShouldBe()
        {
            this.GetLanguage().Get(GherkinStep.When).Localised.Should().Be("Quand");
        }

        [Test]
        public void ThenShouldBe()
        {
            this.GetLanguage().Get(GherkinStep.Then).Localised.Should().Be("Alors");
        }

        [Test]
        public void AndShouldBe()
        {
            this.GetLanguage().Get(GherkinStep.And).Localised.Should().Be("Et");
        }

        [Test]
        public void ButShouldBe()
        {
            this.GetLanguage().Get(GherkinStep.But).Localised.Should().Be("Mais");
        }

        [Test]
        public void GetAll()
        {
            Should.NotThrow(() => this.GetLanguage().AllKeywords().ForAll(x => Console.WriteLine(x.Localised)));
        }
    }
}