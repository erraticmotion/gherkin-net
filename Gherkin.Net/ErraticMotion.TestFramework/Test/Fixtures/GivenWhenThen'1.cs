// ---------------------------------------------------------------------------
// (C) 2015 Parkeon Limited.
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
    using System.Diagnostics.CodeAnalysis;

    using ErraticMotion.Test.Fixtures.Containers;
    using NUnit.Framework;

    /// <include file='xml_include.xml' path='docs/doc[@name="ClassSummary"]/*' />
    /// <include file='xml_include.xml' path='docs/doc[@name="ClassSut"]/*' />
    [TestFixture]
    public abstract class GivenWhenThen<TSut> : GivenWhenThenBase
        where TSut : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GivenWhenThen{TSut}"/> class.
        /// </summary>
        protected GivenWhenThen()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GivenWhenThen{TSut}" /> class.
        /// </summary>
        /// <param name="fixtureIoC">The fixture IoC container.</param>
        protected GivenWhenThen(IFixtureKernel fixtureIoC)
            : base(fixtureIoC)
        {
        }

        /// <summary>
        /// The Software under Test.
        /// </summary>
        protected TSut Sut { get; private set; }

        /// <include file='xml_include.xml' path='docs/doc[@name="SetupSummary"]/*' />
        [SetUp]
        public override void TestSetup()
        {
            base.TestSetup();
            this.Sut = this.Given(this.Kernel);
            this.When(this.Sut);
        }

        /// <include file='xml_include.xml' path='docs/doc[@name="CleanupSummary"]/*' />
        /// <include file='xml_include.xml' path='docs/doc[@name="CleanupRemarks"]/*' />
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Test fixture code")]
        protected virtual void Cleanup(TSut sut)
        {
            try
            {
                if (this.Sut != null)
                {
                    var disposable = this.Sut as IDisposable;
                    if (disposable != null)
                    {
                        disposable.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                if (this.Kernel != null)
                {
                    this.Kernel.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Arrange all necessary preconditions and inputs. 
        /// </summary>
        /// <param name="kernel">The <see cref="IFixtureKernel"/> Test Double IoC container.</param>
        /// <returns>The System/Software Under Test.</returns>
        protected virtual TSut Given(IFixtureKernel kernel)
        {
            return this.Get<TSut>();
        }

        /// <summary>
        /// Act on the software/system under test. 
        /// </summary>
        /// <param name="sut">The System/Software under Test.</param>
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", 
            MessageId = "When", Justification = "Given When Then")]
        protected virtual void When(TSut sut)
        {
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public new void Dispose()
        {
            this.Cleanup(this.Sut);
            base.Dispose();
        }
    }
}