// <copyright file="Feature.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin.Elements
{
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Represents the AST root object returned from the Gherkin Lexer.
    /// </summary>
    internal class Feature : GherkinKeywordBase, IGherkinFeature
    {
        public Feature(
            ILanguageInfo info,
            string name,
            string description,
            string ns,
            IGherkinBlock background,
            IEnumerable<IGherkinScenario> scenarios,
            IList<IGherkinComment> comments,
            IList<IGherkinTag> tags,
            string sourceFile)
            : base(info, GherkinKeyword.Feature, name, description)
        {
            this.Background = background;
            this.Scenarios = new GherkinCollection<IGherkinScenario>(scenarios);
            this.Comments = new GherkinCollection<IGherkinComment>(comments);
            this.Tags = new GherkinCollection<IGherkinTag>(tags);
            this.SourceFile = sourceFile;
            this.Language = info.Code;
            this.Namespace = ns;
        }

        public string Language { get; }

        public string Namespace { get; }

        public string SourceFile { get; }

        public IGherkinBlock Background { get; }

        public IGherkinElements<IGherkinScenario> Scenarios { get; }

        public IGherkinElements<IGherkinComment> Comments { get; }

        public IGherkinElements<IGherkinTag> Tags { get; }

        public IGherkinElements<string> Gherkin
        {
            get
            {
                var result = new GherkinCollectionString();
                foreach (var comment in this.Comments)
                {
                    result.AppendLine("#{0}", comment);
                }

                foreach (var tag in this.Tags)
                {
                    result.AppendLine("@{0}", tag);
                }

                result.AppendLine("{0}: {1}", this.Keyword.Format(), this.Name);
                result.AppendLine();
                if (!string.IsNullOrEmpty(this.Description))
                {
                    result.AppendLine("{0}", this.Description);
                    result.AppendLine();
                }

                if (this.Background != null)
                {
                    result.Append(this.Background);
                    result.AppendLine();
                }

                foreach (var scenario in this.Scenarios)
                {
                    result.Append(scenario);
                    result.AppendLine();
                }

                return result;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var element in this.Gherkin)
            {
                builder.AppendLine(element);
            }

            return builder.ToString();
        }
    }
}