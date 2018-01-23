// <copyright file="LexerFeature.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin
{
    using System;
    using System.IO;

    internal static class LexerFeature
    {
        public static IGherkinFeature Create(string s)
        {
            var result = Lexer.For(@"c:\\some.feature", new StringReader(s)).Parse();
            Should.NotThrow(() => Console.WriteLine(result));
            return result;
        }
    }
}