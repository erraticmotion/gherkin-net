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

    public class BlockSteps : IGherkinBlockSteps
    {
        private readonly List<IGherkinBlockStep> results = new List<IGherkinBlockStep>();

        public BlockSteps()
        {
        }

        public BlockSteps(IEnumerable<IGherkinBlockStep> steps)
        {
            this.results.AddRange(steps);
        }

        public IGherkinBlockStep this[GherkinStep step]
        {
            get
            {
                return this.FirstOrDefault(x => x.Step.Syntax == step);
            }
        }

        public IEnumerable<IGherkinBlockStep> Parent(GherkinScenarioBlock parent)
        {
            return this.Where(x => x.Parent == parent && x.Step.Syntax != parent.Step());
        }

        public IEnumerator<IGherkinBlockStep> GetEnumerator()
        {
            return this.results.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}