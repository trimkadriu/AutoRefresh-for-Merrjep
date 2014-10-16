using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Auto_Refresh_for_MerrJep
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            String configurationFile = AppDomain.CurrentDomain.BaseDirectory + "conf.ini";
            const String key = "ApiServerUrl=";
            String apiServerUrl;

            if (File.Exists(@configurationFile))
            {
                apiServerUrl = "";
                using (StreamReader sr = File.OpenText(configurationFile))
                {
                    String line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        apiServerUrl = line;
                    }
                }
                apiServerUrl = apiServerUrl.Substring(apiServerUrl.IndexOf(key) + key.Length);
                if(String.IsNullOrWhiteSpace(apiServerUrl))
                {
                    MessageBox.Show("Invalid configure file. Application will exit.");
                    return;
                }

                Application.Run(new MainForm(apiServerUrl));
            }
            else
            {
                APIServerUrlForm apiServerUrlForm = new APIServerUrlForm(false, null);
                DialogResult apiServerDialogResult = apiServerUrlForm.ShowDialog();
                if (apiServerDialogResult.Equals(DialogResult.No))
                {
                    return;
                }
                apiServerUrl = apiServerUrlForm.apiServerUrl;
                using (FileStream fs = File.Create(configurationFile))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(key + apiServerUrl);
                    fs.Write(info, 0, info.Length);
                }

                Application.Run(new MainForm(apiServerUrl));
            }
        }
    }
}