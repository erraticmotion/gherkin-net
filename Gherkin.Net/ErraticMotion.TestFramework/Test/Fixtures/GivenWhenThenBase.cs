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

namespace ErraticMotion.Test.Fixtures
{
    using System;
    using ErraticMotion.Test.Fixtures.Containers;
    using NUnit.Framework;

    /// <summary>
    /// Acts as a base class for Given-When-Then test fixture types.
    /// </summary>
    [TestFixture]
    public abstract class GivenWhenThenBase : IDisposable
    {
        private readonly IFixtureKernel kernel;
        private bool disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="GivenWhenThen"/> class.
        /// </summary>
        protected GivenWhenThenBase()
            : this(new NinjectFixtureKernel())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GivenWhenThen" /> class.
        /// </summary>
        /// <param name="kernel">The fixture IoC kernel container.</param>
        protected GivenWhenThenBase(IFixtureKernel kernel)
        {
            this.kernel = kernel;
        }

        /// <include file='xml_include.xml' path='docs/doc[@name="SetupSummary"]/*' />
        [SetUp]
        public virtual void TestSetup()
        {
            this.Bind(this.Kernel);
        }

        /// <summary>
        /// Gets the kernel.
        /// </summary>
        protected IFixtureKernel Kernel { get { return this.kernel; } }

        /// <summary>
        /// Extension point for sub-classes to bind to the IoC kernel.
        /// </summary>
        /// <param name="container">The fixture kernel IoC container.</param>
        protected virtual void Bind(IFixtureKernel container)
        {
        }

        /// <include file='xml_include.xml' path='docs/doc[@name="GetSummary"]/*' />
        protected T Get<T>() where T : class
        {
            return this.kernel.Get<T>();
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="GivenWhenThenBase"/> class.
        /// </summary>
        ~GivenWhenThenBase() 
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
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged 
        /// resources; <c>false</c> to release only unmanaged resources.</param>
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
    }
}