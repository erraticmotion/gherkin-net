// <copyright file="ITestCases.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents a Gherkin test case table.
    /// </summary>
    public interface ITestCases : IGherkin
    {
        /// <summary>
        /// Gets the test case header containing the column names used as parameters.
        /// </summary>
        ITestCaseRow Parameters { get; }

        /// <summary>
        /// Gets the collection of test case data items.
        /// </summary>
        IEnumerable<ITestCaseRow> Values { get; }
    }
}