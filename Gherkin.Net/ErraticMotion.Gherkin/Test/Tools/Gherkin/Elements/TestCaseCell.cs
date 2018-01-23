// <copyright file="TestCaseCell.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin.Elements
{
    internal class TestCaseCell : ITestCaseCell
    {
        public TestCaseCell(object value)
        {
            this.Value = value is string ? value.ToString().Trim() : value;
        }

        public object Value { get; }

        public IGherkinElements<string> Gherkin
        {
            get
            {
                var result = new GherkinCollectionString();
                result.AppendLine(this.ToString());
                return result;
            }
        }

        public override string ToString()
        {
            return this.Value.ToString().Trim();
        }
    }
}