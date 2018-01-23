// <copyright file="BlockStep.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin.Elements
{
    internal class BlockStep : IGherkinBlockStep
    {
        public BlockStep(GherkinScenarioBlock parent, ILanguageSyntax<GherkinStep> step, string description)
        {
            this.Parent = parent;
            this.Step = step;
            this.Description = description;
        }

        public void AddTestCase(TestCases example)
        {
            this.TestCase = example;
        }

        public void AddDocString(DocString docString)
        {
            this.DocString = docString;
        }

        public GherkinScenarioBlock Parent { get; private set; }

        public ILanguageSyntax<GherkinStep> Step { get; private set; }

        public string Description { get; private set; }

        public ITestCases TestCase { get; private set; }

        public IGherkinDocString DocString { get; private set; }

        public IGherkinElements<string> Gherkin
        {
            get
            {
                var result = new GherkinCollectionString();
                IGherkin example = null;
                if (this.TestCase != null)
                {
                    example = this.TestCase;
                }

                var formattedStep = this.Step.Format();
                switch (this.Step.Syntax)
                {
                    case GherkinStep.And:
                    case GherkinStep.But:
                        result.AppendLine("    {0} {1}", formattedStep, this.Description);
                        if (this.DocString != null)
                        {
                            result.Append(this.DocString);
                        }

                        if (example != null)
                        {
                            result.Append(example);
                        }

                        return result;
                }

                result.AppendLine("  {0} {1}", formattedStep, this.Description);
                if (this.DocString != null)
                {
                    result.Append(this.DocString);
                }

                if (example != null)
                {
                    result.Append(example);
                }

                return result;
            }
        }
    }
}