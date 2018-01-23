// <copyright file="ScenarioBuilder.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin.Builders
{
    using System.Linq;

    using Elements;

    internal class ScenarioBuilder : GherkinStepBuilder<Scenario>
    {
        protected internal string Title;

        public ScenarioBuilder(ILanguageInfo info, string title)
            : this(info, title, GherkinKeyword.Scenario)
        {
        }

        protected ScenarioBuilder(ILanguageInfo info, string title, GherkinKeyword keyword)
            : base(info, keyword)
        {
            this.Title = title;
        }

        public override Scenario Build()
        {
            return new Scenario(this.LanguageInfo, this.Title, this.Description, new BlockSteps(this.Steps), this.Comments.ToArray());
        }
    }
}