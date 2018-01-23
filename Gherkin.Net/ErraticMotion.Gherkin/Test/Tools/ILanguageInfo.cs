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
    using System.Globalization;

    using ErraticMotion.Test.Tools.Gherkin;

    /// <summary>
    /// Represents the language that the feature file is written in.
    /// </summary>
    public interface ILanguageInfo
    {
        /// <summary>
        /// Gets the language code.
        /// </summary>
        string Code { get; }

        /// <summary>
        /// Gets the name of the language code in English.
        /// </summary>
        string EnglishName { get; }

        /// <summary>
        /// Gets the culture information.
        /// </summary>
        CultureInfo CultureInfo { get; }

        /// <summary>
        /// Gets the specific culture information.
        /// </summary>
        CultureInfo SpecificCultureInfo { get; }

        /// <summary>
        /// Returns the specified keyword as a localized string value.
        /// </summary>
        /// <param name="item">The keyword.</param>
        /// <returns>A localized <see cref="string"/> representation of the Gherkin keyword.</returns>
        ILanguageSyntax<GherkinKeyword> Get(GherkinKeyword item);

        /// <summary>
        /// Returns the specified step as a localized string value.
        /// </summary>
        /// <param name="step">The step.</param>
        /// <returns>A localized <see cref="string"/> representation of the Gherkin keyword.</returns>
        ILanguageSyntax<GherkinStep> Get(GherkinStep step);
    }
}