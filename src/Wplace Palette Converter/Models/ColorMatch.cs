using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WplacePaletteConverter.Models
{
    internal class ColorMatch(Color input, Color output, Enums.ComparisonMethods method)
    {
        public Color Input = input;
        public Color Output = output;
        public Enums.ComparisonMethods Method = method;
    }
}
