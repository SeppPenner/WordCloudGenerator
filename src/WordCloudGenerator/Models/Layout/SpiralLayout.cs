// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SpiralLayout.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The spiral layout.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WordCloudGenerator.Models.Layout;

/// <inheritdoc cref="BaseLayout"/>
/// <summary>
/// The spiral layout.
/// </summary>
/// <seealso cref="BaseLayout"/>
public class SpiralLayout : BaseLayout
{
    /// <inheritdoc cref="BaseLayout"/>
    /// <summary>
    /// Initializes a new instance of the <see cref="SpiralLayout"/> class.
    /// </summary>
    /// <param name="size">The size.</param>
    /// <seealso cref="BaseLayout"/>
    public SpiralLayout(SizeF size) : base(size)
    {
    }

    /// <inheritdoc cref="BaseLayout"/>
    /// <summary>
    /// Tries to find a free rectangle.
    /// </summary>
    /// <param name="size">The size.</param>
    /// <param name="foundRectangle">The found rectangle.</param>
    /// <returns>A value indicating whether the rectangle is free or not.</returns>
    /// <seealso cref="BaseLayout"/>
    public override bool TryFindFreeRectangle(SizeF size, out RectangleF foundRectangle)
    {
        foundRectangle = RectangleF.Empty;
        double alpha = GetPseudoRandomStartAngle(size);
        const double StepAlpha = Math.PI / 60;
        const double PointsOnSpital = 500;

        Math.Min(this.Center.Y, this.Center.X);

        for (var pointIndex = 0; pointIndex < PointsOnSpital; pointIndex++)
        {
            var dX = pointIndex / PointsOnSpital * Math.Sin(alpha) * this.Center.X;
            var dY = pointIndex / PointsOnSpital * Math.Cos(alpha) * this.Center.Y;
            foundRectangle = new RectangleF((float)(this.Center.X + dX) - (size.Width / 2), (float)(this.Center.Y + dY) - (size.Height / 2), size.Width, size.Height);

            alpha += StepAlpha;

            if (!this.IsInsideSurface(foundRectangle))
            {
                return false;
            }

            if (!this.QuadTree.HasContent(foundRectangle))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Gets a pseudo random start angle.
    /// </summary>
    /// <param name="size">The size.</param>
    /// <returns>The pseudo random start angle as <see cref="float"/>.</returns>
    private static float GetPseudoRandomStartAngle(SizeF size)
    {
        return size.Height * size.Width;
    }
}
