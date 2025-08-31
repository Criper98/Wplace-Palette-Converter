using Colourful;
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
		public static Color GetMostSimilar(this Color input, Models.WplaceColor[] wpColors, Enums.ComparisonMethods method)
		{
			Color? closestColor = null;
			double closestDistance = double.MaxValue;

			foreach (Models.WplaceColor wpColor in wpColors)
			{
				double distance = method switch
				{
					Enums.ComparisonMethods.CIEDE2000 => new CIEDE2000ColorDifference().ComputeDifference(input.ToLabColor(), wpColor.LabColor),
					Enums.ComparisonMethods.CIE94 => new CIE94ColorDifference().ComputeDifference(input.ToLabColor(), wpColor.LabColor),
					Enums.ComparisonMethods.CIE76 => new CIE76ColorDifference().ComputeDifference(input.ToLabColor(), wpColor.LabColor),
					Enums.ComparisonMethods.JzCzhzDEz => new JzCzhzDEzColorDifference().ComputeDifference(input.ToJzCzhzColor(), wpColor.JzColor),
					Enums.ComparisonMethods.Euclidean => new EuclideanDistanceColorDifference<XYZColor>().ComputeDifference(input.ToXYZColor(), wpColor.XYZColor),
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
			new ConverterBuilder().FromRGB().ToLab().Build().Convert(new(color));

		public static JzCzhzColor ToJzCzhzColor(this Color color) =>
			new ConverterBuilder().FromRGB().ToJzCzhz().Build().Convert(new(color));

		public static XYZColor ToXYZColor(this Color color) =>
			new ConverterBuilder().FromRGB().ToXYZ(RGBWorkingSpaces.sRGB.WhitePoint).Build().Convert(new(color));
	}
}
