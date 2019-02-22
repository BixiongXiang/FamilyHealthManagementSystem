using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deemo2
{
    public partial class QuestionaireF : Form
    {
        double result = 0;
        PersonInfo pinfo = null;
        public QuestionaireF(PersonInfo pinf)
        {
            InitializeComponent();
            pinfo = pinf;
        }

        private void CalRisk(String illType)
        {//calculate desease risk
            /*********************************************************************************************************************************************8*/
            /*计算肺癌的风险，一个if结构对应一种病，标一下病名*/
            if (illType.CompareTo("LungCancer") == 0)
            {
                double pMul = 1;
                double pPlus = 0;                

                switch (cmbLung1.FindString(cmbLung1.Text))//吸烟 ← 有心情就标，不标也没事
                {
                    case 0: pMul *= 0.97; break;
                    case 1: pPlus += 1.20 - 1; break;
                    case 2: pPlus += 2.94 - 1; break;
                    case 3: pPlus += 6.08 - 1; break;
                    case 4: pPlus += 1.47 - 1; break;
                    default: break;
                }
                switch (cmbLung2.FindString(cmbLung2.Text))//被动吸烟指数（PSI=每日吸烟支数*吸烟年数）
                {
                    case 0: pPlus += 1.13 - 1; break;
                    case 1: pMul *= 0.72; break;
                    case 2: pPlus += 1.39 - 1; break;
                    case 3: pPlus += 1.54 - 1; break;
                    case 4: pPlus += 2.87 - 1; break;
                    default: break;
                }
                switch (cmbLung3.FindString(cmbLung3.Text))//呼吸病史
                {
                    case 0: pMul *= 0.83; break;
                    case 1: pPlus += 1.90 - 1; break;
                    default: break;
                }
                switch (cmbLung4.FindString(cmbLung4.Text))//家族肿瘤史
                {
                    case 0: pMul *= 0.89; break;
                    case 1: pPlus += 1.62 - 1; break;
                    default: break;
                }
                switch (cmbLung5.FindString(cmbLung5.Text))//长期精神压抑
                {
                    case 0: pMul *= 0.89; break;
                    case 1: pPlus += 2.36 - 1; break;
                    default: break;
                }
                result = pMul + pPlus;
            }

            //计算肝癌的风险
            if (illType.CompareTo("LiverCancer") == 0)
            {
                double pMul = 1;
                double pPlus = 0;

                switch (cmbLiver1.FindString(cmbLiver1.Text))//乙型肝炎
                {
                    case 0: pMul *= 0.67; break;
                    case 1: pPlus += 4.11 - 1; break;
                    default: break;
                }
                switch (cmbLiver2.FindString(cmbLiver2.Text))//吸烟
                {
                    case 0: pMul *= 0.83; break;
                    case 1: pPlus += 1.12 - 1; break;
                    default: break;
                }
                switch (cmbLiver3.FindString(cmbLiver3.Text))//家族肝癌史
                {
                    case 0: pMul *= 0.33; break;
                    case 1: pMul *= 0.50; break;
                    case 2: pPlus += 3.60 - 1; break;
                    case 3: pPlus += 7.68 - 1; break;
                    default: break;
                }
                switch (cmbLiver4.FindString(cmbLiver4.Text))//饮酒
                {
                    case 0: pMul *= 0.92; break;
                    case 1: pPlus += 1.47 - 1; break;
                    default: break;
                }
                result = pMul + pPlus;
            }

            //计算乳腺癌的风险
            if (illType.CompareTo("MammaryCancer") == 0)
            {
                double pMul = 1;
                double pPlus = 0;

                switch (cmbMammary1.FindString(cmbMammary1.Text))//初潮年龄
                {
                    case 0: pMul *= 0.73; break;
                    case 1: pPlus += 1.05 - 1; break;
                    case 2: pPlus += 1.29 - 1; break;
                    default: break;
                }
                switch (cmbMammary2.FindString(cmbMammary2.Text))//初产年龄
                {
                    case 0: pMul *= 0.76; break;
                    case 1: pPlus += 1.32 - 1; break;
                    case 2: pPlus += 1.58 - 1; break;
                    default: break;
                }
                switch (cmbMammary3.FindString(cmbMammary3.Text))//产次
                {
                    case 0: pMul *= 0.80; break;
                    case 1: pPlus += 1.26 - 1; break;
                    case 3: pPlus += 1.92 - 1; break;
                    default: break;
                }
                switch (cmbMammary4.FindString(cmbMammary4.Text))//绝经年龄
                {
                    case 0: pMul *= 0.67; break;
                    case 1: pPlus += 1.03 - 1; break;
                    case 2: pPlus += 1.15 - 1; break;
                    default: break;
                }
                switch (cmbMammary5.FindString(cmbMammary5.Text))//家族史
                {
                    case 0: pMul *= 0.96; break;
                    case 1: pPlus += 3.82 - 1; break;
                    default: break;
                }
                switch (cmbMammary6.FindString(cmbMammary6.Text))//乳腺病史
                {
                    case 0: pMul *= 0.85; break;
                    case 1: pPlus += 3.95 - 1; break;
                    default: break;
                }
                switch (cmbMammary7.FindString(cmbMammary7.Text))//超重（BMI>=25）
                {
                    case 0: pPlus += 1.40 - 1; break;
                    case 1: pMul *= 0.93; break;
                    default: break;
                }
                result = pMul + pPlus;
            }


            //计算食管癌的风险
            if (illType.CompareTo("EsophagusCancer") == 0)
            {
                double pMul = 1;
                double pPlus = 0;

                switch (cmbEsophagus1.FindString(cmbEsophagus1.Text))//吸烟
                {
                    case 0: pMul *= 0.97; break;
                    case 1: pPlus += 1.52 - 1; break;
                    case 2: pPlus += 2.42 - 1; break;
                    case 3: pPlus += 1.58 - 1; break;
                    default: break;
                }
                switch (cmbEsophagus2.FindString(cmbEsophagus2.Text))//家族史
                {
                    case 0: pMul *= 0.80; break;
                    case 1: pPlus += 3.75 - 1; break;
                    default: break;
                }
                switch (cmbEsophagus3.FindString(cmbEsophagus3.Text))//饮酒
                {
                    case 0: pMul *= 0.88; break;
                    case 1: pPlus += 1.68 - 1; break;
                    default: break;
                }
                result = pMul + pPlus;
            }

            //计算胃癌的风险
            if (illType.CompareTo("GastricCancer") == 0)
            {
                double pMul = 1;
                double pPlus = 0;

                switch (cmbGastric1.FindString(cmbGastric1.Text))//吸烟
                {
                    case 0: pMul *= 0.98; break;
                    case 1: pPlus += 2.06 - 1; break;
                    default: break;
                }
                switch (cmbGastric2.FindString(cmbGastric2.Text))//饮酒
                {
                    case 0: pMul *= 0.88; break;
                    case 1: pPlus += 1.66 - 1; break;
                    default: break;
                }
                switch (cmbGastric3.FindString(cmbGastric3.Text))//食用油炸食品
                {
                    case 0: pMul *= 0.93; break;
                    case 1: pPlus += 1.45 - 1; break;
                    default: break;
                }
                switch (cmbGastric4.FindString(cmbGastric4.Text))//食用腌制食品
                {
                    case 0: pMul *= 0.98; break;
                    case 1: pPlus += 1.36 - 1; break;
                    default: break;
                }
                switch (cmbGastric5.FindString(cmbGastric5.Text))//食用新鲜蔬菜
                {
                    case 0: pPlus += 2.23 - 1; break;
                    case 1: pMul *= 0.98; break;
                    default: break;
                }
                switch (cmbGastric6.FindString(cmbGastric6.Text))//摄盐
                {
                    case 0: pMul *= 0.80; break;
                    case 1: pPlus += 1.64 - 1; break;
                    default: break;
                }
                switch (cmbGastric7.FindString(cmbGastric7.Text))//胃癌家族史
                {
                    case 0: pMul *= 0.72; break;
                    case 1: pPlus += 2.21 - 1; break;
                    default: break;
                }
                switch (cmbGastric8.FindString(cmbGastric8.Text))//生闷气吃饭
                {
                    case 0: pMul *= 0.99; break;
                    case 1: pPlus += 2.97 - 1; break;
                    default: break;
                }
                result = pMul + pPlus;
            }

            //计算膀胱癌的风险
            if (illType.CompareTo("BladderCancer") == 0)
            {
                double pMul = 1;
                double pPlus = 0;

                switch (cmbBladder1.FindString(cmbBladder1.Text))//吸烟
                {
                    case 0: pMul *= 0.98; break;
                    case 1: pPlus += 1.22 - 1; break;
                    case 2: pPlus += 1.90 - 1; break;
                    case 3: pPlus += 2.78 - 1; break;
                    case 4: pPlus += 1.43 - 1; break;
                    case 5: pPlus += 1.18 - 1; break;
                    default: break;
                }
                switch (cmbBladder2.FindString(cmbBladder2.Text))//职业暴露
                {
                    case 0: pMul *= 0.92; break;
                    case 1: pPlus += 4.78 - 1; break;
                    case 2: pPlus += 1.84 - 1; break;
                    default: break;
                }
                switch (cmbBladder3.FindString(cmbBladder3.Text))//每年用糖精次数
                {
                    case 0: pMul *= 0.67; break;
                    case 1: pPlus += 1.47 - 1; break;
                    case 2: pPlus += 2.85 - 1; break;
                    default: break;
                }
                result = pMul + pPlus;
            }

            //计算大肠癌的风险
            if (illType.CompareTo("ColonCancer") == 0)
            {
                double pMul = 1;
                double pPlus = 0;

                switch (cmbColon1.FindString(cmbColon1.Text))//肠息肉
                {
                    case 0: pMul *= 0.96; break;
                    case 1: pPlus += 21.54 - 1; break;
                    default: break;
                }
                switch (cmbColon2.FindString(cmbColon2.Text))//溃疡性结肠炎
                {
                    case 0: pMul *= 0.99; break;
                    case 1: pPlus += 2.58 - 1; break;
                    default: break;
                }
                switch (cmbColon3.FindString(cmbColon3.Text))//血吸虫史
                {
                    case 0: pMul *= 0.99; break;
                    case 1: pPlus += 1.59 - 1; break;
                    default: break;
                }
                switch (cmbColon4.FindString(cmbColon4.Text))//食用油炸食品
                {
                    case 0: pMul *= 0.81; break;
                    case 1: pPlus += 1.12 - 1; break;
                    case 2: pPlus += 1.54 - 1; break;
                    default: break;
                }
                switch (cmbColon5.FindString(cmbColon5.Text))//食用腌制食品
                {
                    case 0: pMul *= 0.92; break;
                    case 1: pPlus += 1.15 - 1; break;
                    case 2: pPlus += 1.44 - 1; break;
                    default: break;
                }
                switch (cmbColon6.FindString(cmbColon6.Text))//食用新鲜蔬菜
                {
                    case 0: pPlus += 1.44; break;
                    case 1: pPlus += 1.19 - 1; break;
                    case 2: pMul *= 0.99; break;
                    default: break;
                }
                result = pMul + pPlus;
            }

            //计算冠心病的风险
            if (illType.CompareTo("CoronaryDisease") == 0)
            {
                double pMul = 1;
                double pPlus = 0;

                switch (cmbCAD1.FindString(cmbCAD1.Text))//吸烟
                {
                    case 0: pMul *= 0.98; break;
                    case 1: pPlus += 1.73 - 1; break;
                    case 2: pPlus += 2.07 - 1; break;
                    case 3: pPlus += 3.79 - 1; break;
                    case 4: pPlus += 1.10 - 1; break;
                    default: break;
                }
                switch (cmbCAD2.FindString(cmbCAD2.Text))//饮酒
                {
                    case 0: pMul *= 0.93; break;
                    case 1: pPlus += 1.93 - 1; break;
                    default: break;
                }
                switch (cmbCAD3.FindString(cmbCAD3.Text))//高血压家族史
                {
                    case 0: pMul *= 0.64; break;
                    case 1: pPlus += 1.93 - 1; break;
                    default: break;
                }
                switch (cmbCAD4.FindString(cmbCAD4.Text))//高胆固醇血症
                {
                    case 0: pMul *= 0.83; break;
                    case 1: pPlus += 1.41 - 1; break;
                    default: break;
                }


                switch (cmbCAD51.FindString(cmbCAD51.Text))//血压 51-收缩压 52-舒张压
                {
                    case 0:
                        switch (cmbCAD52.FindString(cmbCAD52.Text))//饮酒
                        {
                            case 0: pMul *= 0.95; break;
                            case 1: pPlus += 2.01 - 1; break;
                            case 2: pPlus += 1.05 - 1; break;
                            default: break;
                        }
                        break;
                    case 1:
                        switch (cmbCAD52.FindString(cmbCAD52.Text))//饮酒
                        {
                            case 0: pPlus += 1.89 - 1; break;
                            case 1: pPlus += 2.35 - 1; break;
                            case 2: pPlus += 2.55 - 1; break;
                            default: break;
                        }
                        break;
                    case 2:
                        switch (cmbCAD52.FindString(cmbCAD52.Text))//饮酒
                        {
                            case 0: pPlus += 7.14 - 1; break;
                            case 1: pPlus += 2.23 - 1; break;
                            case 2: pPlus += 2.60 - 1; break;
                            default: break;
                        }
                        break;
                    default: break;
                } 

                switch (cmbCAD6.FindString(cmbCAD6.Text))//超重
                {
                    case 0: pMul *= 0.94; break;
                    case 1: pPlus += 1.48 - 1; break;
                    case 2: pPlus += 2.42 - 1; break;
                    case 3: pPlus += 2.82 - 1; break;
                    default: break;
                }
                switch (cmbCAD7.FindString(cmbCAD7.Text))//体育锻炼
                {
                    case 0: pPlus += 1.26 - 1; break;
                    case 1: pMul *= 0.66; break;
                    default: break;
                }
                switch (cmbCAD8.FindString(cmbCAD8.Text))//糖尿病
                {
                    case 0: pMul *= 0.99; break;
                    case 1: pPlus += 2.97 - 1; break;
                    case 2: pPlus += 1.48 - 1; break;
                    default: break;
                }
                result = pMul + pPlus;
            }

            //计算脑卒中的风险
            if (illType.CompareTo("CerebralApoplexy") == 0)
            {
                double pMul = 1;
                double pPlus = 0;

                switch (cmbStroke1.FindString(cmbStroke1.Text))//超重（BMI>25）
                {
                    case 0: pMul *= 0.99; break;
                    case 1: pPlus += 1.16 - 1; break;
                    default: break;
                }
                switch (cmbStroke2.FindString(cmbStroke2.Text))//吸烟
                {
                    case 0: pMul *= 0.99; break;
                    case 1: pPlus += 1.09 - 1; break;
                    case 2: pPlus += 1.42 - 1; break;
                    case 3: pPlus += 1.59 - 1; break;
                    case 4: pPlus += 1.24 - 1; break;
                    default: break;
                }
                switch (cmbStroke3.FindString(cmbStroke3.Text))//饮酒
                {
                    case 0: pMul *= 0.88; break;
                    case 1: pPlus += 1.67 - 1; break;
                    default: break;
                }
                switch (cmbStroke4.FindString(cmbStroke4.Text))//糖尿病
                {
                    case 0: pMul *= 0.99; break;
                    case 1: pPlus += 3.35 - 1; break;
                    case 2: pPlus += 2.47 - 1; break;
                    default: break;
                }
                switch (cmbStroke51.FindString(cmbStroke51.Text))//血压 51-收缩压 52-舒张压
                {
                    case 0:
                        switch (cmbStroke52.FindString(cmbStroke52.Text))
                        {
                            case 0: pMul *= 0.95; break;
                            case 1: pPlus += 2.01 - 1; break;
                            case 2: pPlus += 1.05 - 1; break;
                            default: break;
                        }
                        break;
                    case 1:
                        switch (cmbStroke52.FindString(cmbStroke52.Text))
                        {
                            case 0: pPlus += 1.89 - 1; break;
                            case 1: pPlus += 2.35 - 1; break;
                            case 2: pPlus += 2.55 - 1; break;
                            default: break;
                        }
                        break;
                    case 2:
                        switch (cmbStroke52.FindString(cmbStroke52.Text))
                        {
                            case 0: pPlus += 7.14 - 1; break;
                            case 1: pPlus += 2.23 - 1; break;
                            case 2: pPlus += 2.60 - 1; break;
                            default: break;
                        }
                        break;
                    default: break;
                } 
                
                result = pMul + pPlus;
            }
            /**********************************************************************************************************************/

        }

        private void btnLungCal_Click(object sender, EventArgs e)
        {
            CalRisk("LungCancer");
            labLungCaResult.Text = "【肺癌】危险系数：" + result.ToString("0.00");
            pinfo.labLungCa.Text = "【肺癌】危险系数：" + result.ToString("0.00");
        }

        private void btnLiverCal_Click(object sender, EventArgs e)
        {
            CalRisk("LiverCancer");
            labLiverCaResult.Text = "【肝癌】危险系数：" + result.ToString("0.00");
            pinfo.label2.Text = "【肝癌】危险系数：" + result.ToString("0.00");
        }

        private void btnMammaryCal_Click(object sender, EventArgs e)
        {
            CalRisk("MammaryCancer");
            labMammaryCaResult.Text = "【乳腺癌】危险系数：" + result.ToString("0.00");
            pinfo.labMammaryCa.Text = "【乳腺癌】危险系数：" + result.ToString("0.00");
        }

        private void btnEsophagusCal_Click(object sender, EventArgs e)
        {
            CalRisk("EsophagealCancer");
            labEsophagusCaResult.Text = "【食管癌】危险系数：" + result.ToString("0.00");
            pinfo.label9.Text = "【食管癌】危险系数：" + result.ToString("0.00");
        }

        private void btnGastricCal_Click(object sender, EventArgs e)
        {
            CalRisk("GastricCancer");
            labGastricCaResult.Text = "【胃癌】危险系数：" + result.ToString("0.00");
            pinfo.label10.Text = "【胃癌】危险系数：" + result.ToString("0.00");
        }

        private void btnBladderCal_Click(object sender, EventArgs e)
        {
            CalRisk("BladderCancer");
            labBladderCaResult.Text = "【膀胱癌】危险系数：" + result.ToString("0.00");
            pinfo.label11.Text = "【膀胱癌】危险系数：" + result.ToString("0.00");
        }

        private void btnColonCal_Click(object sender, EventArgs e)
        {
            CalRisk("ColorectalCancer");
            labColonCaResult.Text = "【大肠癌】危险系数：" + result.ToString("0.00");
            pinfo.label12.Text = "【大肠癌】危险系数：" + result.ToString("0.00");
        }

        private void btnCADCal_Click(object sender, EventArgs e)
        {
            CalRisk("CoronaryDisease");
            labCADCaResult.Text = "【冠心病】危险系数：" + result.ToString("0.00");
            pinfo.label13.Text = "【冠心病】危险系数：" + result.ToString("0.00");
        }

        private void btnStrokeCal_Click(object sender, EventArgs e)
        {
            CalRisk("CerebralApoplexy");
            labStrokeCaResult.Text = "【脑卒中】危险系数：" + result.ToString("0.00");
            pinfo.label14.Text = "【脑卒中】危险系数：" + result.ToString("0.00");
        }
        
    }
}
