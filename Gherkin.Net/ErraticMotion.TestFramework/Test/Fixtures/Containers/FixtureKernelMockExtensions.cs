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

    using Moq;

    /// <summary>
    /// Contains extension methods for the <see cref="IFixtureKernel"/> interface
    /// that creates Mock objects and registers them into the underlying IoC container.
    /// </summary>
    public static class FixtureKernelMockExtensions
    {
        /// <summary>
        /// Creates and adds a <typeparamref name="T" /> object and returns a <see cref="Mock" />.
        /// </summary>
        /// <typeparam name="T">The type of test double.</typeparam>
        /// <param name="kernel">The IoC kernel object.</param>
        /// <returns>
        /// A <see cref="Mock{T}" /> created from the <typeparamref name="T" />.
        /// </returns>
        /// <remarks>
        /// Test double - Dummy.
        /// </remarks>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "Well understood IoC binding syntax")]
        public static Mock<T> BindMock<T>(this IFixtureKernel kernel) where T : class
        {
            var result = new Mock<T>();
            kernel.Bind(result.Object);
            return result;
        }

        /// <summary>
        /// Adds the specified behaviour.
        /// </summary>
        /// <typeparam name="T">The type of test double.</typeparam>
        /// <param name="kernel">The IoC kernel object.</param>
        /// <param name="behaviour">The behaviour that the mock object exhibits.</param>
        /// <returns>
        /// A <see cref="Mock{T}" /> created from the <typeparamref name="T" />.
        /// </returns>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "Well understood IoC binding syntax")]
        public static Mock<T> BindMock<T>(this IFixtureKernel kernel, Action<Mock<T>> behaviour) where T : class
        {
            var result = kernel.BindMock<T>();
            behaviour(result);
            return result;
        }
    }
}