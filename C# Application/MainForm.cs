using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Auto_Refresh_for_MerrJep
{
    public partial class mainForm : Form
    {
        String apiServerUrl;

        public mainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
            String configurationFile = AppDomain.CurrentDomain.BaseDirectory + "conf.ini";
            if (File.Exists(@configurationFile))
            {
                apiServerUrl = "";
                using (StreamReader sr = File.OpenText(configurationFile))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            else
            {
                APIServerUrlForm apiServerUrlForm = new APIServerUrlForm();
                apiServerUrlForm.ShowDialog();
                apiServerUrl = apiServerUrlForm.apiServerUrl;
                using (FileStream fs = File.Create(configurationFile))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes("ApiServerUrl=" + apiServerUrl);
                    fs.Write(info, 0, info.Length);
                }
            }
        }

        private void btnAddUrl_Click(object sender, EventArgs e)
        {
            String url = txtUrlOfPost.Text;
            if (String.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show(null, "Error! Please fill the URL field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int index = dgwList.Rows.Add();
            DataGridViewRow row = dgwList.Rows[index];
            row.Cells["UrlColumn"].Value = url;
            row.Cells["StatusColumn"].Value = "idle";
        }

        private void btnRemoveUrl_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dgwList.SelectedRows)
            {
                dgwList.Rows.RemoveAt(item.Index);
            }
        }
    }
}
