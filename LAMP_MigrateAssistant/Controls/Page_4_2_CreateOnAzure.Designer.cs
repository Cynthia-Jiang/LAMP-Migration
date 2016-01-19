namespace LAMP_MigrateAssistant.Controls
{
    partial class Page_4_2_CreateOnAzure
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Page_4_2_CreateOnAzure));
            this.btNext = new System.Windows.Forms.Button();
            this.btCreate = new System.Windows.Forms.Button();
            this.lbWebsiteName = new System.Windows.Forms.Label();
            this.lbDBName = new System.Windows.Forms.Label();
            this.blRGLocation = new System.Windows.Forms.Label();
            this.lbResoureGroupName = new System.Windows.Forms.Label();
            this.tbDBName = new System.Windows.Forms.TextBox();
            this.tbWebAppName = new System.Windows.Forms.TextBox();
            this.btLogin = new System.Windows.Forms.Button();
            this.lbAccount = new System.Windows.Forms.Label();
            this.lbSubscription = new System.Windows.Forms.Label();
            this.cbAccount = new System.Windows.Forms.ComboBox();
            this.cbSubscription = new System.Windows.Forms.ComboBox();
            this.btCreateRG = new System.Windows.Forms.Button();
            this.lbMessage = new System.Windows.Forms.Label();
            this.tbRGName = new System.Windows.Forms.TextBox();
            this.gbLogin = new System.Windows.Forms.GroupBox();
            this.gbResourceGroup = new System.Windows.Forms.GroupBox();
            this.cbRGLocation = new System.Windows.Forms.ComboBox();
            this.gbCreateWebApp = new System.Windows.Forms.GroupBox();
            this.cbAPPLocation = new System.Windows.Forms.ComboBox();
            this.lbAppLocation = new System.Windows.Forms.Label();
            this.pbBusyStatue = new System.Windows.Forms.PictureBox();
            this.btBack = new System.Windows.Forms.Button();
            this.gbLogin.SuspendLayout();
            this.gbResourceGroup.SuspendLayout();
            this.gbCreateWebApp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBusyStatue)).BeginInit();
            this.SuspendLayout();
            // 
            // btNext
            // 
            this.btNext.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNext.Location = new System.Drawing.Point(482, 296);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(75, 23);
            this.btNext.TabIndex = 0;
            this.btNext.Text = "Next";
            this.btNext.UseVisualStyleBackColor = true;
            this.btNext.Click += new System.EventHandler(this.btNext_Click);
            // 
            // btCreate
            // 
            this.btCreate.Location = new System.Drawing.Point(398, 67);
            this.btCreate.Name = "btCreate";
            this.btCreate.Size = new System.Drawing.Size(119, 23);
            this.btCreate.TabIndex = 1;
            this.btCreate.Text = "Create Web APP";
            this.btCreate.UseVisualStyleBackColor = true;
            this.btCreate.Click += new System.EventHandler(this.Create_Click);
            // 
            // lbWebsiteName
            // 
            this.lbWebsiteName.AutoSize = true;
            this.lbWebsiteName.Location = new System.Drawing.Point(12, 22);
            this.lbWebsiteName.Name = "lbWebsiteName";
            this.lbWebsiteName.Size = new System.Drawing.Size(87, 13);
            this.lbWebsiteName.TabIndex = 2;
            this.lbWebsiteName.Text = "Web App Name";
            // 
            // lbDBName
            // 
            this.lbDBName.AutoSize = true;
            this.lbDBName.Location = new System.Drawing.Point(12, 47);
            this.lbDBName.Name = "lbDBName";
            this.lbDBName.Size = new System.Drawing.Size(124, 13);
            this.lbDBName.TabIndex = 2;
            this.lbDBName.Text = "MySQL Database Name";
            // 
            // blRGLocation
            // 
            this.blRGLocation.AutoSize = true;
            this.blRGLocation.Location = new System.Drawing.Point(12, 47);
            this.blRGLocation.Name = "blRGLocation";
            this.blRGLocation.Size = new System.Drawing.Size(137, 13);
            this.blRGLocation.TabIndex = 2;
            this.blRGLocation.Text = "Resource Gourp Location";
            // 
            // lbResoureGroupName
            // 
            this.lbResoureGroupName.AutoSize = true;
            this.lbResoureGroupName.Location = new System.Drawing.Point(12, 22);
            this.lbResoureGroupName.Name = "lbResoureGroupName";
            this.lbResoureGroupName.Size = new System.Drawing.Size(122, 13);
            this.lbResoureGroupName.TabIndex = 3;
            this.lbResoureGroupName.Text = "Resource Group Name";
            // 
            // tbDBName
            // 
            this.tbDBName.Location = new System.Drawing.Point(166, 44);
            this.tbDBName.Name = "tbDBName";
            this.tbDBName.Size = new System.Drawing.Size(206, 22);
            this.tbDBName.TabIndex = 6;
            // 
            // tbWebAppName
            // 
            this.tbWebAppName.Location = new System.Drawing.Point(166, 19);
            this.tbWebAppName.Name = "tbWebAppName";
            this.tbWebAppName.Size = new System.Drawing.Size(206, 22);
            this.tbWebAppName.TabIndex = 7;
            // 
            // btLogin
            // 
            this.btLogin.Location = new System.Drawing.Point(15, 24);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(119, 36);
            this.btLogin.TabIndex = 8;
            this.btLogin.Text = "Login";
            this.btLogin.UseVisualStyleBackColor = true;
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // lbAccount
            // 
            this.lbAccount.AutoSize = true;
            this.lbAccount.Location = new System.Drawing.Point(149, 24);
            this.lbAccount.Name = "lbAccount";
            this.lbAccount.Size = new System.Drawing.Size(49, 13);
            this.lbAccount.TabIndex = 9;
            this.lbAccount.Text = "Account";
            // 
            // lbSubscription
            // 
            this.lbSubscription.AutoSize = true;
            this.lbSubscription.Location = new System.Drawing.Point(149, 47);
            this.lbSubscription.Name = "lbSubscription";
            this.lbSubscription.Size = new System.Drawing.Size(72, 13);
            this.lbSubscription.TabIndex = 12;
            this.lbSubscription.Text = "Subscription";
            // 
            // cbAccount
            // 
            this.cbAccount.FormattingEnabled = true;
            this.cbAccount.Location = new System.Drawing.Point(237, 21);
            this.cbAccount.Name = "cbAccount";
            this.cbAccount.Size = new System.Drawing.Size(280, 21);
            this.cbAccount.TabIndex = 13;
            this.cbAccount.SelectedIndexChanged += new System.EventHandler(this.cbAccount_SelectedIndexChanged);
            // 
            // cbSubscription
            // 
            this.cbSubscription.FormattingEnabled = true;
            this.cbSubscription.Location = new System.Drawing.Point(237, 44);
            this.cbSubscription.Name = "cbSubscription";
            this.cbSubscription.Size = new System.Drawing.Size(280, 21);
            this.cbSubscription.TabIndex = 14;
            // 
            // btCreateRG
            // 
            this.btCreateRG.Location = new System.Drawing.Point(398, 42);
            this.btCreateRG.Name = "btCreateRG";
            this.btCreateRG.Size = new System.Drawing.Size(119, 23);
            this.btCreateRG.TabIndex = 15;
            this.btCreateRG.Text = "Create Resource Group";
            this.btCreateRG.UseVisualStyleBackColor = true;
            this.btCreateRG.Click += new System.EventHandler(this.btCreateRG_Click);
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.Location = new System.Drawing.Point(20, 356);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(0, 13);
            this.lbMessage.TabIndex = 16;
            // 
            // tbRGName
            // 
            this.tbRGName.Location = new System.Drawing.Point(166, 19);
            this.tbRGName.Name = "tbRGName";
            this.tbRGName.Size = new System.Drawing.Size(206, 22);
            this.tbRGName.TabIndex = 4;
            // 
            // gbLogin
            // 
            this.gbLogin.Controls.Add(this.btLogin);
            this.gbLogin.Controls.Add(this.lbAccount);
            this.gbLogin.Controls.Add(this.lbSubscription);
            this.gbLogin.Controls.Add(this.cbSubscription);
            this.gbLogin.Controls.Add(this.cbAccount);
            this.gbLogin.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbLogin.Location = new System.Drawing.Point(23, 13);
            this.gbLogin.Name = "gbLogin";
            this.gbLogin.Size = new System.Drawing.Size(534, 74);
            this.gbLogin.TabIndex = 17;
            this.gbLogin.TabStop = false;
            this.gbLogin.Text = "Log In";
            // 
            // gbResourceGroup
            // 
            this.gbResourceGroup.Controls.Add(this.cbRGLocation);
            this.gbResourceGroup.Controls.Add(this.lbResoureGroupName);
            this.gbResourceGroup.Controls.Add(this.blRGLocation);
            this.gbResourceGroup.Controls.Add(this.tbRGName);
            this.gbResourceGroup.Controls.Add(this.btCreateRG);
            this.gbResourceGroup.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbResourceGroup.Location = new System.Drawing.Point(23, 92);
            this.gbResourceGroup.Name = "gbResourceGroup";
            this.gbResourceGroup.Size = new System.Drawing.Size(534, 73);
            this.gbResourceGroup.TabIndex = 18;
            this.gbResourceGroup.TabStop = false;
            this.gbResourceGroup.Text = "Create Resource Group";
            // 
            // cbRGLocation
            // 
            this.cbRGLocation.FormattingEnabled = true;
            this.cbRGLocation.Items.AddRange(new object[] {
            "East Asia",
            "Australia East",
            "Australia Southeast",
            "Brazil South",
            "Central India",
            "Central US",
            "East US",
            "East US 2",
            "Japan East",
            "Japan West",
            "North Central US",
            "North Europe",
            "South Central US",
            "South India",
            "Southeast Asia",
            "West Europe",
            "West India",
            "West US"});
            this.cbRGLocation.Location = new System.Drawing.Point(166, 44);
            this.cbRGLocation.Name = "cbRGLocation";
            this.cbRGLocation.Size = new System.Drawing.Size(206, 21);
            this.cbRGLocation.TabIndex = 16;
            // 
            // gbCreateWebApp
            // 
            this.gbCreateWebApp.Controls.Add(this.cbAPPLocation);
            this.gbCreateWebApp.Controls.Add(this.lbAppLocation);
            this.gbCreateWebApp.Controls.Add(this.tbWebAppName);
            this.gbCreateWebApp.Controls.Add(this.btCreate);
            this.gbCreateWebApp.Controls.Add(this.lbWebsiteName);
            this.gbCreateWebApp.Controls.Add(this.lbDBName);
            this.gbCreateWebApp.Controls.Add(this.tbDBName);
            this.gbCreateWebApp.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCreateWebApp.Location = new System.Drawing.Point(23, 171);
            this.gbCreateWebApp.Name = "gbCreateWebApp";
            this.gbCreateWebApp.Size = new System.Drawing.Size(534, 100);
            this.gbCreateWebApp.TabIndex = 19;
            this.gbCreateWebApp.TabStop = false;
            this.gbCreateWebApp.Text = "Create Web Apps + MySQL";
            // 
            // cbAPPLocation
            // 
            this.cbAPPLocation.FormattingEnabled = true;
            this.cbAPPLocation.Items.AddRange(new object[] {
            "East Asia",
            "Australia East",
            "Australia Southeast",
            "Brazil South",
            "Central India",
            "Central US",
            "East US",
            "East US 2",
            "Japan East",
            "Japan West",
            "North Central US",
            "North Europe",
            "South Central US",
            "South India",
            "Southeast Asia",
            "West Europe",
            "West India",
            "West US"});
            this.cbAPPLocation.Location = new System.Drawing.Point(166, 69);
            this.cbAPPLocation.Name = "cbAPPLocation";
            this.cbAPPLocation.Size = new System.Drawing.Size(206, 21);
            this.cbAPPLocation.TabIndex = 9;
            // 
            // lbAppLocation
            // 
            this.lbAppLocation.AutoSize = true;
            this.lbAppLocation.Location = new System.Drawing.Point(12, 72);
            this.lbAppLocation.Name = "lbAppLocation";
            this.lbAppLocation.Size = new System.Drawing.Size(100, 13);
            this.lbAppLocation.TabIndex = 8;
            this.lbAppLocation.Text = "Web APP Location";
            // 
            // pbBusyStatue
            // 
            this.pbBusyStatue.Image = ((System.Drawing.Image)(resources.GetObject("pbBusyStatue.Image")));
            this.pbBusyStatue.Location = new System.Drawing.Point(23, 296);
            this.pbBusyStatue.Name = "pbBusyStatue";
            this.pbBusyStatue.Size = new System.Drawing.Size(35, 35);
            this.pbBusyStatue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbBusyStatue.TabIndex = 20;
            this.pbBusyStatue.TabStop = false;
            this.pbBusyStatue.Visible = false;
            // 
            // btBack
            // 
            this.btBack.Location = new System.Drawing.Point(401, 296);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(75, 23);
            this.btBack.TabIndex = 15;
            this.btBack.Text = "Back";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // Page_4_2_CreateOnAzure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.pbBusyStatue);
            this.Controls.Add(this.gbCreateWebApp);
            this.Controls.Add(this.gbResourceGroup);
            this.Controls.Add(this.gbLogin);
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.btNext);
            this.Name = "Page_4_2_CreateOnAzure";
            this.Size = new System.Drawing.Size(584, 378);
            this.gbLogin.ResumeLayout(false);
            this.gbLogin.PerformLayout();
            this.gbResourceGroup.ResumeLayout(false);
            this.gbResourceGroup.PerformLayout();
            this.gbCreateWebApp.ResumeLayout(false);
            this.gbCreateWebApp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBusyStatue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btNext;
        private System.Windows.Forms.Button btCreate;
        private System.Windows.Forms.Label lbWebsiteName;
        private System.Windows.Forms.Label lbDBName;
        private System.Windows.Forms.Label blRGLocation;
        private System.Windows.Forms.Label lbResoureGroupName;
        private System.Windows.Forms.TextBox tbDBName;
        private System.Windows.Forms.TextBox tbWebAppName;
        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.Label lbAccount;
        private System.Windows.Forms.Label lbSubscription;
        private System.Windows.Forms.ComboBox cbAccount;
        private System.Windows.Forms.ComboBox cbSubscription;
        private System.Windows.Forms.Button btCreateRG;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.TextBox tbRGName;
        private System.Windows.Forms.GroupBox gbLogin;
        private System.Windows.Forms.GroupBox gbResourceGroup;
        private System.Windows.Forms.GroupBox gbCreateWebApp;
        private System.Windows.Forms.Label lbAppLocation;
        private System.Windows.Forms.ComboBox cbRGLocation;
        private System.Windows.Forms.PictureBox pbBusyStatue;
        private System.Windows.Forms.ComboBox cbAPPLocation;
        private System.Windows.Forms.Button btBack;
    }
}
