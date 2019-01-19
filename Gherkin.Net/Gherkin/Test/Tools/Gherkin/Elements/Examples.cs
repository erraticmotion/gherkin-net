// <copyright file="Examples.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin.Elements
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    internal class Examples : IGherkinExamples
    {
        private readonly List<Example> results = new List<Example>();

        public Examples()
        {
        }

        public Examples(IEnumerable<Example> examples)
        {
            this.results.AddRange(examples);
        }

        public IGherkinExample this[int index] => this.results.ElementAtOrDefault(index);

        public IEnumerator<IGherkinExample> GetEnumerator()
        {
            return this.results.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}