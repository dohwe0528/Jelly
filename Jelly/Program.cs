using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KakaoMSG
{
    static class Program
    {
        static int[] Version = { 0, 1, 4 };

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CheckVersion();
        }


        static void CheckVersion()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync("http://222.122.203.68/api/versioncheck").Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;

                    string responseString = responseContent.ReadAsStringAsync().Result;

                    Version ver = Newtonsoft.Json.JsonConvert.DeserializeObject<Version>(responseString);

                    string[] version = ver.current_version.Split(".");

                    if(Version[0] < int.Parse( version[0] ) || Version[1] < int.Parse(version[1]) || Version[2] < int.Parse(version[2]))
                    {
                        Process.Start("Update.exe", "");
                        Environment.Exit(0);
                    } else
                    {
                        Application.Run(new MainWnd(Version));
                    }
                    
                } else
                {
                    Application.Run(new MainWnd(Version));
                }
            }
        }

    }
}
