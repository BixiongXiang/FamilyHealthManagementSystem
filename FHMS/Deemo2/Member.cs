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
    public partial class Member : Form
    {
        MainFrame frm = null;
        public Member(MainFrame form)
        {
            
            frm = form;
            
            InitializeComponent();
            
        }

        private void Member_Load(object sender, EventArgs e)
        {
            string strCon = "server=" + MainFrame.sqlServer + ";database=" + MainFrame.sqlDatabase + ";uid=" + MainFrame.sqlUid + ";pwd=" + MainFrame.sqlPwd;
            SqlConnection sqlConn = new SqlConnection(strCon);
            try
            {
                sqlConn.Open();
            }
            catch
            {
                MessageBox.Show("网络连接错误，请检查网络是否可用。");
            }
            String sqlQuery = "select * from UserInfo"; //后期修改为从用户名中查找
            SqlDataAdapter mydata = new SqlDataAdapter();
            mydata.SelectCommand = new SqlCommand(sqlQuery, sqlConn);
            dataSet1.Clear();
            mydata.Fill(dataSet1, "UserInfo");

            listViewMember.Items[0].Text = dataSet1.Tables[0].Rows[0][1].ToString();//get name;
        }

        private void Member_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm.panel1.BringToFront();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PersonInfo personalinfo = new PersonInfo(this);
            personalinfo.MdiParent = frm;
            personalinfo.Show();
            //panel1.SendToBack();
        }
    }
}
