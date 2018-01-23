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
    using System.Collections.Generic;

    public class Scenario : GherkinKeywordBase, IGherkinScenario
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

        public IGherkinBlockSteps Steps { get; private set; }

        public IGherkinExamples Examples { get; private set; }

        public IList<IGherkinComment> Comments { get; private set; }

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