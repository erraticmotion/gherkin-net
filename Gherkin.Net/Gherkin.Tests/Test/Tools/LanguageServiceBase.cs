// <copyright file="LanguageServiceBase.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

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