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
    /// Represents a test case row within a tabular data structure.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "It is a test case row, not a collection.")]
    public interface ITestCaseRow : IEnumerable<ITestCaseCell>, IGherkin
    {
        /// <summary>
        /// Gets the <see cref="ITestCaseCell"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="ITestCaseCell"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns>The test case cell value.</returns>
        ITestCaseCell this[int index] { get; }
    }
}