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