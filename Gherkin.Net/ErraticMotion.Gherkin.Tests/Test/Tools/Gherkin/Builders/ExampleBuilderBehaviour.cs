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

    using ErraticMotion.Test.Fixtures;
    using ErraticMotion.Test.Tools.Gherkin.Elements;

    using FluentAssertions;

    using NUnit.Framework;

    [TestFixture]
    public class ExampleBuilderBehaviour : GivenWhenThen
    {
        private Example sut;

        protected override void Given()
        {
            var builder = new ExampleBuilder(Internationalization.Default, "title");
            builder.AddDescription("a description");
            builder.AddDescription("on multiple lines");
            builder.AddTestCase(new object[] { "name ", "value" });
            builder.AddTestCase(new object[] { "a", 1 });
            builder.AddTestCase(new object[] { "b", 2 });
            builder.AddTestCase(new object[] { "c", 3 });
            this.sut = builder.Build();
        }

        [Then]
        public void ExampleKeywordShouldBe()
        {
            this.sut.Keyword.Syntax.Should().Be(GherkinKeyword.Where);
        }

        [Then]
        public void ExampleNameShouldBe()
        {
            this.sut.Name.Should().Contain("title");
        }

        [Then]
        public void ExampleDescriptionShouldBe()
        {
            this.sut.Description.Should().Contain("a description");
            this.sut.Description.Should().Contain("on multiple lines");
        }

        [Then]
        public void ExampleTestCaseParam1ShouldBe()
        {
            this.sut.TestCases.Parameters.ElementAt(0).Value.Should().Be("name");
        }

        [Then]
        public void ExampleTestCaseParam2ShouldBe()
        {
            this.sut.TestCases.Parameters.ElementAt(1).Value.Should().Be("value");
        }

        [Where(0, 0, "a")]
        [Where(0, 1, 1)]
        [Where(1, 0, "b")]
        [Where(1, 1, 2)]
        [Where(2, 0, "c")]
        [Where(2, 1, 3)]
        public void ExampleTestCaseValueShouldBe(int row, int column, object expected)
        {
            this.sut.TestCases.Values.ElementAt(row).ElementAt(column).Value.Should().Be(expected);
        }

        [Test]
        public void ExampleBuilerTTestCasesCountShouldBe()
        {
            this.sut.TestCases.Values.Count().Should().Be(3);
        }

        /// <summary>
        /// See <see cref="GherkinKeywordBase"/> with conditional PREFER_GEHERKIN_PLUS.
        /// Keyword is changed to use the Gherkin+ keyword Where when the object is built.
        /// </summary>
        [Test]
        public void GherkinBlockShouldBe()
        {
            new ExampleBuilder(Internationalization.Default, string.Empty).Keyword.Syntax.Should().Be(GherkinKeyword.Examples);
        }
    }
}