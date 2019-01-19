// <copyright file="IGherkinBlockSteps.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Represents the collection of block steps.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "Gherkin keyword")]
    public interface IGherkinBlockSteps : IEnumerable<IGherkinBlockStep>
    {
        /// <summary>
        /// Gets the <see cref="IGherkinBlockStep"/> with the specified step.
        /// </summary>
        /// <value>
        /// The <see cref="IGherkinBlockStep"/>.
        /// </value>
        /// <param name="step">The step.</param>
        /// <returns>The <see cref="IGherkinBlockStep"/>.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Step", Justification = "Gherkin keyword")]
        IGherkinBlockStep this[GherkinStep step] { get; }

        /// <summary>
        /// Returns a collection of steps for the given scenario.
        /// </summary>
        /// <param name="block">The scenario block.</param>
        /// <returns>
        /// A collection of steps for the Gherkin scenario block.
        /// </returns>
        IEnumerable<IGherkinBlockStep> Parent(GherkinScenarioBlock block);
    }
}