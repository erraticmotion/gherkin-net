// <copyright file="LanguageInfoBuilder.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

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