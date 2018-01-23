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
    /// <summary>
    /// Syntactic sugar for Give-When-Then test fixtures that use the NUnit Framework.
    /// </summary>
    public sealed class WhereAttribute : NUnit.Framework.TestCaseAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhereAttribute"/> class.
        /// </summary>
        /// <param name="arguments">A collection of test case arguments.</param>
        public WhereAttribute(params object[] arguments) 
            : base(arguments)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhereAttribute"/> class.
        /// </summary>
        /// <param name="arg">A test case argument.</param>
        public WhereAttribute(object arg) 
            : base(arg)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhereAttribute"/> class.
        /// </summary>
        /// <param name="arg1">A test case argument.</param>
        /// <param name="arg2">A test case argument.</param>
        public WhereAttribute(object arg1, object arg2) 
            : base(arg1, arg2)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhereAttribute"/> class.
        /// </summary>
        /// <param name="arg1">A test case argument.</param>
        /// <param name="arg2">A test case argument.</param>
        /// <param name="arg3">A test case argument.</param>
        public WhereAttribute(object arg1, object arg2, object arg3)
            : base(arg1, arg2, arg3)
        {
        }
    }
}