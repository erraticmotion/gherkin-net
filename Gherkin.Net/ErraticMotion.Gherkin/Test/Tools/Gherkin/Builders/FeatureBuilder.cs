// <copyright file="FeatureBuilder.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin.Builders
{
    using System.Collections.Generic;
    using System.Linq;

    using Elements;

    internal class FeatureBuilder : GherkinBuilder<Feature>
    {
        private readonly IList<IBuilder<Scenario>> scenarios = new List<IBuilder<Scenario>>();
        private readonly string suffix = string.Empty;
        private string name;
        private BackgroundBuilder background;

        public FeatureBuilder(ILanguageInfo info, string sourceFile)
            : base(info, GherkinKeyword.Feature, sourceFile, info.Code)
        {
            this.SourceFile = sourceFile;
            this.suffix = GetSuffix(sourceFile);
        }

        public string SourceFile { get; private set; }

        public void AddName(string value)
        {
            this.name = value.Trim('.') + this.suffix;
        }

        public void AddScenario(IBuilder<Scenario> scenarioBuilder)
        {
            this.scenarios.Add(scenarioBuilder);
        }

        public void AddBackground(BackgroundBuilder backgroundBuilder)
        {
            this.background = backgroundBuilder;
        }

        public override Feature Build()
        {
            var ns = "Parkeon";
            var item = this.Comments.FirstOrDefault(x => x.CommentKey == CommentKey.Namespace);
            if (item != null)
            {
                ns = item.Value;
            }

            return new Feature(
                this.LanguageInfo,
                this.name,
                this.Description,
                ns,
                this.background == null ? null : this.background.Build(),
                this.scenarios.Select(sb => sb.Build()),
                this.Comments.ToArray(),
                this.Tags.ToArray(),
                this.SourceFile);
        }

        private static string GetSuffix(string value)
        {
            if (value.EndsWith("_01.feature"))
            {
                return "_01";
            }

            if (value.EndsWith("_02.feature"))
            {
                return "_02";
            }

            if (value.EndsWith("_03.feature"))
            {
                return "_03";
            }

            if (value.EndsWith("_04.feature"))
            {
                return "_04";
            }

            if (value.EndsWith("_05.feature"))
            {
                return "_05";
            }

            if (value.EndsWith("_06.feature"))
            {
                return "_06";
            }

            if (value.EndsWith("_07.feature"))
            {
                return "_07";
            }

            return string.Empty;
        }
    }
}