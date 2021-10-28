using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShutdownTimer
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }








        private void ShutdownIn(int seconds)
        {

           Process cmd = new Process();
           cmd.StartInfo.FileName = "cmd.exe";
           cmd.StartInfo.RedirectStandardInput = true;
           cmd.StartInfo.RedirectStandardOutput = true;
           cmd.StartInfo.CreateNoWindow = true;
           cmd.StartInfo.UseShellExecute = false;
           cmd.Start();

           cmd.StandardInput.WriteLine("shutdown -s -t "+ seconds);
           cmd.StandardInput.Flush();
           cmd.StandardInput.Close();
           cmd.WaitForExit();
           Console.WriteLine(cmd.StandardOutput.ReadToEnd());
        
        }

        private void CancelShutdown()
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine("shutdown -a");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());
        }




    }
}
