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

namespace ErraticMotion.Test.Tools
{
    /// <summary>
    /// Represents a Gherkin keyword with it's corresponding localised string version.
    /// </summary>
    /// <typeparam name="T">The type of syntax.</typeparam>
    public interface ILanguageSyntax<out T>
    {
        /// <summary>
        /// Gets the Gherkin keyword.
        /// </summary>
        T Syntax { get; }

        /// <summary>
        /// Gets the localised string value that matches the keyword.
        /// </summary>
        string Localised { get; }
    }
}