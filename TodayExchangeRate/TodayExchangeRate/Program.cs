using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TodayExchangeRate
{
    class Program
    {
        private static string PrintMode = ConfigurationManager.AppSettings["PrintMode"];
        static void Main(string[] args)
        {
            switch (PrintMode)
            {
                case "Console":
                    Console.WriteLine("Console mode");
                    Console.ReadLine();
                    break;
                case "MessageBox":
                    MessageBox.Show("MessageBox mode");
                    break;
                default:
                    Console.WriteLine("Default console mode");
                    Console.ReadLine();
                    break;
            }

        }
    }
}
