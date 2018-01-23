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

    /// <summary>
    /// Represents the interface that IoC containers must implement 
    /// so that it can be used within the Test Automation Framework.
    /// </summary>
    public interface IFixtureKernel : IDisposable
    {
        /// <summary>
        /// Gets an instance of the specified service.
        /// </summary>
        /// <typeparam name="T">The service to resolve.</typeparam>
        /// <returns>An instance of the service.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Get", Justification = "Well understood IoC binding syntax")]
        T Get<T>() where T : class;

        /// <summary>
        /// Binds the specified object.
        /// </summary>
        /// <typeparam name="T">The type of the implementation.</typeparam>
        /// <param name="obj">The object.</param>
        void Bind<T>(T obj) where T : class;

        /// <summary>
        /// Binds the singleton.
        /// </summary>
        /// <typeparam name="T">The type of the implementation.</typeparam>
        /// <param name="obj">The object.</param>
        void BindSingleton<T>(T obj) where T : class;

        /// <summary>
        /// Binds this instance.
        /// </summary>
        /// <typeparam name="T">The type of the interface.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "Well understood IoC binding syntax")]
        void Bind<T, TImplementation>()
            where T : class
            where TImplementation : class, T;

        /// <summary>
        /// Binds the singleton.
        /// </summary>
        /// <typeparam name="T">The type of the interface.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "Well understood IoC binding syntax")]
        void BindSingleton<T, TImplementation>()
            where T : class
            where TImplementation : class, T;
    }
}