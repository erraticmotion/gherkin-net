// <copyright file="IGherkinDocString.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Represents a Gherkin DocString object.
    /// </summary>
    /// <remarks>
    /// Indentation of the opening """ is unimportant, although common practice is two
    /// spaces in from the enclosing step. The indentation inside the triple quotes,
    /// however, is significant. Each line of the Doc String will be de-indented according
    /// to the opening """. Indentation beyond the column of the opening """ will
    /// therefore be preserved.
    /// </remarks>
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "Gherkin keyword")]
    public interface IGherkinDocString : IEnumerable<string>, IGherkin
    {
        /// <summary>
        /// Gets the <see cref="string"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="string"/> at the specified index that relates to the test data value.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns>A string representation of the test data at the specified index.</returns>
        string this[int index] { get; }
    }
}