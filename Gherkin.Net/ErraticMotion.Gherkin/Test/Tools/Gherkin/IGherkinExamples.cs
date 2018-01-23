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
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Represents a collection of Gherkin Examples.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "Gherkin keyword")]
    public interface IGherkinExamples : IEnumerable<IGherkinExample>
    {        
        /// <summary>
        /// Gets or sets the <see cref="IGherkinExample"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="IGherkinExample"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns>An object that supports the <see cref="IGherkinExample"/> interface.</returns>
        IGherkinExample this[int index] { get; }
    }
}