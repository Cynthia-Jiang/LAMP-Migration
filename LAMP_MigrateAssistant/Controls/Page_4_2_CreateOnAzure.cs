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
using LAMP_MigrateAssistant.Models;
using ARMClient.Authentication.Contracts;
using AuthUtils = ARMClient.Authentication.Utilities.Utils;
using System.Net.Http;
using ARMClient.Authentication;
using System.IO;

namespace LAMP_MigrateAssistant.Controls
{
    public partial class Page_4_2_CreateOnAzure : UserControl
    {
        public Page_4_2_CreateOnAzure()
        {
            InitializeComponent();
            this._authHelper = new GuiPersistentAuthHelper();
            //this.btUploadPS.Enabled = false;
            //this.btUploadPS.Visible = false;
            this.gbResourceGroup.Enabled = false;
            this.gbCreateWebApp.Enabled = false;
            this.cbAccount.Enabled = false;
            this.cbSubscription.Enabled = false;
            this.btNext.Enabled = false;

        }
        private GuiPersistentAuthHelper _authHelper;
        private SSHHelper _sshHelper;
        private BackgroundWorker _worker;
        private string _publishSettingsFileName;

        private void btNext_Click(object sender, EventArgs e)
        {
            Parent.Controls.Add(new Page_5_Migration(_publishSettingsFileName));
            Parent.Controls.Remove(this);
        }

        private void PopulateTenant()
        {
            Dictionary<string, TenantCacheInfo> tenants = this._authHelper.GetTenants();
            this.cbAccount.DataSource = new List<TenantCacheInfo>(tenants.Values);
            this.cbAccount.DisplayMember = "domain";
            this.cbAccount.ValueMember = "tenantId";

            if (tenants.Count > 0)
            {
                string selectedTenantId = cbAccount.SelectedValue.ToString();

                if (!string.IsNullOrWhiteSpace(selectedTenantId))
                {
                    TenantCacheInfo tenant = tenants[selectedTenantId];
                    this.cbSubscription.DataSource = new List<SubscriptionCacheInfo>(tenant.subscriptions);
                    this.cbSubscription.DisplayMember = "domain";
                    this.cbSubscription.ValueMember = "subscriptionId";
                }
            }
        }
        private void cbAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTenantId = this.cbAccount.SelectedValue as string;

            if (!string.IsNullOrWhiteSpace(selectedTenantId))
            {
                Dictionary<string, TenantCacheInfo> tenants = this._authHelper.GetTenants();

                TenantCacheInfo tenant = tenants[selectedTenantId];
                this.cbSubscription.DataSource = new List<SubscriptionCacheInfo>(tenant.subscriptions);
                this.cbSubscription.DisplayMember = "domain";
                this.cbSubscription.ValueMember = "subscriptionId";
            }
        }
        private async void btLogin_Click(object sender, EventArgs e)
        {
            Global.AzureEnvironments = AzureEnvironments.Prod;
            this._authHelper.AzureEnvironments = AzureEnvironments.Prod;
            this.pbBusyStatue.Visible = true;
            this.lbMessage.Text = "Retrieving your Account and Subscirption information ...";
            try
            {
                await this._authHelper.AcquireTokens();
                PopulateTenant();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login Failed."+ex.Message);
                this.pbBusyStatue.Visible = false;
                return;
            }

            this.pbBusyStatue.Visible = false;
            this.gbResourceGroup.Enabled = true;
            this.cbAccount.Enabled = true;
            this.cbSubscription.Enabled = true;
            this.btNext.Enabled = true;
            this.lbMessage.Text = "Done!";
        }

