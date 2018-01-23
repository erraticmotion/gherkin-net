// <copyright file="GherkinExceptionType.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin
{
    /// <summary>
    /// Enumerates the possible failure types when generating a Gherkin file.
    /// </summary>
    public enum GherkinExceptionType
    {
        /// <summary>
        /// Means I haven't got round to working out why the Gherkin Lexer failed.
        /// </summary>
        NotMapped,

        /// <summary>
        /// There are no scenarios in the feature.
        /// </summary>
        NoScenariosInFeature,

        /// <summary>
        /// The Gherkin syntax was invalid.
        /// </summary>
        InvalidGherkin,

        /// <summary>
        /// The language specified is not supported.
        /// </summary>
        LanguageNotSupported,
    }
}