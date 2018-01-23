// <copyright file="TestCaseBuilderBehaviour.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin.Builders
{
    using System.Linq;

    using FluentAssertions;

    using NUnit.Framework;

    [TestFixture]
    public class TestCaseBuilderBehaviour
    {
        [Test]
        public void TestCase()
        {
            var sut = new TestCaseBuilder();
            sut.AddTestCase(new object[] { "one", "two", "three" });
            sut.AddTestCase(new object[] { 1, 2, 3 });
            sut.AddTestCase(new object[] { 4, 5, 6 });
            var result = sut.Build();
            result.Parameters[0].Value.Should().Be("one");
            result.Parameters[1].Value.Should().Be("two");
            result.Parameters[2].Value.Should().Be("three");
            result.Values.ElementAt(0).ElementAt(0).Value.Should().Be(1);
            result.Values.ElementAt(0).ElementAt(1).Value.Should().Be(2);
            result.Values.ElementAt(0).ElementAt(2).Value.Should().Be(3);
            result.Values.ElementAt(1).ElementAt(0).Value.Should().Be(4);
            result.Values.ElementAt(1).ElementAt(1).Value.Should().Be(5);
            result.Values.ElementAt(1).ElementAt(2).Value.Should().Be(6);
        }
    }
}