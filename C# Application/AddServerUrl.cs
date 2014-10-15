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

        public APIServerUrlForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtApiServerUrl.Text))
            {
                MessageBox.Show("Please add a valid URL");
            }
            else
            {
                apiServerUrl = txtApiServerUrl.Text;
                this.Close();
            }
        }

        private void APIServerUrlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtApiServerUrl.Text))
            {
                Application.Exit();
            }
        }
    }
}
