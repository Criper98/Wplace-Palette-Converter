using Colourful;
using Colourful.Internals;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WplacePaletteConverter.Extensions
{
	internal static class ColorExt
	{
        // PERF: Initialize the color difference algorithm once to save time, memory,
        // and reduce GC pressure. This avoids creating a new instance every time
        // we need to calculate the distance between two colors.
        private static readonly CIEDE2000ColorDifference cIEDE2000ColorDifference = new();
        private static readonly CIE94ColorDifference cIE94ColorDifference = new();
        private static readonly CIE76ColorDifference cIE76ColorDifference = new();
        private static readonly JzCzhzDEzColorDifference jzCzhzDEzColorDifference = new();
        private static readonly EuclideanDistanceColorDifference<XYZColor> euclideanDistanceColorDifference = new();

        // PERF: Do the same for converters.
        private static readonly IColorConverter<RGBColor, LabColor> rgbToLabConverter = new ConverterBuilder().FromRGB().ToLab().Build();
        private static readonly IColorConverter<RGBColor, JzCzhzColor> rgbToJzCzhzConverter = new ConverterBuilder().FromRGB().ToJzCzhz().Build();
        private static readonly IColorConverter<RGBColor, XYZColor> rgbToXYZConverter = new ConverterBuilder().FromRGB().ToXYZ(RGBWorkingSpaces.sRGB.WhitePoint).Build();

        public static Color GetMostSimilar(this Color input, Models.WplaceColor[] wpColors, Enums.ComparisonMethods method)
		{
			Color? closestColor = null;
			double closestDistance = double.MaxValue;

            // PERF: Precompute LabColor once from the input, even if it's not always used.
            // This is the most expensive color conversion, and it's also the most commonly
            // used—since the first three conversion options typically depend on it.
            LabColor labColor = input.ToLabColor();

            foreach (Models.WplaceColor wpColor in wpColors)
			{
                double distance = method switch
                {
                    Enums.ComparisonMethods.CIEDE2000 => cIEDE2000ColorDifference.ComputeDifference(labColor, wpColor.LabColor),
                    Enums.ComparisonMethods.CIE94 => cIE94ColorDifference.ComputeDifference(labColor, wpColor.LabColor),
                    Enums.ComparisonMethods.CIE76 => cIE76ColorDifference.ComputeDifference(labColor, wpColor.LabColor),
                    Enums.ComparisonMethods.JzCzhzDEz => jzCzhzDEzColorDifference.ComputeDifference(input.ToJzCzhzColor(), wpColor.JzColor),
                    Enums.ComparisonMethods.Euclidean => euclideanDistanceColorDifference.ComputeDifference(input.ToXYZColor(), wpColor.XYZColor),
                    _ => throw new ArgumentOutOfRangeException(nameof(method), method, null)
                };

                if (distance < closestDistance)
				{
					closestDistance = distance;
					closestColor = wpColor.Color;
				}
			}

			if (closestColor == null)
				throw new InvalidOperationException($"No similar color found for input color {input} using method {method}.");

			return closestColor.Value;
		}

		
        public static LabColor ToLabColor(this Color color) =>
            rgbToLabConverter.Convert(new(color));

        
        public static JzCzhzColor ToJzCzhzColor(this Color color) =>
            rgbToJzCzhzConverter.Convert(new(color));

        
        public static XYZColor ToXYZColor(this Color color) =>
            rgbToXYZConverter.Convert(new(color));
	}
}
