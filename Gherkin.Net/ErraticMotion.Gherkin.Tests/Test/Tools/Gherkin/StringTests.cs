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
    using FluentAssertions;

    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class StringTests
    {
        [TestCase("And stuff", "stuff")]
        [TestCase(" And stuff", "stuff")]
        [TestCase(" and stuff", "stuff")]
        [TestCase("And  stuff", "stuff")]
        [TestCase("and   stuff", "stuff")]
        public void ShouldTrimAfterStep(string value, string expected)
        {
            var doc = new Mock<ILanguageSyntax<GherkinStep>>();
            doc.SetupGet(x => x.Localised).Returns("And");

            // TODO Enable
            //value.Trim(doc.Object).Should().Be(expected);
        }
    }
}