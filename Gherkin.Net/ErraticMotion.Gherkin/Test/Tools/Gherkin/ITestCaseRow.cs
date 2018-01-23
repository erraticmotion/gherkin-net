// <copyright file="ITestCaseRow.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Represents a test case row within a tabular data structure.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "It is a test case row, not a collection.")]
    public interface ITestCaseRow : IEnumerable<ITestCaseCell>, IGherkin
    {
        /// <summary>
        /// Gets the <see cref="ITestCaseCell"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="ITestCaseCell"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns>The test case cell value.</returns>
        ITestCaseCell this[int index] { get; }
    }
}