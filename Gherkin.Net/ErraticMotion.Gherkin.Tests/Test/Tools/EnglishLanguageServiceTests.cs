// <copyright file="EnglishLanguageServiceTests.cs" company="Erratic Motion Ltd">
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