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
    public partial class PersonInfo : Form
    {
        Member mb = null;

        private String name = "";
        private String gender = "";  //   m/f
        private int age = 0;

        public PersonInfo()//原始构造函数
        {
            InitializeComponent();
        }
        public PersonInfo(Member member)//默认构造函数
        {
            mb = member;
            InitializeComponent();
        }

        private void PersonInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            //mb.panel1.BringToFront();
        }

        private void PersonInfo_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = mb.imageList1.Images[0];

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


            name = dataSet1.Tables[0].Rows[0][1].ToString();//get name
            name.Trim();
            gender = dataSet1.Tables[0].Rows[0][2].ToString();//getgender   m/f
            gender = gender.Trim();
            age = int.Parse(dataSet1.Tables[0].Rows[0][3].ToString().Trim());//get age
            updateInfo("basic");//update Frame.

            this.tabControl1.TabPages.Remove(tabControl1.TabPages[3]);
        }

        void updateInfo(String model) {
            if(model.CompareTo("basic") == 0){

                txtName.Text = name;

                if (gender.CompareTo("m") == 0)
                {// 若性别为男
                    cmbGender.SelectedIndex = 0;
                    labMammaryCa.Visible = false; 
                } 
                if (gender.CompareTo("f") == 0)
                {
                    cmbGender.SelectedIndex = 1;
                    labMammaryCa.Visible = true;     
                }

                txtAge.Text = age.ToString();
            }
        }
        private void button3_Click(object sender, EventArgs e)//疾病风险评估
        {
            //男性表单
            if (gender.CompareTo("m") == 0)
            {
                QuestionaireM questionaireM = new QuestionaireM(this);
                questionaireM.Show();
            }
            else
            {
                //女性表单
                if (gender.CompareTo("f") == 0)
                {
                    QuestionaireF questionaireF = new QuestionaireF(this);
                    questionaireF.Show();
                }
                else
                {
                    MessageBox.Show("请检查个人信息是否填写正确（手动填写需点击修改）");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double pCi = 0;
            double pDi = 0;
            double[] pBP = new double[3] { 0, 0, 0 };
            double[] pTC = new double[4] { 0, 0, 0 , 0 };
            double[] pHDL = new double[3] { 0, 0, 0 };

            double fx = 0;
            double resultChronic = 0;

            //获取结果
            switch (cmbCigarette.FindString(cmbCigarette.Text))//吸烟
            {
                case 0: pCi = 0; break;
                case 1: pCi = 1; break;
                default: break;
            }
            switch (cmbDiabetes.FindString(cmbDiabetes.Text))//糖尿病
            {
                case 0: pDi = 0; break;
                case 1: pDi = 1; break;
                default: break;
            }
            switch (cmbBP.FindString(cmbBP.Text))//BP
            {
                case 0: pBP[0] = 1; break;
                case 1: pBP[1] = 1; break;
                case 2: pBP[2] = 1; break;
                default: break;
            }
            switch (cmbTC.FindString(cmbTC.Text))//TC
            {
                case 0: pTC[0] = 1; break;
                case 1: pTC[1] = 1; break;
                case 2: pTC[2] = 1; break;
                case 3: pTC[3] = 1; break;
                default: break;
            }
            switch (cmbHDL.FindString(cmbHDL.Text))//HDL
            {
                case 0: pHDL[0] = 1; break;
                case 1: pHDL[1] = 1; break;
                case 2: pHDL[2] = 1; break;
                default: break;
            }
            //计算结果
            fx = 0.09*(age - 47.4) + 0.4*(pCi - 0.59) 
                + 0.75*(pBP[0] - 0.19) + 1.18*(pBP[1] - 0.07) + 1.76*(pBP[2] - 0.03) 
                + 0.47*(pTC[0] - 0.41) + 0.65*(pTC[1] - 0.22) + 0.78*(pTC[2] - 0.06) + 0.91*(pTC[3] - 0.03)
                - 0.21 * (pHDL[0] - 0.52) - 0.53 * (pHDL[1] - 0.33) - 0.7 * (pHDL[2] - 0.05)//此项可能有问题
                + 0.35*(pDi - 0.59);
            resultChronic = 1 - Math.Pow(0.979,Math.Exp(fx));

            //设置输出格式
            resultChronic *= 100.0;         
            labChronicResult.Text = "评估结果：" + resultChronic.ToString("0.00") + "%";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            QuestionaireSF36 questionaireSF36 = new QuestionaireSF36(this);
            questionaireSF36.Show();
        }

        private void button1_Click(object sender, EventArgs e)//修改基本信息
        {
            name = txtName.Text;
            age = int.Parse(txtAge.Text);//字符串转数字
            switch (cmbGender.FindString(cmbGender.Text))//
            {
                case 0: gender = "m"; break;
                case 1: gender = "f"; break;
                default: break;
            }
            MessageBox.Show("修改基本信息成功");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ExaminationList exNormal = new ExaminationList();
            exNormal.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("敬请期待");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ExaminationList exNormal = new ExaminationList();
            exNormal.Show();
        }

    }
}
