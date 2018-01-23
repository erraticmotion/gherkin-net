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
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq.Expressions;

    /// <summary>
    /// Contains extension methods for the <see cref="IFixtureKernel"/> interface
    /// that creates registers <see cref="Parkeon.Test.Doubles.ITestDouble{T}"/> 
    /// types and add them into the underlying IoC container.
    /// </summary>
    public static class FixtureKernelTestDoubleExtensions
    {
        /// <summary>
        /// Binds the test double builder into the underlying IoC container.
        /// </summary>
        /// <typeparam name="T">The type of interface to add to the underlying IoC container.</typeparam>
        /// <param name="kernel">The kernel.</param>
        /// <param name="builder">The test double builder.</param>
        public static void BindBuilder<T>(this IFixtureKernel kernel, ITestDoubleBuilder<T> builder) where T : class
        {
            kernel.Bind(builder.Build());
        }

        /// <summary>
        /// Binds the specified factory into the underlying IoC container.
        /// </summary>
        /// <typeparam name="T">The type of interface to add to the underlying IoC container.</typeparam>
        /// <param name="kernel">The kernel.</param>
        /// <param name="factory">The factory.</param>
        /// <returns>An object that support the <typeparamref name="T"/> interface.</returns>
        public static T Bind<T>(this IFixtureKernel kernel, Func<IFixtureKernel, T> factory) where T : class
        {
            var result = factory(kernel);
            kernel.Bind(result);
            return result;
        }
    }
}