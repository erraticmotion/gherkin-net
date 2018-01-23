// <copyright file="Scenario.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin.Elements
{
    using System.Collections.Generic;

    internal class Scenario : GherkinKeywordBase, IGherkinScenario
    {
        public Scenario(ILanguageInfo info, string name, string description, BlockSteps scenarioSteps, IList<IGherkinComment> comments)
            : base(info, GherkinKeyword.Scenario, name, description)
        {
            this.Steps = scenarioSteps ?? new BlockSteps();
            this.Examples = new Examples();
            this.Comments = comments;
        }

        public Scenario(ILanguageInfo info, string name, string description, BlockSteps scenarioSteps, Examples examples, IList<IGherkinComment> comments)
            : base(info, GherkinKeyword.ScenarioOutline, name, description)
        {
            this.Steps = scenarioSteps ?? new BlockSteps();
            this.Examples = examples ?? new Examples();
            this.Comments = comments;
        }

        public IGherkinBlockSteps Steps { get; }

        public IGherkinExamples Examples { get; }

        public IList<IGherkinComment> Comments { get; }

        public IGherkinElements<string> Gherkin
        {
            get
            {
                var result = new GherkinCollectionString();
                foreach (var comment in this.Comments)
                {
                    result.AppendLine("# {0}", comment);
                }

                if (this.Comments.Count > 0)
                {
                    result.AppendLine();
                }

                result.AppendLine("{0}: {1}", this.Keyword.Format(), this.Name);
                if (!string.IsNullOrEmpty(this.Description))
                {
                    result.AppendLine(this.Description);
                }

                foreach (var step in this.Steps)
                {
                    result.Append(step);
                }

                foreach (var example in this.Examples)
                {
                    result.Append(example);
                }

                return result;
            }
        }
    }
}