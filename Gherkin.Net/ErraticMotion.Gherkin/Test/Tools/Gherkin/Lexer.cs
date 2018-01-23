// ---------------------------------------------------------------------------
// (C) 2016 Parkeon Limited.
// 
//  No part of this source code may be reproduced, digitised, stored in a 
//  retrieval system, communicated to the public or caused to be seen or heard 
//  in public, made publicly available or publicly performed, offered for sale 
//  or hire or exhibited by way of trade in public or distributed by way of trade 
//  in any form or by any means, electronic, mechanical or otherwise without the 
//  written permission of Parkeon Limited.
// 
// ---------------------------------------------------------------------------

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