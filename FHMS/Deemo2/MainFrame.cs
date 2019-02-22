using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;//database namespace       


namespace Deemo2
{

    public partial class MainFrame : Form
    {
        public static String sqlServer = "JAMES-PC";
        public static String sqlDatabase = "HealthInfo";
        public static String sqlUid = "HMC";
        public static String sqlPwd = "HMC";
        //Sunisoft.IrisSkin.SkinEngine skin = new Sunisoft.IrisSkin.SkinEngine();//Skin
        
        public MainFrame()
        {
            Login login = new Login(this);
            login.Show();

            InitializeComponent();
            
            //Skin  请在References中重新添加IrisSkin4.dll
            //skin.SkinFile = System.Environment.CurrentDirectory + "\\skins\\" + "GG.ssk";
            //skin.Active = true;
        }

        private void main_Load(object sender, EventArgs e)
        {
         
            
        }
          
        private void button1_Click(object sender, EventArgs e)
        {
            this.panel1.SendToBack();

            Member member = new Member(this);
            member.MdiParent = this;
            member.Show();
            
        }

        private void MainFrame_Activated(object sender, EventArgs e)
        {
            if (Program.loginState == false)
            {
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.panel1.SendToBack();
            Browser browser = new Browser(this);
            browser.MdiParent = this;
            browser.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("敬请期待");
        }

        
    }
}
