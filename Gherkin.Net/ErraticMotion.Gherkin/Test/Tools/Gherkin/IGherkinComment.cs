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
    /// <summary>
    /// Represents a Gherkin comment, any text within a feature file that begins with the character '#'.
    /// </summary>
    public interface IGherkinComment
    {
        /// <summary>
        /// Gets the complete comment text.
        /// </summary>
        string Text { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is a key value pair.
        /// </summary>
        bool IsKeyValue { get; }

        /// <summary>
        /// Gets the first part of the <see cref="Text"/> value if the comment has been delimitated by the ':' character;
        /// otherwise return <see cref="string.Empty"/>.
        /// </summary>
        string Key { get; }

        /// <summary>
        /// Gets the second part of the <see cref="Text"/> value if the comment has been delimitated by the ':' character;
        /// otherwise return <see cref="string.Empty"/>.
        /// </summary>
        string Value { get; }

        /// <summary>
        /// Gets the comment key.
        /// </summary>
        CommentKey CommentKey { get; }
    }
}