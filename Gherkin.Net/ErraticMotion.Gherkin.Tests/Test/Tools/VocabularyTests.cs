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
    using System;

    using FluentAssertions;

    using NUnit.Framework;

    [TestFixture]
    public class VocabularyTests
    {
        [Test]
        public void Show()
        {
            var sut = Internationalization.Vocabularies.Find("fr");
            Should.NotThrow(() => Console.WriteLine("{0}", sut));
        }

        [Test]
        public void EnLanguageShouldBe()
        {
            var sut = Internationalization.Vocabularies.Find("en");
            var result = string.Format("{0:l}", sut);
            result.Should().Contain("# language: en");
        }

        [Test]
        public void FrLanguageShouldBe()
        {
            var sut = Internationalization.Vocabularies.Find("fr");
            var result = string.Format("{0:l}", sut);
            result.Should().Contain("# language: fr");
        }
    }
}