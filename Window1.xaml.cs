using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace test
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        WebClient updater = new WebClient();

        private void btn_mise_Click(object sender, RoutedEventArgs e)
        {
            if (!updater.DownloadString("https://pastebin.com/raw/C8AENLFK").Contains("1.0.0"))
            {
                var updateMsg = MessageBox.Show("There is an update, do you want to download it?", "Updates",
                MessageBoxButton.YesNo, MessageBoxImage.Information);

                if (updateMsg == MessageBoxResult.Yes)
                {
                    Task.Run(() =>
                    {
                        try
                        {
                            for (int i = 0; i <= 100; i++)
                            {

                                Thread.Sleep(50);
                                this.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
                                {
                                    prog_value.Value = i;
                                    lbl_pourcent.Content = i.ToString() + "%";

                                    updater.DownloadFile("https://massif.weebly.com/uploads/1/3/5/3/135385611/update.zip", @"C:\Users\Administrateur\Desktop\testupdate\update.zip");

                                    if (prog_value.Value == 100)
                                    {
                                        Environment.Exit(0);
                                    }

                                });

                            }

                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Failed to download");
                            Environment.Exit(0);
                        }
                        updater.Dispose();

                    });
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            else
            {
                MessageBox.Show("You are in the latest version");
            }
        }
    }
}
