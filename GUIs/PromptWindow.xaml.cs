using Calckit.GUIs;
using Calckit.Properties;
using System.Windows;

namespace Calckit
{
    /// <summary>
    /// Interaction logic for PromptWindow.xaml
    /// </summary>
    public partial class PromptWindow : Window
    {
        public PromptWindow()
        {
            InitializeComponent();
        }


        Scientific_Calckit scientific = new Scientific_Calckit();
        DigitalWindow digital = new DigitalWindow();
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Settings settings = new Settings();

            if (settings.AskonStart) { }
            else
            {


                    if (settings.DefaultTool == "Guis/Scientific_Calckit.xaml")
                    {
                        scientific.Show();
                        scientific.Activate();
                    }
                    else if (settings.DefaultTool == "Guis/DigitalWindow.xaml")
                    {
                        digital.Show();
                        digital.Activate();
                    }
                    Close();

            }
        }

        private void MakeDefCheck_Checked(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            switch (LauchCombo.SelectedIndex)
            {
                case 0:
                    {
                        settings.DefaultTool = "Guis/Scientific_Calckit.xaml";
                        settings.Save();
                        break;
                    }

                case 1:
                    {
                        settings.DefaultTool = "Guis/DigitalWindow.xaml";
                        settings.Save();
                        break;
                    }
            }
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            switch (LauchCombo.SelectedIndex)
            {
                case 0:
                    {
                        scientific.Show();
                        scientific.Activate();

                        if (MakeDefCheck.IsChecked == true)
                        {
                            settings.DefaultTool = "Guis/Scientific_Calckit.xaml";
                            settings.Save();
                        }
                        break;
                    }
                case 1:
                    {
                        digital.Show();
                        digital.Activate();
                        if (MakeDefCheck.IsChecked == true)
                        {
                            settings.DefaultTool = "Guis/DigitalWindow.xaml";
                            settings.Save();
                        }
                        break;
                    }
            }

            Close();
        }

        private void DontShowCheck_Checked(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            settings.AskonStart = false;
            settings.Save();
        }
    }
}
