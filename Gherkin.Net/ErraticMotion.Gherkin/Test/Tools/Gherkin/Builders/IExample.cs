// <copyright file="IExample.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin.Builders
{
    internal interface IExample
    {
        void AddExample(ExampleBuilder examplebuilder);
    }
}