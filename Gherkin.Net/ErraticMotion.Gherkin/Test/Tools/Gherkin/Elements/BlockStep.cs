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

namespace ErraticMotion.Test.Tools.Gherkin.Elements
{
    public class BlockStep : IGherkinBlockStep
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