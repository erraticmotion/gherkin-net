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
    using ErraticMotion.Test.Tools.Gherkin.Elements;

    public class ExampleBuilder : GherkinBuilder<Example>, ITestCaseBuilder<Example>
    {
        private readonly string title;
        private readonly TestCaseBuilder testCaseBuilder = new TestCaseBuilder();

        public ExampleBuilder(ILanguageInfo info, string title)
            : base(info, GherkinKeyword.Examples)
        {
            this.title = title;
        }

        public void AddTestCase(object[] cells)
        {
            this.testCaseBuilder.AddTestCase(cells);
        }

        public override Example Build()
        {
            var exampleTable = this.testCaseBuilder.Build();
            return new Example(this.LanguageInfo, this.title, this.Description, exampleTable);
        }
    }
}