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

namespace ErraticMotion.Test.Tools.Gherkin.Elements
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class TestCaseRow : ITestCaseRow
    {
        private readonly List<ITestCaseCell> row;

        public TestCaseRow(IEnumerable<ITestCaseCell> cells)
        {
            this.row = new List<ITestCaseCell>(cells);
        }

        public ITestCaseCell this[int index]
        {
            get
            {
                return this.ElementAt(index);
            }
        }

        public IEnumerator<ITestCaseCell> GetEnumerator()
        {
            return this.row.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IGherkinElements<string> Gherkin
        {
            get
            {
                var result = new GherkinCollectionString();
                result.AppendLine(this.ToString());
                return result;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append('(');
            foreach (var cell in this)
            {
                builder.AppendFormat("{0},", cell);
            }

            return builder.ToString().TrimEnd(',') + ")";
        }
    }
}