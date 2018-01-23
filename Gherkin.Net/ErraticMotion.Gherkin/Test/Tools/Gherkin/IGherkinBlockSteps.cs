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