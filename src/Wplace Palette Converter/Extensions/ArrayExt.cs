using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WplacePaletteConverter.Extensions
{
	internal static class ArrayExt
	{
		public static T[] Copy<T>(this T[] array) where T : ICloneable
		{
			T[] newArray = new T[array.Length];
			for (int i = 0; i < array.Length; i++)
				newArray[i] = (T)array[i].Clone();

			return newArray;
		}
	}
}
