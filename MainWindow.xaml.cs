using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
using System.Xml;
using RobloxStudioModder;
using RobloxStudioModder.Content;

namespace RobloxStudioModder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.Delay(0); // makes sure that the ui initialize sucefully, avoiding any type of lag

            ///<summary>
            /// Gets the roblox path
            ///
            /// First it gets the computer path to LocalData
            /// Then looks for the roblox folder, its versions and the last edit date of each one
            /// Finally, checks if the content folder exist. If true, it will replace the class image, else, it will go back and go
            /// to the next version folder
            ///</summary>

            string LocalDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            LocalDataPath = @$"{LocalDataPath}\Roblox\Versions";

            //IEnumerable<string> Versions = System.IO.Directory.EnumerateDirectories(LocalDataPath);

            await Task.Delay(1700);

            try
            {
                string[] Versions = Directory.GetDirectories(LocalDataPath);
                string OffStudioPath = "";
                string StudioVer = "";

                foreach (string VersionPath in Versions)
                {
                    string StudioPath = $@"{VersionPath}\RobloxStudioBeta.exe";

                    

                    if (File.Exists(StudioPath)) 
                    { 
                        OffStudioPath = StudioPath;
                        loading.Content = $"Studio path found: {StudioPath}";
                        StudioVer = VersionPath.Replace(@$"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\Roblox\Versions\", "");
                    }

                    

                    //MessageBox.Show($"{StudioPath} and studio exist: {FoundPath}");
                    //MessageBox.Show(StudioPath == @"C:\Users\javier\AppData\Local\Roblox\Versions\version-0a4cf97c7c1047a1\RobloxStudioBeta.exe" ? "yes" : "no");

                    
                }

                await Task.Delay(1000);
                loading.Content = $"Studio version: {StudioVer}";
                Version.Content = StudioVer;
                Path.Content = OffStudioPath.Replace(@"\RobloxStudioBeta.exe", "");
                StudioVersionLabel.Content = $"Studio version: {StudioVer}";

            }
            catch (Exception err)
            {
                string Title = "Cant access the roblox folder";
                string message = $"We couldnt access the roblox versions folder: '{err.Message}' \n \n The app will close";
                MessageBoxButton Button = MessageBoxButton.OK;
                MessageBoxImage Image = MessageBoxImage.Error;
                MessageBoxResult Result = MessageBox.Show(message, Title, Button, Image);

                if (Result == MessageBoxResult.OK) {Close(); }
            }



            await Task.Delay(1200);
            for (double i = 1; i >= 0; i = i - 0.05)
            {
                logo.Opacity = i;
                name.Opacity = i;
                loading.Opacity = i;
                
                await Task.Delay(80);
            }

            logo.Opacity = 0;
            name.Opacity = 0;
            loading.Opacity = 0;

            Thickness Margin = new Thickness();
            Margin.Left = 36;
            Margin.Top = 23;

            logo.Margin = Margin;
            logo.Width = 76;
            logo.Height = 69;
            logo.HorizontalAlignment = HorizontalAlignment.Left;

            switch (DateTime.Now.Hour)
            {
                case <= 12:
                    presentation.Content = "Good morning!";
                        break;

                case <= 19:
                    presentation.Content = "Good afternoon!";
                        break;

                default:
                    presentation.Content = "Good night!";
                        break;
                
            }

            for (double i = 0; i <= 1; i = i + 0.05)
            {
                presentation.Opacity = i;
                logo.Opacity = i;
                MainMenu_ExplorerIcons.Opacity = i;
                StudioVersionLabel.Opacity = i;

                await Task.Delay(80);
            }
        }

        private async void MainMenu_ExplorerIcons_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (MainMenu_ExplorerIcons.Opacity >= 0.9)
            {
                for (double i = 1; i >= 0; i = i - 0.05)
                {
                    MainMenu_ExplorerIcons.Opacity = i;
                    StudioVersionLabel.Opacity = i;

                    await Task.Delay(80);
                }
                MainMenu_ExplorerIcons.Opacity = 0;
                StudioVersionLabel.Opacity = 0;

                for (double i = 0; i <= 1; i = i + 0.05)
                {
                    ColorfullDark.Opacity = i;
                    ColorfullLight.Opacity = i;
                    MonoDark.Opacity = i;
                    MonoLight.Opacity = i;

                    await Task.Delay(80);
                }

                MessageBox.Show($"Icons should be visible ColorfullDark.Source is {ColorfullDark.Source}");
                ColorfullDark.Opacity = 1;
                ColorfullLight.Opacity = 1;
                MonoDark.Opacity = 1;
                MonoLight.Opacity = 1;
            }
        }

        private void MainMenu_ExplorerIcons_MouseEnter(object sender, MouseEventArgs e)
        {
            if (MainMenu_ExplorerIcons.Opacity >= 0.9) 
            {
                DoubleAnimation anim1 = new();
                Duration dur1 = new Duration(new TimeSpan(00, 00, 00, 9));
                anim1.To = 250;
                anim1.Duration = dur1;
                anim1.SpeedRatio = 29;

                DoubleAnimation anim2 = new();
                Duration dur2 = new Duration(new TimeSpan(00, 00, 00, 7));
                anim2.To = 68;
                anim2.Duration = dur2;
                anim2.SpeedRatio = 29;

                MainMenu_ExplorerIcons.BeginAnimation(Image.WidthProperty, anim1);
                MainMenu_ExplorerIcons.BeginAnimation(Image.HeightProperty, anim2);
            }
            
        }

        private void MainMenu_ExplorerIcons_MouseLeave(object sender, MouseEventArgs e)
        {
            if (MainMenu_ExplorerIcons.Opacity >= 0.9)
            {
                DoubleAnimation anim1 = new();
                Duration dur1 = new Duration(new TimeSpan(00, 00, 00, 9));
                anim1.To = 230;
                anim1.Duration = dur1;
                anim1.SpeedRatio = 29;

                DoubleAnimation anim2 = new();
                Duration dur2 = new Duration(new TimeSpan(00, 00, 00, 7));
                anim2.To = 66;
                anim2.Duration = dur2;
                anim2.SpeedRatio = 29;

                MainMenu_ExplorerIcons.BeginAnimation(Image.WidthProperty, anim1);
                MainMenu_ExplorerIcons.BeginAnimation(Image.HeightProperty, anim2);
            }
        }

        private void ColorfullDark_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ColorfullDark.Opacity >= 0.9)
            {
                DoubleAnimation anim1 = new();
                Duration dur1 = new Duration(new TimeSpan(00, 00, 00, 9));
                anim1.To = 163;
                anim1.Duration = dur1;
                anim1.SpeedRatio = 29;

                DoubleAnimation anim2 = new();
                Duration dur2 = new Duration(new TimeSpan(00, 00, 00, 9));
                anim2.To = 106;
                anim2.Duration = dur2;
                anim2.SpeedRatio = 29;

                ColorfullDark.BeginAnimation(Image.WidthProperty, anim1);
                ColorfullDark.BeginAnimation(Image.HeightProperty, anim2);
            }
        }

        private void ColorfullDark_MouseLeave(object sender, MouseEventArgs e)
        {
            if (ColorfullDark.Opacity >= 0.9)
            {
                DoubleAnimation anim1 = new();
                Duration dur1 = new Duration(new TimeSpan(00, 00, 00, 9));
                anim1.To = 145;
                anim1.Duration = dur1;
                anim1.SpeedRatio = 29;

                DoubleAnimation anim2 = new();
                Duration dur2 = new Duration(new TimeSpan(00, 00, 00, 9));
                anim2.To = 95;
                anim2.Duration = dur2;
                anim2.SpeedRatio = 29;

                ColorfullDark.BeginAnimation(Image.WidthProperty, anim1);
                ColorfullDark.BeginAnimation(Image.HeightProperty, anim2);
            }
        }

        private void ColorfullDark_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ColorfullDark.Opacity >= 1)
            {
                bool result = NewIconSetClass.SetIcons("ColorfullDark", Path.Content.ToString(), $@".\Content\Icons\ColorfullDark\ClassImages.png");
                if (result)
                {
                    MessageBox.Show("Icon set (ColorfullDark) replaced sucefully");
                }
            }
        }

        private void ColorfullLight_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ColorfullDark.Opacity >= 0.9)
            {
                DoubleAnimation anim1 = new();
                Duration dur1 = new Duration(new TimeSpan(00, 00, 00, 9));
                anim1.To = 163;
                anim1.Duration = dur1;
                anim1.SpeedRatio = 29;

                DoubleAnimation anim2 = new();
                Duration dur2 = new Duration(new TimeSpan(00, 00, 00, 9));
                anim2.To = 106;
                anim2.Duration = dur2;
                anim2.SpeedRatio = 29;

                ColorfullLight.BeginAnimation(Image.WidthProperty, anim1);
                ColorfullLight.BeginAnimation(Image.HeightProperty, anim2);
            }
        }

        private void ColorfullLight_MouseLeave(object sender, MouseEventArgs e)
        {
            if (ColorfullDark.Opacity >= 0.9)
            {
                DoubleAnimation anim1 = new();
                Duration dur1 = new Duration(new TimeSpan(00, 00, 00, 9));
                anim1.To = 145;
                anim1.Duration = dur1;
                anim1.SpeedRatio = 29;

                DoubleAnimation anim2 = new();
                Duration dur2 = new Duration(new TimeSpan(00, 00, 00, 9));
                anim2.To = 95;
                anim2.Duration = dur2;
                anim2.SpeedRatio = 29;

                ColorfullLight.BeginAnimation(Image.WidthProperty, anim1);
                ColorfullLight.BeginAnimation(Image.HeightProperty, anim2);
            }
        }

        private void ColorfullLight_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ColorfullDark.Opacity >= 1)
            {
                bool result = NewIconSetClass.SetIcons("ColorfullLight", Path.Content.ToString(), $@".\Content\Icons\ColorfullLight\ClassImages.png");
                if (result)
                {
                    MessageBox.Show("Icon set(ColorfullLight) replaced sucefully");
                }
            }
        }

        private void MonoDark_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ColorfullDark.Opacity >= 0.9)
            {
                DoubleAnimation anim1 = new();
                Duration dur1 = new Duration(new TimeSpan(00, 00, 00, 9));
                anim1.To = 163;
                anim1.Duration = dur1;
                anim1.SpeedRatio = 29;

                DoubleAnimation anim2 = new();
                Duration dur2 = new Duration(new TimeSpan(00, 00, 00, 9));
                anim2.To = 106;
                anim2.Duration = dur2;
                anim2.SpeedRatio = 29;

                MonoDark.BeginAnimation(Image.WidthProperty, anim1);
                MonoDark.BeginAnimation(Image.HeightProperty, anim2);
            }
        }

        private void MonoDark_MouseLeave(object sender, MouseEventArgs e)
        {
            if (ColorfullDark.Opacity >= 0.9)
            {
                DoubleAnimation anim1 = new();
                Duration dur1 = new Duration(new TimeSpan(00, 00, 00, 9));
                anim1.To = 145;
                anim1.Duration = dur1;
                anim1.SpeedRatio = 29;

                DoubleAnimation anim2 = new();
                Duration dur2 = new Duration(new TimeSpan(00, 00, 00, 9));
                anim2.To = 95;
                anim2.Duration = dur2;
                anim2.SpeedRatio = 29;

                MonoDark.BeginAnimation(Image.WidthProperty, anim1);
                MonoDark.BeginAnimation(Image.HeightProperty, anim2);
            }
        }

        private void MonoDark_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ColorfullDark.Opacity >= 1)
            {
                bool result = NewIconSetClass.SetIcons("MonoDark", Path.Content.ToString(), $@".\Content\Icons\MonoDark\ClassImages.png");
                if (result)
                {
                    MessageBox.Show("Icon set(MonoDark) replaced sucefully");
                }
            }
        }

        private void MonoLight_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ColorfullDark.Opacity >= 0.9)
            {
                DoubleAnimation anim1 = new();
                Duration dur1 = new Duration(new TimeSpan(00, 00, 00, 9));
                anim1.To = 163;
                anim1.Duration = dur1;
                anim1.SpeedRatio = 29;

                DoubleAnimation anim2 = new();
                Duration dur2 = new Duration(new TimeSpan(00, 00, 00, 9));
                anim2.To = 106;
                anim2.Duration = dur2;
                anim2.SpeedRatio = 29;

                MonoLight.BeginAnimation(Image.WidthProperty, anim1);
                MonoLight.BeginAnimation(Image.HeightProperty, anim2);
            }
        }

        private void MonoLight_MouseLeave(object sender, MouseEventArgs e)
        {
            if (ColorfullDark.Opacity >= 0.9)
            {
                DoubleAnimation anim1 = new();
                Duration dur1 = new Duration(new TimeSpan(00, 00, 00, 9));
                anim1.To = 145;
                anim1.Duration = dur1;
                anim1.SpeedRatio = 29;

                DoubleAnimation anim2 = new();
                Duration dur2 = new Duration(new TimeSpan(00, 00, 00, 9));
                anim2.To = 95;
                anim2.Duration = dur2;
                anim2.SpeedRatio = 29;

                MonoLight.BeginAnimation(Image.WidthProperty, anim1);
                MonoLight.BeginAnimation(Image.HeightProperty, anim2);
            }
        }

        private void MonoLight_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ColorfullDark.Opacity >= 1)
            {
                bool result = NewIconSetClass.SetIcons("MonoLight", Path.Content.ToString(), $@".\Content\Icons\MonoLight\ClassImages.png");
                if (result)
                {
                    MessageBox.Show("Icon set(MonoLight) replaced sucefully");
                }
            }
        }
    }
}
