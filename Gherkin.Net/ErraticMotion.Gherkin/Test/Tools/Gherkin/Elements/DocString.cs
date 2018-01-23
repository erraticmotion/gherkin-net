// <copyright file="DocString.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin.Elements
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    internal class DocString : IGherkinDocString
    {
        private readonly List<string> testCase;
        private readonly int whiteSpacePadding;

        public DocString(IEnumerable<string> testCase, int whiteSpacePadding)
        {
            this.testCase = new List<string>(testCase);
            this.whiteSpacePadding = whiteSpacePadding;
        }

        public IGherkinElements<string> Gherkin
        {
            get
            {
                const string Format = "   [{0}]";
                var result = new GherkinCollectionString();
                result.AppendLine(Format, GherkinSyntax.DocString);
                foreach (var line in this.testCase)
                {
                    result.AppendLine(line);
                }

                result.AppendLine(Format, GherkinSyntax.DocString);
                return result;
            }
        }

        public string this[int index] => this.ElementAt(index);

        public IEnumerator<string> GetEnumerator()
        {
            return this.testCase.Select(t => t.Remove(0, this.whiteSpacePadding)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}