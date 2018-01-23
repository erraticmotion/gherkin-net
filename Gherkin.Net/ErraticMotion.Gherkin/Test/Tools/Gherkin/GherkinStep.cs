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