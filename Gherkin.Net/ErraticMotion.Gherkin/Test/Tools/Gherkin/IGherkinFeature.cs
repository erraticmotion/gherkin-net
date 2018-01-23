// <copyright file="IGherkinFeature.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Represents the AST root object returned from the Gherkin Lexer.
    /// </summary>
    public interface IGherkinFeature : IGherkinKeyword, IGherkin
    {
        /// <summary>
        /// Gets the language.
        /// </summary>
        string Language { get; }

        /// <summary>
        /// Gets the namespace.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Namespace", Justification = "Gherkin keyword")]
        string Namespace { get; }

        /// <summary>
        /// Gets the source file.
        /// </summary>
        string SourceFile { get; }

        /// <summary>
        /// Gets the Gherkin Background.
        /// </summary>
        IGherkinBlock Background { get; }

        /// <summary>
        /// Gets the collection of Gherkin Scenarios belonging to this feature.
        /// </summary>
        IGherkinElements<IGherkinScenario> Scenarios { get; }

        /// <summary>
        /// Gets the collection of Gherkin Comments belonging to this feature.
        /// </summary>
        IGherkinElements<IGherkinComment> Comments { get; }

        /// <summary>
        /// Gets the collection of Gherkin tags belonging to this feature.
        /// </summary>
        IGherkinElements<IGherkinTag> Tags { get; }
    }
}