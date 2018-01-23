// <copyright file="TestCaseBuilder.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin.Builders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Elements;

    internal class TestCaseBuilder : ITestCaseBuilder<TestCases>
    {
        private readonly List<TestCaseRow> testCases = new List<TestCaseRow>();

        public TestCases Build()
        {
            return this.testCases.Count == 0 
                ? null 
                : new TestCases(this.testCases[0], this.testCases.Skip(1).ToArray());
        }

        public void AddTestCase(object[] cells)
        {
            var row = new TestCaseRow(cells.Select(c => new TestCaseCell(c)));

            if (this.testCases.Count > 0 && this.testCases[0].Count() != row.Count())
            {
                throw new ArgumentOutOfRangeException("cells",
                    "Number of cells in the row does not match the number of cells in the header.");
            }

            this.testCases.Add(row);
        }
    }
}