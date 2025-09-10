using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WplacePaletteConverter.Services
{
    internal static class AutoUpdater
    {
        private static JObject latestReleaseJson = [];
        private static readonly string MyExeName = Process.GetCurrentProcess().MainModule?.ModuleName ?? "Wplace Palette Converter.exe";

        public static bool CheckForUpdates()
        {
            using HttpClient client = new();
            using HttpRequestMessage request = new(
                HttpMethod.Get,
                "https://api.github.com/repos/Criper98/Wplace-Palette-Converter/releases/latest"
            );

            client.Timeout = TimeSpan.FromMilliseconds(2500);
            request.Headers.Add("User-Agent", "Wplace Palette Converter");
            HttpResponseMessage response = client.Send(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return false;

            latestReleaseJson = JObject.Parse(response.Content.ReadAsStringAsync().Result);

            if ((string?)latestReleaseJson["tag_name"] != Application.ProductVersion)
                return true;

            return false;
        }

        public static void Download()
        {
            string downloadUrl = (string?)latestReleaseJson["assets"]?[0]?["browser_download_url"] ?? "";

            if (downloadUrl == "")
                throw new Exception("Download URL not found.");

            using HttpClient client = new();
            using Task<Stream> stream = client.GetStreamAsync(downloadUrl);

            using FileStream fileStream = new(Global.WorkingDirectory + "wppc_new.exe", FileMode.Create);
            stream.Result.CopyTo(fileStream);
        }

        public static void Update()
        {
            File.WriteAllText(Global.WorkingDirectory + "update.bat",
                $"""
				@echo off
				timeout /t 2 /nobreak > NUL
				taskkill /f /im "{MyExeName}"
				move /y "{Global.WorkingDirectory}wppc_new.exe" "{Global.WorkingDirectory}{MyExeName}"
				start "" "{Global.WorkingDirectory}{MyExeName}"
				del "%~f0" & exit
				"""
            );

            Process.Start(new ProcessStartInfo
            {
                FileName = Global.WorkingDirectory + "update.bat",
                UseShellExecute = true,
                WindowStyle = ProcessWindowStyle.Hidden
            });
        }
    }
}
