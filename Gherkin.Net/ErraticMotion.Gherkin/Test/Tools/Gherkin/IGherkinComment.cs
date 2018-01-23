// <copyright file="IGherkinComment.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin
{
    /// <summary>
    /// Represents a Gherkin comment, any text within a feature file that begins with the character '#'.
    /// </summary>
    public interface IGherkinComment
    {
        /// <summary>
        /// Gets the complete comment text.
        /// </summary>
        string Text { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is a key value pair.
        /// </summary>
        bool IsKeyValue { get; }

        /// <summary>
        /// Gets the first part of the <see cref="Text"/> value if the comment has been delimitated by the ':' character;
        /// otherwise return <see cref="string.Empty"/>.
        /// </summary>
        string Key { get; }

        /// <summary>
        /// Gets the second part of the <see cref="Text"/> value if the comment has been delimitated by the ':' character;
        /// otherwise return <see cref="string.Empty"/>.
        /// </summary>
        string Value { get; }

        /// <summary>
        /// Gets the comment key.
        /// </summary>
        CommentKey CommentKey { get; }
    }
}