// <copyright file="Lexer.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin
{
    using System.IO;

    /// <summary>
    /// Entry point into the namespace functionality.
    /// </summary>
    public static class Lexer
    {
        /// <summary>
        /// Returns a Lexer capable of creating an Abstract Syntax Tree from
        /// a Gherkin feature file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>
        /// An object that supports the <see cref="IGherkinLexer" /> interface.
        /// </returns>
        public static IGherkinLexer For(string fileName)
        {
            StringReader reader;
            using (var sr = new StreamReader(fileName))
            {
                reader = new StringReader(sr.ReadToEnd());
            }

            return new GherkinLexer(fileName, reader);
        }

        /// <summary>
        /// Returns a Lexer capable of creating an Abstract Syntax Tree from
        /// a Gherkin feature file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="featureFileReader">The feature file reader.</param>
        /// <returns>An object that supports the <see cref="IGherkinLexer"/> interface.</returns>
        public static IGherkinLexer For(string fileName, TextReader featureFileReader)
        {
            return new GherkinLexer(fileName, featureFileReader);
        }
    }
}