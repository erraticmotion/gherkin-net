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