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
using ARMClient.Authentication.Contracts;
using AuthUtils = ARMClient.Authentication.Utilities.Utils;
using System.Net.Http;
using LAMP_MigrateAssistant.Models;
using ARMClient.Authentication;
using System.Net.Http.Headers;
using ARMClient.Authentication.Utilities;
using System.Web.Script.Serialization;
using System.IO;


namespace LAMP_MigrateAssistant.Controls
{
    public partial class Page_4_2_ChooseExitstingWebApp : UserControl
    {
        public Page_4_2_ChooseExitstingWebApp()
        {
            this._authHelper = new GuiPersistentAuthHelper();
            InitializeComponent();
            this.cbResouceList.Enabled = false;
            this.btNext.Enabled = false;
            this.group = new ResouceGroup();
            this.reslist = new List<Resouce>();
            this.subIdList = new List<string>();
            this.resgroup = new List<ResouceGroup>();
            this.btLogin.Enabled = false;
        }

        private GuiPersistentAuthHelper _authHelper;
        private ResouceGroup group;
        private List<Resouce> reslist;
        private string userDomain;
        private string subscriptionid;
        private List<string> subIdList;
        private List<ResouceGroup> resgroup;

        private async void btLogin_Click(object sender, EventArgs e)
        {
            this.gbAzure.Enabled = false;
            this.pbBusyStatue.Visible = true;
            this.lbMessage.Text = "Retrieving your candidate web app information ...";
            try
            {
                await this._authHelper.AcquireTokens();
                PopulateTenant();
                foreach(var item in subIdList)
                {
                    subscriptionid = item as string;
                    var grouplist=await getRescouceGroupList();
                    resgroup.InsertRange(0, grouplist);
                }
                foreach (var item in resgroup)
                {
                    group = item;
                    subscriptionid = item.subscriptionID;
                    var reslist1=await getResouceList();
                    reslist.InsertRange(0, reslist1);
                }

                cbResouceList.DataSource = reslist;
                this.cbResouceList.Enabled = true;
                this.pbBusyStatue.Visible = false;
                this.lbMessage.Text = "Done";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login Failed."+ex.Message);
                this.pbBusyStatue.Visible = false;
                return;
            }
        }
        private void PopulateTenant()
        {
            Dictionary<string, TenantCacheInfo> tenants = this._authHelper.GetTenants();
            List<TenantCacheInfo> listSource = new List<TenantCacheInfo>(tenants.Values);
            List<TenantCacheInfo> listSource1 = new List<TenantCacheInfo>();
            //MessageBox.Show("登录成功");
            foreach (var item in listSource)
            {
                Console.WriteLine(item.displayName);
                Console.WriteLine(item.domain);
                Console.WriteLine(item.tenantId);
                foreach (var sub in item.subscriptions)
                {
                    Console.WriteLine(sub.subscriptionId);
                    if(!subIdList.Contains(sub.subscriptionId))
                        subIdList.Add(sub.subscriptionId);
                }
            }
        }

