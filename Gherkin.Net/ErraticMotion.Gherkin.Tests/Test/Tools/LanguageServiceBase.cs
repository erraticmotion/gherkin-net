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
    using System.IO;
    using System.Text;

    using ErraticMotion.Test.Fixtures;

    using NUnit.Framework;

    [TestFixture]
    public abstract class LanguageServiceBase : GivenWhenThen
    {
        private StringBuilder text = new StringBuilder();

        protected override void Cleanup()
        {
            this.text = new StringBuilder();
        }

        protected ILanguageInfo GetLanguage(string defaultLanguage = "en")
        {
            var reader = new StringReader(this.text.ToString());
            var fileContent = reader.ReadToEnd();

            var sut = Internationalization.SetDefault(defaultLanguage);
            return sut.TryParse(fileContent);
        }

        protected void AddLanguage(string language)
        {
            this.text.AppendLine(language);
            this.text.AppendLine("Feature:");
        }
    }
}