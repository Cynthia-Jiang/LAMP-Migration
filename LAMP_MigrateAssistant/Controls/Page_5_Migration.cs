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
using System.Diagnostics;
using LAMP_MigrateAssistant.Models;

namespace LAMP_MigrateAssistant.Controls
{
    public partial class Page_5_Migration : UserControl
    {
        public Page_5_Migration(string publishsettings)
        {
            InitializeComponent();
            _publishsettings = publishsettings;
            this.btStart.Enabled = true;
            this.btMigrateNewOne.Visible = false;

        }
        private string _publishsettings;
        private BackgroundWorker _worker;

        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            _worker = new BackgroundWorker();
            this.btStart.Enabled = false;
            this.btBack.Enabled = false;
            this.btExit.Enabled = false;
            this.lbMessage.Text = "Migrating...";
            this.pbBusyStatue.Visible = true;
            string result = "";
            _worker.DoWork += (object doWorkSender, DoWorkEventArgs doWorkEventArgs) =>
            {
               result += WritePreScript();
               result += RunMigrateScript();
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
                    this.rtbStatus.Text = result;
                    this.rtbStatus.SelectionStart = this.rtbStatus.Text.Length;
                    this.rtbStatus.ScrollToCaret();
                    this.lbMessage.Text = "Done!";
                    this.pbBusyStatue.Visible = false;

                    var linkString = _publishsettings.Substring(0, _publishsettings.LastIndexOf('.'));
                    this.linkLabel1.Visible = true;
                    this.linkLabel1.Text = linkString;
                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = "Http://" + linkString;
                    linkLabel1.Links.Add(link);
                    this.btMigrateNewOne.Visible = true;
                    this.btBack.Enabled = true ;
                    this.btExit.Enabled = true ;
                }

            };
            _worker.RunWorkerAsync();

        }

        private string WritePreScript()
        {
            string result = "";
            //string preScript = "\"K\nTestSection\n" + Global.ApacheConfig + "\nN\nY\nY\nN\nN\n/home/" + this._sshHelper._username + "/" + _publishsettings + "\nY\n\"";
            string id="";
            foreach(var item in Global.ApacheSiteList){
                if (item.IsMigCandidate){ id = item.SiteId.ToString();};
            }
            //var home_folder = @"/home/" + Global.sshHelper._username;
            //var home_folder = Global.sshHelper.runSudoCMD("echo $HOME");
            //string preScript = @"perl ~/aamt/aamt_deploysite.pl test01 " + Global.ApacheConfig + " " + id + @" /home/" + Global.sshHelper._username + "/aamt/" + _publishsettings + "\"";
            result += Global.sshHelper.runSudoCMD("pwd");
            result += Global.sshHelper.runSudoCMD("echo -e \"#!/bin/bash\n cd " + Global.homeFolder + @"/aamt; perl -I " + Global.homeFolder + @"/aamt/ -I " + Global.homeFolder + @"/aamt/lib -I " + Global.homeFolder + @"/aamt/xml aamt_deploysite.pl test01 " + Global.ApacheConfig + " " + id +" "+ Global.homeFolder + "/aamt/" + _publishsettings + "\" > PreBash");
            result += Global.sshHelper.runSudoCMD("chmod u+x PreBash");

            return result;
        }
        private string RunMigrateScript()
        {
            string result = "";

            string cmd = Global.homeFolder + "/PreBash";
            result += Global.sshHelper.runSudoCMD(cmd);
            CleanUp();

            return result;
        }

        private void CleanUp() {

            Global.sshHelper.runSudoCMD("rm -rf " + Global.homeFolder + "/aamt/test01");
            Global.sshHelper.runSudoCMD("rm aamt.tar.gz PreScript PreBash PreListSite" + _publishsettings);
        }



        //public void RunCMDWithShell(string cmd)
        //{
        //    var commond = "echo \"" + this._sshHelper._password + "\" | sudo -S " + cmd;
        //    _worker = new BackgroundWorker();
        //    string result = "";
        //    _worker.DoWork += (object doWorkSender, DoWorkEventArgs doWorkEventArgs) =>
        //    {
        //        var reader = new StreamReader(_sshHelper.m_sshStream);
        //        var writer = new StreamWriter(_sshHelper.m_sshStream);
        //        writer.AutoFlush = true;

        //        result += ReadStream(reader);
        //        WriteStream(commond, writer, _sshHelper.m_sshStream);
        //        result += ReadStream(reader);
        //    };

        //    _worker.RunWorkerCompleted += (object runWorkerCompletedSender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs) =>
        //    {
        //        this.rtbStatus.Text += result;
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo(e.Link.LinkData.ToString());
            Process.Start(sInfo);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Parent.Controls.Add(new Page_3_2_ApacheChecking());
            Parent.Controls.Remove(this);
        }

        private void btBack_Click(object sender, EventArgs e)
        {

            Parent.Controls.Add(new Page_4_2_ChoosePublishSettings());
            Parent.Controls.Remove(this);
        }
    }
}
