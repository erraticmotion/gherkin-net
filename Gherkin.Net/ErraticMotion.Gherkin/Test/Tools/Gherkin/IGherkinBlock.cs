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

    /// <summary>
    /// Represents a Gherkin block element that contains a collection of steps and comments.
    /// </summary>
    public interface IGherkinBlock : IGherkinKeyword, IGherkin
    {
        /// <summary>
        /// Gets the Gherkin steps for this scenario.
        /// </summary>
        IGherkinBlockSteps Steps { get; }

        /// <summary>
        /// Gets a collection of Gherkin Comments belonging to this feature.
        /// </summary>
        IList<IGherkinComment> Comments { get; }
    }
}