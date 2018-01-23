// ---------------------------------------------------------------------------
// (C) 2016 Parkeon Limited.
// 
//  No part of this source code may be reproduced, digitised, stored in a 
//  retrieval system, communicated to the public or caused to be seen or heard 
//  in public, made publicly available or publicly performed, offered for sale 
//  or hire or exhibited by way of trade in public or distributed by way of trade 
//  in any form or by any means, electronic, mechanical or otherwise without the 
//  written permission of Parkeon Limited.
// 
// ---------------------------------------------------------------------------

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