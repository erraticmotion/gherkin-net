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

    using Ninject;
    using Ninject.Modules;

    /// <summary>
    /// Represents a Ninject fixture kernel object that supports the <see cref="IFixtureKernel"/> interface.
    /// </summary>
    public class NinjectFixtureKernel : IFixtureKernel
    {
        private readonly StandardKernel kernel;
        private bool disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectFixtureKernel"/> class.
        /// </summary>
        public NinjectFixtureKernel()
        {
            this.kernel = new StandardKernel();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectFixtureKernel"/> class.
        /// </summary>
        /// <param name="module">The module.</param>
        protected NinjectFixtureKernel(INinjectModule module)
        {
            this.kernel = new StandardKernel(new[] { module });
        }

        /// <summary>
        /// Gets an instance of the specified service.
        /// </summary>
        /// <typeparam name="T">The service to resolve.</typeparam>
        /// <returns>
        /// An instance of the service.
        /// </returns>
        public virtual T Get<T>() where T : class
        {
            return this.kernel.Get<T>();
        }

        /// <summary>
        /// Binds the specified object.
        /// </summary>
        /// <typeparam name="T">The type of the implementation.</typeparam>
        /// <param name="obj">The object.</param>
        public virtual void Bind<T>(T obj) where T : class
        {
            this.Clear<T>();
            this.kernel.Bind<T>().ToMethod(ctx => obj);
        }

        /// <summary>
        /// Binds the singleton.
        /// </summary>
        /// <typeparam name="T">The type of the implementation.</typeparam>
        /// <param name="obj">The object.</param>
        public virtual void BindSingleton<T>(T obj) where T : class
        {
            this.Clear<T>();
            this.kernel.Bind<T>().ToMethod(ctx => obj).InSingletonScope();
        }

        /// <summary>
        /// Binds this instance.
        /// </summary>
        /// <typeparam name="T">The type of the interface.</typeparam>
        /// <typeparam name="TImpl">The type of the implementation.</typeparam>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "IoC design")]
        public virtual void Bind<T, TImpl>()
            where T : class
            where TImpl : class, T
        {
            this.Clear<T>();
            this.kernel.Bind<T>().To<TImpl>();
        }

        /// <summary>
        /// Binds the singleton.
        /// </summary>
        /// <typeparam name="T">The type of the interface.</typeparam>
        /// <typeparam name="TImpl">The type of the implementation.</typeparam>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "IoC design")]
        public virtual void BindSingleton<T, TImpl>()
            where T : class
            where TImpl : class, T
        {
            this.Clear<T>();
            this.kernel.Bind<T>().To<TImpl>().InSingletonScope();
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="NinjectFixtureKernel"/> class.
        /// </summary>
        ~NinjectFixtureKernel() 
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and 
        /// unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.kernel.Dispose();
                }

                this.disposed = true;
            }
        }

        private void Clear<T>()
        {
            this.kernel.Unbind<T>();
        }
    }
}