// ---------------------------------------------------------------------------
// (C) 2016 Parkeon Limited.
// 
//  No part of this source code may be reproduced, digitised, stored in a 
//  retrieval system, communicated to the public or caused to be seen or heard 
//  in public, made publicly available or publicly performed, offered for sale 
//  or hire or exhibited by way of trade in public or distributed by way of trade 
//  in any form or by any means, electronic, mechanical or otherwise without the 
//  written permission of Parkeon Limited.
// 
// ---------------------------------------------------------------------------

namespace ErraticMotion.Test.Tools.Gherkin.Builders
{
    using ErraticMotion.Test.Tools.Gherkin.Elements;

    public class ScenarioStepBuilder : ITestCaseBuilder<BlockStep>
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