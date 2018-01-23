// <copyright file="TestCases.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin.Elements
{
    using System.Collections.Generic;

    internal class TestCases : ITestCases
    {
        public TestCases(ITestCaseRow header, IEnumerable<ITestCaseRow> body)
        {
            this.Parameters = header;
            this.Values = body;
        }

        public ITestCaseRow Parameters { get; }

        public IEnumerable<ITestCaseRow> Values { get; }

        public IGherkinElements<string> Gherkin
        {
            get
            {
                var result = new GherkinCollectionString();
                result.AppendLine("          {0}", this.Parameters);
                foreach (var value in this.Values)
                {
                    result.AppendLine("          {0}", value);
                }

                return result;
            }
        }
    }
}