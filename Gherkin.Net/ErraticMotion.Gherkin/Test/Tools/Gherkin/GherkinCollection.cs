// <copyright file="GherkinCollection.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    internal class GherkinCollection<T> : IGherkinElements<T>
        where T : class
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

        public T this[int index] => this.items.ElementAtOrDefault(index);

        public IEnumerator<T> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        protected void AddContainer(IList<T> value)
        {
            this.items = value;
        }
    }
}