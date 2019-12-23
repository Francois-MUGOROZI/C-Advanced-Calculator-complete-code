
using System.Windows;
using System.Windows.Controls;
using Calckit.Properties;
using forms = System.Windows.Forms;

namespace Calckit.GUIs
{
    /// <summary>
    /// Interaction logic for HelpWindow.xaml
    /// </summary>
    public partial class HelpWindow : Window
    {
        public HelpWindow()
        {
            InitializeComponent();
        }

        private void PathBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            Settings settings = new Settings();
            forms.FolderBrowserDialog folder = new forms.FolderBrowserDialog();
            folder.RootFolder = System.Environment.SpecialFolder.Desktop;
            folder.ShowNewFolderButton = true;

            string path;

            if (folder.ShowDialog() == forms.DialogResult.OK)
            {
                path = folder.SelectedPath;
                settings.DefaultPath = path;
                settings.Save();
                PathBox.Text = path;
            }
            }
            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message, "File path Error");
            }
        }
        
        private void StartupCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Settings settings = new Settings();
            switch (StartupCombo.SelectedIndex)
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

        private void MakeDef3_Checked(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            if (string.IsNullOrEmpty(PathBox.Text))
                MessageBox.Show("Please choose the path!", "Path-Error");
            else
            {
                settings.DefaultPath = PathBox.Text;
                settings.Save();
            }
        }

        private void MakeDef4_Checked(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            settings.AskonStart = true;
            settings.Save();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            if (string.IsNullOrEmpty(settings.DefaultPath))
            {
            }
            else
            {
                PathBox.Text = settings.DefaultPath;
            }
        }

        private void MakeDef2_Checked(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            settings.SaveonExit = true;
            settings.Save();
        }
    }
}
