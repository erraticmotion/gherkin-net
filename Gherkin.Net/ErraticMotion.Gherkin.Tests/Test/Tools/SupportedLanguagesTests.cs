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

namespace ErraticMotion.Test.Tools
{
    using FluentAssertions;

    using NUnit.Framework;

    public class SupportedLanguagesTests
    {
        [Test]
        public void ShouldSupportEnglish()
        {
            var item = SupportedLanguages.GetSupportedLanguage("en");
            item.Should().NotBeNull();
        }

        [Test]
        public void ShouldSupportEnglishUk()
        {
            var item = SupportedLanguages.GetSupportedLanguage("en-UK");
            item.Should().NotBeNull();
        }

        [Test]
        public void ShouldSupportFrench()
        {
            var item = SupportedLanguages.GetSupportedLanguage("fr");
            item.Should().NotBeNull();
        }

        [Test]
        public void ShouldNotSupportGerman()
        {
            Should.Throw<Gherkin.GherkinException>(() => SupportedLanguages.GetSupportedLanguage("de"));
        }
    }
}