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

namespace ErraticMotion.Test.Tools.Gherkin.Builders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ErraticMotion.Test.Tools.Gherkin.Elements;

    public class TestCaseBuilder : ITestCaseBuilder<TestCases>
    {
        private readonly List<TestCaseRow> testCases = new List<TestCaseRow>();

        public TestCases Build()
        {
            return this.testCases.Count == 0 
                ? null 
                : new TestCases(this.testCases[0], this.testCases.Skip(1).ToArray());
        }

        public void AddTestCase(object[] cells)
        {
            var row = new TestCaseRow(cells.Select(c => new TestCaseCell(c)));

            if (this.testCases.Count > 0 && this.testCases[0].Count() != row.Count())
            {
                throw new ArgumentOutOfRangeException("cells",
                    "Number of cells in the row does not match the number of cells in the header.");
            }

            this.testCases.Add(row);
        }
    }
}