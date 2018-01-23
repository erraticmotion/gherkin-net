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

namespace ErraticMotion.Test.Tools.Gherkin.Builders
{
    /// <summary>
    /// Represents a type of object builder.
    /// </summary>
    /// <typeparam name="T">The type of object to be built.</typeparam>
    public interface IBuilder<out T> where T : class
    {
        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns>A object of type T.</returns>
        T Build();
    }
}