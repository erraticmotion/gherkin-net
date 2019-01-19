// <copyright file="ExampleBuilderBehaviour.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin.Builders
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using ErraticMotion.Test.Fixtures;
    using ErraticMotion.Test.Tools.Gherkin.Elements;

    using FluentAssertions;
    using NUnit.Framework;

    /// <summary>
    /// Example Builder Tests.
    /// </summary>
    /// <seealso cref="GivenWhenThen" />
    [TestFixture]
    [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess", Justification = "Reviewed. Suppression is OK here.")]
    public class ExampleBuilderBehaviour : GivenWhenThen
    {
        /// <summary>
        /// The SUT
        /// </summary>
        private Example sut;

        /// <inheritdoc />
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

        /// <summary>
        /// Example keyword should be.
        /// </summary>
        [Then]
        public void ExampleKeywordShouldBe()
        {
            this.sut.Keyword.Syntax.Should().Be(GherkinKeyword.Where);
        }

        /// <summary>
        /// Example name should be.
        /// </summary>
        [Then]
        public void ExampleNameShouldBe()
        {
            this.sut.Name.Should().Contain("title");
        }

        /// <summary>
        /// Example description should be.
        /// </summary>
        [Then]
        public void ExampleDescriptionShouldBe()
        {
            this.sut.Description.Should().Contain("a description");
            this.sut.Description.Should().Contain("on multiple lines");
        }

        /// <summary>
        /// Example test case param 1 should be.
        /// </summary>
        [Then]
        public void ExampleTestCaseParam1ShouldBe()
        {
            this.sut.TestCases.Parameters.ElementAt(0).Value.Should().Be("name");
        }

        /// <summary>
        /// Example test case param 2 should be.
        /// </summary>
        [Then]
        public void ExampleTestCaseParam2ShouldBe()
        {
            this.sut.TestCases.Parameters.ElementAt(1).Value.Should().Be("value");
        }

        /// <summary>
        /// Example test case value should be.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        /// <param name="expected">The expected.</param>
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

        /// <summary>
        /// Example builder test cases count should be.
        /// </summary>
        [Test]
        public void ExampleBuilderTTestCasesCountShouldBe()
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