using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

        //
        int CustomSeconds=0;
        int CustomMinutes=30;
        int CustomHours=0;
        //

        // presets
        private void btn_cancelSD_Click(object sender, RoutedEventArgs e)
        {
            CancelShutdown();
        }
        private void btn_lockdown_Click(object sender, RoutedEventArgs e)
        {
            Lockdown();
        }
        private void btn_shutdown1h_Click(object sender, RoutedEventArgs e)
        {
            ShutdownIn(3600);
        }
        private void btn_shutdown2h_Click(object sender, RoutedEventArgs e)
        {
            ShutdownIn(7200);
        }
        private void Shutdown_in_5h_Click(object sender, RoutedEventArgs e)
        {
            ShutdownIn(18000);
        }
        private void btn_shutdown12h_Click(object sender, RoutedEventArgs e)
        {
            ShutdownIn(43200);
        }


        // ends presets
        // custom stuff
        private void Button_Click(object sender, RoutedEventArgs e) //custom
        {
            int CustomSecondsFinal = ((CustomHours * 3600) + (CustomMinutes * 60) + CustomSeconds);
            ShutdownIn(CustomSecondsFinal);
        }

        private void tbx_hours_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tbx_hours = (TextBox)sender;
            string hoursString = tbx_hours.Text;
            CustomHours = Int32.Parse(hoursString);
        }

        private void tbx_minutes_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tbx_minutes = (TextBox)sender;
            string minutesString = tbx_minutes.Text;
            CustomMinutes = Int32.Parse(minutesString);
        }

        private void tbx_seconds_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tbx_seconds = (TextBox)sender;
            string secondsString = tbx_seconds.Text;
            CustomSeconds = Int32.Parse(secondsString);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        // end custom stuff
        // commands

        private void ShutdownIn(int seconds)
        {

            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine("shutdown -s -t " + seconds);
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

        private void Lockdown()
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine("rundll32.exe user32.dll,LockWorkStation");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());
        }

        





        //ends commands
    }
}
