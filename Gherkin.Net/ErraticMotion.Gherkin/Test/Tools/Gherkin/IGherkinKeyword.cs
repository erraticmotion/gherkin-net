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
    /// Represents a Gherkin keyword base interface.
    /// </summary>
    public interface IGherkinKeyword
    {
        /// <summary>
        /// Gets the gherkin keyword.
        /// </summary>
        ILanguageSyntax<GherkinKeyword> Keyword { get; }

        /// <summary>
        /// Gets an optional name related to this object.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets an optional description related to this object.
        /// </summary>
        string Description { get; }
    }
}