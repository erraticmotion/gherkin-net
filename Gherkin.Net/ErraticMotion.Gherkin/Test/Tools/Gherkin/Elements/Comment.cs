// <copyright file="Comment.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin.Elements
{
    using System;

    internal class Comment : IGherkinComment
    {
        public Comment(string line)
        {
            this.Text = line.TrimStart().Replace('#', ' ').Trim();
            if (this.Text.Contains(":"))
            {
                this.IsKeyValue = true;
                var split = this.Text.Split(':');
                this.Key = split[0].Trim();
                this.Value = split[1].Trim();

                if (0 == string.Compare(this.Key, "language", StringComparison.Ordinal))
                {
                    this.CommentKey = CommentKey.Language;
                    return;
                }

                if (0 == string.Compare(this.Key, "namespace", StringComparison.Ordinal))
                {
                    this.CommentKey = CommentKey.Namespace;
                    return;
                }

                if (0 == string.Compare(this.Key, "source", StringComparison.Ordinal))
                {
                    this.CommentKey = CommentKey.Source;
                    return;
                }

                this.CommentKey = CommentKey.Undefined;
            }
            else
            {
                this.IsKeyValue = false;
                this.Key = string.Empty;
                this.Value = string.Empty;
                this.CommentKey = CommentKey.Undefined;
            }
        }

        public string Text { get; private set; }

        public bool IsKeyValue { get; private set; }

        public string Key { get; private set; }

        public string Value { get; private set; }

        public CommentKey CommentKey { get; private set; }

        public override string ToString()
        {
            return this.Text;
        }
    }
}