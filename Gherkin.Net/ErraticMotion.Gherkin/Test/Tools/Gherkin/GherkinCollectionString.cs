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
    using System.Collections.Generic;
    using System.Globalization;

    internal class GherkinCollectionString : GherkinCollection<string>
    {
        private const string NewLine = "\r\n";
        private readonly List<string> container = new List<string>();

        public GherkinCollectionString()
        {
            this.AddContainer(this.container);
        }

        public void Append(IGherkin item)
        {
            foreach (var element in item.Gherkin)
            {
                this.container.Add(element);
            }
        }

        public void AppendLine(string format, object arg0)
        {
            this.AppendLine(format, new[] { arg0 });
        }

        public void AppendLine(string format, object arg0, object arg1)
        {
            this.AppendLine(format, new[] { arg0, arg1 });
        }

        public void AppendLine(string format, object arg0, object arg1, object arg2)
        {
            this.AppendLine(format, new[] { arg0, arg1, arg2 });
        }

        public void AppendLine(string format, params object[] args)
        {
            this.container.Add(string.Format(CultureInfo.CurrentCulture, format, args));
        }

        public void AppendLine()
        {
            this.container.Add(NewLine);
        }
    }
}