// <copyright file="Internationalization.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Represents the language and vocabulary service entry point.
    /// </summary>
    /// <remarks>
    /// Internationalization and localization, i18n; where 18 stands for the number of letters 
    /// between the first i and the last n in the word “internationalization”.
    /// </remarks>
    public class Internationalization : ILanguageService, IVocabularyService
    {
        private const string DefaultCode = "en";
        private static readonly Regex LanguagePattern = new Regex(@"^\s*#\s*language:\s*(?<lang>[\w-]+)\s*\n");
        
        /// <summary>
        /// Gets the default language information.
        /// </summary>
        /// <value>An object that supports the <see cref="ILanguageInfo"/> abstraction.</value>
        public static ILanguageInfo Default
        {
            get { return For(DefaultCode); }
        }

        /// <summary>
        /// Gets the language information for the specified code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>An object that supports the <see cref="ILanguageInfo"/> abstraction.</returns>
        public static ILanguageInfo For(string code)
        {
            return SupportedLanguages.GetSupportedLanguage(code);
        }

        /// <summary>
        /// Services the specified default language.
        /// </summary>
        /// <param name="defaultLanguage">The default language.</param>
        /// <returns>An object that supports the <see cref="ILanguageService"/> abstraction.</returns>
        public static ILanguageService SetDefault(string defaultLanguage = "en")
        {
            return new Internationalization(CultureInfo.GetCultureInfo(defaultLanguage));
        }

        /// <summary>
        /// Gets an object that contains the international vocabularies.
        /// </summary>
        /// <returns>An object that supports the <see cref="IVocabularyService"/> abstraction.</returns>
        public static IVocabularyService Vocabularies
        {
            get { return new Internationalization(); }
        }

        private readonly CultureInfo specifiedLanguage;

        /// <summary>
        /// Prevents a default instance of the <see cref="Internationalization"/> class from being created.
        /// </summary>
        private Internationalization()
            : this(CultureInfo.GetCultureInfo(DefaultCode))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Internationalization"/> class.
        /// </summary>
        /// <param name="specifiedLanguage">The specified language.</param>
        private Internationalization(CultureInfo specifiedLanguage)
        {
            this.specifiedLanguage = specifiedLanguage;
        }

        #region ILanguageService

        /// <summary>
        /// Gets the language.
        /// </summary>
        /// <param name="fileContent">Content of the file.</param>
        /// <returns>
        /// An object that supports the <see cref="ILanguageInfo" /> abstraction.
        /// </returns>
        public ILanguageInfo TryParse(string fileContent)
        {
            var name = this.specifiedLanguage.Name;
            var langMatch = LanguagePattern.Match(fileContent);
            if (langMatch.Success)
            {
                name = langMatch.Groups["lang"].Value;
            }
                
            return SupportedLanguages.GetSupportedLanguage(name);
        }

        #endregion

        #region IVocabularyService

        /// <summary>
        /// Returns the Gherkin vocabulary for the specified code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>
        /// An object that supports the <see cref="IGherkinVocabulary" /> abstraction.
        /// </returns>
        public IGherkinVocabulary Find(string code)
        {
            return this.FirstOrDefault(x => x.Code == code);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<IGherkinVocabulary> GetEnumerator()
        {
            return SupportedLanguages.All().Select(x => new VocabularyAdapter(x)).GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion
    }
}