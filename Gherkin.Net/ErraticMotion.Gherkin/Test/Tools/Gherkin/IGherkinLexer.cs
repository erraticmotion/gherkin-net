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
    /// Responsible for creating a Gherkin feature AST.
    /// </summary>
    public interface IGherkinLexer
    {
        /// <summary>
        /// Parses the specified feature file reader.
        /// </summary>
        /// <returns>An object that supports the <see cref="IGherkinFeature"/> interface.</returns>
        IGherkinFeature Parse();
    }
}