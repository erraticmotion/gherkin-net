// <copyright file="ExampleBuilder.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin.Builders
{
    using Elements;

    internal class ExampleBuilder : GherkinBuilder<Example>, ITestCaseBuilder<Example>
    {
        private readonly string title;
        private readonly TestCaseBuilder testCaseBuilder = new TestCaseBuilder();

        public ExampleBuilder(ILanguageInfo info, string title)
            : base(info, GherkinKeyword.Examples)
        {
            this.title = title;
        }

        public void AddTestCase(object[] cells)
        {
            this.testCaseBuilder.AddTestCase(cells);
        }

        public override Example Build()
        {
            var exampleTable = this.testCaseBuilder.Build();
            return new Example(this.LanguageInfo, this.title, this.Description, exampleTable);
        }
    }
}