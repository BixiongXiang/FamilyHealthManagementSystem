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
   
    public partial class Login : Form
    {
        MainFrame mf = null;
       
        //Set SQL Connection
        
        public Login(MainFrame mainframe)
        {
            
            mf = mainframe;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)//Login Button
        {
            string strCon = "server="+MainFrame.sqlServer+";database="+MainFrame.sqlDatabase+";uid="+MainFrame.sqlUid+";pwd="+MainFrame.sqlPwd;
                SqlConnection sqlConn = new SqlConnection(strCon);
            try
            {
                
                sqlConn.Open();
                if (sqlConn.State == ConnectionState.Open)
                {
                    label2.Text = "Loading succeed!";// MessageBox.Show("Loading succeed!");
                }
            }
            catch
            {
                MessageBox.Show("网络连接错误，请检查网络是否可用。");
            }
            String sqlQuery = "select * from Account";
            SqlDataAdapter mydata = new SqlDataAdapter();
            mydata.SelectCommand = new SqlCommand(sqlQuery, sqlConn);
            dataSet1.Clear();
            mydata.Fill(dataSet1, "Account");


            String uid = dataSet1.Tables[0].Rows[0][0].ToString();
            String pwd = dataSet1.Tables[0].Rows[0][1].ToString();
            
            label3.Text = "用户名： " + uid;//后期删除
            label4.Text = "密码： " + pwd;//后期删除

            uid = uid.Trim();
            pwd = pwd.Trim();

            label3.Text = "["+uid+"]";//后期删除
            label4.Text = "[" + pwd+"]";//后期删除

            if (textBox1.Text.CompareTo(uid) == 0 && textBox2.Text.CompareTo(pwd) == 0) //后期更改为正常判别方式
            {
                Program.loginState = true;
                label1.Visible = false;
                this.Close();
                mf.Show();
                mf.Activate();
            }
            else {
                label1.Visible = true;
            }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "") {
                textBox1.Text = "请输入用户名";
            }
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.Text = "";
            textBox2.UseSystemPasswordChar = true;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if(textBox2.Text == ""){
                textBox2.UseSystemPasswordChar = false;
                textBox2.Text = "请输入密码";
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(Program.loginState == false){
                Application.Exit();
            }
        }

        private void button3_Click(object sender, EventArgs e)//测试-连接数据库
        {
            
            try
            {
                string strCon = "server=JAMES-PC;database=StudentGrade;uid=HMC;pwd=HMC";

                SqlConnection sqlConn = new SqlConnection(strCon);
                sqlConn.Open();
                if (sqlConn.State == ConnectionState.Open)
                {
                    label2.Text = "Loading succeed!";
                    // MessageBox.Show("Loading succeed!");

                    String sql = "select * from StuInfo";
                    SqlDataAdapter mydata = new SqlDataAdapter();
                    mydata.SelectCommand = new SqlCommand(sql, sqlConn);
                    dataSet1.Clear();
                    mydata.Fill(dataSet1, "StuInfo");

                    String stuid = dataSet1.Tables[0].Rows[0][0].ToString();
                    label3.Text = "用户名" + stuid;
                }

                //string strCon = "server=USER-20160314EZ;database=jiankangguanli;uid=WYY;pwd=2040";

                //SqlConnection sqlConn = new SqlConnection(strCon);
                //sqlConn.Open();
                //if (sqlConn.State == ConnectionState.Open)
                //{
                //    label2.Text = "Loading succeed!";
                //    MessageBox.Show("Loading succeed!");

                //    String sql = "select * from Account";
                //    SqlDataAdapter mydata = new SqlDataAdapter();
                //    mydata.SelectCommand = new SqlCommand(sql, sqlConn);
                //    mydata.Fill(dataSet1, "Account");

                //    String stuid = dataSet1.Tables[0].Rows[0][0].ToString();
                //    label3.Text = "用户名" + stuid;
                //}
            }
            catch
            {
                label2.Text = "Loading Failed! Please Check Your Network!";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string strCon = "server=JAMES-PC;database=StudentGrade;uid=HMC;pwd=HMC";

                SqlConnection sqlConn = new SqlConnection(strCon);
                sqlConn.Open();
                if (sqlConn.State == ConnectionState.Open)
                {
                    label2.Text = "Loading succeed!";
                    // MessageBox.Show("Loading succeed!");

                    SqlCommand sqlCom = new SqlCommand();
                    sqlCom.Connection = sqlConn;
                    sqlCom.CommandType = CommandType.Text;
                    sqlCom.CommandText = "update StuInfo set StuID=321 where StuName='xbx'";
                    //SqlDataReader dr = 
                    sqlCom.ExecuteReader();//执行SQL语句

                    label2.Text = "Update succeed!";
                }
            }
            catch
            {
                label2.Text = "Loading Failed! Please Check Your Network!";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string strCon = "server=JAMES-PC;database=StudentGrade;uid=HMC;pwd=HMC";

                SqlConnection sqlConn = new SqlConnection(strCon);
                sqlConn.Open();
                if (sqlConn.State == ConnectionState.Open)
                {
                    label2.Text = "Loading succeed!";
                    // MessageBox.Show("Loading succeed!");

                    SqlCommand sqlCom = new SqlCommand();
                    sqlCom.Connection = sqlConn;
                    sqlCom.CommandType = CommandType.Text;
                    sqlCom.CommandText = "update StuInfo set StuID=14282038 where StuName='xbx'";
                    //SqlDataReader dr = 
                    sqlCom.ExecuteReader();//执行SQL语句

                    label2.Text = "Update succeed!";
                }
            }
            catch
            {
                label2.Text = "Loading Failed! Please Check Your Network!";
            }
        }

        private void btnAdminLogin_Click(object sender, EventArgs e)
        {
            Program.loginState = true;
            label1.Visible = false;
            this.Close();
            mf.Show();
            mf.Activate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("敬请期待");
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtS.Text = MainFrame.sqlServer;
            txtD.Text = MainFrame.sqlDatabase;
            txtU.Text = MainFrame.sqlUid;
            txtP.Text = MainFrame.sqlPwd;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainFrame.sqlServer = txtS.Text;
            MainFrame.sqlDatabase = txtD.Text;
            MainFrame.sqlUid = txtU.Text;
            MainFrame.sqlPwd = txtP.Text;
            MessageBox.Show("修改成功");
        }
    }
}
