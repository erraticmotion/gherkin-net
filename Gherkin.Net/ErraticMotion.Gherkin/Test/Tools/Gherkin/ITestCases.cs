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

    /// <summary>
    /// Represents a Gherkin test case table.
    /// </summary>
    public interface ITestCases : IGherkin
    {
        /// <summary>
        /// Gets the test case header containing the column names used as parameters.
        /// </summary>
        ITestCaseRow Parameters { get; }

        /// <summary>
        /// Gets the collection of test case data items.
        /// </summary>
        IEnumerable<ITestCaseRow> Values { get; }
    }
}