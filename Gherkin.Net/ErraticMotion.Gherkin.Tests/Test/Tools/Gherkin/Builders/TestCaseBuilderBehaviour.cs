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