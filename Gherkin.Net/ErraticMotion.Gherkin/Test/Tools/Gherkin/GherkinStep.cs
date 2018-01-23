// <copyright file="GherkinStep.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin
{
    /// <summary>
    /// Represents a gherkin step keyword.
    /// </summary>
    public enum GherkinStep
    {
        /// <summary>
        /// The gherkin keyword Given.
        /// </summary>
        Given,

        /// <summary>
        /// The gherkin keyword When.
        /// </summary>
        When,

        /// <summary>
        /// The gherkin keyword Then.
        /// </summary>
        Then,

        /// <summary>
        /// The gherkin keyword And.
        /// </summary>
        And,

        /// <summary>
        /// The gherkin keyword But.
        /// </summary>
        But,

        /// <summary>
        /// Undefined step.
        /// </summary>
        None
    }
}