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
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    internal class GherkinCollection<T> : IGherkinElements<T> where T : class
    {
        private IList<T> items;

        protected GherkinCollection()
        {
        }

        public GherkinCollection(IList<T> items)
        {
            this.items = items;
        }

        public GherkinCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        protected void AddContainer(IList<T> value)
        {
            this.items = value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public T this[int index]
        {
            get { { return this.items.ElementAtOrDefault(index); } }
        }
    }
}