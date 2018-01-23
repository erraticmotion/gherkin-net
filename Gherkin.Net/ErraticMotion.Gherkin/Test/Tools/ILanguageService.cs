// <copyright file="ILanguageService.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools
{
    /// <summary>
    /// Represents the language service.
    /// </summary>
    public interface ILanguageService
    {
        /// <summary>
        /// Gets the language.
        /// </summary>
        /// <param name="fileContent">Content of the file.</param>
        /// <returns>An object that supports the <see cref="ILanguageInfo"/> abstraction.</returns>
        ILanguageInfo TryParse(string fileContent);
    }
}