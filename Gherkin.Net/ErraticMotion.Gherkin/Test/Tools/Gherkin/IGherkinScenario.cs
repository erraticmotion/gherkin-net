// <copyright file="IGherkinScenario.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin
{
    /// <summary>
    /// Represents a Gherkin Scenario.
    /// </summary>
    public interface IGherkinScenario : IGherkinBlock
    {
        /// <summary>
        /// Gets the examples for this scenario.
        /// </summary>
        IGherkinExamples Examples { get; }
    }
}