// <copyright file="LexerFeatureBehaviour.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;

    using ErraticMotion.Test.Fixtures;
    using ErraticMotion.Test.Fixtures.Containers;

    using FluentAssertions;
    using NUnit.Framework;

    /// <summary>
    /// Lexer Feature Tests.
    /// </summary>
    /// <seealso cref="Fixtures.GivenWhenThen{GIGherkinFeature}" />
    [TestFixture]
    [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess", Justification = "Reviewed. Suppression is OK here.")]
    public class LexerFeatureBehaviour : GivenWhenThen<IGherkinFeature>
    {
        /// <inheritdoc />
        protected override IGherkinFeature Given(IFixtureKernel kernel)
        {
            var f = new StringBuilder();
            f.AppendLine("Feature: Calculator");
            f.AppendLine("In order to avoid silly mistakes");
            f.AppendLine("as a math idiot");
            f.AppendLine("I want to be told the sum of two numbers");

            return LexerFeature.Create(f.ToString());
        }

        /// <summary>
        /// Feature should be.
        /// </summary>
        [Test]
        public void FeatureShouldBe()
        {
            this.Sut.Comments.Count().Should().Be(2);
            this.Sut.Keyword.Syntax.Should().Be(GherkinKeyword.Feature);
            this.Sut.Name.Should().Be("Calculator");
            this.Sut.Description.Should().Contain("In order to");
            this.Sut.Description.Should().Contain("as a math idiot");
            this.Sut.Description.Should().Contain("want to be told the sum of two");
        }
    }
}