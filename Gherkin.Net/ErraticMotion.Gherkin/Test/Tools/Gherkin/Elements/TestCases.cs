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
    using System.Collections.Generic;

    public class TestCases : ITestCases
    {
        public TestCases(ITestCaseRow header, IEnumerable<ITestCaseRow> body)
        {
            this.Parameters = header;
            this.Values = body;
        }

        public ITestCaseRow Parameters { get; private set; }

        public IEnumerable<ITestCaseRow> Values { get; private set; }

        public IGherkinElements<string> Gherkin
        {
            get
            {
                var result = new GherkinCollectionString();
                result.AppendLine("          {0}", this.Parameters);
                foreach (var value in this.Values)
                {
                    result.AppendLine("          {0}", value);
                }

                return result;
            }
        }
    }
}