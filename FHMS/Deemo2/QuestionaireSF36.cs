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
    public partial class QuestionaireSF36 : Form
    {
        double result = 0;
        PersonInfo pinfo = null;
        public QuestionaireSF36(PersonInfo pinf)
        {
            InitializeComponent();
            pinfo = pinf;
        }


        private void calculate(int function) {
            double PF = 0;
            double RP = 0;
            double BP = 0;
            double GH = 0;
            double VT = 0;
            double SF = 0;
            double RE = 0;
            double MH = 0;

            switch(function){

                case 1: //PF
                    foreach (Control c in tabPage1.Controls){
                        if(c is ComboBox){
                            ComboBox cmb = (ComboBox)c;//强制控件类型转换
                            switch (cmb.FindString(cmb.Text))
                            {
                                case 0: PF += 1; break;
                                case 1: PF += 2; break;
                                case 2: PF += 3; break;
                                default: break;
                            }     
                        }
                    };
                    result = 100 * (PF - 10.0)/20.0;
                    break;

                case 2: //RP 
                    foreach (Control c in tabPage2.Controls){
                        if(c is ComboBox){
                            ComboBox cmb = (ComboBox)c;//强制控件类型转换
                            switch (cmb.FindString(cmb.Text))
                            {
                                case 0: RP += 1; break;
                                case 1: RP += 2; break;
                                default: break;
                            }     
                        }
                    };
                    result = 100 * (RP - 4) / 4;
                    break;

                case 3: //BP
                    foreach (Control c in tabPage3.Controls){
                        if(c is ComboBox){
                            double flag = 0;
                            ComboBox cmb = (ComboBox)c;//强制控件类型转换
                            if (cmb.Name == "cmbBP1")
                            {
                                switch (cmb.FindString(cmb.Text))
                                {
                                    case 0: BP += 6.0; flag = 1; break;
                                    case 1: BP += 5.4; break;
                                    case 2: BP += 4.2; break;
                                    case 3: BP += 3.1; break;
                                    case 4: BP += 2.2; break;
                                    case 5: BP += 1.0; break;
                                    default: break;
                                }    
                            }
                            if (cmb.Name == "cmbBP2")
                            {
                                switch (cmb.FindString(cmb.Text))
                                {
                                    case 0: BP += 5 + flag; break;
                                    case 1: BP += 4; break;
                                    case 2: BP += 3; break;
                                    case 3: BP += 2; break;
                                    case 4: BP += 1; break;
                                    default: break;
                                }
                            }
                        }
                    };
                    result = 100 * (BP - 2) / 10;
                    break;

                case 4: //GH
                   foreach (Control c in tabPage4.Controls){
                        if(c is ComboBox){
                            ComboBox cmb = (ComboBox)c;//强制控件类型转换
                            if (cmb.Name == "cmbGH1")
                            {
                                switch (cmb.FindString(cmb.Text))
                                {
                                    case 0: GH += 5.0; break;
                                    case 1: GH += 4.4; break;
                                    case 2: GH += 4.2; break;
                                    case 3: GH += 3.4; break;
                                    case 4: GH += 2.0; break;
                                    case 5: GH += 1.0; break;
                                    default: break;
                                }    
                            }
                            if (cmb.Name == "cmbGH2" || cmb.Name == "cmbGH3")
                            {
                                switch (cmb.FindString(cmb.Text))
                                {
                                    case 0: GH += 1; break;
                                    case 1: GH += 2; break;
                                    case 2: GH += 3; break;
                                    case 3: GH += 4; break;
                                    case 4: GH += 5; break;
                                    default: break;
                                }
                            }
                            if (cmb.Name == "cmbGH4" || cmb.Name == "cmbGH5")
                            {
                                switch (cmb.FindString(cmb.Text))
                                {
                                    case 0: GH += 5; break;
                                    case 1: GH += 4; break;
                                    case 2: GH += 3; break;
                                    case 3: GH += 2; break;
                                    case 4: GH += 1; break;
                                    default: break;
                                }
                            }
                        }
                    };
                    result = 100 * (GH - 5) / 20;
                    break;

                case 5: //VT
                      foreach (Control c in tabPage5.Controls){
                        if(c is ComboBox){
                            ComboBox cmb = (ComboBox)c;//强制控件类型转换
                            if (cmb.Name == "cmbVT1" || cmb.Name == "cmbVT2")
                            {
                                switch (cmb.FindString(cmb.Text))
                                {
                                    case 0: VT += 6; break;
                                    case 1: VT += 5; break;
                                    case 2: VT += 4; break;
                                    case 3: VT += 3; break;
                                    case 4: VT += 2; break;
                                    case 5: VT += 1; break;
                                    default: break;
                                }
                            }
                            if (cmb.Name == "cmbVT3" || cmb.Name == "cmbVT4")
                            {
                                switch (cmb.FindString(cmb.Text))
                                {
                                    case 0: VT += 1; break;
                                    case 1: VT += 2; break;
                                    case 2: VT += 3; break;
                                    case 3: VT += 4; break;
                                    case 4: VT += 5; break;
                                    case 5: VT += 6; break;
                                    default: break;
                                }
                            }
                        }
                    };
                    result = 100 * (VT - 4) / 20;
                    break;
                case 6: //SF
                         foreach (Control c in tabPage6.Controls){
                        if(c is ComboBox){
                            ComboBox cmb = (ComboBox)c;//强制控件类型转换
                            if (cmb.Name == "cmbSF1")
                            {
                                switch (cmb.FindString(cmb.Text))
                                {
                                    case 0: SF += 5; break;
                                    case 1: SF += 4; break;
                                    case 2: SF += 3; break;
                                    case 3: SF += 2; break;
                                    case 4: SF += 1; break;
                                    default: break;
                                }
                            }
                            if (cmb.Name == "cmbSF2")
                            {
                                switch (cmb.FindString(cmb.Text))
                                {
                                    case 0: SF += 1; break;
                                    case 1: SF += 2; break;
                                    case 2: SF += 3; break;
                                    case 3: SF += 4; break;
                                    case 4: SF += 5; break;
                                    case 5: SF += 6; break;
                                    default: break;
                                }
                            }
                        }
                    };
                    result = 100 * (SF - 2) / 9;
                    break;
                case 7: //RE
                    foreach (Control c in tabPage7.Controls){
                        if(c is ComboBox){
                            ComboBox cmb = (ComboBox)c;//强制控件类型转换
                            switch (cmb.FindString(cmb.Text))
                            {
                                case 0: RE += 1; break;
                                case 1: RE += 2; break;
                                default: break;
                            }     
                        }
                    };
                    result = 100 * (RE - 3.0)/3.0;
                    break;
                case 8:  //MH
                   foreach (Control c in tabPage8.Controls){
                        if(c is ComboBox){
                            ComboBox cmb = (ComboBox)c;//强制控件类型转换
                            if (cmb.Name == "cmbMH1" || cmb.Name == "cmbMH2" || cmb.Name == "cmbMH3")
                            {
                                switch (cmb.FindString(cmb.Text))
                                {
                                    case 0: MH += 1; break;
                                    case 1: MH += 2; break;
                                    case 2: MH += 3; break;
                                    case 3: MH += 4; break;
                                    case 4: MH += 5; break;
                                    case 5: MH += 6; break;
                                    default: break;
                                }
                            }
                            if (cmb.Name == "cmbMH4" || cmb.Name == "cmbMH5")
                            {
                                switch (cmb.FindString(cmb.Text))
                                {
                                    case 0: MH += 6; break;
                                    case 1: MH += 5; break;
                                    case 2: MH += 4; break;
                                    case 3: MH += 3; break;
                                    case 4: MH += 2; break;
                                    case 5: MH += 1; break;
                                    default: break;
                                }
                            }
                        }
                    };
                    result = 100 * (MH - 5) / 25;
                    break;
                default: break;
            }
        
        }

        private void btnPF_Click(object sender, EventArgs e)
        {
            calculate(1);
            labPF.Text = "【结果】：" + result.ToString("0.00");
            pinfo.label19.Text = "躯体功能(PF):" + result.ToString("0.00");
        }

        private void btnRP_Click(object sender, EventArgs e)
        {
            calculate(2);
            labRP.Text = "【结果】：" + result.ToString("0.00");
            pinfo.label20.Text = "躯体角色(RP):" + result.ToString("0.00");
        }

        private void btnBP_Click(object sender, EventArgs e)
        {
            calculate(3);
            labBP.Text = "【结果】：" + result.ToString("0.00");
            pinfo.label21.Text = "肌体疼痛(BP):" + result.ToString("0.00");
        }

        private void btnGH_Click(object sender, EventArgs e)
        {
            calculate(4);
            labGH.Text = "【结果】：" + result.ToString("0.00");
            pinfo.label22.Text = "总体健康(GH):" + result.ToString("0.00");
        }

        private void btnVT_Click(object sender, EventArgs e)
        {
            calculate(5);
            labVT.Text = "【结果】：" + result.ToString("0.00");
            pinfo.label23.Text = "生命活力(VT):" + result.ToString("0.00");
        }

        private void btnSF_Click(object sender, EventArgs e)
        {
            calculate(6);
            labSF.Text = "【结果】：" + result.ToString("0.00");
            pinfo.label24.Text = "社交功能(SF):" + result.ToString("0.00");
        }

        private void btnRE_Click(object sender, EventArgs e)
        {
            calculate(7);
            labRE.Text = "【结果】：" + result.ToString("0.00");
            pinfo.label25.Text = "情感角色(RE):" + result.ToString("0.00");
        }

        private void btnMH_Click(object sender, EventArgs e)
        {
            calculate(8);
            labMH.Text = "【结果】：" + result.ToString("0.00");
            pinfo.label26.Text = "心理健康(MH):" + result.ToString("0.00");
        }
    }
}
