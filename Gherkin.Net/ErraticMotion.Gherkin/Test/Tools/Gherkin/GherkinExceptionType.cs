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
    /// Enumerates the possible failure types when generating a Gherkin file.
    /// </summary>
    public enum GherkinExceptionType
    {
        /// <summary>
        /// Means I haven't got round to working out why the Gherkin Lexer failed.
        /// </summary>
        NotMapped,

        /// <summary>
        /// There are no scenarios in the feature.
        /// </summary>
        NoScenariosInFeature,

        /// <summary>
        /// The Gherkin syntax was invalid.
        /// </summary>
        InvalidGherkin,

        /// <summary>
        /// The language specified is not supported.
        /// </summary>
        LanguageNotSupported,
    }
}