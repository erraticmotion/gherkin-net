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

    /// <summary>
    /// Represents a culture specific Gherkin vocabulary.
    /// </summary>
    public interface IGherkinVocabulary : IFormattable
    {
        /// <summary>
        /// Gets the code.
        /// </summary>
        string Code { get; }

        /// <summary>
        /// Gets the vocabulary for the supported culture.
        /// </summary>
        IEnumerable<IGherkinSyntax> Vocabulary { get; }
    }
}