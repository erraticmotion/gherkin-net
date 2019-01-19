// <copyright file="GherkinScenarioBlock.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin
{
    /// <summary>
    /// Represents an scenario block gherkin element.
    /// </summary>
    /// <remarks>
    /// A scenario block is an enclosing type that can contain
    /// And's and But's that apply to one of the values defined here.
    /// </remarks>
    public enum GherkinScenarioBlock
    {
        /// <summary>
        /// Undefined, means the gherkin syntax cannot match the enclosing type.
        /// </summary>
        None,

        /// <summary>
        /// The gherkin Given keyword is followed by optional And's and But's.
        /// </summary>
        Given,

        /// <summary>
        /// The gherkin When keyword is followed by optional And's and But's.
        /// </summary>
        When,

        /// <summary>
        /// The gherkin Then keyword is followed by optional And's and But's.
        /// </summary>
        Then,
    }
}