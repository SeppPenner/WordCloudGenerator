// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILayoutFactory.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The layout factory interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WordCloudGenerator.Interfaces.Layout
{
    using System.Drawing;

    using WordCloudGenerator.Models.Enumerations;

    /// <summary>
    /// The layout factory interface.
    /// </summary>
    public interface ILayoutFactory
    {
        /// <summary>
        /// Creates a layout.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <param name="type">The type.</param>
        /// <returns>A new <see cref="ILayout"/>.</returns>
        // ReSharper disable once UnusedMemberInSuper.Global
        ILayout CreateLayout(SizeF size, LayoutType type);
    }
}