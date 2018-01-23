// <copyright file="IVocabularyService.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents the vocabulary service.
    /// </summary>
    public interface IVocabularyService : IEnumerable<IGherkinVocabulary>
    {
        /// <summary>
        /// Returns the Gherkin vocabulary for the specified code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>An object that supports the <see cref="IGherkinVocabulary"/> abstraction.</returns>
        IGherkinVocabulary Find(string code);
    }
}