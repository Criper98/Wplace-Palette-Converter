using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace WplacePaletteConverter.Services
{
    internal static class Settings
    {
        private static readonly string filePath = Global.WorkingDirectory + "settings.json";

        // ====[ SETTINGS ON FILE ]====

        public static Models.WplaceColor[] WplaceFreePalette = [];
        public static Models.WplaceColor[] WplaceLockedPalette = [];

        // ================================

        public static void Init()
        {
            WplaceFreePalette = Global.WplaceFreePalette;
            WplaceLockedPalette = Global.WplaceLockedPalette;
        }

        public static void Save()
        {
            JObject json = [];

            FieldInfo[] fields = typeof(Settings).GetFields();

            foreach (FieldInfo fi in fields)
                json[fi.Name] = JToken.FromObject(fi.GetValue(null)!);

            File.WriteAllText(filePath, json.ToString());
        }

        public static void Read()
        {
            if (!File.Exists(filePath))
            {
                Init();
                Save();
                return;
            }

            string fileContent;
            JObject json;

            try
            {
                fileContent = File.ReadAllText(filePath);
                json = JObject.Parse(fileContent);
            }
            catch
            {
                Init();
                Save();
                return;
            }

            FieldInfo[] fields = typeof(Settings).GetFields();

            foreach (FieldInfo fi in fields)
                if (json.TryGetValue(fi.Name, out JToken? jk))
                    fi.SetValue(null, jk.ToObject(fi.FieldType));
        }

    }
}
