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

namespace ErraticMotion.Test.Tools.Gherkin.Elements
{
    using System;

    public class Comment : IGherkinComment
    {
        public Comment(string line)
        {
            this.Text = line.TrimStart().Replace('#', ' ').Trim();
            if (this.Text.Contains(":"))
            {
                this.IsKeyValue = true;
                var split = this.Text.Split(':');
                this.Key = split[0].Trim();
                this.Value = split[1].Trim();

                if (0 == string.Compare(this.Key, "language", StringComparison.Ordinal))
                {
                    this.CommentKey = CommentKey.Language;
                    return;
                }

                if (0 == string.Compare(this.Key, "namespace", StringComparison.Ordinal))
                {
                    this.CommentKey = CommentKey.Namespace;
                    return;
                }

                if (0 == string.Compare(this.Key, "source", StringComparison.Ordinal))
                {
                    this.CommentKey = CommentKey.Source;
                    return;
                }

                this.CommentKey = CommentKey.Undefined;
            }
            else
            {
                this.IsKeyValue = false;
                this.Key = string.Empty;
                this.Value = string.Empty;
                this.CommentKey = CommentKey.Undefined;
            }
        }

        public string Text { get; private set; }

        public bool IsKeyValue { get; private set; }

        public string Key { get; private set; }

        public string Value { get; private set; }

        public CommentKey CommentKey { get; private set; }

        public override string ToString()
        {
            return this.Text;
        }
    }
}