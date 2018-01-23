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
    using FluentAssertions;

    using NUnit.Framework;

    [TestFixture]
    public class FeatureBuilderBehaviour
    {
        [TestCase("en", "Feature")]
        [TestCase("en-GB", "Feature")]
        [TestCase("en-US", "Feature")]
        [TestCase("fr", "Fonctionnalité")]
        public void GherkinKeywordShouldBe(string lang, string expected)
        {
            var sut = new FeatureBuilder(Internationalization.For(lang), string.Empty);
            sut.Keyword.Syntax.Should().Be(GherkinKeyword.Feature);
            sut.Keyword.Localised.Should().Be(expected);
        }
    }
}