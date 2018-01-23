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
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using ErraticMotion.Test.Tools.Gherkin.Elements;

    /// <summary>
    /// Represents a base class for building types of objects that support Gherkin block keywords.
    /// </summary>
    /// <typeparam name="T">The type of object that supports the specified Gherkin keyword.</typeparam>
    public abstract class GherkinBuilder<T> : IBuilder<T> where T : class
    {
        private const string Lang = "language";
        private readonly StringBuilder description = new StringBuilder();
        private readonly List<IGherkinComment> comments = new List<IGherkinComment>();
        private readonly List<IGherkinTag> tags = new List<IGherkinTag>();

        /// <summary>
        /// Initializes a new instance of the <see cref="GherkinBuilder{T}" /> class.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <param name="keyword">The block keyword.</param>
        protected GherkinBuilder(ILanguageInfo info, GherkinKeyword keyword)
        {
            this.Keyword = info.Get(keyword);
            this.LanguageInfo = info;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GherkinBuilder{T}" /> class.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <param name="keyword">The keyword.</param>
        /// <param name="source">The source.</param>
        /// <param name="language">The language.</param>
        protected GherkinBuilder(ILanguageInfo info, GherkinKeyword keyword, string source, string language)
            : this(info, keyword)
        {
            this.comments.Add(new Comment(Lang + ": " + language));
            this.comments.Add(new Comment("source: " + source));
        }

        /// <summary>
        /// Gets the gherkin block keyword.
        /// </summary>
        public virtual ILanguageSyntax<GherkinKeyword> Keyword { get; private set; }

        /// <summary>
        /// Gets the Gherkin description.
        /// </summary>
        public virtual string Description { get { return this.description.ToString().Trim(); } }

        /// <summary>
        /// Gets the language.
        /// </summary>
        public virtual ILanguageInfo LanguageInfo { get; private set; }  

        /// <summary>
        /// Gets the Gherkin comments.
        /// </summary>
        public virtual IEnumerable<IGherkinComment> Comments
        {
            get
            {
                // The Gherkin spec states that 'language' as the first comment if it's been defined.
                var lang = this.comments.FirstOrDefault(x => x.CommentKey == CommentKey.Language);
                if (lang != null)
                {
                    yield return lang;
                    foreach (var comment in this.comments.Where(x => x.CommentKey != CommentKey.Language))
                    {
                        yield return comment;
                    }
                }
                else
                {
                    foreach (var comment in this.comments)
                    {
                        yield return comment;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the Gherkin tags.
        /// </summary>
        public virtual IEnumerable<IGherkinTag> Tags { get { return this.tags; } }

        /// <summary>
        /// Adds a line to this objects description.
        /// </summary>
        /// <param name="line">The line to add.</param>
        public virtual void AddDescription(string line)
        {
            this.description.AppendFormat("{0}{1}", line.Trim(), Environment.NewLine);
        }

        /// <summary>
        /// Adds the comment.
        /// </summary>
        /// <param name="line">The line.</param>
        public virtual void AddComment(string line)
        {
            var item = new Comment(line);
            if (item.IsKeyValue && item.Key == Lang)
            {
                var lang = this.comments.FirstOrDefault(x => x.Key == Lang);
                if (lang != null)
                {
                    this.comments.Remove(lang);
                }
            }

            this.comments.Add(item);
        }

        /// <summary>
        /// Adds the tag to this object.
        /// </summary>
        /// <param name="line">The line containing the tag to add.</param>
        public virtual void AddTag(string line)
        {
            this.tags.Add(new Tag(line));
        }

        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns>An object that supports the <typeparamref name="T"/>.</returns>
        public abstract T Build();
    }
}