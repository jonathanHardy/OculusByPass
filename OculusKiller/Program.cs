using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web.Script.Serialization;


namespace OculusKiller
{
    public class Program
    {
        

        public static void Main()
        {
            Item item = JsonFileReader.Read<Item>(@"C:\Program Files\Oculus\Support\oculus-dash\dash\bin\config.json");
            //MessageBox.Show(item.pathToIntro);
            //MessageBox.Show(item.stamp);
            /*try
            {
                string openVrPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"openvr\openvrpaths.vrpath");
                if (File.Exists(openVrPath))
                {
                    var jss = new JavaScriptSerializer();
                    string jsonString = File.ReadAllText(openVrPath);
                    dynamic steamVrPath = jss.DeserializeObject(jsonString);

                    string vrStartupPath = Path.Combine(steamVrPath["runtime"][0].ToString(), @"bin\win64\vrstartup.exe");
                    if (File.Exists(vrStartupPath))
                    {*/
                        Process vrStartupProcess = Process.Start(item.pathToIntro);
                        //Process vrStartupProcess = Process.Start(@"C:\Jonathan\Projects\Summer22Exh_Quest_Urp_22_2a\Builds\win10\Summer22Exh.exe");
                        //OLD//Process vrStartupProcess = Process.Start(vrStartupPath);
                        vrStartupProcess.WaitForExit();
                        Process vrStartupApp = Process.Start(item.pathToApp);
                        //Process vrStartupApp = Process.Start(@"C:\Jonathan\Projects\Marco_Polo_build\MarcoPolo.exe");
                        vrStartupApp.WaitForExit();
            /*}
            else
                MessageBox.Show("SteamVR does not exist in installation directory.");
        }
        else
            MessageBox.Show("Could not find openvr config file within LocalAppdata.");
    }
    catch (Exception e)
    {
        MessageBox.Show($"An exception occured while attempting to find SteamVR!\n\nMessage: {e}");
    }*/
        }
    }

    public static class JsonFileReader
    {
        public static T Read<T>(string filePath)
        {
            string text = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(text);
        }
    }
    public class Item
    {
        public string pathToApp { get; set; }
        public string pathToIntro { get; set; }
    }
}
