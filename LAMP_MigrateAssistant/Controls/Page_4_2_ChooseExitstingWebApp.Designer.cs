namespace LAMP_MigrateAssistant.Controls
{
    partial class Page_4_2_ChooseExitstingWebApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Page_4_2_ChooseExitstingWebApp));
            this.btLogin = new System.Windows.Forms.Button();
            this.lbMessage = new System.Windows.Forms.Label();
            this.pbBusyStatue = new System.Windows.Forms.PictureBox();
            this.gbResourceGroup = new System.Windows.Forms.GroupBox();
            this.tbWebGroup = new System.Windows.Forms.TextBox();
            this.tbWebLocation = new System.Windows.Forms.TextBox();
            this.tbWebID = new System.Windows.Forms.TextBox();
            this.lbWebAppGroup = new System.Windows.Forms.Label();
            this.lbWebAppID = new System.Windows.Forms.Label();
            this.lbWebappLocation = new System.Windows.Forms.Label();
            this.cbResouceList = new System.Windows.Forms.ComboBox();
            this.btBack = new System.Windows.Forms.Button();
            this.btNext = new System.Windows.Forms.Button();
            this.gbAzure = new System.Windows.Forms.GroupBox();
            this.btMooncake = new System.Windows.Forms.RadioButton();
            this.btGlobal = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pbBusyStatue)).BeginInit();
            this.gbResourceGroup.SuspendLayout();
            this.gbAzure.SuspendLayout();
            this.SuspendLayout();
            // 
            // btLogin
            // 
            this.btLogin.Location = new System.Drawing.Point(373, 32);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(103, 46);
            this.btLogin.TabIndex = 8;
            this.btLogin.Text = "Log in";
            this.btLogin.UseVisualStyleBackColor = true;
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.Location = new System.Drawing.Point(20, 356);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(0, 13);
            this.lbMessage.TabIndex = 21;
            // 
            // pbBusyStatue
            // 
            this.pbBusyStatue.Image = ((System.Drawing.Image)(resources.GetObject("pbBusyStatue.Image")));
            this.pbBusyStatue.Location = new System.Drawing.Point(23, 296);
            this.pbBusyStatue.Name = "pbBusyStatue";
            this.pbBusyStatue.Size = new System.Drawing.Size(35, 35);
            this.pbBusyStatue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbBusyStatue.TabIndex = 22;
            this.pbBusyStatue.TabStop = false;
            this.pbBusyStatue.Visible = false;
            // 
            // gbResourceGroup
            // 
            this.gbResourceGroup.Controls.Add(this.tbWebGroup);
            this.gbResourceGroup.Controls.Add(this.tbWebLocation);
            this.gbResourceGroup.Controls.Add(this.tbWebID);
            this.gbResourceGroup.Controls.Add(this.lbWebAppGroup);
            this.gbResourceGroup.Controls.Add(this.lbWebAppID);
            this.gbResourceGroup.Controls.Add(this.lbWebappLocation);
            this.gbResourceGroup.Controls.Add(this.cbResouceList);
            this.gbResourceGroup.Location = new System.Drawing.Point(73, 119);
            this.gbResourceGroup.Name = "gbResourceGroup";
            this.gbResourceGroup.Size = new System.Drawing.Size(403, 171);
            this.gbResourceGroup.TabIndex = 23;
            this.gbResourceGroup.TabStop = false;
            this.gbResourceGroup.Text = "Please choose your destination Web Apps: ";
            // 
            // tbWebGroup
            // 
            this.tbWebGroup.Location = new System.Drawing.Point(131, 119);
            this.tbWebGroup.Name = "tbWebGroup";
            this.tbWebGroup.Size = new System.Drawing.Size(231, 20);
            this.tbWebGroup.TabIndex = 23;
            // 
            // tbWebLocation
            // 
            this.tbWebLocation.Location = new System.Drawing.Point(131, 91);
            this.tbWebLocation.Name = "tbWebLocation";
            this.tbWebLocation.Size = new System.Drawing.Size(231, 20);
            this.tbWebLocation.TabIndex = 22;
            // 
            // tbWebID
            // 
            this.tbWebID.Location = new System.Drawing.Point(101, 66);
            this.tbWebID.Name = "tbWebID";
            this.tbWebID.Size = new System.Drawing.Size(261, 20);
            this.tbWebID.TabIndex = 21;
            // 
            // lbWebAppGroup
            // 
            this.lbWebAppGroup.AutoSize = true;
            this.lbWebAppGroup.Location = new System.Drawing.Point(25, 119);
            this.lbWebAppGroup.Name = "lbWebAppGroup";
            this.lbWebAppGroup.Size = new System.Drawing.Size(87, 13);
            this.lbWebAppGroup.TabIndex = 20;
            this.lbWebAppGroup.Text = "Web App Group:";
            // 
            // lbWebAppID
            // 
            this.lbWebAppID.AutoSize = true;
            this.lbWebAppID.Location = new System.Drawing.Point(22, 66);
            this.lbWebAppID.Name = "lbWebAppID";
            this.lbWebAppID.Size = new System.Drawing.Size(72, 13);
            this.lbWebAppID.TabIndex = 19;
            this.lbWebAppID.Text = "Web App ID: ";
            // 
            // lbWebappLocation
            // 
            this.lbWebappLocation.AutoSize = true;
            this.lbWebappLocation.Location = new System.Drawing.Point(22, 91);
            this.lbWebappLocation.Name = "lbWebappLocation";
            this.lbWebappLocation.Size = new System.Drawing.Size(102, 13);
            this.lbWebappLocation.TabIndex = 18;
            this.lbWebappLocation.Text = "Web App Location: ";
            // 
            // cbResouceList
            // 
            this.cbResouceList.FormattingEnabled = true;
            this.cbResouceList.Location = new System.Drawing.Point(25, 29);
            this.cbResouceList.Name = "cbResouceList";
            this.cbResouceList.Size = new System.Drawing.Size(337, 21);
            this.cbResouceList.TabIndex = 16;
            this.cbResouceList.SelectedIndexChanged += new System.EventHandler(this.cbResouceList_SelectedIndexChanged);
            // 
            // btBack
            // 
            this.btBack.Location = new System.Drawing.Point(401, 296);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(75, 23);
            this.btBack.TabIndex = 26;
            this.btBack.Text = "Back";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // btNext
            // 
            this.btNext.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNext.Location = new System.Drawing.Point(482, 296);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(75, 23);
            this.btNext.TabIndex = 25;
            this.btNext.Text = "Next";
            this.btNext.UseVisualStyleBackColor = true;
            this.btNext.Click += new System.EventHandler(this.btNext_Click);
            // 
            // gbAzure
            // 
            this.gbAzure.Controls.Add(this.btMooncake);
            this.gbAzure.Controls.Add(this.btGlobal);
            this.gbAzure.Location = new System.Drawing.Point(40, 4);
            this.gbAzure.Name = "gbAzure";
            this.gbAzure.Size = new System.Drawing.Size(280, 93);
            this.gbAzure.TabIndex = 27;
            this.gbAzure.TabStop = false;
            this.gbAzure.Text = "Choose Azure Enviroment:";
            // 
            // btMooncake
            // 
            this.btMooncake.AutoSize = true;
            this.btMooncake.Location = new System.Drawing.Point(12, 57);
            this.btMooncake.Name = "btMooncake";
            this.btMooncake.Size = new System.Drawing.Size(76, 17);
            this.btMooncake.TabIndex = 1;
            this.btMooncake.TabStop = true;
            this.btMooncake.Text = "Mooncake";
            this.btMooncake.UseVisualStyleBackColor = true;
            this.btMooncake.CheckedChanged += new System.EventHandler(this.btMooncake_CheckedChanged);
            // 
            // btGlobal
            // 
            this.btGlobal.AutoSize = true;
            this.btGlobal.Location = new System.Drawing.Point(12, 28);
            this.btGlobal.Name = "btGlobal";
            this.btGlobal.Size = new System.Drawing.Size(85, 17);
            this.btGlobal.TabIndex = 0;
            this.btGlobal.TabStop = true;
            this.btGlobal.Text = "Global Azure";
            this.btGlobal.UseVisualStyleBackColor = true;
            this.btGlobal.CheckedChanged += new System.EventHandler(this.btGlobal_CheckedChanged);
            // 
            // Page_4_2_ChooseExitstingWebApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbAzure);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.btLogin);
            this.Controls.Add(this.gbResourceGroup);
            this.Controls.Add(this.btNext);
            this.Controls.Add(this.pbBusyStatue);
            this.Controls.Add(this.lbMessage);
            this.Name = "Page_4_2_ChooseExitstingWebApp";
            this.Size = new System.Drawing.Size(584, 378);
            ((System.ComponentModel.ISupportInitialize)(this.pbBusyStatue)).EndInit();
            this.gbResourceGroup.ResumeLayout(false);
            this.gbResourceGroup.PerformLayout();
            this.gbAzure.ResumeLayout(false);
            this.gbAzure.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.PictureBox pbBusyStatue;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.GroupBox gbResourceGroup;
        private System.Windows.Forms.ComboBox cbResouceList;
        private System.Windows.Forms.Label lbWebappLocation;
        private System.Windows.Forms.Button btBack;
        private System.Windows.Forms.Button btNext;
        private System.Windows.Forms.Label lbWebAppID;
        private System.Windows.Forms.Label lbWebAppGroup;
        private System.Windows.Forms.TextBox tbWebGroup;
        private System.Windows.Forms.TextBox tbWebLocation;
        private System.Windows.Forms.TextBox tbWebID;
        private System.Windows.Forms.GroupBox gbAzure;
        private System.Windows.Forms.RadioButton btMooncake;
        private System.Windows.Forms.RadioButton btGlobal;
    }
}
