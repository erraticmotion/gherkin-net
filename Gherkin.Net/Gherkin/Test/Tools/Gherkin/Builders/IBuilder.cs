// <copyright file="IBuilder.cs" company="Erratic Motion Ltd">
// Copyright (c) Erratic Motion Ltd. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ErraticMotion.Test.Tools.Gherkin.Builders
{
    /// <summary>
    /// Represents a type of object builder.
    /// </summary>
    /// <typeparam name="T">The type of object to be built.</typeparam>
    public interface IBuilder<out T>
        where T : class
    {
        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns>A object of type T.</returns>
        T Build();
    }
}