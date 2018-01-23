// <copyright file="FrenchLanguageServiceTests.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

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