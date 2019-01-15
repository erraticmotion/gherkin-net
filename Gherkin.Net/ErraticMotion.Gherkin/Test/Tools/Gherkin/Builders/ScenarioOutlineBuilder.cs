// <copyright file="ScenarioOutlineBuilder.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin.Builders
{
    using System.Collections.Generic;
    using System.Linq;

    using Elements;

    internal class ScenarioOutlineBuilder : ScenarioBuilder, IExample
    {
        /// <summary>
        /// The examples
        /// </summary>
        private readonly IList<ExampleBuilder> examples = new List<ExampleBuilder>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioOutlineBuilder"/> class.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <param name="title">The title.</param>
        public ScenarioOutlineBuilder(ILanguageInfo info, string title)
            : base(info, title, GherkinKeyword.ScenarioOutline)
        {
        }

        /// <summary>
        /// Adds the example.
        /// </summary>
        /// <param name="exampleBuilder">The example builder.</param>
        public void AddExample(ExampleBuilder exampleBuilder)
        {
            this.examples.Add(exampleBuilder);
        }

        /// <inheritdoc />
        public override Scenario Build()
        {
            return new Scenario(
                this.LanguageInfo,
                this.Title,
                this.Description,
                new BlockSteps(this.Steps),
                new Examples(this.examples.Select(example => example.Build()).ToArray()),
                this.Comments.ToArray());
        }
    }
}