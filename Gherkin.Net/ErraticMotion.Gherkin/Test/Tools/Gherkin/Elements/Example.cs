// <copyright file="Example.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin.Elements
{
    internal class Example : GherkinKeywordBase, IGherkinExample
    {
        public Example(ILanguageInfo info, string name, string description, ITestCases testCases)
            : base(info, GherkinKeyword.Examples, name, description)
        {
            this.TestCases = testCases;
        }

        public ITestCases TestCases { get; private set; }

        public IGherkinElements<string> Gherkin
        {
            get
            {
                var result = new GherkinCollectionString();
                result.AppendLine("    {0}: {1}", this.Keyword.Format(), this.Name);
                if (!string.IsNullOrEmpty(this.Description))
                {
                    result.AppendLine("    {0}", this.Description);
                }

                result.Append(this.TestCases);
                return result;
            }
        }
    }
}