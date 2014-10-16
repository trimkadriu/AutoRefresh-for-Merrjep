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
    public partial class MainForm : Form
    {
        public String apiServerUrl;
        bool isStarted = false;

        public MainForm(String apiServerUrl)
        {
            InitializeComponent();
            this.apiServerUrl = apiServerUrl;
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

        private void btnStart_Click(object sender, EventArgs e)
        {
            if(!isStarted) 
            {
                if (dgwList.Rows.Count == 0)
                {
                    MessageBox.Show(null, "Error! Please add at least one Post URL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                btnStart.Text = "Stop AutoRefresh !!!";
                isStarted = true;
            }
            else
            {
                btnStart.Text = "Start AutoRefresh !!!";
                isStarted = false;
            }
        }
    }
}
