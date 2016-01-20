namespace LAMP_MigrateAssistant.Controls
{
    partial class Page_4_1_CreateOrChoose
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Page_4_1_CreateOrChoose));
            this.button1 = new System.Windows.Forms.Button();
            this.btChoose = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Image = global::LAMP_MigrateAssistant.Resource1._21;
            this.button1.Location = new System.Drawing.Point(121, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(341, 71);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btChoose
            // 
            this.btChoose.Image = ((System.Drawing.Image)(resources.GetObject("btChoose.Image")));
            this.btChoose.Location = new System.Drawing.Point(121, 226);
            this.btChoose.Name = "btChoose";
            this.btChoose.Size = new System.Drawing.Size(341, 71);
            this.btChoose.TabIndex = 1;
            this.btChoose.UseVisualStyleBackColor = true;
            this.btChoose.Click += new System.EventHandler(this.btChoose_Click);
            // 
            // button2
            // 
            this.button2.Image = global::LAMP_MigrateAssistant.Properties.Resources.Create;
            this.button2.Location = new System.Drawing.Point(121, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(341, 71);
            this.button2.TabIndex = 3;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Page_4_1_CreateOrChoose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btChoose);
            this.Name = "Page_4_1_CreateOrChoose";
            this.Size = new System.Drawing.Size(584, 378);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btChoose;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
