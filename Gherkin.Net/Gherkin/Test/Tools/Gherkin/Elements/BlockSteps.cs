// <copyright file="BlockSteps.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin.Elements
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    internal class BlockSteps : IGherkinBlockSteps
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