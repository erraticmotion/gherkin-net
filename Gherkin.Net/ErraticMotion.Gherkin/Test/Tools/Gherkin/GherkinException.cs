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

namespace ErraticMotion.Test.Tools.Gherkin
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Is raised when the Gherkin Lexer encounters an invalid feature file.
    /// </summary>
    [Serializable]
    public sealed class GherkinException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GherkinException" /> class.
        /// </summary>
        /// <param name="reason">The reason.</param>
        public GherkinException(GherkinExceptionType reason)
            : this(reason, "An exception was raised by the Gherkin Lexer.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GherkinException" /> class.
        /// </summary>
        /// <param name="reason">The reason.</param>
        /// <param name="message">The message that describes the error.</param>
        public GherkinException(GherkinExceptionType reason, string message)
            : base(message)
        {
            this.Reason = reason;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GherkinException" /> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="reason">The reason.</param>
        /// <param name="innerException">The exception that is the cause of the current exception,
        /// or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public GherkinException(string message, GherkinExceptionType reason, Exception innerException)
            : base(message, innerException)
        {
            this.Reason = reason;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GherkinException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that 
        /// holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> 
        /// that contains contextual information about the source or destination.</param>
        private GherkinException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Gets the reason for raising the exception.
        /// </summary>
        /// <value>
        /// The failure reason.
        /// </value>
        public GherkinExceptionType Reason { get; internal set; }
    }
}