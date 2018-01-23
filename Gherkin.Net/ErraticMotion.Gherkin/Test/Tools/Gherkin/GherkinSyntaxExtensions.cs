// <copyright file="GherkinSyntaxExtensions.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin
{
    /// <summary>
    /// Provides extension methods for <c>Gherkin</c> language elements.
    /// </summary>
    public static class GherkinSyntaxExtensions
    {
        /// <summary>
        /// Returns the Gherkin Step for the block.
        /// </summary>
        /// <param name="block">The block.</param>
        /// <returns>The corresponding step.</returns>
        public static GherkinStep Step(this GherkinScenarioBlock block)
        {
            switch (block)
            {
                case GherkinScenarioBlock.Given:
                    return GherkinStep.Given;
                case GherkinScenarioBlock.When:
                    return GherkinStep.When;
                case GherkinScenarioBlock.Then:
                    return GherkinStep.Then;
                default:
                    return GherkinStep.None;
            }
        }

        /// <summary>
        /// Returns the Gherkin Block for the step.
        /// </summary>
        /// <param name="step">The step.</param>
        /// <returns>The corresponding block.</returns>
        public static GherkinScenarioBlock Block(this GherkinStep step)
        {
            switch (step)
            {
                case GherkinStep.Given:
                    return GherkinScenarioBlock.Given;
                case GherkinStep.When:
                    return GherkinScenarioBlock.When;
                case GherkinStep.Then:
                    return GherkinScenarioBlock.Then;
                default:
                    return GherkinScenarioBlock.Then;
            }
        }
    }
}