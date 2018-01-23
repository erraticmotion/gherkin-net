// <copyright file="TestCaseRow.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin.Elements
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class TestCaseRow : ITestCaseRow
    {
        private readonly List<ITestCaseCell> row;

        public TestCaseRow(IEnumerable<ITestCaseCell> cells)
        {
            this.row = new List<ITestCaseCell>(cells);
        }

        public IGherkinElements<string> Gherkin
        {
            get
            {
                var result = new GherkinCollectionString();
                result.AppendLine(this.ToString());
                return result;
            }
        }

        public ITestCaseCell this[int index] => this.ElementAt(index);

        public IEnumerator<ITestCaseCell> GetEnumerator()
        {
            return this.row.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append('(');
            foreach (var cell in this)
            {
                builder.AppendFormat("{0},", cell);
            }

            return builder.ToString().TrimEnd(',') + ")";
        }
    }
}