// <copyright file="ScenarioStepBuilderBehaviour.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin.Builders
{
    using System;
    using System.Linq;

    using FluentAssertions;

    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class ScenarioStepBuilderBehaviour
    {
        [Test]
        public void ScenarioBuilderBehaviour()
        {
            var doc = new Mock<ILanguageSyntax<GherkinStep>>();
            doc.SetupGet(x => x.Syntax).Returns(GherkinStep.And);
            doc.SetupGet(x => x.Localised).Returns("And");
            var sut = new ScenarioStepBuilder(GherkinScenarioBlock.Then, doc.Object, "Then after And do this");
            sut.AddTestCase(new object[] { "value" });
            sut.AddTestCase(new object[] { 1 });
            sut.AddTestCase(new object[] { 2 });
            sut.AddTestCase(new object[] { 3 });

            var result = sut.Build();
            result.Description.Should().Contain("Then after And do this");
            result.Parent.Should().Be(GherkinScenarioBlock.Then);
            result.Step.Syntax.Should().Be(GherkinStep.And);
            result.TestCase.Parameters.ElementAt(0).Value.Should().Be("value");
            result.TestCase.Values.ElementAt(0).ElementAt(0).Value.Should().Be(1);
            result.TestCase.Values.ElementAt(1).ElementAt(0).Value.Should().Be(2);
            result.TestCase.Values.ElementAt(2).ElementAt(0).Value.Should().Be(3);

            Console.WriteLine(result);
        }
    }
}