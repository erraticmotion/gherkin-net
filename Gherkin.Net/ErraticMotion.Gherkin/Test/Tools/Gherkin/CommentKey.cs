// <copyright file="CommentKey.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin
{
    /// <summary>
    /// Enumerates the well known keywords used within Gherkin+.
    /// </summary>
    public enum CommentKey
    {
        /// <summary>
        /// Represents an undefined key being used within a comment.
        /// </summary>
        Undefined,

        /// <summary>
        /// Represents the language key.
        /// </summary>
        Language,

        /// <summary>
        /// Represents the namespace key.
        /// </summary>
        Namespace,

        /// <summary>
        /// Represents the source key.
        /// </summary>
        Source
    }
}