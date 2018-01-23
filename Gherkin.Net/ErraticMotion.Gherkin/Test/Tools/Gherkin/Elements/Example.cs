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
    public class Example : GherkinKeywordBase, IGherkinExample
    {
        public Example(ILanguageInfo info, string name, string description, ITestCases testCases)
            : base(info, GherkinKeyword.Examples, name, description)
        {
            this.TestCases = testCases;
        }

        public ITestCases TestCases { get; private set; }

        public IGherkinElements<string> Gherkin
        {
            get
            {
                var result = new GherkinCollectionString();
                result.AppendLine("    {0}: {1}", this.Keyword.Format(), this.Name);
                if (!string.IsNullOrEmpty(this.Description))
                {
                    result.AppendLine("    {0}", this.Description);
                }

                result.Append(this.TestCases);
                return result;
            }
        }
    }
}