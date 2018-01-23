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
    using System.Collections.Generic;
    using System.Linq;

    using ErraticMotion.Test.Tools.Gherkin.Elements;

    public class ScenarioOutlineBuilder : ScenarioBuilder, IExample
    {
        private readonly IList<ExampleBuilder> examples = new List<ExampleBuilder>();

        public ScenarioOutlineBuilder(ILanguageInfo info, string title) 
            : base(info, title, GherkinKeyword.ScenarioOutline)
        {
        }

        public void AddExample(ExampleBuilder examplebuilder)
        {
            this.examples.Add(examplebuilder);
        }

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