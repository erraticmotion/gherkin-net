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

    /// <summary>
    /// Contains extension methods for the <see cref="IFixtureKernel"/> interface
    /// that registers types of <see cref="IFixtureBindings"/> 
    /// into the underlying IoC container.
    /// </summary>
    public static class FixtureKernelExtensions
    {
        /// <summary>
        /// Loads the specified bindings into the underlying IoC container.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        /// <param name="bindings">The bindings.</param>
        public static void Load(this IFixtureKernel kernel, IFixtureBindings bindings)
        {
            bindings.Load(kernel);
        }

        /// <summary>
        /// Loads the bindings into the underlying IoC container.
        /// </summary>
        /// <typeparam name="TBindings">The bindings.</typeparam>
        /// <param name="kernel">The kernel.</param>
        public static void Load<TBindings>(this IFixtureKernel kernel) where TBindings : IFixtureBindings, new() 
        {
            Load(kernel, new TBindings());
        }

        /// <summary>
        /// Loads the bindings created by the factory into the underlying IoC container.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        /// <param name="factory">The factory.</param>
        public static void Load(this IFixtureKernel kernel, Func<IFixtureKernel, IFixtureBindings> factory)
        {
            Load(kernel, factory(kernel));
        }
    }
}