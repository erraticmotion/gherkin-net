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
    using System.Diagnostics.CodeAnalysis;
    using ErraticMotion.Test.Fixtures.Containers;
    using NUnit.Framework;

    /// <include file='xml_include.xml' path='docs/doc[@name="ClassSummary"]/*' />
    [TestFixture]
    public abstract class GivenWhenThen : GivenWhenThenBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GivenWhenThen"/> class.
        /// </summary>
        protected GivenWhenThen()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GivenWhenThen"/> class.
        /// </summary>
        /// <param name="fixtureIoC">The fixture io c.</param>
        protected GivenWhenThen(IFixtureKernel fixtureIoC)
            : base(fixtureIoC)
        {
        }

        /// <include file='xml_include.xml' path='docs/doc[@name="SetupSummary"]/*' />
        [SetUp]
        public override void TestSetup()
        {
            base.TestSetup();
            this.Given();
            this.When();
        }

        /// <include file='xml_include.xml' path='docs/doc[@name="CleanupSummary"]/*' />
        [TearDown]
        public void TestCleanup()
        {
            this.Cleanup();
        }

        /// <summary>
        /// Extension point for sub-classes to arrange all necessary preconditions and inputs. 
        /// </summary>
        protected virtual void Given()
        {
        }

        /// <summary>
        /// Extension point for sub-classes to act on the object or method under test. 
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords",
            MessageId = "When", Justification = "Given When Then")]
        protected virtual void When()
        {
        }

        /// <summary>
        /// Extension point for sub-classes to cleans up the environment after the test is verified.
        /// </summary>
        protected virtual void Cleanup()
        {
        }
    }
} 
