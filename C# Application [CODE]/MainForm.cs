using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Auto_Refresh_for_MerrJep
{
    public partial class MainForm : Form
    {
        public String apiServerUrl;
        bool isStarted = false;
        System.Timers.Timer timer = new System.Timers.Timer();

        public MainForm(String apiServerUrl)
        {
            InitializeComponent();
            this.apiServerUrl = apiServerUrl;
            timer.Elapsed += new ElapsedEventHandler(onTimedEvent);
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
            row.Cells["StatusColumn"].Value = "N/A";
            row.Cells["SuccessColumn"].Value = "0";
            row.Cells["FailColumn"].Value = "0";
            txtUrlOfPost.Text = "";
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
                if (dgwList.Rows.Count == 0 || String.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show(null, "Error! Please fill the form correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                btnStart.Text = "STOP";
                isStarted = true;
                timer.Interval = (double)txtTime.Value * 60 * 1000;
                dgwList.Enabled = false;
                btnAddUrl.Enabled = false;
                btnRemoveUrl.Enabled = false;
                txtUrlOfPost.Enabled = false;
                txtPassword.Enabled = false;
                txtTime.Enabled = false;
                btnServerUrlConf.Enabled = false;
                timer.Start();
                onTimedEvent(null, null);
            }
            else
            {
                btnStart.Text = "START";
                isStarted = false;
                dgwList.Enabled = true;
                btnAddUrl.Enabled = true;
                btnRemoveUrl.Enabled = true;
                txtUrlOfPost.Enabled = true;
                txtPassword.Enabled = true;
                txtTime.Enabled = true;
                btnServerUrlConf.Enabled = true;
                timer.Stop();
            }
        }

        private void onTimedEvent(object source, ElapsedEventArgs e)
        {
            foreach (DataGridViewRow row in dgwList.Rows)
            {
                String postUrl = row.Cells[0].Value.ToString();
                String result = "N/A";
                String data = "url=" + Uri.EscapeDataString(postUrl) + "&password=" + Uri.EscapeDataString(txtPassword.Text);

                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiServerUrl);
                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Accept = "Accept=text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                    using (StreamWriter writer = new StreamWriter(request.GetRequestStream(), Encoding.ASCII))
                    {
                        writer.Write(data);
                    }
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        result = reader.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                int success = Int32.Parse(row.Cells["SuccessColumn"].Value.ToString());
                int fail = Int32.Parse(row.Cells["FailColumn"].Value.ToString());
                if (result.Equals("\"SUCCESS\""))
                {
                    success++;
                    row.Cells["SuccessColumn"].Value = success;
                    row.Cells["StatusColumn"].Value = "[" + success + "]   |   [" + fail + "]";
                }
                else
                {
                    fail++;
                    row.Cells["FailColumn"].Value = fail;
                    row.Cells["StatusColumn"].Value = "[" + success + "]   |   [" + fail + "]";
                }
            }
        }

        private void btnServerUrlConf_Click(object sender, EventArgs e)
        {
            APIServerUrlForm apiServerUrlForm = new APIServerUrlForm(true, apiServerUrl);
            DialogResult dr = apiServerUrlForm.ShowDialog();
            if (dr.Equals(DialogResult.Yes))
            {
                apiServerUrl = apiServerUrlForm.apiServerUrl;
            }
        }
    }
}
