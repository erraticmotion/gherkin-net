// <copyright file="IGherkinExample.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin
{
    /// <summary>
    /// Represents a a Gherkin Example.
    /// </summary>
    public interface IGherkinExample : IGherkinKeyword, IGherkin
    {
        /// <summary>
        /// Gets the tabular test case data.
        /// </summary>
        ITestCases TestCases { get; }
    }
}