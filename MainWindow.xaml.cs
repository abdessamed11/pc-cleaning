using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;


namespace test
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        DirectoryInfo winTemp = new DirectoryInfo(System.IO.Path.GetTempPath());
        public void Size()
        {
            
            /*long size = 0;
            var myDir = $@"C:\Users\Administrateur\Desktop\autre";
            

            var dirInfo = new DirectoryInfo(myDir);

            foreach (FileInfo fi in dirInfo.EnumerateFiles("*", SearchOption.AllDirectories))
            {
                size += fi.Length;
            }

            lbl_clean.Content = $"{size} bytes";*/
            
            lbl_clean.Content= Sizef();
            

        }

        public long Sizef()
        {
            /*DirectoryInfo winTemp = new DirectoryInfo(System.IO.Path.GetTempPath());*/
            long size = 0;
            var myDir = $@"C:\Users\Administrateur\Desktop\autre";

            var dirInfo = new DirectoryInfo(myDir);

            foreach (FileInfo fi in winTemp.EnumerateFiles("*", SearchOption.AllDirectories))
            {
                size += fi.Length;
            }

            //lbl_clean.Content = $"{size} bytes";
            return (size/1024)/1024;
        }

        public DateTime dateanal()
        {
            DateTime date= DateTime.Now;

            return date;
        }

        public void ecrire()
        {
            string[] str = new string[]
         {
               "Lorem Ipsum",
               "Lorem Ipsum",
               "Lorem Ipsum",
               "Lorem Ipsum"
         };

            using (StreamWriter sw = new StreamWriter("file.txt"))
            {
                foreach (string s in str)
                {
                    sw.WriteLine(s);
                }
            }

            // Lire et afficher chaque ligne du fichier.
            string line = "";
            using (StreamReader sr = new StreamReader("file.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        public void Delete()
        {
            using (StreamWriter sw = File.AppendText("file.txt"))
            {
                sw.WriteLine($"Size of analyse is {Sizef()} Mo");
                sw.WriteLine("Date of analyse: " + DateTime.Now.ToString());
                sw.WriteLine("==================");

            }

            foreach (FileInfo file in winTemp.EnumerateFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in winTemp.EnumerateDirectories())
            {
                dir.Delete(true);
            }
        }
       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("premiers analyse");
            btn_vue.Visibility = Visibility.Hidden;
            lbl_espace.Visibility = Visibility.Hidden;
            cnt_espace.Visibility = Visibility.Hidden;
            progresse.Visibility = Visibility.Visible;
            prog_percentage.Visibility = Visibility.Visible;
            btn_anal.IsEnabled = false;
            btn_analyse.IsEnabled = false;
            lbl_analyse.Content = "analyse en cours";
            lbl_date.Content = DateTime.Now.ToString();

            Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                 
                    Thread.Sleep(50);
                    this.Dispatcher.Invoke(() => 
                    {
                        progresse.Value = i;
                        prog_percentage.Content = i.ToString() + "%";

                                            
                        if (progresse.Value == 100)
                        {
                            System.Windows.Forms.MessageBox.Show("Analyse complete");
                            btn_vue.Visibility = Visibility.Visible;
                            lbl_espace.Visibility = Visibility.Visible;
                            cnt_espace.Visibility = Visibility.Visible;
                            progresse.Visibility = Visibility.Hidden;
                            prog_percentage.Visibility = Visibility.Hidden;
                            btn_anal.IsEnabled = true;
                            btn_analyse.IsEnabled = true;
                            lbl_analyse.Content = "Analyse du pc nécessaire";
                            lbl_date.Content = DateTime.Now.ToString();

                            Size();

                        }


                    });

                }
            });
        }

        private void anall_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.MessageBox.Show("premiers analyse");
            btn_vue.Visibility = Visibility.Hidden;
            lbl_espace.Visibility = Visibility.Hidden;
            cnt_espace.Visibility = Visibility.Hidden;
            progresse.Visibility = Visibility.Visible;
            prog_percentage.Visibility = Visibility.Visible;
            btn_anal.IsEnabled = false;
            btn_analyse.IsEnabled = false;
            lbl_analyse.Content = "analyse en cours";
            lbl_date.Content = DateTime.Now.ToString();

            Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    
                    Thread.Sleep(50);
                    this.Dispatcher.Invoke(() => 
                    {
                        progresse.Value = i;
                        prog_percentage.Content = i.ToString() + "%";

                        

                        if (progresse.Value == 100)
                        {
                            System.Windows.MessageBox.Show("Analyse complete");
                            btn_vue.Visibility = Visibility.Visible;
                            lbl_espace.Visibility = Visibility.Visible;
                            cnt_espace.Visibility = Visibility.Visible;
                            progresse.Visibility = Visibility.Hidden;
                            prog_percentage.Visibility = Visibility.Hidden;
                            btn_anal.IsEnabled = true;
                            btn_analyse.IsEnabled = true;
                            lbl_analyse.Content = "Analyse du pc nécessaire";
                            lbl_date.Content = DateTime.Now.ToString();
                            Size();

                        }
                        

                    });

                }
            });
        }

        WebClient updater = new WebClient();
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();

            try
            {
                if (!webClient.DownloadString("https://pastebin.com/raw/C8AENLFK").Contains("v1.0.0"))
                {
                    if (System.Windows.Forms.MessageBox.Show("il y a une mise à jour! Voulez-vous le télécharger?", "Demo", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) using (var client = new WebClient())

                        {
                            Process.Start(@"C:\Users\Administrateur\Desktop\update clean\bin\Debug\update clean.exe");
                            this.Close();
                        }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Vous êtes déjà à jour !");
                }
            }
            catch
            {

            }

        }

        private void progresse_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            Delete();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Process.Start("file.txt");
        }
    }
}
