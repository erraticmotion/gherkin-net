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

    public class Examples : IGherkinExamples
    {
        private readonly List<Example> results = new List<Example>();

        public Examples()
        {
        }

        public Examples(IEnumerable<Example> examples)
        {
            this.results.AddRange(examples);
        }

        public IEnumerator<IGherkinExample> GetEnumerator()
        {
            return this.results.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IGherkinExample this[int index]
        {
            get { return this.results.ElementAtOrDefault(index); }
        }
    }
}