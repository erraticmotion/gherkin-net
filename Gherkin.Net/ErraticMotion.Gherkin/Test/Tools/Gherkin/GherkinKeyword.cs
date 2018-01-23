// <copyright file="GherkinKeyword.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin
{
    /// <summary>
    /// Represents gherkin keywords.
    /// </summary>
    /// <remarks>
    /// Used to separate different sections of the gherkin feature file.
    /// </remarks>
    public enum GherkinKeyword
    {
        /// <summary>
        /// The Gherkin keyword Feature.
        /// </summary>
        Feature,

        /// <summary>
        /// The Gherkin keyword Background.
        /// </summary>
        Background,

        /// <summary>
        /// The Gherkin keyword Scenario.
        /// </summary>
        Scenario,

        /// <summary>
        /// The Gherkin keyword Scenario Outline.
        /// </summary>
        ScenarioOutline,

        /// <summary>
        /// The Gherkin Scenarios keyword.
        /// </summary>
        /// <remarks>
        /// Can be used as a shorthand way of specifying the <see cref="ScenarioOutline"/> value.
        /// </remarks>
        Scenarios,

        /// <summary>
        /// The Gherkin keyword Examples.
        /// </summary>
        Examples,

        /// <summary>
        /// The Gherkin+ Keyword.
        /// </summary>
        /// <remarks>
        /// Can used as a replacement for the <see cref="Examples"/> keyword.
        /// </remarks>
        Where
    }
}