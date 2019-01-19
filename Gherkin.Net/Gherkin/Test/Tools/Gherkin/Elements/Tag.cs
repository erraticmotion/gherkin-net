// <copyright file="Tag.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin.Elements
{
    internal class Tag : IGherkinTag
    {
        public Tag(string line)
        {
            this.Text = line.TrimStart().Replace('@', ' ').Trim();
        }

        public string Text { get; }

        public override string ToString()
        {
            return this.Text;
        }
    }
}