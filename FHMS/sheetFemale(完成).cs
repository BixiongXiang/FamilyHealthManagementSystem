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
    public partial class QuestionaireM : Form
    {
        PersonInfo pinfo = null;
        double result = 0;
        public QuestionaireM(PersonInfo pinf)
        {
            InitializeComponent();
            pinfo = pinf;
        }

        private void CalRisk(String illType)
        {//calculate desease risk
/*********************************************************************************************************************************************8*/
            /*计算肺癌的风险，一个if结构对应一种病，标一下病名*/
            if (illType.CompareTo("LungCa") == 0)
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
            if (illType.CompareTo("EsophagealCancer") == 0)
            {
                double pMul = 1;
                double pPlus = 0;

                switch (cmbEsophageal1.FindString(cmbEsophageal1.Text))//吸烟
                {
                    case 0: pMul *= 0.97; break;
                    case 1: pPlus += 1.52 - 1; break;
                    case 2: pPlus += 2.42 - 1; break;
                    case 3: pPlus += 1.58 - 1; break;
                    default: break;
                }
                switch (cmbEsophageal2.FindString(cmbEsophageal2.Text))//家族史
                {
                    case 0: pMul *= 0.80; break;
                    case 1: pPlus += 3.75 - 1; break;
                    default: break;
                }
                switch (cmbEsophageal3.FindString(cmbEsophageal3.Text))//饮酒
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
                    case 0: pMul *=0.72; break;
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
            if (illType.CompareTo("ColorectalCancer") == 0)
            {
                double pMul = 1;
                double pPlus = 0;

                switch (cmbColorectal1.FindString(cmbColorectal1.Text))//肠息肉
                {
                    case 0: pMul *= 0.96; break;
                    case 1: pPlus += 21.54 - 1; break;
                    default: break;
                }
                switch (cmbColorectal2.FindString(cmbColorectal2.Text))//溃疡性结肠炎
                {
                    case 0: pMul *= 0.99; break;
                    case 1: pPlus += 2.58 - 1; break;
                    default: break;
                }
                switch (cmbColorectal3.FindString(cmbColorectal3.Text))//血吸虫史
                {
                    case 0: pMul *= 0.99; break;
                    case 1: pPlus += 1.59 - 1; break;
                    default: break;
                }
                switch (cmbColorectal4.FindString(cmbColorectal4.Text))//食用油炸食品
                {
                    case 0: pMul *= 0.81; break;
                    case 1: pPlus += 1.12 - 1; break;
                    case 2: pPlus += 1.54 - 1; break;
                    default: break;
                }
                switch (cmbColorectal5.FindString(cmbColorectal5.Text))//食用腌制食品
                {
                    case 0: pMul *= 0.92; break;
                    case 1: pPlus += 1.15 - 1; break;
                    case 2: pPlus += 1.44 - 1; break;
                    default: break;
                }
                switch (cmbColorectal6.FindString(cmbColorectal6.Text))//食用新鲜蔬菜
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

                switch (cmbCoronary1.FindString(cmbCoronaryl1.Text))//吸烟
                {
                    case 0: pMul *= 0.98; break;
                    case 1: pPlus += 1.73 - 1; break;
                    case 2: pPlus += 2.07 - 1; break;
                    case 3: pPlus += 3.79 - 1; break;
                    case 4: pPlus += 1.10 - 1; break;
                    default: break;
                }
                switch (cmbCoronary2.FindString(cmbCoronary2.Text))//饮酒
                {
                    case 0: pMul *= 0.93; break;
                    case 1: pPlus += 1.93 - 1; break;
                    default: break;
                }
                switch (cmbCoronary3.FindString(cmbCoronary3.Text))//高血压家族史
                {
                    case 0: pMul *= 0.64; break;
                    case 1: pPlus += 1.93 - 1; break;
                    default: break;
                }
                switch (cmbCoronary4.FindString(cmbCoronary4.Text))//高胆固醇血症
                {
                    case 0: pMul *= 0.83; break;
                    case 1: pPlus += 1.41 - 1; break;
                    default: break;
                }
                switch (cmbCoronary5.FindString(cmbCoronary5.Text))//超重
                {
                    case 0: pMul *= 0.94; break;
                    case 1: pPlus += 1.48 - 1; break;
                    case 2: pPlus += 2.42 - 1; break;
                    case 3: pPlus += 2.82 - 1; break;
                    default: break;
                }
                switch (cmbCoronary6.FindString(cmbCoronary6.Text))//体育锻炼
                {
                    case 0: pPlus += 1.26 - 1; break;
                    case 1: pMul *= 0.66; break;
                    default: break;
                }
                switch (cmbCoronary7.FindString(cmbCoronary7.Text))//糖尿病
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

                switch (cmbCerebral1.FindString(cmbCerebral1.Text))//超重（BMI>25）
                {
                    case 0: pMul *= 0.99; break;
                    case 1: pPlus += 1.16 - 1; break;
                    default: break;
                }
                switch (cmbCerebral2.FindString(cmbCerebral2.Text))//吸烟
                {
                    case 0: pMul *= 0.99; break;
                    case 1: pPlus += 1.09 - 1; break;
                    case 2: pPlus += 1.42 - 1; break;
                    case 3: pPlus += 1.59 - 1; break;
                    case 4: pPlus += 1.24 - 1; break;
                    default: break;
                }
                switch (cmbCerebral3.FindString(cmbCerebral3.Text))//饮酒
                {
                    case 0: pMul *= 0.64; break;
                    case 1: pPlus += 1.93 - 1; break;
                    default: break;
                }
                switch (cmbCoronary4.FindString(cmbCoronary4.Text))//高胆固醇血症
                {
                    case 0: pMul *= 0.88; break;
                    case 1: pPlus += 1.67 - 1; break;
                    default: break;
                }
                switch (cmbCerebral5.FindString(cmbCerebral5.Text))//糖尿病
                {
                    case 0: pMul *= 0.99; break;
                    case 1: pPlus += 3.35 - 1; break;
                    case 2: pPlus += 2.47 - 1; break;
                    default: break;
                }
                result = pMul + pPlus;
            }
/**********************************************************************************************************************/
            


        }

        
    }
}
                                                                                                                              