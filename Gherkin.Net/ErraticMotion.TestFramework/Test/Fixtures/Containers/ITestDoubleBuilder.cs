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
    /// Represents a GoF Builder pattern that can be used by types of test doubles.
    /// </summary>
    /// <remarks>
    /// Implement this interface for type of test double builder so that they can be injected
    /// into the test fixture IoC mechanism using the 
    /// <see cref="FixtureKernelTestDoubleExtensions.BindBuilder{T}"/> member.
    /// </remarks>
    /// <typeparam name="T">The type that the test double is impersonating.</typeparam>
    public interface ITestDoubleBuilder<out T> where T : class
    {
        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns>A object of type T.</returns>
        T Build();
    }
}