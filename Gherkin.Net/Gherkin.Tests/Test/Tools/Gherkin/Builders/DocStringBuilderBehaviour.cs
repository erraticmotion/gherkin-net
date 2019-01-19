// <copyright file="DocStringBuilderBehaviour.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin.Builders
{
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using NUnit.Framework;

    /// <summary>
    /// DocString Builder Tests.
    /// </summary>
    [TestFixture]
    public class DocStringBuilderBehaviour
    {
        /// <summary>
        /// Documents the Gherkin doc string builder gherkin.
        /// When transformed into Gherkin, expect the builder to not preserve the
        /// whitespace on the Gherkin DocString (the 3 double quotes) keyword, but
        /// keep the original indentation of any text between the opening and closing
        /// keyword.
        /// </summary>
        [Test]
        public void DocStringBuilderGherkinBehaviour()
        {
            var sut = Builder(DocStringThreeSpaces()).Build();
            sut.Gherkin[0].Should().Contain(string.Format("[{0}{0}{0}]", "\""));
            sut.Gherkin[1].Should().Be("   some");
            sut.Gherkin[2].Should().Be("    text ");
            sut.Gherkin[3].Should().Contain(string.Format("[{0}{0}{0}]", "\""));
        }

        /// <summary>
        /// Documents the Gherkin doc string get enumerator.
        /// Expect on the text values between the Gherkin keywords.
        /// </summary>
        [Test]
        public void DocStringGetEnumeratorBehaviour()
        {
            var sut = Builder(DocStringThreeSpaces()).Build();
            var result = sut.ToArray();
            result[0].Should().Be("some");
            result[1].Should().Be(" text ");
        }

        /// <summary>
        /// Documents the Gherkin doc string get index.
        /// Expect on the text values between the Gherkin keywords.
        /// </summary>
        [Test]
        public void DocStringGetIndexBehaviour()
        {
            var sut = Builder(DocStringThreeSpaces()).Build();
            sut[0].Should().Be("some");
            sut[1].Should().Be(" text ");
        }

        private static IEnumerable<string> DocStringThreeSpaces()
        {
            var s = new string(new[] { ' ', ' ', ' ', '"', '"', '"' });
            yield return s;
            yield return "   some";
            yield return "    text "; // important that the trailing space is preserved
            yield return s;
        }

        private static DocStringBuilder Builder(IEnumerable<string> text)
        {
            var builder = new DocStringBuilder();
            foreach (var s in text)
            {
                builder.Add(s);
            }

            return builder;
        }
    }
}