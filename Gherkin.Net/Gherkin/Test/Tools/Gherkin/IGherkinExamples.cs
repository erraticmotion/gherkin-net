// <copyright file="IGherkinExamples.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Represents a collection of Gherkin Examples.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "Gherkin keyword")]
    public interface IGherkinExamples : IEnumerable<IGherkinExample>
    {
        /// <summary>
        /// Gets or sets the <see cref="IGherkinExample"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="IGherkinExample"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns>An object that supports the <see cref="IGherkinExample"/> interface.</returns>
        IGherkinExample this[int index] { get; }
    }
}