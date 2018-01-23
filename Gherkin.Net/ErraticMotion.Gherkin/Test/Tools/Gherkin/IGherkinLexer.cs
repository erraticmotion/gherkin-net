// <copyright file="IGherkinLexer.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin
{
    /// <summary>
    /// Responsible for creating a Gherkin feature AST.
    /// </summary>
    public interface IGherkinLexer
    {
        /// <summary>
        /// Parses the specified feature file reader.
        /// </summary>
        /// <returns>An object that supports the <see cref="IGherkinFeature"/> interface.</returns>
        IGherkinFeature Parse();
    }
}