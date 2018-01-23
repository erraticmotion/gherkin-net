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
    using System.Collections.Generic;

    using ErraticMotion.Test.Tools.Gherkin;

    /// <summary>
    /// Represents the culture specific Gherkin keywords and steps for a specific language.
    /// </summary>
    public interface ILanguageSupport 
    {
        /// <summary>
        /// Gets the language information.
        /// </summary>
        ILanguageInfo LanguageInfo { get; }

        /// <summary>
        /// Gets the culture specific keywords.
        /// </summary>
        IEnumerable<ILanguageSyntax<GherkinKeyword>> Keywords { get; }

        /// <summary>
        /// Gets the culture specific steps.
        /// </summary>
        IEnumerable<ILanguageSyntax<GherkinStep>> Steps { get; }
    }
}