// <copyright file="IGherkinBlockStep.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Represents a Gherkin step within a scenario or background block.
    /// </summary>
    public interface IGherkinBlockStep : IGherkin
    {
        /// <summary>
        /// Gets the enclosing scenario block that this object belongs to.
        /// </summary>
        GherkinScenarioBlock Parent { get; }

        /// <summary>
        /// Gets the scenario step of this object.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Step", Justification = "Gherkin keyword")]
        ILanguageSyntax<GherkinStep> Step { get; }

        /// <summary>
        /// Gets the description (expected behaviour) of this step.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets the tabular test case data that applies to this step 
        /// (optional, only applies to <see cref="GherkinKeyword.ScenarioOutline"/>).
        /// </summary>
        ITestCases TestCase { get; }

        /// <summary>
        /// Gets the doc string test case data.
        /// </summary>
        IGherkinDocString DocString { get; }
    }
}