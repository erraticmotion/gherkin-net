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

namespace ErraticMotion.Test.Tools
{
    using System.Collections.Generic;

    using ErraticMotion.Test.Tools.Gherkin;

    internal class SupportedLanguage : ILanguageSupport
    {
        public SupportedLanguage(ILanguageInfo info)
        {
            this.LanguageInfo = info;
        }

        public ILanguageInfo LanguageInfo { get; private set; }

        public IEnumerable<ILanguageSyntax<GherkinKeyword>> Keywords { get { return this.LanguageInfo.AllKeywords(); } }

        public IEnumerable<ILanguageSyntax<GherkinStep>> Steps { get { return this.LanguageInfo.AllSteps(); } }
    }
}