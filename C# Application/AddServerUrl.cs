using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
                if (isSet)
                {
                    // UPDATE CONF FILE
                }
                apiServerUrl = txtApiServerUrl.Text;
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
    }
}
