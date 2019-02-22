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
    public partial class ExaminationList : Form
    {
        public ExaminationList()
        {
            InitializeComponent();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string strCon = "server=" + MainFrame.sqlServer + ";database=" + MainFrame.sqlDatabase + ";uid=" + MainFrame.sqlUid + ";pwd=" + MainFrame.sqlPwd;
            SqlConnection sqlConn = new SqlConnection(strCon);
            try
            {

                sqlConn.Open();
                if (sqlConn.State != ConnectionState.Open) 
                { MessageBox.Show("连接失败！"); }
          
                String sql;
                String sqlSubjects = "";

                switch (cmbSubjects.FindString(cmbSubjects.Text))//吸烟 ← 有心情就标，不标也没事
                {
                    case 0: sqlSubjects = "Examination"; break;
                    case 1: sqlSubjects = "BloodRoutine"; break;
                    case 2: sqlSubjects = "BloodFat"; break;
                    case 3: sqlSubjects = "LiverTest"; break;
                    case 4: sqlSubjects = "Tumour"; break;
                    case 5: sqlSubjects = "UrineTest"; break;
                    case 6: sqlSubjects = "HepatitisB"; break;
                    case 7: sqlSubjects = "KidneyFunction"; break;
                    default: break;
                    //常规检查
                    //血常规检查
                    //血脂检查
                    //肝脏检查
                    //肿瘤检查
                    //尿常规
                    //乙肝检查
                    //肾脏检查
                }

                if (txtSearch.Text == "")
                {
                    sql = "select * from " + sqlSubjects;
                }
                else
                {
                    sql = "select * from " + sqlSubjects + " where Date='" + txtSearch.Text + "'";
                }

                SqlDataAdapter myda = new SqlDataAdapter();
                myda.SelectCommand = new SqlCommand(sql, sqlConn);

                //DataSet dataSetS = new DataSet();
                //Button a = new Button();
                //this.Controls.Add(dataSetS);

                dataSetS.Reset();
                myda.Fill(dataSetS, "ExResult");
                dataGridView1.DataSource = dataSetS.Tables["ExResult"];
            }
            catch
            {
                MessageBox.Show("查询错误！");
            }
        }
    }
}
