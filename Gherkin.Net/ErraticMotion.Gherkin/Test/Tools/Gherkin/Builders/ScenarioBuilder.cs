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
    using System.Linq;

    using ErraticMotion.Test.Tools.Gherkin.Elements;

    public class ScenarioBuilder : GherkinStepBuilder<Scenario>
    {
        protected internal string Title;

        public ScenarioBuilder(ILanguageInfo info, string title)
            : this(info, title, GherkinKeyword.Scenario)
        {
        }

        protected ScenarioBuilder(ILanguageInfo info, string title, GherkinKeyword keyword)
            : base(info, keyword)
        {
            this.Title = title;
        }

        public override Scenario Build()
        {
            return new Scenario(this.LanguageInfo, this.Title, this.Description, new BlockSteps(this.Steps), this.Comments.ToArray());
        }
    }
}