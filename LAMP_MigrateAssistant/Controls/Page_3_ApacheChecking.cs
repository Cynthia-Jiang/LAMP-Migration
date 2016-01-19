using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LAMP_MigrateAssistant.Helper;
using System.IO;
using Renci.SshNet;
using System.Threading;
using LAMP_MigrateAssistant.Models;
using System.Text.RegularExpressions;

namespace LAMP_MigrateAssistant.Controls
{
    public partial class Page_3_ApacheChecking : UserControl
    {
        private BackgroundWorker _worker;
        private string _content="";
        public Page_3_ApacheChecking()
        {
            InitializeComponent();
            this.rtbContent.Text = "";
            this.btNext.Enabled = false;
            this.pbBusyStatue.Visible = false;
            this.btCheck.Enabled = false;

            if (Global.ApacheConfig != null)
            {
                SetApacheConfig();
            }
            
        }
        private void btNext_Click(object sender, EventArgs e)
        {

            Parent.Controls.Add(new Page_3_2_ApacheChecking());
            Parent.Controls.Remove(this);
        }

        private void btStartChecn_Click(object sender, EventArgs e)
        {
           

            if (!String.IsNullOrEmpty(tbApacheConfig.Text))
            {
                Global.ApacheConfig = tbApacheConfig.Text;
            }
            string configTest = Global.sshHelper.runSudoCMD(@"[ -f " + Global.ApacheConfig + @" ] && echo ""Found"" || echo ""Not found"" ");
            if (configTest.TrimEnd('\n') == "Not found")
            {
                MessageBox.Show("The Apache configure file <"+Global.ApacheConfig+"> is not found!",
                        System.Windows.Forms.Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this._worker = new BackgroundWorker();
            this.pbBusyStatue.Visible = true;
            bool isPassed = false;
            this.lbMessage.Text = "Checking and finding your Apache sites...";
            this.rtbContent.Text = "";

            _worker.DoWork += (object doWorkSender, DoWorkEventArgs doWorkEventArgs) =>
            {
                
                isPassed = CheckAndParseApacheSite();
            };

            _worker.RunWorkerCompleted += (object runWorkerCompletedSender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs) =>
            {
                if (runWorkerCompletedEventArgs.Error != null)
                {
                    string message = runWorkerCompletedEventArgs.Error != null ? runWorkerCompletedEventArgs.Error.Message : "Could not connect to the computer specified with the credentials supplied.";
                    MessageBox.Show(message,
                        System.Windows.Forms.Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
                else
                {

                    this.rtbContent.Text = _content;
                    this.rtbContent.SelectionStart = this.rtbContent.Text.Length;
                    this.rtbContent.ScrollToCaret();

                    this.pbBusyStatue.Visible = false;
                    if (isPassed) { this.btNext.Enabled = true; }
                    

                }
            };
            _worker.RunWorkerAsync();
        }

        private List<ApacheSite> GetApacheSitesInfo()
        {
            var siteList = new List<ApacheSite>();
            //var home_folder = @"/home/"+Global.sshHelper._username;

            string cmd = @"perl -I " + Global.homeFolder + @"/aamt/ -I " + Global.homeFolder + @"/aamt/xml -I " + Global.homeFolder + @"/aamt/lib " + Global.homeFolder + @"/aamt/aamt_listsites.pl test01 " + Global.ApacheConfig;
            //string result = _sshHelper.runSudoCMD(cmd);
            Global.sshHelper.runSudoCMD("echo -e \"#!/bin/bash\n" + cmd + " \" > PreListBash");
            Global.sshHelper.runSudoCMD("chmod u+x PreListBash");
            string result = Global.sshHelper.runSudoCMD(Global.homeFolder + @"/PreListBash");
            Global.sshHelper.runSudoCMD("rm "+Global.homeFolder+"/PreListBash");
            var lines = result.TrimEnd('\n').Split('\n');
            if (lines.Length < 0)
            {
                MessageBox.Show("Sorry, I can't find any website here.");
            }
            else{

                for (int i = 0;i < lines.Length; i = i + 1)
                {
                var siteInfo = new ApacheSite();
                siteInfo.SiteId = i + 1;
                siteInfo.SiteName = lines[i];
                siteList.Add(siteInfo);
                }


            }
            return siteList;



        }
        //private string WritePreScript()
        //{
        //    string result = "";
        //    string preScript = "\"K\nTestSeccion\n"+Global.ApacheConfig+"\nN\nN\nN\nN\nN\nN\nN\nN\nN\nN\nN\nN\nN\nN\nN\nN\nN\nN\nN\nN\nN\nN\nN\nN\nN\nN\nN\nN\nN\nN\nN\nN\nN\n\"";

        //    result += Global.sshHelper.runSudoCMD("pwd");
        //    result += Global.sshHelper.runSudoCMD("rm -rf Prescript");
        //    result += Global.sshHelper.runSudoCMD("echo -e " + preScript + " > PreScript");
        //    result += Global.sshHelper.runSudoCMD("echo -e \"#!/bin/bash\n perl -I ~/Azure-Apache-Migration-Tool/ -I ~/Azure-Apache-Migration-Tool/xml -I ~/Azure-Apache-Migration-Tool/lib ~/Azure-Apache-Migration-Tool/migrate_tool_main.pl < PreScript\" > PreBash");
        //    result += Global.sshHelper.runSudoCMD("chmod u+x PreBash");

        //    return result;
        //}

        private bool CheckAndParseApacheSite(){
            string message = "Perl Scripts will be uploaded to your Linux Host, do you agree?";
            string title = "Agree";
            _content = "";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;


            

            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Global.sshHelper.UploadFile("aamt.tar.gz",Global.homeFolder);
                _content += Global.sshHelper.runSudoCMD("tar -xvf " + Global.homeFolder + "/aamt.tar.gz");
                if (String.IsNullOrEmpty(_content.TrimEnd('\n')))
                {
                    _content += "Error, please check the prerequisites.";
                    return false;
                }
                else
                {
                    _content += "Passed!";
                }

                Global.ApacheSiteList = GetApacheSitesInfo();
                return true;
                
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("Thanks, Bye!");
                Application.Exit();
                return false;
            }
            else
            {
                // Do something
                return false;
            }
        }

        private void cbLinuxDistro_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btCheck.Enabled = true;
            if (cbLinuxDistro.SelectedIndex == 0)
            {
                tbApacheConfig.Text = "/etc/apache2/apache2.conf";
            }
            else if (cbLinuxDistro.SelectedIndex == 1)
            {
                tbApacheConfig.Text = "/etc/httpd/conf/httpd.conf";
            }
            else if (cbLinuxDistro.SelectedIndex == 2)
            {
                tbApacheConfig.Text = "/etc/apache2/httpd.conf";
            }
            else
            {
                //Do something?
            }
        }
        private void SetApacheConfig()
        {
            this.tbApacheConfig.Text = Global.ApacheConfig;
            if (Global.ApacheConfig == "/etc/apache2/apache2.conf")
            {
                cbLinuxDistro.SelectedIndex = 0;
            }
            else if (Global.ApacheConfig == "/etc/httpd/conf/httpd.conf")
            {
                cbLinuxDistro.SelectedIndex = 1;
            }
            else if (Global.ApacheConfig == "/etc/apache2/httpd.conf")
            {
                cbLinuxDistro.SelectedIndex = 2;
            }
            else
            {
                //Do nothing?
            }
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            Parent.Controls.Add(new Page_2_ConnectToLinux());
            Parent.Controls.Remove(this);
        }




        //Test Code

        //public void RunCMDWithShell(string cmd)
        //{
        //    _worker = new BackgroundWorker();
        //    string result = "";
        //    _worker.DoWork += (object doWorkSender, DoWorkEventArgs doWorkEventArgs) =>
        //    {
        //        var reader = new StreamReader(_sshHelper.m_sshStream);
        //        var writer = new StreamWriter(_sshHelper.m_sshStream);
        //        writer.AutoFlush = true;

        //        result += ReadStream(reader);
        //        WriteStream(cmd, writer, _sshHelper.m_sshStream);
        //        result += ReadStream(reader);
        //    };

        //    _worker.RunWorkerCompleted += (object runWorkerCompletedSender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs) =>
        //    {
        //        this.rtbContent.Text += result;
        //    };
        //    _worker.RunWorkerAsync();
        //}
        //private string ReadStream(StreamReader reader)
        //{
        //    string returnString = "";
        //    string line = reader.ReadLine();
        //    while (line != null)
        //    {
        //        returnString += line + '\n';
        //        line = reader.ReadLine();
        //        //this.rtbContent.SelectionStart = this.rtbContent.Text.Length;
        //        //this.rtbContent.ScrollToCaret();
        //    }
        //    return returnString;
        //}
        //private void WriteStream(string cmd, StreamWriter writer, ShellStream stream)
        //{
        //    writer.WriteLine(cmd);
        //    while (stream.Length == 0)
        //    {
        //        Thread.Sleep(500);
        //    }
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    RunCMDWithShell("cd Azure-Apache-Migration-Tool");
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    RunCMDWithShell("echo \"adamusadmin\" | sudo -S echo perl migrate_tool_main.pl|echo");
        //}
    }
}
