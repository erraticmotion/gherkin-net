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

    [TestFixture]
    public class LexerScenarioOutlinesBehaviour : GivenWhenThen<IGherkinFeature>
    {
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
            f.AppendLine("Feature: Calculator");
            f.AppendLine("Scenario Outline: Add two numbers");
            f.AppendLine("    System should add two");
            f.AppendLine("    numbers");
            f.AppendLine("Given a <first>");
            f.AppendLine("When add a <second>");
            f.AppendLine("Then should have <result>");
            f.AppendLine("Examples:");
            f.AppendLine("| first | second | result |");
            f.AppendLine("| 1 | 2 | 3 |");
            f.AppendLine("| 1 | 3 | 4 |");
            f.AppendLine("Scenario Outline: Subtract two numbers");
            f.AppendLine("  Given a <first>:");
            f.AppendLine("  When subtract a <second>");
            f.AppendLine("  Then should have <result>:");
            f.AppendLine("Examples:");
            f.AppendLine("    | first | second | result |");
            f.AppendLine("    |    11 |     10 |      1 |");
            f.AppendLine("    |    12 |     10 |      2 |");

            return LexerFeature.Create(f.ToString());
        }

        [Test]
        public void FeatureNameShouldBe()
        {
            Sut.Name.Should().Be("Calculator");
        }

        [Test]
        public void BackgroundShouldBeNull()
        {
            Sut.Background.Should().BeNull();
        }

        [Test]
        public void ScenarioCountShouldBe()
        {
            Sut.Scenarios.Count().Should().Be(2);
        }

        [Test]
        public void Scenario0DescriptionShouldBe()
        {
            Sut.Scenarios[0].Description.Should().Be("System should add two\r\nnumbers");
        }

        [Test]
        public void Scenario1DescriptionShouldBe()
        {
            Sut.Scenarios[1].Description.Should().Be(string.Empty);
        }
    }
}