// <copyright file="IGherkin.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin
{
    /// <summary>
    /// Represents the operation to get Gherkin syntax.
    /// </summary>
    public interface IGherkin
    {
        /// <summary>
        /// Gets the Gherkin syntax.
        /// </summary>
        IGherkinElements<string> Gherkin { get; }
    }
}