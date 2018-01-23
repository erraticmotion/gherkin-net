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