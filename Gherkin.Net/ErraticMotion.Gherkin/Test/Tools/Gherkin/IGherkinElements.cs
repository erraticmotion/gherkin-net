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
    /// Represents the collection of Gherkin elements within a feature.
    /// </summary>
    /// <typeparam name="TGherkinElement">The type of the gherkin element.</typeparam>
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "Gherkin keyword")]
    public interface IGherkinElements<out TGherkinElement> : IEnumerable<TGherkinElement> where TGherkinElement : class
    {
        /// <summary>
        /// Gets the <typeparamref name="TGherkinElement"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <typeparamref name="TGherkinElement"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns>An object that supports the <see typeparamref="TGherkinElement"/> interface.</returns>
        TGherkinElement this[int index] { get; }
    }
}