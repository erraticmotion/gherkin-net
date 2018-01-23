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
    /// Enumerates the well known keywords used within Gherkin+.
    /// </summary>
    public enum CommentKey
    {
        /// <summary>
        /// Represents an undefined key being used within a comment. 
        /// </summary>
        Undefined,

        /// <summary>
        /// Represents the language key.
        /// </summary>
        Language,

        /// <summary>
        /// Represents the namespace key.
        /// </summary>
        Namespace,

        /// <summary>
        /// Represents the source key.
        /// </summary>
        Source
    }
}