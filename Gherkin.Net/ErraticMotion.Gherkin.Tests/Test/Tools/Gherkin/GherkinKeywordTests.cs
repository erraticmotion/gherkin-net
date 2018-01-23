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
    public class GherkinKeywordTests
    {
        [TestCase("feature:")]
        [TestCase("Feature:")]
        [TestCase("FEATURE:")]
        [TestCase(" feature:")]
        [TestCase(" feature: ")]
        public void ShouldMatchFeatureKeyword(string value)
        {
            value.StartsWith(GherkinKeyword.Feature).Should().BeTrue();
        }

        [TestCase("feature:", "")]
        [TestCase("Feature:", "")]
        [TestCase("FEATURE:", "")]
        [TestCase(" feature:", "")]
        [TestCase(" feature: ", "")]
        [TestCase("Feature: a feature", "a feature")]
        [TestCase("Feature: a feature  ", "a feature")]
        public void ShouldReturnFeatureName(string value, string expected)
        {
            value.Name(GherkinKeyword.Feature).Should().Be(expected);
        }

        [TestCase("Feature a feature")]
        public void ShouldRaiseExceptionWhenNoNameForKeyword(string value)
        {
            Assert.Throws<GherkinException>(() => value.Name(GherkinKeyword.Feature));
        }
    }
}