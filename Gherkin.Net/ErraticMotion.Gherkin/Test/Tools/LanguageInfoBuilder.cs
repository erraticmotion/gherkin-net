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
    using System.Globalization;
    using System.Linq;
    using System.Xml.Linq;

    internal class LanguageInfoBuilder
    {
        public static LanguageInfoBuilder For(string code, string name, CultureInfo cultureInfo, CultureInfo defaultCulture, XElement element)
        {
            return new LanguageInfoBuilder(code, name, cultureInfo, defaultCulture, element);
        }

        private readonly string code;
        private readonly string name;
        private readonly CultureInfo cultureInfo;
        private readonly CultureInfo specificCultureInfo;
        private readonly Func<string, string> find;

        private LanguageInfoBuilder(string code, string name, CultureInfo cultureInfo, CultureInfo specificCultureInfo, XContainer element)
        {
            this.code = code;
            this.name = name;
            this.cultureInfo = cultureInfo;
            this.specificCultureInfo = specificCultureInfo;
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            this.find = n =>
            {
                var firstOrDefault = element.Elements().FirstOrDefault(x => x.Name == n);
                return firstOrDefault != null ? firstOrDefault.Value : null;
            };
        }

        public ILanguageInfo Build()
        {
            return new LanguageInfo(this.code, this.name, this.cultureInfo, this.specificCultureInfo, this.find);
        }
    }
}