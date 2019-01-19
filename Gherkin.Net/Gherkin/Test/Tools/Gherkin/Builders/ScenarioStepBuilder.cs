// <copyright file="ScenarioStepBuilder.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin.Builders
{
    using Elements;

    internal class ScenarioStepBuilder : ITestCaseBuilder<BlockStep>
    {
        private readonly BlockStep scenarioStep;
        private readonly TestCaseBuilder testCaseBuilder = new TestCaseBuilder();
        private DocString docString;

        public ScenarioStepBuilder(GherkinScenarioBlock scenario, ILanguageSyntax<GherkinStep> step, string text)
        {
            this.scenarioStep = new BlockStep(scenario, step, text);
        }

        public GherkinScenarioBlock Parent { get { return this.scenarioStep.Parent; } }

        public void AddTestCase(object[] cells)
        {
            this.testCaseBuilder.AddTestCase(cells);
        }

        public void AddDocString(DocStringBuilder item)
        {
            this.docString = item.Build();
        }

        public BlockStep Build()
        {
            this.scenarioStep.AddTestCase(this.testCaseBuilder.Build());
            if (this.docString != null)
            {
                this.scenarioStep.AddDocString(this.docString);
            }

            return this.scenarioStep;
        }
    }
}