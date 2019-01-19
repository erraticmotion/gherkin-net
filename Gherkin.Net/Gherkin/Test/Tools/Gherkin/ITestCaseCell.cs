// <copyright file="ITestCaseCell.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin
{
    /// <summary>
    /// Represents a value within a test case example.
    /// </summary>
    public interface ITestCaseCell : IGherkin
    {
        /// <summary>
        /// Gets the value within this data cell.
        /// </summary>
        object Value { get; }
    }
}