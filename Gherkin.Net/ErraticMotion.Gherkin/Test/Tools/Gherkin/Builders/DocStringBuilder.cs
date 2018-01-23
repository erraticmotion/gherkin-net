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

namespace ErraticMotion.Test.Tools.Gherkin.Builders
{
    using System.Collections.Generic;

    using ErraticMotion.Test.Tools.Gherkin.Elements;

    public class DocStringBuilder : IBuilder<DocString>
    {
        private readonly List<string> item = new List<string>();
        private int whiteSpacePadding;

        public void Add(string line)
        {
            if (line.IsDocString()) 
            {
                // count of white space before first "
                this.whiteSpacePadding = line.Split('"')[0].Length;
            }
            else
            {
                this.item.Add(line);
            }
        }

        public DocString Build()
        {
            return new DocString(this.item, this.whiteSpacePadding);
        }
    }
}