using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deemo2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static bool loginState = false;//记录登录状态

        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainFrame mainframe = new MainFrame();
            Application.Run(mainframe);

            //调试窗口用
            //PersonInfo perinfo = new PersonInfo();
            //Application.Run(perinfo);

            
        }
    }
}
