// <copyright file="DocStringBuilder.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin.Builders
{
    using System.Collections.Generic;

    using Elements;

    internal class DocStringBuilder : IBuilder<DocString>
    {
        private readonly List<string> item = new List<string>();
        private int whiteSpacePadding;

        public void Add(string line)
        {
            if (line.IsDocString())
            {
                // count of white space before first "
                this.whiteSpacePadding = line.Split('"')[0].Length;
            }
            else
            {
                this.item.Add(line);
            }
        }

        public DocString Build()
        {
            return new DocString(this.item, this.whiteSpacePadding);
        }
    }
}