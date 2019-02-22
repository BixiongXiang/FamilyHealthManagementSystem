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

        private void CalRisk(String illType) {//calculate desease risk

            /*calculate lung cancer risk*/
            if (illType.CompareTo("LungCa") == 0)
            {
                double pMul = 1;
                double pPlus = 0;

                switch (cmbLung1.FindString(cmbLung1.Text))//吸烟
                {
                    case 0: pMul *= 0.45; break;
                    case 1: pMul *= 0.59; break;
                    case 2: pPlus += 1.51-1; break;
                    case 3: pPlus += 3.50-1; break;
                    case 4: pPlus += 4.78-1; break;
                    case 5: pMul *= 0.59; break;
                    default: break;
                }
                switch (cmbLung2.FindString(cmbLung2.Text))//呼吸病史
                {
                    case 0: pMul *= 0.83; break;
                    case 1: pPlus += 1.90 - 1; break;
                    default: break;
                }
                switch (cmbLung3.FindString(cmbLung3.Text))//肿瘤史
                {
                    case 0: pMul *= 0.90; break;
                    case 1: pPlus += 1.62 - 1; break;
                    default: break;
                }
                switch (cmbLung4.FindString(cmbLung4.Text))//精神压抑
                {
                    case 0: pMul *= 0.89; break;
                    case 1: pPlus += 2.36 - 1; break;
                    default: break;
                }

                result = pMul + pPlus;
            }

            /*calculate liver cancer risk*/
            if (illType.CompareTo("LiverCa") == 0)
            {
                double pMul = 1;
                double pPlus = 0;

                switch (cmbLiver2.FindString(cmbLiver2.Text))//吸烟
                {
                    case 0: pMul *= 0.7; break;
                    case 1: pPlus += 3.85 - 1; break;
                    default: break;
                }
                switch (cmbLiver1.FindString(cmbLiver1.Text))//呼吸病史
                {
                    case 0: pMul *= 0.83; break;
                    case 1: pPlus += 1.12 - 1; break;
                    default: break;
                }
                switch (cmbLiver3.FindString(cmbLiver3.Text))//肿瘤史
                {
                    case 0: pMul *= 0.33; break;
                    case 1: pMul *= 0.50; break;
                    case 2: pPlus += 3.60 - 1; break;
                    case 3: pPlus += 7.68 - 1; break;
                    default: break;
                }
                switch (cmbLiver4.FindString(cmbLiver4.Text))//精神压抑
                {
                    case 0: pMul *= 0.76; break;
                    case 1: pPlus += 1.22 - 1; break;
                    default: break;
                }

                result = pMul + pPlus;
            }

            /*calculate Esophagus cancer risk*/
            if (illType.CompareTo("EsophagusCa") == 0)
            {
                double pMul = 1;
                double pPlus = 0;

                switch (cmbEsophagus1.FindString(cmbEsophagus1.Text))//吸烟
                {
                    case 0: pMul *= 0.53; break;
                    case 1: pMul *= 0.83; break;
                    case 2: pPlus += 1.32 - 1; break;                    
                    case 5: pMul *= 0.87; break;
                    default: break;
                }
                switch (cmbEsophagus2.FindString(cmbEsophagus2.Text))//呼吸病史
                {
                    case 0: pMul *= 0.80; break;
                    case 1: pPlus += 3.75 - 1; break;
                    default: break;
                }
                switch (cmbEsophagus3.FindString(cmbEsophagus3.Text))//肿瘤史
                {
                    case 0: pMul *= 0.68; break;
                    case 1: pPlus += 1.30 - 1; break;
                    default: break;
                }

                result = pMul + pPlus;
            }

            /*calculate Gastric cancer risk*/
            if (illType.CompareTo("GastricCa") == 0)
            {
                double pMul = 1;
                double pPlus = 0;

                switch (cmbGastric1.FindString(cmbGastric1.Text))//吸烟
                {
                    case 0: pMul *= 0.63; break;
                    case 1: pPlus += 1.32 - 1; break;
                    default: break;
                }
                switch (cmbGastric2.FindString(cmbGastric2.Text))//呼吸病史
                {
                    case 0: pMul *= 0.68; break;
                    case 1: pPlus += 1.29 - 1; break;
                    default: break;
                }
                switch (cmbGastric3.FindString(cmbGastric3.Text))//肿瘤史
                {
                    case 0: pMul *= 0.93; break;
                    case 1: pPlus += 1.45 - 1; break;
                    default: break;
                }
                switch (cmbGastric4.FindString(cmbGastric4.Text))//精神压抑
                {
                    case 0: pMul *= 0.98; break;
                    case 1: pPlus += 1.36 - 1; break;
                    default: break;
                }
                switch (cmbGastric5.FindString(cmbGastric5.Text))//精神压抑
                {
                    case 0: pPlus += 2.23 - 1; break;
                    case 1: pMul *= 0.98; break;                    
                    default: break;
                }
                switch (cmbGastric6.FindString(cmbGastric6.Text))//精神压抑
                {
                    case 0: pMul *= 0.82; break;
                    case 1: pPlus += 1.68 - 1; break;
                    default: break;
                }
                switch (cmbGastric7.FindString(cmbGastric7.Text))//精神压抑
                {
                    case 0: pMul *= 0.72; break;
                    case 1: pPlus += 2.21 - 1; break;
                    default: break;
                }
                switch (cmbGastric8.FindString(cmbGastric8.Text))//精神压抑
                {
                    case 0: pMul *= 0.99; break;
                    case 1: pPlus += 2.97 - 1; break;
                    default: break;
                }

                result = pMul + pPlus;
            }

            /*calculate Bladder cancer risk*/
            if (illType.CompareTo("BladderCa") == 0)
            {
                double pMul = 1;
                double pPlus = 0;

                switch (cmbBladder1.FindString(cmbBladder1.Text))//吸烟
                {
                    case 0: pMul *= 0.61; break;
                    case 1: pMul *= 0.76; break;
                    case 2: pPlus += 1.18 - 1; break;
                    case 3: pMul *= 0.89; break;
                    case 4: pMul *= 0.73; break;
                    default: break;
                }
                switch (cmbBladder2.FindString(cmbBladder2.Text))//呼吸病史
                {
                    case 0: pMul *= 0.92; break;
                    case 1: pPlus += 4.78 - 1; break;
                    case 2: pPlus += 1.84 - 1; break;
                    default: break;
                }
                switch (cmbBladder3.FindString(cmbBladder3.Text))//肿瘤史
                {
                    case 0: pMul *= 0.67; break;
                    case 1: pPlus += 1.47 - 1; break;
                    case 2: pPlus += 2.85 - 1; break;
                    default: break;
                }

                result = pMul + pPlus;
            }

            /*calculate colon cancer risk*/
            if (illType.CompareTo("ColonCa") == 0)
            {
                double pMul = 1;
                double pPlus = 0;

                switch (cmbColon1.FindString(cmbColon1.Text))//吸烟
                {
                    case 0: pMul *= 0.96; break;
                    case 1: pPlus += 21.54 - 1; break;
                    default: break;
                }
                switch (cmbColon2.FindString(cmbColon2.Text))//呼吸病史
                {
                    case 0: pMul *= 0.99; break;
                    case 1: pPlus += 2.58 - 1; break;
                    default: break;
                }
                switch (cmbColon3.FindString(cmbColon3.Text))//肿瘤史
                {
                    case 0: pMul *= 0.99; break;
                    case 1: pPlus += 1.59 - 1; break;
                    default: break;
                }
                switch (cmbColon4.FindString(cmbColon4.Text))//精神压抑
                {
                    case 0: pMul *= 0.81; break;
                    case 1: pPlus += 1.12 - 1; break;
                    case 2: pPlus += 1.54 - 1; break;
                    default: break;
                }
                switch (cmbColon5.FindString(cmbColon5.Text))//精神压抑
                {
                    case 0: pMul *= 0.92; break;
                    case 1: pPlus += 1.15 - 1; break;
                    case 2: pPlus += 1.44 - 1; break;
                    default: break;
                }
                switch (cmbColon6.FindString(cmbColon6.Text))//精神压抑
                {                    
                    case 0: pPlus += 1.44 - 1; break;
                    case 1: pPlus += 1.19 - 1; break;
                    case 2: pMul *= 0.99; break;
                    default: break;
                }

                result = pMul + pPlus;
            }

            /*calculate CAD risk*/  
            if (illType.CompareTo("CAD") == 0)
            {
                double pMul = 1;
                double pPlus = 0;

                switch (cmbCAD1.FindString(cmbCAD1.Text))//吸烟
                {
                    case 0: pMul *= 0.45; break;
                    case 1: pMul *= 0.59; break;
                    case 2: pPlus += 1.51 - 1; break;
                    case 3: pPlus += 3.50 - 1; break;
                    case 4: pPlus += 4.78 - 1; break;
                    case 5: pMul *= 0.59; break;
                    default: break;
                }
                switch (cmbCAD2.FindString(cmbCAD2.Text))//呼吸病史
                {
                    case 0: pMul *= 0.83; break;
                    case 1: pPlus += 1.90 - 1; break;
                    default: break;
                }
                switch (cmbCAD3.FindString(cmbCAD3.Text))//肿瘤史
                {
                    case 0: pMul *= 0.90; break;
                    case 1: pPlus += 1.62 - 1; break;
                    default: break;
                }
                switch (cmbCAD4.FindString(cmbCAD4.Text))//精神压抑
                {
                    case 0: pMul *= 0.89; break;
                    case 1: pPlus += 2.36 - 1; break;
                    default: break;
                }

                switch (cmbCAD51.FindString(cmbCAD51.Text))//血压 51-收缩压 52-舒张压
                {
                    case 0:
                        switch (cmbCAD52.FindString(cmbCAD52.Text))//饮酒
                        {
                            case 0: pMul *= 0.88; break;
                            case 1: pPlus += 1.87  - 1; break;
                            case 2: pMul *= 0.97; break;
                            default: break;
                        }
                        break;
                    case 1:
                        switch (cmbCAD52.FindString(cmbCAD52.Text))//饮酒
                        {
                            case 0: pPlus += 1.75 - 1; break;
                            case 1: pPlus += 2.18 - 1; break;
                            case 2: pPlus += 2.36 - 1; break;
                            default: break;
                        }
                        break;
                    case 2:
                        switch (cmbCAD52.FindString(cmbCAD52.Text))//饮酒
                        {
                            case 0: pPlus += 6.63 - 1; break;
                            case 1: pPlus += 2.07 - 1; break;
                            case 2: pPlus += 2.41 - 1; break;
                            default: break;
                        }
                        break;
                    default: break;
                }

                switch (cmbCAD6.FindString(cmbCAD6.Text))//超重
                {
                    case 0: pMul *= 0.90; break;
                    case 1: pPlus += 1.41 - 1; break;
                    case 2: pPlus += 2.31 - 1; break;
                    case 3: pPlus += 2.70 - 1; break;
                    default: break;
                }
                switch (cmbCAD7.FindString(cmbCAD7.Text))//体育锻炼
                {
                    case 0: pPlus += 1.34 - 1; break;
                    case 1: pMul *= 0.70; break;
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

            /*calculate Stroke risk*/   
            if (illType.CompareTo("Stroke") == 0)
            {
                double pMul = 1;
                double pPlus = 0;

                switch (cmbStroke1.FindString(cmbStroke1.Text))//吸烟
                {
                    case 0: pMul *= 0.45; break;
                    case 1: pMul *= 0.59; break;
                    case 2: pPlus += 1.51 - 1; break;
                    case 3: pPlus += 3.50 - 1; break;
                    case 4: pPlus += 4.78 - 1; break;
                    case 5: pMul *= 0.59; break;
                    default: break;
                }
                switch (cmbStroke2.FindString(cmbStroke2.Text))//呼吸病史
                {
                    case 0: pMul *= 0.83; break;
                    case 1: pPlus += 1.90 - 1; break;
                    default: break;
                }
                switch (cmbStroke3.FindString(cmbStroke3.Text))//肿瘤史
                {
                    case 0: pMul *= 0.90; break;
                    case 1: pPlus += 1.62 - 1; break;
                    default: break;
                }
                switch (cmbStroke4.FindString(cmbStroke4.Text))//精神压抑
                {
                    case 0: pMul *= 0.89; break;
                    case 1: pPlus += 2.36 - 1; break;
                    default: break;
                }

                switch (cmbStroke51.FindString(cmbStroke51.Text))//血压 51-收缩压 52-舒张压
                {
                    case 0:
                        switch (cmbStroke52.FindString(cmbStroke52.Text))
                        {
                            case 0: pMul *= 0.85; break;
                            case 1: pPlus += 1.63 - 1; break;
                            case 2: pPlus += 3.19 - 1; break;
                            default: break;
                        }
                        break;
                    case 1:
                        switch (cmbStroke52.FindString(cmbStroke52.Text))
                        {
                            case 0: pMul *= 0.94; break;
                            case 1: pPlus += 3.26 - 1; break;
                            case 2: pPlus += 3.74 - 1; break;
                            default: break;
                        }
                        break;
                    case 2:
                        switch (cmbStroke52.FindString(cmbStroke52.Text))
                        {
                            case 0: pPlus += 5.24 - 1; break;
                            case 1: pPlus += 4.96 - 1; break;
                            case 2: pPlus += 7.97 - 1; break;
                            default: break;
                        }
                        break;
                    default: break;
                }

                switch (cmbStroke6.FindString(cmbStroke6.Text))//锻炼
                {
                    case 0: pPlus += 1.61 - 1; break;
                    case 1: pMul *= 0.45; break;
                    default: break;
                }

                result = pMul + pPlus;
            }
        }

        private void btnlungCal_Click(object sender, EventArgs e)
        {
            CalRisk("LungCa");
            labLungCaResult.Text = "【肺癌】危险系数：" + result.ToString("0.00");
            pinfo.labLungCa.Text = "【肺癌】危险系数：" + result.ToString("0.00");
        }

        private void btnLiverCal_Click(object sender, EventArgs e)
        {
            CalRisk("LiverCa");
            labLiverCaResult.Text = "【肝癌】危险系数：" + result.ToString("0.00");
            pinfo.label2.Text = "【肝癌】危险系数：" + result.ToString("0.00");
        }

        private void btnEsophagusCal_Click(object sender, EventArgs e)
        {
            CalRisk("EsophagusCa");
            labEsophagusCaResult.Text = "【食道癌】危险系数：" + result.ToString("0.00");
            pinfo.label9.Text = "【食道癌】危险系数：" + result.ToString("0.00");
        }

        private void btnGastricCal_Click(object sender, EventArgs e)
        {
            CalRisk("GastricCa");
            labGastricCaResult.Text = "【胃癌】危险系数：" + result.ToString("0.00");
            pinfo.label10.Text = "【胃癌】危险系数：" + result.ToString("0.00");
        }

        private void btnBladderCal_Click(object sender, EventArgs e)
        {
            CalRisk("BladderCa");
            labBladderCaResult.Text = "【膀胱癌】危险系数：" + result.ToString("0.00");
            pinfo.label11.Text = "【膀胱癌】危险系数：" + result.ToString("0.00");
        }

        private void btnColonCal_Click(object sender, EventArgs e)
        {
            CalRisk("ColonCa");
            labColonCaResult.Text = "【大肠癌】危险系数：" + result.ToString("0.00");
            pinfo.label12.Text = "【大肠癌】危险系数：" + result.ToString("0.00");
        }

        private void btnCADCal_Click(object sender, EventArgs e)
        {
            CalRisk("CADCa");
            labCADCaResult.Text = "【冠心病】危险系数：" + result.ToString("0.00");
            pinfo.label13.Text = "【冠心病】危险系数：" + result.ToString("0.00");
        }

        private void btnStrokeCal_Click(object sender, EventArgs e)
        {
            CalRisk("StrokeCa");
            labStrokeCaResult.Text = "【脑卒中】危险系数：" + result.ToString("0.00");
            pinfo.label14.Text = "【脑卒中】危险系数：" + result.ToString("0.00");
        }

       
    }
}
