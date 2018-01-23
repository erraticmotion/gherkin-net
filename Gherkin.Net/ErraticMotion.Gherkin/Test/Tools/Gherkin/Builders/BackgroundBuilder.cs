// <copyright file="BackgroundBuilder.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin.Builders
{
    using System.Linq;

    using Elements;

    internal class BackgroundBuilder : GherkinStepBuilder<Background>
    {
        private readonly string name;

        public BackgroundBuilder(ILanguageInfo info, string name)
            : base(info, GherkinKeyword.Background)
        {
            this.name = name;
        }

        public override Background Build()
        {
            return new Background(this.LanguageInfo, this.name, this.Description, new BlockSteps(this.Steps), this.Comments.ToArray());
        }
    }
}