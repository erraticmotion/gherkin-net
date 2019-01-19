// <copyright file="Background.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin.Elements
{
    using System.Collections.Generic;

    internal class Background : GherkinKeywordBase, IGherkinBlock
    {
        public Background(ILanguageInfo info, string name, string description, BlockSteps scenarioSteps, IList<IGherkinComment> comments)
            : base(info, GherkinKeyword.Background, name, description)
        {
            this.Steps = scenarioSteps ?? new BlockSteps();
            this.Comments = comments;
        }

        public IGherkinBlockSteps Steps { get; }

        public IList<IGherkinComment> Comments { get; }

        public IGherkinElements<string> Gherkin
        {
            get
            {
                var result = new GherkinCollectionString();
                result.AppendLine("{0}: {1}", this.Keyword.Format(), this.Name);
                if (!string.IsNullOrEmpty(this.Description))
                {
                    result.AppendLine("{0}", this.Description);
                }

                foreach (var step in this.Steps)
                {
                    result.Append(step);
                }

                return result;
            }
        }
    }
}