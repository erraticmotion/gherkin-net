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

    [TestFixture(Category = "Language")]
    public class LanguageServiceTests : LanguageServiceBase
    {
        [Test]
        public void GetLanguageFromEn()
        {
            this.AddLanguage("# language: en");
            var result = this.GetLanguage("fr");
            result.Code.Should().Be("en");
        }

        [Test]
        public void GetLanguageFromFr()
        {
            this.AddLanguage("# language: fr");
            var result = this.GetLanguage();
            result.Code.Should().Be("fr");
        }

        [Test]
        public void GetLanguageFrom()
        {
            this.AddLanguage(string.Empty);
            var result = this.GetLanguage();
            result.Code.Should().Be("en");
        }

        [Test]
        public void GetLanguageFromNo()
        {
            this.AddLanguage("# language: no");
            Should.Throw<Gherkin.GherkinException>(() => this.GetLanguage());
        }
    }
}