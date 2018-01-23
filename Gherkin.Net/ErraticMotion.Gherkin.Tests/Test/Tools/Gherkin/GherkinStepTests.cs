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

    using NUnit.Framework;

    [TestFixture]
    public class GherkinStepTests
    {
        [TestCase("and")]
        [TestCase("And")]
        [TestCase("AND")]
        [TestCase(" and")]
        [TestCase(" and ")]
        public void ShouldMatchStepKeyword(string value)
        {
            // TODO Enable
            //value.StartsWith(GherkinStep.And).Should().BeTrue();
        }
    }
}