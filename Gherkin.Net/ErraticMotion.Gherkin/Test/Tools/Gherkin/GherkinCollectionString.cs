// <copyright file="GherkinCollectionString.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin
{
    using System.Collections.Generic;
    using System.Globalization;

    internal class GherkinCollectionString : GherkinCollection<string>
    {
        private const string NewLine = "\r\n";
        private readonly List<string> container = new List<string>();

        public GherkinCollectionString()
        {
            this.AddContainer(this.container);
        }

        public void Append(IGherkin item)
        {
            foreach (var element in item.Gherkin)
            {
                this.container.Add(element);
            }
        }

        public void AppendLine(string format, object arg0)
        {
            this.AppendLine(format, new[] { arg0 });
        }

        public void AppendLine(string format, object arg0, object arg1)
        {
            this.AppendLine(format, new[] { arg0, arg1 });
        }

        public void AppendLine(string format, object arg0, object arg1, object arg2)
        {
            this.AppendLine(format, new[] { arg0, arg1, arg2 });
        }

        public void AppendLine(string format, params object[] args)
        {
            this.container.Add(string.Format(CultureInfo.CurrentCulture, format, args));
        }

        public void AppendLine()
        {
            this.container.Add(NewLine);
        }
    }
}