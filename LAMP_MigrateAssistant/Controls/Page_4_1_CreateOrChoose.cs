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

namespace LAMP_MigrateAssistant.Controls
{
    public partial class Page_4_1_CreateOrChoose : UserControl
    {
        public Page_4_1_CreateOrChoose()
        {
            InitializeComponent();
            _sshHelper = Global.sshHelper;
        }
        private SSHHelper _sshHelper;

        private void btChoose_Click(object sender, EventArgs e)
        {
            Parent.Controls.Add(new Page_4_2_ChoosePublishSettings());
            Parent.Controls.Remove(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Parent.Controls.Add(new Page_4_2_ChooseExitstingWebApp());
            Parent.Controls.Remove(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Parent.Controls.Add(new Page_4_2_CreateOnAzure());
            Parent.Controls.Remove(this);
        }
    }
}
