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
    public partial class Browser : Form
    {
        MainFrame mf = null;
        public Browser(MainFrame mainframe)
        {
            mf = mainframe;
            InitializeComponent();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //Uri address = new Uri("http://search.dxy.cn/");
            //webBrowser1.Url = address;
            this.webBrowser1.Navigate("http://search.dxy.cn/");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mf.panel1.BringToFront();
            this.Close();
        }

        private void Browser_FormClosing(object sender, FormClosingEventArgs e)
        {
            mf.panel1.BringToFront();
        }
    }
}
