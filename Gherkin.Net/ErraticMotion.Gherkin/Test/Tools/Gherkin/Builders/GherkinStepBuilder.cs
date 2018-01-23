// <copyright file="GherkinStepBuilder.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin.Builders
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// Represents a builder for Gherkin Steps.
    /// </summary>
    /// <typeparam name="T">The type of object to be returned after building this instance.</typeparam>
    public abstract class GherkinStepBuilder<T> : GherkinBuilder<T>
        where T : class
    {
        private readonly IList<IBuilder<IGherkinBlockStep>> steps = new List<IBuilder<IGherkinBlockStep>>();

        /// <summary>
        /// Initializes a new instance of the <see cref="GherkinStepBuilder{T}" /> class.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <param name="keyword">The keyword.</param>
        protected GherkinStepBuilder(ILanguageInfo info, GherkinKeyword keyword)
            : base(info, keyword)
        {
        }

        /// <summary>
        /// Gets the collection of Gherkin steps.
        /// </summary>
        public IEnumerable<IGherkinBlockStep> Steps
        {
            get
            {
                return this.steps.Select(x => x.Build());
            }
        }

        /// <summary>
        /// Adds the step.
        /// </summary>
        /// <param name="step">The step.</param>
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Step", Justification = "Gherkin keyword")]
        public virtual void AddStep(IBuilder<IGherkinBlockStep> step)
        {
            this.steps.Add(step);
        }
    }
}