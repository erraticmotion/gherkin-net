// <copyright file="IGherkinBlock.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents a Gherkin block element that contains a collection of steps and comments.
    /// </summary>
    public interface IGherkinBlock : IGherkinKeyword, IGherkin
    {
        /// <summary>
        /// Gets the Gherkin steps for this scenario.
        /// </summary>
        IGherkinBlockSteps Steps { get; }

        /// <summary>
        /// Gets a collection of Gherkin Comments belonging to this feature.
        /// </summary>
        IList<IGherkinComment> Comments { get; }
    }
}