        private async void Create_Click(object sender, EventArgs e)
        {
            try
            {


                var subscriptionId = cbSubscription.SelectedValue as string;
                //path "https://management.azure.com/subscriptions/<YourSubscriptionId>/resourcegroups/<YourResourceGroupName>/providers/Microsoft.Resources/deployments/<YourDeploymentName>?api-version=2015-01-01"
                var path = @"/subscriptions/"+
                    subscriptionId+@"/resourcegroups/"+
                    "Adamus1231231" + @"/providers/Microsoft.Resources/deployments/" +
                    tbWebAppName.Text+@"?api-version=2015-01-01";
                Uri uri = AuthUtils.EnsureAbsoluteUri(path, this._authHelper);
                var cacheInfo = await this._authHelper.GetToken(subscriptionId);
                var handler = new HttpHandler(new HttpClientHandler(), ConfigSettingFactory.ConfigSettings.Verbose);
                //HttpContent payload = new StringContent("{\"location\":\"East Asia\",\"properties\":{\"serverFarm\":\"Default0\"}}", Encoding.UTF8, Constants.JsonContentType);
                //"{\"location\":\"East Asia\",\"properties\":{\"serverFarm\":\"Default0\"}}";
                var _tmpPayloadFile = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WebAPPwithMySQLDB.json");
                HttpContent payload = new StringContent(File.ReadAllText(_tmpPayloadFile), Encoding.UTF8, Constants.JsonContentType);
                await AuthUtils.HttpInvoke(uri, cacheInfo, "put", handler, payload);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed."+ex.Message);
                return;
            }
        }

        private async void getSitePublishSettings(string siteName)
        {
            try
            {
                var subscriptionId = cbSubscription.SelectedValue as string;
                var path = @"/subscriptions/" + subscriptionId + @"/resourceGroups/default-web-eastasia/providers/Microsoft.Web/sites/"+siteName+@"/publishxml?api-version=2014-04-01";
                Uri uri = AuthUtils.EnsureAbsoluteUri(path, this._authHelper);
                var cacheInfo = await this._authHelper.GetToken(subscriptionId);
                var handler = new HttpHandler(new HttpClientHandler(), ConfigSettingFactory.ConfigSettings.Verbose, siteName);
                HttpContent payload = null;

                //this.labelHint.Text = "Downloading "+siteName+".publishSettings ...";
                await AuthUtils.HttpInvoke(uri, cacheInfo, "get", handler, payload);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Creating Failed."+ex.Message);
                return;
            }
            //MessageBox.Show("Create successfully and get PublishSettings.");
           // this.labelHint.Text = "Done!";
            //this.pictureBusy.Visible = false;
           // this.buttonNext.Enabled = true;
        }

        private async void btCreateRG_Click(object sender, EventArgs e)
        {
            try
            {
                this.pbBusyStatue.Visible = true;
                this.lbMessage.Text = "Creating Resource Group ...";
                var subscriptionId = cbSubscription.SelectedValue as string;

                //put "https://management.azure.com/subscriptions/{subscription-id}/resourcegroups/{resource-group-name}?api-version=2015-01-01"
                var path = @"/subscriptions/"+subscriptionId+@"/resourcegroups/"+tbRGName.Text+@"?api-version=2015-01-01";
                Uri uri = AuthUtils.EnsureAbsoluteUri(path, this._authHelper);
                var cacheInfo = await this._authHelper.GetToken(subscriptionId);
                var handler = new HttpHandler(new HttpClientHandler(), ConfigSettingFactory.ConfigSettings.Verbose);
                HttpContent payload = new StringContent("{\"location\": \""+this.cbRGLocation.SelectedItem+"\"}", Encoding.UTF8, Constants.JsonContentType);
                await AuthUtils.HttpInvoke(uri, cacheInfo, "put", handler, payload);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed.");
                return;
            }
            this.gbCreateWebApp.Enabled = true;
            this.pbBusyStatue.Visible = false;
            this.lbMessage.Text = "Done!";
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            Parent.Controls.Add(new Page_4_1_CreateOrChoose());
            Parent.Controls.Remove(this);
        }


        //private void btChoose_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog choofdlog = new OpenFileDialog();
        //    choofdlog.Filter = "PublishSetting File (*.PublishSettings)| *.PublishSettings";
        //    choofdlog.FilterIndex = 1;
        //    choofdlog.Multiselect = false;

        //    if (choofdlog.ShowDialog() == DialogResult.OK)
        //    {
        //        //this.tbPSLocation.Text = choofdlog.FileName;
        //        //this.btUploadPS.Enabled = true;
        //        _publishSettingsFileName = choofdlog.SafeFileName;

        //    }

        //}

        //private void btUploadPS_Click(object sender, EventArgs e)
        //{
        //    if (this._sshHelper.UploadFile(this.tbPSLocation.Text))
        //    {
        //        MessageBox.Show("Done! Please click \"Next\" to continue!");
        //        this.btNext.Enabled = true;
        //    }
        //    else
        //    {
        //        MessageBox.Show("Upload failed!");
        //    }

        //}



    }
}
