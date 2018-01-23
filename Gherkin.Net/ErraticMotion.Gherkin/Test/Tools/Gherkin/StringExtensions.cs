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

namespace ErraticMotion.Test.Tools.Gherkin
{
    /// <summary>
    /// Contains extension methods for the <see cref="string"/> type.
    /// </summary>
    internal static class StringExtensions
    {
        /// <summary>
        /// Trims the specified value based on the gherkin step keyword.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="step">The keyword.</param>
        /// <returns>A string representation of the value after the value has been trimmed.</returns>
        public static string Trim(this string value, ILanguageSyntax<GherkinStep> step)
        {
            var l = step.Localised.Length + 1;
            return value.TrimStart().Remove(0, l).TrimStart();
        }
    }
}