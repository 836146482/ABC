using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WinClient.YellEatClient;

namespace WinClient
{   
    public static class Program
    {
        public static YellEatServiceClient Client { get; set; }

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
