// <copyright file="IGherkinVocabulary.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a culture specific Gherkin vocabulary.
    /// </summary>
    public interface IGherkinVocabulary : IFormattable
    {
        /// <summary>
        /// Gets the code.
        /// </summary>
        string Code { get; }

        /// <summary>
        /// Gets the vocabulary for the supported culture.
        /// </summary>
        IEnumerable<IGherkinSyntax> Vocabulary { get; }
    }
}