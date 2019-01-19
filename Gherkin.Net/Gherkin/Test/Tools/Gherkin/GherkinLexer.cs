// <copyright file="GherkinLexer.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Builders;

    /// <summary>
    /// Responsible for creating an Abstract Syntax Tree from the Gherkin domain language.
    /// </summary>
    internal class GherkinLexer : IGherkinLexer
    {
        /// <summary>
        /// The source file path
        /// </summary>
        private readonly string sourceFilePath;

        /// <summary>
        /// The feature file reader
        /// </summary>
        private readonly TextReader featureFileReader;

        /// <summary>
        /// The language
        /// </summary>
        private readonly ILanguageInfo language;

        /// <summary>
        /// Initializes a new instance of the <see cref="GherkinLexer"/> class.
        /// </summary>
        /// <param name="sourceFilePath">The source file path.</param>
        /// <param name="featureFileReader">The feature file reader.</param>
        public GherkinLexer(string sourceFilePath, TextReader featureFileReader)
        {
            this.sourceFilePath = sourceFilePath;
            var contents = featureFileReader.ReadToEnd();
            this.language = Internationalization.SetDefault().TryParse(contents);
            this.featureFileReader = new StringReader(contents);
        }

        /// <summary>
        /// Parses the specified feature file reader containing Gherkin syntax.
        /// </summary>
        /// <returns>An AST of the feature.</returns>
        public IGherkinFeature Parse()
        {
            var featureBuilder = new FeatureBuilder(this.language, this.sourceFilePath);

            string currentLine;

            BackgroundBuilder backgroundBuilder = null;
            ScenarioBuilder scenarioBuilder = null;
            ScenarioStepBuilder stepBuilder = null;
            ExampleBuilder exampleBuilder = null;
            DocStringBuilder docStringBuilder = null;

            var scenarioComments = new List<string>();

            var beforeFirstScenario = true;
            var tokenisingFeature = false;
            var tokenisingBackground = false;
            var tokenisingScenario = false;
            var tokenisingExamples = false;
            var tokenisingDocString = false;

            var keywords = this.language.AllKeywords().ToArray();
            var steps = this.language.AllSteps().ToArray();
            while ((currentLine = this.featureFileReader.ReadLine()) != null)
            {
                var keywordMatched = false;
                foreach (var keyword in keywords)
                {
                    if (!currentLine.StartsWith(keyword))
                    {
                        continue;
                    }

                    keywordMatched = true;
                    switch (keyword.Syntax)
                    {
                        case GherkinKeyword.Feature:
                            featureBuilder.AddName(currentLine.Name(keyword));
                            tokenisingFeature = true;
                            break;

                        case GherkinKeyword.Background:
                            if (!tokenisingFeature)
                            {
                                break;
                            }

                            tokenisingBackground = true;
                            backgroundBuilder = new BackgroundBuilder(this.language, currentLine.Name(keyword));
                            var backgroundDesc = currentLine.Name(keyword);
                            if (!string.IsNullOrEmpty(backgroundDesc))
                            {
                                backgroundBuilder.AddDescription(backgroundDesc);
                            }

                            featureBuilder.AddBackground(backgroundBuilder);
                            break;

                        case GherkinKeyword.Scenarios:
                        case GherkinKeyword.ScenarioOutline:
                            beforeFirstScenario = false;
                            tokenisingFeature = false;
                            tokenisingBackground = false;
                            tokenisingExamples = false;

                            if (!tokenisingScenario)
                            {
                                tokenisingScenario = true;
                                scenarioBuilder = new ScenarioOutlineBuilder(this.language, currentLine.Name(keyword));
                                foreach (var comment in scenarioComments)
                                {
                                    scenarioBuilder.AddComment(comment);
                                }

                                scenarioComments.Clear();
                                featureBuilder.AddScenario(scenarioBuilder);
                            }

                            break;

                        case GherkinKeyword.Scenario:
                            beforeFirstScenario = false;
                            tokenisingFeature = false;
                            tokenisingBackground = false;
                            tokenisingExamples = false;

                            if (!tokenisingScenario)
                            {
                                tokenisingScenario = true;
                                scenarioBuilder = new ScenarioBuilder(this.language, currentLine.Name(keyword));
                                foreach (var comment in scenarioComments)
                                {
                                    scenarioBuilder.AddComment(comment);
                                }

                                scenarioComments.Clear();
                                featureBuilder.AddScenario(scenarioBuilder);
                            }

                            break;

                        case GherkinKeyword.Where:
                        case GherkinKeyword.Examples:
                            beforeFirstScenario = false;
                            tokenisingExamples = true;
                            exampleBuilder = new ExampleBuilder(this.language, currentLine.Name(keyword));
                            if (scenarioBuilder != null)
                            {
                                var outline = scenarioBuilder as ScenarioOutlineBuilder;
                                outline?.AddExample(exampleBuilder);
                            }

                            break;
                    }
                }

                if (!keywordMatched)
                {
                    foreach (var step in steps)
                    {
                        if (!currentLine.StartsWith(step))
                        {
                            continue;
                        }

                        tokenisingScenario = false;
                        keywordMatched = true;
                        var scenario = GherkinScenarioBlock.None;
                        switch (step.Syntax)
                        {
                            case GherkinStep.Given:
                                stepBuilder = new ScenarioStepBuilder(
                                    GherkinScenarioBlock.Given,
                                    step,
                                    currentLine.Trim(step));
                                if (tokenisingBackground)
                                {
                                    backgroundBuilder.AddStep(stepBuilder);
                                    break;
                                }

                                scenarioBuilder?.AddStep(stepBuilder);

                                break;

                            case GherkinStep.When:
                                stepBuilder = new ScenarioStepBuilder(
                                    GherkinScenarioBlock.When,
                                    step,
                                    currentLine.Trim(step));
                                if (tokenisingBackground)
                                {
                                    backgroundBuilder.AddStep(stepBuilder);
                                    break;
                                }

                                scenarioBuilder?.AddStep(stepBuilder);

                                break;

                            case GherkinStep.Then:
                                stepBuilder = new ScenarioStepBuilder(
                                    GherkinScenarioBlock.Then,
                                    step,
                                    currentLine.Trim(step));
                                if (tokenisingBackground)
                                {
                                    backgroundBuilder.AddStep(stepBuilder);
                                    break;
                                }

                                scenarioBuilder?.AddStep(stepBuilder);

                                break;

                            case GherkinStep.And:
                                if (stepBuilder != null)
                                {
                                    scenario = stepBuilder.Parent;
                                }

                                stepBuilder = new ScenarioStepBuilder(
                                    scenario,
                                    step,
                                    currentLine.Trim(step));
                                if (tokenisingBackground)
                                {
                                    backgroundBuilder.AddStep(stepBuilder);
                                    break;
                                }

                                scenarioBuilder?.AddStep(stepBuilder);

                                break;

                            case GherkinStep.But:
                                if (stepBuilder != null)
                                {
                                    scenario = stepBuilder.Parent;
                                }

                                stepBuilder = new ScenarioStepBuilder(
                                    scenario,
                                    step,
                                    currentLine.Trim(step));
                                if (tokenisingBackground)
                                {
                                    backgroundBuilder.AddStep(stepBuilder);
                                    break;
                                }

                                scenarioBuilder?.AddStep(stepBuilder);

                                break;
                        }
                    }
                }

                if (currentLine.IsDocString())
                {
                    if (docStringBuilder == null)
                    {
                        tokenisingDocString = true;
                        docStringBuilder = new DocStringBuilder();
                        docStringBuilder.Add(currentLine);
                    }
                    else
                    {
                        tokenisingDocString = false;
                        if (stepBuilder != null)
                        {
                            docStringBuilder.Add(currentLine);
                            stepBuilder.AddDocString(docStringBuilder);
                            docStringBuilder = null;
                        }
                    }

                    continue;
                }

                if (tokenisingDocString)
                {
                    docStringBuilder.Add(currentLine);
                    continue;
                }

                if (string.IsNullOrEmpty(currentLine))
                {
                    continue;
                }

                if (currentLine == Environment.NewLine)
                {
                    continue;
                }

                if (currentLine.IsTag())
                {
                    if (beforeFirstScenario)
                    {
                        featureBuilder.AddTag(currentLine);
                    }

                    continue;
                }

                if (currentLine.IsComment())
                {
                    if (tokenisingFeature)
                    {
                        scenarioComments.Add(currentLine);
                        continue;
                    }

                    if (beforeFirstScenario && !tokenisingBackground)
                    {
                        featureBuilder.AddComment(currentLine);
                        continue;
                    }

                    scenarioComments.Add(currentLine);
                    continue;
                }

                if (currentLine.TrimStart().StartsWith("|", StringComparison.CurrentCultureIgnoreCase))
                {
                    var cells = currentLine.Trim().Split('|').Where(x => !string.IsNullOrEmpty(x)).Cast<object>().ToArray();
                    if (tokenisingExamples && exampleBuilder != null)
                    {
                        exampleBuilder.AddTestCase(cells);
                        continue;
                    }

                    if (stepBuilder != null)
                    {
                        stepBuilder.AddTestCase(cells);
                        continue;
                    }
                }

                if (tokenisingBackground && !keywordMatched)
                {
                    backgroundBuilder.AddDescription(currentLine);
                    continue;
                }

                if (tokenisingFeature && !keywordMatched)
                {
                    featureBuilder.AddDescription(currentLine);
                    continue;
                }

                if (tokenisingExamples && !keywordMatched)
                {
                    exampleBuilder.AddDescription(currentLine);
                    continue;
                }

                if (tokenisingScenario && !keywordMatched)
                {
                    scenarioBuilder.AddDescription(currentLine);

                    // continue;
                }
            }

            return featureBuilder.Build();
        }
    }
}