        private async Task<List<ResouceGroup>> getRescouceGroupList()
        {
            try
            {
                this.pbBusyStatue.Visible = true;            

                //Get "https://management.azure.com/subscriptions/{subscription-id}/resourcegroups?api-version={api-version}&$top={top}$skiptoken={skiptoken}&$filter={filter}"
                var path = @"subscriptions/" + subscriptionid + @"/resourcegroups" + @"?api-version=2015-01-01";
                Uri uri = AuthUtils.EnsureAbsoluteUri(path, this._authHelper);
                var cacheInfo = await this._authHelper.GetToken(subscriptionid);

                using (var client = new HttpClient())
                {
                    //client.BaseAddress = new Uri("https://management.azure.com/");
                    // client.BaseAddress = new Uri("https://management.chinacloudapi.cn/");
                    client.BaseAddress = new Uri(Global.BaseUrls[(int)Global.AzureEnvironments]);
                    client.DefaultRequestHeaders.Add("Authorization", cacheInfo.CreateAuthorizationHeader());
                    client.DefaultRequestHeaders.Add("User-Agent", Constants.UserAgent.Value);
                    client.DefaultRequestHeaders.Add("Accept", Constants.JsonContentType);

                    if (Utils.IsRdfe(uri))
                    {
                        client.DefaultRequestHeaders.Add("x-ms-version", "2013-10-01");
                    }

                    client.DefaultRequestHeaders.Add("x-ms-request-id", Guid.NewGuid().ToString());
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // HTTP GET
                    HttpResponseMessage response = await client.GetAsync(path);
                    if (response.IsSuccessStatusCode)
                    {
                        var grouplist=await ProceseGetResourceGroupResponse(response);
                        return grouplist;
                    }
                    else
                    {
                        MessageBox.Show("Get Resource Group Failed.");
                        return null;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed: "+ ex.Message);
                return null;
            }
        }

        private async Task<List<ResouceGroup>> ProceseGetResourceGroupResponse(HttpResponseMessage _response){
            string responseBody = await _response.Content.ReadAsStringAsync();
            ResouceGroupList resourceGroupList = new JavaScriptSerializer().Deserialize<ResouceGroupList>(responseBody);
            //for debug YJ
            try
            {
                foreach (var item in resourceGroupList.value)
                {
                    item.subscriptionID = subscriptionid;
                    Console.WriteLine(item.name);
                    Console.WriteLine(item.id);
                    Console.WriteLine(item.location);
                    Console.WriteLine(item.subscriptionID);
                    //  group = item;
                    //  await getResouceList();
                    //MessageBox.Show(item.name);
                }
                return resourceGroupList.value;
               //YJYJ cbResouceList.DataSource = reslist;
               // this.cbResouceList.Enabled = true;
                //this.pbBusyStatue.Visible = false;
                //this.lbMessage.Text = "Done";
            }
            catch (Exception ex)
            {
                MessageBox.Show("get  All App List failed!");
                return null;
            }
            //for debug YJ
        }


        private async Task<List<Resouce>> getResouceList()
        {
            try
            {
                // this.pbBusyStatue.Visible = true;
                //                this.lbMessage.Text = "Querying Your WebApp Information ...";
                //var subscriptionId = cbSubscription.SelectedValue as string;
                // var resourceGroup = cbResourceGroupList.SelectedItem as ResouceGroup;

                //Get https://management.azure.com/subscriptions/{subscription-id}/resourcegroups/{resource-group-name}/resources?$top={top}$skiptoken={skiptoken}&$filter={filter}&api-version={api-version}
                var path = @"subscriptions/" + subscriptionid + @"/resourcegroups/" + group.name + @"/Resources?api-version=2015-01-01";
                Uri uri = AuthUtils.EnsureAbsoluteUri(path, this._authHelper);
                var cacheInfo = await this._authHelper.GetToken(subscriptionid);

                using (var client = new HttpClient())
                {
                   // client.BaseAddress = new Uri("https://management.azure.com/");
                    //client.BaseAddress = new Uri("https://management.chinacloudapi.cn/");
                    client.BaseAddress = new Uri(Global.BaseUrls[(int)Global.AzureEnvironments]);
                    client.DefaultRequestHeaders.Add("Authorization", cacheInfo.CreateAuthorizationHeader());
                    client.DefaultRequestHeaders.Add("User-Agent", Constants.UserAgent.Value);
                    client.DefaultRequestHeaders.Add("Accept", Constants.JsonContentType);

                    if (Utils.IsRdfe(uri))
                    {
                        client.DefaultRequestHeaders.Add("x-ms-version", "2013-10-01");
                    }

                    client.DefaultRequestHeaders.Add("x-ms-request-id", Guid.NewGuid().ToString());
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // HTTP GET
                    HttpResponseMessage response = await client.GetAsync(path);
                    if (response.IsSuccessStatusCode)
                    {
                        var listres=await ProceseGetResourcesListResponse(response);
                        return listres;
                    }
                    else
                    {
                        MessageBox.Show("Get Resources Failed.");
                        return null;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed: " + ex.Message);
                return null;
            }
        }

        private async Task<List<Resouce>> ProceseGetResourcesListResponse(HttpResponseMessage response)
        {
            string responseBody = await response.Content.ReadAsStringAsync();
            ReouceList resouceList = new JavaScriptSerializer().Deserialize<ReouceList>(responseBody);
            this.cbResouceList.Items.Clear();
            this.cbResouceList.DisplayMember = "name";
            List<Resouce> listres = new List<Resouce>();
            try
            {
                foreach (var item in resouceList.value)
                {
                    if (item.type == "Microsoft.Web/sites")
                    {
                        //cbResouceList.Items.Add(item);
                        item.group = group;
                        item.subscriptionID = subscriptionid;
                        Console.WriteLine(group.name);
                        Console.WriteLine(item.name);
                        listres.Add(item);
                    }
                }
                return listres;
            }
            catch (Exception ex)
            {
                MessageBox.Show(group.name + " get web app list failed");
                return null;
            }

        }

        private void cbResouceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var webapp = cbResouceList.SelectedItem as Resouce;
            tbWebLocation.Text = webapp.location;
            tbWebID.Text = webapp.id;
            tbWebGroup.Text = webapp.group.name;
            this.btNext.Enabled = true;
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            Parent.Controls.Add(new Page_4_1_CreateOrChoose());
            Parent.Controls.Remove(this);
        }

        private async void btNext_Click(object sender, EventArgs e)
        {
            try
            {
                lbMessage.Text = "Downloading PublishSettings file and upload to Linux server...";
                pbBusyStatue.Visible = true;
               // var subscriptionId = cbSubscription.SelectedValue as string;
                //var resouceGroup = cbResourceGroupList.SelectedItem as ResouceGroup;
                var webapp = cbResouceList.SelectedItem as Resouce;
                //var path = webapp.id + @"/publishxml?api-version=2014-04-01";
                var path = @"/subscriptions/" + webapp.subscriptionID + @"/resourceGroups/" + webapp.group.name + @"/providers/Microsoft.Web/sites/" + webapp.name + @"/publishxml?api-version=2014-04-01";
                Uri uri = AuthUtils.EnsureAbsoluteUri(path, this._authHelper);
                var cacheInfo = await this._authHelper.GetToken(webapp.subscriptionID);
                using (var client = new HttpClient())
                {
                    //client.BaseAddress = new Uri("https://management.azure.com/");
                    //client.BaseAddress = new Uri("https://management.chinacloudapi.cn/");
                    client.BaseAddress = new Uri(Global.BaseUrls[(int)Global.AzureEnvironments]);
                    client.DefaultRequestHeaders.Add("Authorization", cacheInfo.CreateAuthorizationHeader());
                    client.DefaultRequestHeaders.Add("User-Agent", Constants.UserAgent.Value);
                    client.DefaultRequestHeaders.Add("Accept", Constants.JsonContentType);

                    if (Utils.IsRdfe(uri))
                    {
                        client.DefaultRequestHeaders.Add("x-ms-version", "2013-10-01");
                    }

                    client.DefaultRequestHeaders.Add("x-ms-request-id", Guid.NewGuid().ToString()); 
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // HTTP GET
                    HttpResponseMessage response = await client.GetAsync(path);
                    if (response.IsSuccessStatusCode)
                    {
                         ProceseGetPublishSettingResponse(response);
                    }
                    else
                    {
                        MessageBox.Show("Get Resource Group Failed.");
                        return;
                    }

                }
                pbBusyStatue.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Download PublishSettings Failed."+ex.Message);
                return;
            }
        }
        private async void ProceseGetPublishSettingResponse(HttpResponseMessage response)
        {
            try {
            var webapp = cbResouceList.SelectedItem as Resouce;
            var publishSettingsFileName = webapp.name + ".azurewebsites.net.PublishSettings";
            string responseBody = await response.Content.ReadAsStringAsync();
           // MessageBox.Show(responseBody);
            var publishSettingFileLocation = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, publishSettingsFileName);
            //MessageBox.Show(publishSettingFileLocation);
            File.WriteAllText(publishSettingFileLocation, string.IsNullOrWhiteSpace(responseBody) ? "" : responseBody);
                //ugly
            if (Global.sshHelper.UploadFile(publishSettingsFileName, Global.homeFolder + "/aamt/"))
                this.btNext.Enabled = true;
            else
            {
                MessageBox.Show("Upload failed!");
                return;
            }

            Parent.Controls.Add(new Page_5_Migration( publishSettingsFileName));
            Parent.Controls.Remove(this);
            }
            catch(Exception ex)
            {
                MessageBox.Show("upload publish file failed" + ex.Message);
                return;
            }
        }


        private void btGlobal_CheckedChanged(object sender, EventArgs e)
        {
            this.btLogin.Enabled = true;
            Global.AzureEnvironments = AzureEnvironments.Prod;
            this._authHelper.AzureEnvironments= AzureEnvironments.Prod;
        }

        private void btMooncake_CheckedChanged(object sender, EventArgs e)
        {
            this.btLogin.Enabled = true;
            Global.AzureEnvironments = AzureEnvironments.Mooncake;
            this._authHelper.AzureEnvironments = AzureEnvironments.Mooncake;
        }
    }
}
