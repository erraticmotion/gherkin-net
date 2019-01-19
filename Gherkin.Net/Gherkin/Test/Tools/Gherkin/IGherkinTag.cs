// <copyright file="IGherkinTag.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin
{
    /// <summary>
    /// Represents a Gherkin comment, any text within a feature file that begins with the character '@'.
    /// </summary>
    public interface IGherkinTag
    {
        /// <summary>
        /// Gets the comment text.
        /// </summary>
        string Text { get; }
    }
}