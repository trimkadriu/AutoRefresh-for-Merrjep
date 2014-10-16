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
    public partial class APIServerUrlForm : Form
    {
        public string apiServerUrl { get; set; }
        bool isSet;
        String currentApiServerUrl;

        public APIServerUrlForm(bool isSet, String currentApiServerUrl)
        {
            InitializeComponent();
            this.isSet = isSet;
            this.currentApiServerUrl = currentApiServerUrl;
            if(isSet)
            {
                txtApiServerUrl.Text = currentApiServerUrl;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtApiServerUrl.Text))
            {
                MessageBox.Show("Please add a valid URL");
            }
            else
            {
                apiServerUrl = txtApiServerUrl.Text;
                if (isSet)
                {
                    using (FileStream fs = File.Create(AppDomain.CurrentDomain.BaseDirectory + "conf.ini"))
                    {
                        Byte[] info = new UTF8Encoding(true).GetBytes("ApiServerUrl=" + apiServerUrl);
                        fs.Write(info, 0, info.Length);
                    }
                }
                this.DialogResult = DialogResult.Yes;
            }
        }

        private void APIServerUrlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason.Equals(CloseReason.UserClosing))
                this.DialogResult = DialogResult.No;
            else
                this.DialogResult = DialogResult.Yes;
        }

        private void APIServerUrlForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
