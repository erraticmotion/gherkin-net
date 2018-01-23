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
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    using ErraticMotion.Test.Tools.Gherkin;

    public static class SupportedLanguages
    {
        private const string Root = "Language";
        private static readonly XDocument Languages;

        static SupportedLanguages()
        {
            var docStream = typeof(SupportedLanguages).Assembly
                .GetManifestResourceStream("ErraticMotion.Test.Tools.Languages.xml");

            if (docStream == null)
            {
                throw new InvalidOperationException("Language resource not found.");
            }

            using (var reader = new StreamReader(docStream))
            {
                Languages = XDocument.Load(reader);
            }
        }

        public static ILanguageInfo GetSupportedLanguage(string languageName)
        {
            return GetLanguageInfo(GetBestFitLanguageElement(languageName));
        }

        public static IEnumerable<ILanguageSupport> All()
        {
// ReSharper disable PossibleNullReferenceException
            var elements = Languages.Root.Elements(Root);
// ReSharper restore PossibleNullReferenceException
            return elements.Select(GetLanguageInfo).Select(x => new SupportedLanguage(x));
        }

        private static ILanguageInfo GetLanguageInfo(XElement element)
        {
            var code = element.Attribute(XName.Get("code", string.Empty)).Value;
            var name = element.Attribute(XName.Get("englishName", string.Empty)).Value;
            var culture = CultureInfo.GetCultureInfo(element.Attribute(XName.Get("cultureInfo", string.Empty)).Value);
            var specificCulture = CultureInfo.GetCultureInfo(element.Attribute(XName.Get("defaultSpecificCulture", string.Empty)).Value);
            var builder = LanguageInfoBuilder.For(code, name, culture, specificCulture, element);
            return builder.Build();
        }

        private static XElement GetBestFitLanguageElement(string code)
        {
// ReSharper disable PossibleNullReferenceException
            var element = Languages.Root.Elements(Root).FirstOrDefault(x => x.Attribute("code").Value == code);
// ReSharper restore PossibleNullReferenceException
            if (element != null)
            {
                return element;
            }

            var lastDashIndex = code.LastIndexOf('-');
            if (lastDashIndex <= 0)
            {
                throw new GherkinException(
                    GherkinExceptionType.LanguageNotSupported,
                    string.Format("The specified feature file language ('{0}') is not supported.", code));
            }

            return GetBestFitLanguageElement(code.Substring(0, lastDashIndex));
        }
    }
}