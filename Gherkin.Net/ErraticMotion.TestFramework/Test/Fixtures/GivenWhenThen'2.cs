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
    using ErraticMotion.Test.Fixtures.Containers;
    using NUnit.Framework;

    /// <include file='xml_include.xml' path='docs/doc[@name="ClassSummary"]/*' />
    /// <include file='xml_include.xml' path='docs/doc[@name="ClassSut"]/*' />
    /// <include file='xml_include.xml' path='docs/doc[@name="ClassKernel"]/*' />
    [TestFixture]
    public abstract class GivenWhenThen<TSut, TFixtureKernel> : GivenWhenThen<TSut>
        where TSut : class 
        where TFixtureKernel : IFixtureKernel, new()
    {  
        /// <summary>
        /// Initializes a new instance of the <see cref="GivenWhenThen{TSut, TFixtureKernel}"/> class.
        /// </summary>
        protected GivenWhenThen()
            : base(new TFixtureKernel())
        {
        }
    }
}