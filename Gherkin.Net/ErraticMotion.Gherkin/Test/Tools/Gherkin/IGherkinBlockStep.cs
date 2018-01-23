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