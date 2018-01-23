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
    /// <summary>
    /// Represents the Gherkin language keywords with their corresponding
    /// culture specific equivalents.
    /// </summary>
    public interface IGherkinSyntax
    {
        /// <summary>
        /// Gets the Gherkin keyword.
        /// </summary>
        string Keyword { get; }

        /// <summary>
        /// Gets the culture specific description of the <see cref="Keyword"/>.
        /// </summary>
        string CultureSpecific { get; }
    }
}