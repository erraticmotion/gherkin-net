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

namespace ErraticMotion.Test.Fixtures.Containers
{
    /// <summary>
    /// Represents an operation to bind common dependencies into the underlying IoC container.
    /// </summary>
    public interface IFixtureBindings
    {
        /// <summary>
        /// Loads the specified bindings into the kernel.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        void Load(IFixtureKernel kernel);
    }
}