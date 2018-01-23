﻿// ---------------------------------------------------------------------------
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

    public class DocString : IGherkinDocString
    {
        private readonly List<string> testCase = new List<string>();
        private readonly int whiteSpacePadding;

        public DocString(IEnumerable<string> testCase, int whiteSpacePadding)
        {
            this.testCase = new List<string>(testCase);
            this.whiteSpacePadding = whiteSpacePadding;
        }
        
        public string this[int index]
        {
            get
            {
                return this.ElementAt(index);
            }
        }

        public IEnumerator<string> GetEnumerator()
        {
            return this.testCase.Select(t => t.Remove(0, this.whiteSpacePadding)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IGherkinElements<string> Gherkin
        {
            get
            {
                const string Format = "   [{0}]";
                var result = new GherkinCollectionString();
                result.AppendLine(Format, GherkinSyntax.DocString);
                foreach (var line in this.testCase)
                {
                    result.AppendLine(line);
                }

                result.AppendLine(Format, GherkinSyntax.DocString);
                return result;
            }
        }
    }
}