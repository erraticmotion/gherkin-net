// <copyright file="IGherkinElements.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Represents the collection of Gherkin elements within a feature.
    /// </summary>
    /// <typeparam name="TGherkinElement">The type of the gherkin element.</typeparam>
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "Gherkin keyword")]
    public interface IGherkinElements<out TGherkinElement> : IEnumerable<TGherkinElement>
        where TGherkinElement : class
    {
        /// <summary>
        /// Gets the <typeparamref name="TGherkinElement"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <typeparamref name="TGherkinElement"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns>An object that supports the <see typeparamref="TGherkinElement"/> interface.</returns>
        TGherkinElement this[int index] { get; }
    }
}