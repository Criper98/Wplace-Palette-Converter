using Colourful;
using Colourful.Internals;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WplacePaletteConverter.Extensions;

namespace WplacePaletteConverter.Models
{
    internal class WplaceColor(Color color, string name, Enums.WplaceColorType type, bool used) : ICloneable
    {
        public Color Color { get; } = color;
        public LabColor LabColor { get; } = color.ToLabColor();
        public JzCzhzColor JzColor { get; } = color.ToJzCzhzColor();
        public XYZColor XYZColor { get; } = color.ToXYZColor();
        public string Name = name;
        public Enums.WplaceColorType Type = type;
        public bool Used = used;

        object ICloneable.Clone() => Clone();

        public WplaceColor Clone() => new(Color, Name, Type, Used);
    }
}
