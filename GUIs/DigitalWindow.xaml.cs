using Calckit.GUIsHandle;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using InfoUnitsConverter;
using Calckit.Calculations;
using Subnetting;
using Calckit.FileHandle;

namespace Calckit.GUIs
{
    /// <summary>
    /// Interaction logic for DigitalWindow.xaml
    /// </summary>
    public partial class DigitalWindow : Window
    {
        Window Std, Consts,Sett;
        string path = "";

        //Creating converter items
        string[] InfoUnits = {"Bits","Kilobits","Megabits","Gigabits","Terabits","Petabits","Exabits","Zetabits","Yotabits","Bytes","Kilobytes","Megabytes","Gigabytes","Terabytes","Petabytes","Exabytes","Zetabytes","Yotabytes",
        "Nibble","Word","Dword","Qword","Block","Page","Kibibits","Kibibytes","Mebibits","Mebibytes","Tebibits","Tebibytes","Pebibits","Pebibytes","Exbibits","Exbibytes","Zebibits","Zebibytes","Yobibits","Yobibytes"};

        string[] NumberSystem = { "Binary", "Octal", "Decimal", "Hexadecimal" };
        string[] BinaryCodes = { "Binary-Code", "Gray-Code", "Excess3-Code", "BCD-Code", "1's Complement", "2's Complement","Decimal" };

        string From, To; string baseFrom; string ComResult = "";
        public DigitalWindow()
        {
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                BitOpComBtn.Content = "BYTE";
                DisabledTKB("BYTE");
                FullKBComBtn.Background = Brushes.LightBlue;
                OptionLv.SelectedIndex = 0;
                CommonInputBox.Focus();
                InputOpLv.SelectedIndex = 2;

                ComboItems("Units");
            }
            catch (Exception)
            {
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Properties.Settings settings = new Properties.Settings();
            SaveHistHandle save = new SaveHistHandle();
            if (settings.SaveonExit)
            {
                if (string.IsNullOrEmpty(path))
                {
                    if (string.IsNullOrEmpty(settings.DefaultPath))
                    {
                        save.SaveAs(HistoryArea);
                    }
                    else
                    {
                        path = settings.DefaultPath + "\\History-Calckit.txt";
                        save.Save(path, HistoryArea);
                    }
                }
                else
                {
                    save.Save(path, HistoryArea);
                }
            }
        }

        #region MenuItems events handling


        private void NewItem_Click(object sender, RoutedEventArgs e)
        {
            DigitalWindow digital = new DigitalWindow();
            digital.Show();
            digital.Activate();
        }

        private void SaveItem_Click(object sender, RoutedEventArgs e)
        {
            SaveHistHandle save = new SaveHistHandle();
            save.Save(path,HistoryArea);
           
        }

        private void SaveasItem_Click(object sender, RoutedEventArgs e)
        {
            SaveHistHandle save = new SaveHistHandle();
            save.SaveAs(HistoryArea);
            path = save.GetPath();
        }

        private void CloseItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ExitItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CutItem_Click(object sender, RoutedEventArgs e)
        {
            if (HistoryArea.IsVisible)
            {
                HistoryArea.Cut();
            }
            else
              Focused().Cut();

        }

        private void CopyItem_Click(object sender, RoutedEventArgs e)
        {
            if (HistoryArea.IsVisible)
            {
                HistoryArea.Copy();
            }
            else
                Focused().Copy();
        }

        private void PasteItem_Click(object sender, RoutedEventArgs e)
        {
            if (HistoryArea.IsVisible)
            {
                HistoryArea.Paste();
            }
            else
                Focused().Paste();
        }

        private void ClMemItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            MemoryArea.Items.Clear();

            }
            catch (Exception)
            {
            }
        }

        private void ClHistItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HistoryArea.Document.Blocks.Clear();
            }
            catch (Exception)
            {
            }
        }

        private void STDItem_Click(object sender, RoutedEventArgs e)
        {

            try
            {
            StdCackWindow stdCack = new StdCackWindow();

            if (Std != null)
            {
                    Std.Close();
                    Std = stdCack;
                    Std.Show();
                    Std.Activate();
            }
            else
            {
                Std = stdCack;
                Std.Show();
                Std.Activate();
            }
           
            }
            catch (Exception)
            {
            }
          
        }

        private void ConstFormItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ConstFormWindow stdCack = new ConstFormWindow();

                if (Consts != null)
                {
                    Consts.Close();
                    Consts = stdCack;
                    Consts.Show();
                    Consts.Activate();
                }
                else
                {
                    Consts = stdCack;
                    Consts.Show();
                    Consts.Activate();
                }

            }
            catch (Exception)
            {
            }
        }

        private void ScientItem_Click(object sender, RoutedEventArgs e)
        {
            Scientific_Calckit scientific = new Scientific_Calckit();
            scientific.Show();
            scientific.Activate();
            Close();
        }

        private void SettingsItem_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow help = new HelpWindow();
            if (Sett != null)
            {
                Sett.Close();
                Sett = help;
                Sett.Show();
                Sett.Activate();
            }
            else
            {
                Sett = help;
                Sett.Show();
                Sett.Activate();
            }
        }

        private void ConstFormualItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ConstFormWindow stdCack = new ConstFormWindow();

                if (Consts != null)
                {
                    Consts.Close();
                    Consts = stdCack;
                    Consts.Show();
                    Consts.Activate();
                }
                else
                {
                    Consts = stdCack;
                    Consts.Show();
                    Consts.Activate();
                }

            }
            catch (Exception)
            {
            }
        }

        private void MemoryItem_Click(object sender, RoutedEventArgs e)
        {
            MemoryArea.Visibility = Visibility.Visible;
            MvComBtn.Background = Brushes.LightBlue;
        }

        private void HistItem_Click(object sender, RoutedEventArgs e)
        {
            HistoryArea.Visibility = Visibility.Visible;
            HistBtn.Background = Brushes.LightBlue;
            ClearHistBtn.Visibility = Visibility.Visible;
            SaveHistBtn.Visibility = Visibility.Visible;
        }

        private void UserManualItem_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow help = new HelpWindow();
            if (Sett != null)
            {
                Sett.Close();
                help.HelpTab.IsSelected = true;
                Sett = help;
                Sett.Show();
                Sett.Activate();
            }
            else
            {
                help.HelpTab.IsSelected = true;
                Sett = help;
                Sett.Show();
                Sett.Activate();
            }
        }

        private void AboutItem_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow help = new HelpWindow();
            if (Sett != null)
            {
                Sett.Close();
                help.AboutTab.IsSelected = true;
                Sett = help;
                Sett.Show();
               Sett.Activate();
            }
            else
            {
                help.AboutTab.IsSelected = true;
                Sett = help;
                Sett.Show();
                Sett.Activate();
            }
        }

        #endregion


        #region Common controls methods
        private void OptionBtn_Click(object sender, RoutedEventArgs e)
        {
            if (OptionLv.IsVisible)
            {
                OptionLv.Visibility = Visibility.Hidden;
                OptionBtn.Background = Brushes.Transparent;
            }
            else
            {
                OptionLv.Visibility = Visibility.Visible;
                OptionBtn.Background = Brushes.LightBlue;
            }
        }

        private void HistBtn_Click(object sender, RoutedEventArgs e)
        {
            if (HistoryArea.IsVisible)
            {
                HistBtn.Background = Brushes.Transparent;
                HistoryArea.Visibility = Visibility.Hidden;
                ClearHistBtn.Visibility = Visibility.Collapsed;
                SaveHistBtn.Visibility = Visibility.Collapsed;
            }
            else
            {
                HistBtn.Background = Brushes.LightBlue;
                HistoryArea.Visibility = Visibility.Visible;
                ClearHistBtn.Visibility = Visibility.Visible;
                SaveHistBtn.Visibility = Visibility.Visible;
            }
        }

       

        private void LeftBrBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(LeftBrBtn, Focused());
        }

        private TextBox Focused()
        {
            if (CommonInputBox.Focus())
                return CommonInputBox;
            else if (FromBox.Focus())
                return FromBox;
            else if (BinInput1.Focus())
                return BinInput1;
            else if (BinInput2.Focus())
                return BinInput2;
            else if (BoolInput.Focus())
                return BoolInput;
            else if (IpBox.Focus())
                return IpBox;
            else if (CidrBox.Focus())
                return CidrBox;

            else
                return CommonInputBox;
        }

        private void RightBrBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(RightBrBtn, Focused());
        }

        private void ZeroComBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZeroComBtn, Focused());
        }

        private void PointComBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(PointComBtn, Focused());
        }

        private void EComBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(EComBtn, Focused());
        }

        private void FComBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(FComBtn, Focused());
        }

        private void OneComBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(OneComBtn, Focused());
        }

        private void TwoComBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(TwoComBtn, Focused());
        }

        private void ThreeComBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ThreeComBtn, Focused());
        }

        private void PlusComBtn_Click(object sender, RoutedEventArgs e)
        {
            if (BinaryBoxGrid.IsVisible)
            {
                OperLabel.Content = PlusComBtn.Content;
                BinInput2.Focusable = true;
                BinInput2.CaretIndex = BinInput2.CaretIndex;
                BinInput2.Focus();
            }
            else
            {
                ButtonHandle button = new ButtonHandle();
                button.NumBtnHandle(PlusComBtn, CommonInputBox);
            }
        }

        private void CComBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(CComBtn, Focused());
        }

        private void DComBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(DComBtn, Focused());
        }

        private void FourComBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(FourComBtn, Focused());
        }

        private void FiveComBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(FiveComBtn, Focused());
        }

        private void SixComBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(SixComBtn, Focused());
        }

        private void MinusComBtn_Click(object sender, RoutedEventArgs e)
        {
            if (BinaryBoxGrid.IsVisible)
            {
                OperLabel.Content = MinusComBtn.Content;
                BinInput2.Focusable = true;
                BinInput2.CaretIndex = BinInput2.CaretIndex;
                BinInput2.Focus();
            }
            else
            {
                ButtonHandle button = new ButtonHandle();
                button.NumBtnHandle(MinusComBtn, CommonInputBox);
            }
        }

        private void AComBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(AComBtn, Focused());
        }

        private void BComBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(BComBtn, Focused());
        }

        private void SevenComBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(SevenComBtn, Focused());
        }

        private void EightComBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(EightComBtn, Focused());
        }

        private void NineComBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(NineComBtn, Focused());
        }

        private void TimesComBtn_Click(object sender, RoutedEventArgs e)
        {
            if (BinaryBoxGrid.IsVisible)
            {
                OperLabel.Content = TimesComBtn.Content;
                BinInput2.Focusable = true;
                BinInput2.CaretIndex = BinInput2.CaretIndex;
                BinInput2.Focus();
            }
            else
            {
                ButtonHandle button = new ButtonHandle();
                button.NumBtnHandle(TimesComBtn, CommonInputBox);
            }
        }

        private void ModComBtn_Click(object sender, RoutedEventArgs e)
        {
            if (BinaryBoxGrid.IsVisible)
            {
                OperLabel.Content = ModComBtn.Content;
                BinInput2.Focusable = true;
                BinInput2.CaretIndex = BinInput2.CaretIndex;
                BinInput2.Focus();
            }
            else
            {
                ButtonHandle button = new ButtonHandle();
                button.NumBtnHandle(ModComBtn, CommonInputBox);
            }
        }

        private void LshBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(LshBtn, Focused());
        }

        private void RshBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(RshBtn, Focused());
        }

        private void XorBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(XorBtn, Focused());
        }

        private void NotBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(NotBtn, Focused());
        }

        private void ORBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ORBtn, Focused());
        }

        private void ANDBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ANDBtn, Focused());
        }

        private void ROLBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ROLBtn, Focused());
        }

        private void RoRBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(RoRBtn, Focused());
        }

        private void XnorBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(XnorBtn, Focused());
        }

        private void EQBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(EQBtn, Focused());
        }

        private void NORBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(NORBtn, Focused());
        }

        private void NANDBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(NANDBtn, Focused());
        }

        private void ArrowComBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ComFunc2Grid.IsVisible)
            {
                ComFunc2Grid.Visibility = Visibility.Collapsed;
                ComFunc1Grid.Visibility = Visibility.Visible;
            }
            else
            {
                ComFunc2Grid.Visibility = Visibility.Visible;
                ComFunc1Grid.Visibility = Visibility.Collapsed;
            }
        }

        private void CEComBtn_Click(object sender, RoutedEventArgs e)
        {
            Focused().Text = "";
            Focused().Focus();
        }

        private void ClComBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CommonBoxGrid.IsVisible)
            {
                CommonInputBox.Text = "";
                CommonResultBox.Text = "";
                ComResult = "";
                CommonInputBox.Focus();
            }

            else if (BinaryBoxGrid.IsVisible)
            {
                BinInput1.Text = "";
                BinInput2.Text = "";
                BinResult.Text = "";
                OperLabel.Content = "";
            }
            else if (BolleanBoxGrid.IsVisible)
            {
                BoolInput.Text = "";
                BoolResultTb.Text = "";
            }
            else if (SubnetBoxGrid.IsVisible)
            {
                IpBox.Text = "";
                CidrBox.Text = "";
            }
            FromBox.Text = "";
            ToBox.Text = "";

          for(int i=0; i< Bits.Length;i++)
          {
                Bits[i] = 0;
          }

            BittogInputBox.Text = "";
            SetbackTogBtns();
        }

        private void DelComBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.Delete(Focused());
        }

        private void DivideComBtn_Click(object sender, RoutedEventArgs e)
        {
            if (BinaryBoxGrid.IsVisible)
            {
                OperLabel.Content = "/";
                BinInput2.Focusable = true;
                BinInput2.CaretIndex = BinInput2.CaretIndex;
                BinInput2.Focus();
            }
            else
            {
                ButtonHandle button = new ButtonHandle();
                button.NumBtnHandle(MinusComBtn, CommonInputBox);
            }
        }

        private void PlMinusBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FullKBComBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CommonBoxGrid.IsVisible || BinaryBoxGrid.IsVisible)
            {
                BitKBBorder.Visibility = Visibility.Collapsed;
                CommonBtnGrid.Visibility = Visibility.Visible;
                FullKBComBtn.Background = Brushes.LightBlue;
            }
            else if (BolleanBoxGrid.IsVisible)
            {
                BitKBBorder.Visibility = Visibility.Collapsed;
                BolleanBtnGrid.Visibility = Visibility.Visible;
                FullKBComBtn.Background = Brushes.LightBlue;
            }
            else if (SubnetBoxGrid.IsVisible)
            {
                BitKBBorder.Visibility = Visibility.Collapsed;
                SubnetBtnGrid.Visibility = Visibility.Visible;
                FullKBComBtn.Background = Brushes.LightBlue;
            }
            BitKBComBtn.Background = Brushes.Transparent;
        }

        private void BitKBComBtn_Click(object sender, RoutedEventArgs e)
        {
            if (BitKBBorder.IsVisible)
            {
                BitKBBorder.Visibility = Visibility.Collapsed;
                BitKBComBtn.Background = Brushes.Transparent;
                FullKBComBtn.Background = Brushes.LightBlue;
            }
            else
            {
                BitKBBorder.Visibility = Visibility.Visible;
                BitKBComBtn.Background = Brushes.LightBlue;
                FullKBComBtn.Background = Brushes.Transparent;
            }
        }

        private void BitOpComBtn_Click(object sender, RoutedEventArgs e)
        {
            if (BitOpComBtn.Content.ToString() == "BYTE")
            {
                BitOpComBtn.Content = "WORD";
                DisabledTKB("WORD");
            }
            else if (BitOpComBtn.Content.ToString() == "WORD")
            {
                BitOpComBtn.Content = "DWORD";
                DisabledTKB("DWORD");
            }
            else if (BitOpComBtn.Content.ToString() == "DWORD")
            {
                BitOpComBtn.Content = "QWORD";
                DisabledTKB("QWORD");
            }
            else if (BitOpComBtn.Content.ToString() == "QWORD")
            {
                BitOpComBtn.Content = "BYTE";
                DisabledTKB("BYTE");
            }
        }

        //method to disable toggle kb buttons
        private void DisabledTKB(string Op)
        {
            switch (Op)
            {
                case "BYTE":
                    {
                        B64.IsEnabled = false; B55.IsEnabled = false; B46.IsEnabled = false;
                        B63.IsEnabled = false; B54.IsEnabled = false; B45.IsEnabled = false;
                        B62.IsEnabled = false; B53.IsEnabled = false; B44.IsEnabled = false;
                        B61.IsEnabled = false; B52.IsEnabled = false; B43.IsEnabled = false;
                        B60.IsEnabled = false; B51.IsEnabled = false; B42.IsEnabled = false;
                        B59.IsEnabled = false; B50.IsEnabled = false; B41.IsEnabled = false;
                        B58.IsEnabled = false; B49.IsEnabled = false; B40.IsEnabled = false;
                        B57.IsEnabled = false; B48.IsEnabled = false; B39.IsEnabled = false;
                        B56.IsEnabled = false; B47.IsEnabled = false; B38.IsEnabled = false;
                        B37.IsEnabled = false; B33.IsEnabled = false; B29.IsEnabled = false;
                        B36.IsEnabled = false; B32.IsEnabled = false; B28.IsEnabled = false;
                        B35.IsEnabled = false; B31.IsEnabled = false; B27.IsEnabled = false;
                        B34.IsEnabled = false; B30.IsEnabled = false; B26.IsEnabled = false;
                        B25.IsEnabled = false; B22.IsEnabled = false; B19.IsEnabled = false;
                        B24.IsEnabled = false; B21.IsEnabled = false; B18.IsEnabled = false;
                        B23.IsEnabled = false; B20.IsEnabled = false; B17.IsEnabled = false;
                        B16.IsEnabled = false; B13.IsEnabled = false; B10.IsEnabled = false;
                        B15.IsEnabled = false; B12.IsEnabled = false; B9.IsEnabled = false;
                        B14.IsEnabled = false; B11.IsEnabled = false;
                        break;
                        
                    }
                case "WORD":
                    {
                        B64.IsEnabled = false; B55.IsEnabled = false; B46.IsEnabled = false;
                        B63.IsEnabled = false; B54.IsEnabled = false; B45.IsEnabled = false;
                        B62.IsEnabled = false; B53.IsEnabled = false; B44.IsEnabled = false;
                        B61.IsEnabled = false; B52.IsEnabled = false; B43.IsEnabled = false;
                        B60.IsEnabled = false; B51.IsEnabled = false; B42.IsEnabled = false;
                        B59.IsEnabled = false; B50.IsEnabled = false; B41.IsEnabled = false;
                        B58.IsEnabled = false; B49.IsEnabled = false; B40.IsEnabled = false;
                        B57.IsEnabled = false; B48.IsEnabled = false; B39.IsEnabled = false;
                        B56.IsEnabled = false; B47.IsEnabled = false; B38.IsEnabled = false;
                        B37.IsEnabled = false; B33.IsEnabled = false; B29.IsEnabled = false;
                        B36.IsEnabled = false; B32.IsEnabled = false; B28.IsEnabled = false;
                        B35.IsEnabled = false; B31.IsEnabled = false; B27.IsEnabled = false;
                        B34.IsEnabled = false; B30.IsEnabled = false; B26.IsEnabled = false;
                        B25.IsEnabled = false; B22.IsEnabled = false; B19.IsEnabled = false;
                        B24.IsEnabled = false; B21.IsEnabled = false; B18.IsEnabled = false;
                        B23.IsEnabled = false; B20.IsEnabled = false; B17.IsEnabled = false;
                        B16.IsEnabled = true; B13.IsEnabled = true; B10.IsEnabled = true;
                        B15.IsEnabled = true; B12.IsEnabled = true; B9.IsEnabled = true;
                        B14.IsEnabled = true; B11.IsEnabled = true;
                        break;
                    }
                case "DWORD":
                    {

                        B64.IsEnabled = false; B55.IsEnabled = false; B46.IsEnabled = false;
                        B63.IsEnabled = false; B54.IsEnabled = false; B45.IsEnabled = false;
                        B62.IsEnabled = false; B53.IsEnabled = false; B44.IsEnabled = false;
                        B61.IsEnabled = false; B52.IsEnabled = false; B43.IsEnabled = false;
                        B60.IsEnabled = false; B51.IsEnabled = false; B42.IsEnabled = false;
                        B59.IsEnabled = false; B50.IsEnabled = false; B41.IsEnabled = false;
                        B58.IsEnabled = false; B49.IsEnabled = false; B40.IsEnabled = false;
                        B57.IsEnabled = false; B48.IsEnabled = false; B39.IsEnabled = false;
                        B56.IsEnabled = false; B47.IsEnabled = false; B38.IsEnabled = false;
                        B37.IsEnabled = false; B33.IsEnabled = false; B29.IsEnabled = true;
                        B36.IsEnabled = false; B32.IsEnabled = true; B28.IsEnabled = true;
                        B35.IsEnabled = false; B31.IsEnabled = true; B27.IsEnabled = true;
                        B34.IsEnabled = false; B30.IsEnabled = true; B26.IsEnabled = true;
                        B25.IsEnabled = true; B22.IsEnabled = true; B19.IsEnabled = true;
                        B24.IsEnabled = true; B21.IsEnabled = true; B18.IsEnabled = true;
                        B23.IsEnabled = true; B20.IsEnabled = true; B17.IsEnabled = true;
                        B16.IsEnabled = true; B13.IsEnabled = true; B10.IsEnabled = true;
                        B15.IsEnabled = true; B12.IsEnabled = true; B9.IsEnabled = true;
                        B14.IsEnabled = true; B11.IsEnabled = true;
                        break;
                    }
                case "QWORD":
                    {
                        B64.IsEnabled = true; B55.IsEnabled = true; B46.IsEnabled = true;
                        B63.IsEnabled = true; B54.IsEnabled = true; B45.IsEnabled = true;
                        B62.IsEnabled = true; B53.IsEnabled = true; B44.IsEnabled = true;
                        B61.IsEnabled = true; B52.IsEnabled = true; B43.IsEnabled = true;
                        B60.IsEnabled = true; B51.IsEnabled = true; B42.IsEnabled = true;
                        B59.IsEnabled = true; B50.IsEnabled = true; B41.IsEnabled = true;
                        B58.IsEnabled = true; B49.IsEnabled = true; B40.IsEnabled = true;
                        B57.IsEnabled = true; B48.IsEnabled = true; B39.IsEnabled = true;
                        B56.IsEnabled = true; B47.IsEnabled = true; B38.IsEnabled = true;
                        B37.IsEnabled = true; B33.IsEnabled = true; B29.IsEnabled = true;
                        B36.IsEnabled = true; B32.IsEnabled = true; B28.IsEnabled = true;
                        B35.IsEnabled = true; B31.IsEnabled = true; B27.IsEnabled = true;
                        B34.IsEnabled = true; B30.IsEnabled = true; B26.IsEnabled = true;
                        B25.IsEnabled = true; B22.IsEnabled = true; B19.IsEnabled = true;
                        B24.IsEnabled = true; B21.IsEnabled = true; B18.IsEnabled = true;
                        B23.IsEnabled = true; B20.IsEnabled = true; B17.IsEnabled = true;
                        B16.IsEnabled = true; B13.IsEnabled = true; B10.IsEnabled = true;
                        B15.IsEnabled = true; B12.IsEnabled = true; B9.IsEnabled = true;
                        B14.IsEnabled = true; B11.IsEnabled = true;
                        break;
                    }
            }
        }

        private void MRComBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.MemHandle(MRComBtn, Focused(), MemoryArea);
        }

        private void MSComBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.MemHandle(MSComBtn, CommonResultBox, MemoryArea);
        }

        private void MvComBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.MemHandle(MvComBtn,null, MemoryArea);
        }

        private void ClearHistBtn_Click(object sender, RoutedEventArgs e)
        {
            HistoryArea.Document.Blocks.Clear();
        }

        private void SaveHistBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveHistHandle save = new SaveHistHandle();
            save.Save(path, HistoryArea);
        }


        #endregion


        #region TextBox events control

        private void ToBox_MouseDown(object sender, MouseButtonEventArgs e)
        {

            ToBox.Focus();
        }
        private void CommonInputBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CommonInputBox.Focusable = true;
            CommonInputBox.CaretIndex = CommonInputBox.CaretIndex;
            CommonInputBox.Focus();
        }

        private void CommonInputBox_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
            FromBox.Focusable = false;
            BinInput1.Focusable = false;
            BinInput2.Focusable = false;
            BoolInput.Focusable = false;
            IpBox.Focusable = false;
            CidrBox.Focusable = false;

            }
            catch (Exception)
            {
            }
        }
        private void BinInput1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            BinInput1.Focusable = true;
            BinInput1.CaretIndex = BinInput1.CaretIndex;
            BinInput1.Focus();
        }

        private void BinInput2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            BinInput2.Focusable = true;
            BinInput2.CaretIndex = BinInput1.CaretIndex;
            BinInput2.Focus();
        }

        private void BinInput2_GotFocus(object sender, RoutedEventArgs e)
        {
            FromBox.Focusable = false;
            BinInput1.Focusable = false;
            CommonInputBox.Focusable = false;
            BoolInput.Focusable = false;
            IpBox.Focusable = false;
            CidrBox.Focusable = false;
        }

        private void BinInput1_GotFocus(object sender, RoutedEventArgs e)
        {
            FromBox.Focusable = false;
            CommonInputBox.Focusable = false;
            BinInput2.Focusable = false;
            BoolInput.Focusable = false;
            IpBox.Focusable = false;
            CidrBox.Focusable = false;
        }

        private void BinInput1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-1.]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void BinInput2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-1.]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void IpBox_GotFocus(object sender, RoutedEventArgs e)
        {
            FromBox.Focusable = false;
            BinInput1.Focusable = false;
            BinInput2.Focusable = false;
            BoolInput.Focusable = false;
            CommonInputBox.Focusable = false;
            CidrBox.Focusable = false;
        }

        private void IpBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            IpBox.Focusable = true;
            IpBox.CaretIndex = IpBox.CaretIndex;
            IpBox.Focus();
        }

        private void IpBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (NumberIpRadio.IsChecked == true)
            {
                Regex regexn = new Regex("[^0-9.]");
                e.Handled = regexn.IsMatch(e.Text);
            }
            else if(BinIpRadio.IsChecked==true)
            {
            Regex regex = new Regex("[^0-1.]");
            e.Handled = regex.IsMatch(e.Text);

            }
        }

        private void CidrBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void CidrBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CidrBox.Focusable = true;
            CidrBox.CaretIndex = CidrBox.CaretIndex;
            CidrBox.Focus();
        }

        private void CidrBox_GotFocus(object sender, RoutedEventArgs e)
        {
            FromBox.Focusable = false;
            BinInput1.Focusable = false;
            BinInput2.Focusable = false;
            BoolInput.Focusable = false;
            IpBox.Focusable = false;
            CommonInputBox.Focusable = false;
        }

        private void BoolInput_GotFocus(object sender, RoutedEventArgs e)
        {
            FromBox.Focusable = false;
            BinInput1.Focusable = false;
            BinInput2.Focusable = false;
            CommonInputBox.Focusable = false;
            IpBox.Focusable = false;
            CidrBox.Focusable = false;
        }

        private void BoolInput_MouseDown(object sender, MouseButtonEventArgs e)
        {
            BoolInput.Focusable = true;
            BoolInput.CaretIndex = BoolInput.CaretIndex;
            BoolInput.Focus();
        }


        private void FromBox_GotFocus(object sender, RoutedEventArgs e)
        {
            BoolInput.Focusable = false;
            BinInput1.Focusable = false;
            BinInput2.Focusable = false;
            CommonInputBox.Focusable = false;
            IpBox.Focusable = false;
            CidrBox.Focusable = false;
        }

        private void FromBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FromBox.Focusable = true;
            FromBox.CaretIndex = FromBox.CaretIndex;
            FromBox.Focus();
        }

        private void FromBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.A-Fa-f]");
            e.Handled = regex.IsMatch(e.Text);
        }


        #endregion


        #region Subnetting Buttons events
        //Inside Subnet detail border

        private void Hideres_Click(object sender, RoutedEventArgs e)
        {
            ResultBordernet.Visibility = Visibility.Hidden;
            NetDetailBtn.Background = Brushes.Transparent;
        }

        private void NumberIpRadio_Checked(object sender, RoutedEventArgs e)
        {
            Net2Btn.IsEnabled = true;
            Net3Btn.IsEnabled = true;
            Net4Btn.IsEnabled = true;
            Net5Btn.IsEnabled = true;
            Net6Btn.IsEnabled = true;
            Net8Btn.IsEnabled = true;
            Net9Btn.IsEnabled = true;
            Net7Btn.IsEnabled = true;

        }

        private void BinIpRadio_Checked(object sender, RoutedEventArgs e)
        {
            Net2Btn.IsEnabled = false;
            Net3Btn.IsEnabled = false;
            Net4Btn.IsEnabled = false;
            Net5Btn.IsEnabled = false;
            Net6Btn.IsEnabled = false;
            Net8Btn.IsEnabled = false;
            Net9Btn.IsEnabled = false;
            Net7Btn.IsEnabled = false;
        }

        private void NetZeroBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(NetZeroBtn, Focused());
        }

        private void NetPointBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(NetPointBtn, Focused());
        }

        private void Net1Btn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Net1Btn, Focused());
        }

        private void Net2Btn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Net2Btn, Focused());
        }

        private void Net3Btn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Net3Btn, Focused());
        }

        private void Net4Btn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Net4Btn, Focused());
        }

        private void Net5Btn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Net5Btn, Focused());
        }

        private void Net6Btn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Net6Btn, Focused());
        }

        private void Net7Btn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Net7Btn, Focused());
        }

        private void Net8Btn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Net8Btn, Focused());
        }

        private void Net9Btn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Net9Btn, Focused());
        }

        private void NetMyipBtn_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void NetNetipBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NetDetailBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ResultBordernet.IsVisible)
            {
                ResultBordernet.Visibility = Visibility.Hidden;
                NetDetailBtn.Background = Brushes.Transparent;
            }
            else
            {
                ResultBordernet.Visibility = Visibility.Visible;
                NetDetailBtn.Background = Brushes.LightBlue;
            }
        }

            Subnetter subnetter = new Subnetter();
        private void NetEqualBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(IpBox.Text) || string.IsNullOrEmpty(CidrBox.Text))
                MessageBox.Show("Please fill all field: IP and CIDR", "Invalid input-Error");
            else
            {
                //try
                //{
                    if (NumberIpRadio.IsChecked == true) 
                         subnetter.Calculate(IpBox.Text, CidrBox.Text);
                    else
                    {
                        DigitalHandle handle = new DigitalHandle();
                        string part1 = IpBox.Text.Substring(0, IpBox.Text.IndexOf("."));
                        string part4 = IpBox.Text.Substring(IpBox.Text.LastIndexOf(".") + 1);
                        string subs = IpBox.Text.Substring(IpBox.Text.IndexOf(".") + 1);
                    subs = subs.Substring(0, subs.LastIndexOf("."));
                        string part2 = subs.Substring(0, subs.IndexOf("."));
                        string part3 = subs.Substring(subs.IndexOf(".") + 1);

                        part1 = handle.ConvertFrom(part1, 2); part2 = handle.ConvertFrom(part2, 2); part3 = handle.ConvertFrom(part3, 2);
                        part4 = handle.ConvertFrom(part4, 2);
                        string fian = part1 + "." + part2 + "." + part3 + "." + part4;
                        subnetter.Calculate(fian, CidrBox.Text);
                    }
                    UpdateFields();
                //}
                //catch (Exception)
                //{

                //    MessageBox.Show("Failed to calculate the subnet\nPlease enter IP as 192.168.1.0 and CIDR should be\\tless than 255");
                //}
            }
        }

        private void UpdateFields()
        {
            SubmaskTb.Text = subnetter.Netmask;
            SubmaskTb_Copy.Text = subnetter.NumberOfSubnets;
            SubmaskTb_Copy1.Text = subnetter.FirstUsable;
            SubmaskTb_Copy2.Text = subnetter.LastUsable;

            Iptb.Text = subnetter.IP;
            cidtb.Text = CidrBox.Text;
            netad.Text = subnetter.NetworkAddress;
            mask.Text = subnetter.Netmask;
            fusabtb.Text = subnetter.FirstUsable;
            lusabtb.Text = subnetter.LastUsable;
            subtb.Text = subnetter.NumberOfSubnets;
            hosttb.Text = subnetter.NumberOfHosts;
            Broadcastb.Text = subnetter.Broadcast;
        }

        #endregion


        #region Boolean buttons events
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.BFBtnHandle(Back, Focused());
        }

        private void Forth_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.BFBtnHandle(Forth, Focused());
        }

        private void LbrBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(LbrBtn, BoolInput);
        }

        private void RbrBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(RbrBtn, BoolInput);
        }

        private void Point_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Point, BoolInput);
        }

        private void Camma_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Camma, BoolInput);
        }

        private void BolABtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(BolABtn, Focused());
        }

        private void BolBBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(BolBBtn, Focused());
        }

        private void BolCBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(BolCBtn, Focused());
        }

        private void BolDBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(BolDBtn, Focused());
        }

        private void BolEBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(BolEBtn, Focused());
        }

        private void BolFBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(BolFBtn, Focused());
        }

        private void BolVBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(BolVBtn, BoolInput);
        }

        private void BolWBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(BolWBtn, BoolInput);
        }

        private void BolXBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(BolXBtn, BoolInput);
        }

        private void BolYBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(BolYBtn, BoolInput);
        }

        private void BolZBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(BolZBtn, BoolInput);
        }

        private void BolPBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(BolPBtn, BoolInput);
        }

        private void BolQBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(BolQBtn, BoolInput);
        }

        private void Bol1Btn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Bol1Btn, Focused());
        }

        private void Bol0Btn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Bol0Btn, Focused());
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Plus, BoolInput);
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TruthTBBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ArUpBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ComFunc2Grid.IsVisible)
            {
                ComFunc2Grid.Visibility = Visibility.Collapsed;
                ComFunc1Grid.Visibility = Visibility.Visible;
            }
            else
            {
                ComFunc2Grid.Visibility = Visibility.Visible;
                ComFunc1Grid.Visibility = Visibility.Collapsed;
            }
        }

        #endregion

      
        private void InputOpLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string Res;
            int index = InputOpLv.SelectedIndex;
            switch (index)
            {
                case 0:
                    {
                        AComBtn.IsEnabled = true; FComBtn.IsEnabled = true; SixComBtn.IsEnabled = true;
                        BComBtn.IsEnabled = true; TwoComBtn.IsEnabled = true; SevenComBtn.IsEnabled = true;
                        CComBtn.IsEnabled = true; ThreeComBtn.IsEnabled = true; EightComBtn.IsEnabled = true;
                        DComBtn.IsEnabled = true; FourComBtn.IsEnabled = true; NineComBtn.IsEnabled = true;
                        EComBtn.IsEnabled = true; FiveComBtn.IsEnabled = true;

                        Res = HEXItem.Content.ToString().Remove(0, 3);
                        CommonResultBox.Text = Res;
                        break;
                    }
                case 1:
                    {
                        AComBtn.IsEnabled = false; FComBtn.IsEnabled = false; SixComBtn.IsEnabled = true;
                        BComBtn.IsEnabled = false; TwoComBtn.IsEnabled = true; SevenComBtn.IsEnabled = true;
                        CComBtn.IsEnabled = false; ThreeComBtn.IsEnabled = true; EightComBtn.IsEnabled = false;
                        DComBtn.IsEnabled = false; FourComBtn.IsEnabled = true; NineComBtn.IsEnabled = false;
                        EComBtn.IsEnabled = false; FiveComBtn.IsEnabled = true;
                        Res = OCTItem.Content.ToString().Remove(0, 3);
                        CommonResultBox.Text = Res;
                        break;
                    }
                case 2:
                    {
                        AComBtn.IsEnabled = false; FComBtn.IsEnabled = false; SixComBtn.IsEnabled = true;
                        BComBtn.IsEnabled = false; TwoComBtn.IsEnabled = true; SevenComBtn.IsEnabled = true;
                        CComBtn.IsEnabled = false; ThreeComBtn.IsEnabled = true; EightComBtn.IsEnabled = true;
                        DComBtn.IsEnabled = false; FourComBtn.IsEnabled = true; NineComBtn.IsEnabled = true;
                        EComBtn.IsEnabled = false; FiveComBtn.IsEnabled = true;
                        Res = DECItem.Content.ToString().Remove(0, 3);
                        CommonResultBox.Text = Res;
                        break;
                    }
                case 3:
                    {
                        AComBtn.IsEnabled = false; FComBtn.IsEnabled = false; SixComBtn.IsEnabled = false;
                        BComBtn.IsEnabled = false; TwoComBtn.IsEnabled = false; SevenComBtn.IsEnabled = false;
                        CComBtn.IsEnabled = false; ThreeComBtn.IsEnabled = false; EightComBtn.IsEnabled = false;
                        DComBtn.IsEnabled = false; FourComBtn.IsEnabled = false; NineComBtn.IsEnabled = false;
                        EComBtn.IsEnabled = false; FiveComBtn.IsEnabled = false;
                        Res = BINItem.Content.ToString().Remove(0, 3);
                        CommonResultBox.Text = Res;


                        break;
                    }
            }
        }

        private void OptionLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = OptionLv.SelectedIndex;
            switch (index)
            {
                case 0:
                    {
                        BasicBtnGrid.Visibility = Visibility.Visible;
                        CommonBoxGrid.Visibility = Visibility.Visible;
                        CommonInputBox.Focusable = true;
                        CommonInputBox.CaretIndex = CommonInputBox.CaretIndex;
                        CommonInputBox.Focus();
                        BinaryBoxGrid.Visibility = Visibility.Hidden;
                        BolleanBoxGrid.Visibility = Visibility.Hidden;
                        BolleanBtnGrid.Visibility = Visibility.Collapsed;
                        SubnetBoxGrid.Visibility = Visibility.Collapsed;
                        SubnetBtnGrid.Visibility = Visibility.Collapsed;

                        LeftBrBtn.IsEnabled = true;
                        RightBrBtn.IsEnabled = true;
                        AComBtn.IsEnabled = true;
                        BComBtn.IsEnabled = true;
                        CComBtn.IsEnabled = true;
                        DComBtn.IsEnabled = true;
                        EComBtn.IsEnabled = true;
                        FComBtn.IsEnabled = true;
                        TwoComBtn.IsEnabled = true;
                        ThreeComBtn.IsEnabled = true;
                        FourComBtn.IsEnabled = true;
                        FiveComBtn.IsEnabled = true;
                        SixComBtn.IsEnabled = true;
                        SevenComBtn.IsEnabled = true;
                        EightComBtn.IsEnabled = true;
                        NineComBtn.IsEnabled = true;
                        PlMinusBtn.IsEnabled = true;
                        ModComBtn.IsEnabled = true;
                        ArrowComBtn.IsEnabled = true;
                        LshBtn.IsEnabled = true;
                        RshBtn.IsEnabled = true;
                        XorBtn.IsEnabled = true;
                        NotBtn.IsEnabled = true;
                        ORBtn.IsEnabled = true;
                        ANDBtn.IsEnabled = true;

                        break;
                    }

                case 1:
                    {
                        BasicBtnGrid.Visibility = Visibility.Visible;
                        CommonBoxGrid.Visibility = Visibility.Collapsed;

                        BinaryBoxGrid.Visibility = Visibility.Visible;
                        BolleanBoxGrid.Visibility = Visibility.Hidden;
                        BolleanBtnGrid.Visibility = Visibility.Collapsed;
                        SubnetBoxGrid.Visibility = Visibility.Collapsed;
                        SubnetBtnGrid.Visibility = Visibility.Collapsed;

                        BinInput1.Focusable = true;
                        BinInput1.CaretIndex = BinInput1.CaretIndex;
                        BinInput1.Focus();

                        LeftBrBtn.IsEnabled = false;
                        RightBrBtn.IsEnabled = false;
                        AComBtn.IsEnabled = false;
                        BComBtn.IsEnabled = false;
                        CComBtn.IsEnabled = false;
                        DComBtn.IsEnabled = false;
                        EComBtn.IsEnabled = false;
                        FComBtn.IsEnabled = false;
                        TwoComBtn.IsEnabled = false;
                        ThreeComBtn.IsEnabled = false;
                        FourComBtn.IsEnabled = false;
                        FiveComBtn.IsEnabled = false;
                        SixComBtn.IsEnabled = false;
                        SevenComBtn.IsEnabled = false;
                        EightComBtn.IsEnabled = false;
                        NineComBtn.IsEnabled = false;
                        PlMinusBtn.IsEnabled = false;
                        ModComBtn.IsEnabled = false;
                        ArrowComBtn.IsEnabled = false;
                        LshBtn.IsEnabled = false;
                        RshBtn.IsEnabled = false;
                        XorBtn.IsEnabled = false;
                        NotBtn.IsEnabled = false;
                        ORBtn.IsEnabled = false;
                        ANDBtn.IsEnabled = false;

                        break;
                    }

                case 2:
                    {
                        MessageBox.Show("This option is available in Calckit v2\nPlease ask for new version", "Message");

                        break;
                    }

                case 3:
                    {

                        BasicBtnGrid.Visibility = Visibility.Collapsed;
                        CommonBoxGrid.Visibility = Visibility.Collapsed;

                        BinaryBoxGrid.Visibility = Visibility.Collapsed;
                        BolleanBoxGrid.Visibility = Visibility.Collapsed;
                        BolleanBtnGrid.Visibility = Visibility.Collapsed;
                        SubnetBoxGrid.Visibility = Visibility.Visible;
                        SubnetBtnGrid.Visibility = Visibility.Visible;

                        IpBox.Focusable = true;
                        IpBox.CaretIndex = IpBox.CaretIndex;
                        IpBox.Focus();

                        LshBtn.IsEnabled = false;
                        RshBtn.IsEnabled = false;
                        XorBtn.IsEnabled = false;
                        NotBtn.IsEnabled = false;
                        ORBtn.IsEnabled = false;
                        ANDBtn.IsEnabled = false;

                        break;

                    }
            }

            if (OptionLv.SelectedIndex == 2) { }
            else
               OpLabel.Content = OptionLv.SelectedItem.ToString().Remove(0, 38);
            OptionLv.Visibility = Visibility.Hidden;
            OptionBtn.Background = Brushes.Transparent;
        }
        private void UnitsCodesRadio_Checked(object sender, RoutedEventArgs e)
        {

            try
            {
                FromBox.Text = "";
                ToBox.Text = "";
                ComboItems("Units");
                FromBox.Focus();
            }
            catch (Exception)
            {
            }
        }

        private void NumCodesRadio_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                FromBox.Text = "";
                ToBox.Text = "";
                ComboItems("Nums");
            FromBox.Focus();
            }
            catch (Exception)
            {

            }
        }

        private void BinCodesRadio_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                FromBox.Text = "";
                ToBox.Text = "";
                ComboItems("BCs");
                FromBox.Focus();
                FromCombo.SelectedIndex = -1;
                ToCombo.SelectedIndex = -1;
            }
            catch (Exception)
            {

            }
        }

        private void FromCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FromCombo.SelectedIndex == -1) { }
            else { 

            From = FromCombo.SelectedItem.ToString().Remove(0, 38);
            if (string.IsNullOrEmpty(FromBox.Text)) { }
            else
            {
                try
                {
                    if (UnitsCodesRadio.IsChecked == true&&!string.IsNullOrEmpty(To))
                    {
                        InfounitsConvert convert = new InfounitsConvert();
                        ToBox.Text = convert.Convert(double.Parse(FromBox.Text), From, To).ToString();
                    }
                    else if (NumCodesRadio.IsChecked == true)
                    {
                            DigitalHandle handle = new DigitalHandle();
                            int index = FromCombo.SelectedIndex;
                            if (index == 0)
                                baseFrom = handle.ConvertFrom(FromBox.Text, 2);
                            else if (index == 1)
                                baseFrom = handle.ConvertFrom(FromBox.Text, 8);
                            else if (index == 2)
                                baseFrom = handle.ConvertFrom(FromBox.Text, 10);
                            else if (index == 3)
                                baseFrom = handle.ConvertFrom(FromBox.Text, 16);
                    }
                    else
                    {
                            
                            ToBox.Text = "";
                            ToCombo.SelectedIndex = -1;
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Couldn't convert because of invalid input\n Correct it and try again", "Calculation-Error");
                }
            }
        }
        }

        private void ToCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ToCombo.SelectedIndex == -1) { }
            else { 

            To = ToCombo.SelectedItem.ToString().Remove(0, 38);
            if (string.IsNullOrEmpty(From) || string.IsNullOrEmpty(FromBox.Text)) { }
            else
            {
                try
                {
                    if (UnitsCodesRadio.IsChecked == true)
                    {
                        InfounitsConvert convert = new InfounitsConvert();
                        ToBox.Text = convert.Convert(double.Parse(FromBox.Text), From, To).ToString();
                    }
                    else if (NumCodesRadio.IsChecked == true&&!string.IsNullOrEmpty(baseFrom))
                    {
                            DigitalHandle handle = new DigitalHandle();
                            int index = ToCombo.SelectedIndex;
                            if (index == 0)
                                ToBox.Text = handle.ConvertTo(baseFrom, 2);
                            else if (index == 1)
                                ToBox.Text = handle.ConvertTo(baseFrom, 8);
                            else if (index == 2)
                                ToBox.Text = handle.ConvertTo(baseFrom, 10);
                            else if (index == 3)
                                ToBox.Text = handle.ConvertTo(baseFrom, 16);

                    }
                    else
                    {
                            DigitalHandle handle = new DigitalHandle();
                            if (To == "BCD-Code" && From == "Binary-Code")
                                MessageBox.Show("This function is not supported yet!", "Invalid option-Error");
                            else if(From=="Gray-Code" &&(To=="Excess3-Code"||To=="BCD-Code"||To=="1's Complement"||To=="2's Complement"||To=="Decimal"))
                                MessageBox.Show("This function is not supported yet!", "Invalid option-Error");
                            else if(From=="Excess3-Code"&&(To=="Binary-Code"||To=="1's Complement"||To=="2's Complement"||To=="Gray-Code"))
                                MessageBox.Show("This function is not supported yet!", "Invalid option-Error");
                            else if (From == "BCD-Code" && (To == "Binary-Code" || To == "1's Complement" || To == "2's Complement" || To == "Gray-Code"))
                                MessageBox.Show("This function is not supported yet!", "Invalid option-Error");
                            else if (From == "1's Complement" && (To == "BCD-Code" || To == "Excess3-Code" || To == "Gray-Code"||To=="Decimal"))
                                MessageBox.Show("This function is not supported yet!", "Invalid option-Error");
                            else if (From == "2's Complement" && (To == "BCD-Code" || To == "Excess3-Code" || To == "Gray-Code"||To=="Decimal"))
                                MessageBox.Show("This function is not supported yet!", "Invalid option-Error");
                           

                            else
                            {
                                ToBox.Text = handle.CodeConverter(FromBox.Text, From, To);
                            }
                        }
                }
                catch (Exception)
                {

                    MessageBox.Show("Couldn't convert because of invalid input\n Correct it and try again", "Calculation-Error");
                }
            }
        }
        }

        private void FromBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(FromBox.Text)) { if (BinCodesRadio.IsChecked == true)
                        ToCombo.SelectedIndex = -1;
                }
                else
                {
                    if (UnitsCodesRadio.IsChecked == true)
                    {
                        InfounitsConvert convert = new InfounitsConvert();
                        ToBox.Text = convert.Convert(double.Parse(FromBox.Text), From, To).ToString();
                    }
                    else if (NumCodesRadio.IsChecked == true)
                    {
                        
                       
                    }
                    else
                    {
                        
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void EqualComBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                if (BinaryBoxGrid.IsVisible)
                {
                    if (string.IsNullOrEmpty(BinInput1.Text) || string.IsNullOrEmpty(BinInput2.Text))
                        MessageBox.Show("No values to calculate\nEnter values in both boxes", "Invalid input-Error");
                    else
                    {
                        DigitalHandle handle = new DigitalHandle();
                        EqLabel.Visibility = Visibility.Visible;

                        if (Bin.IsChecked == true)
                        {
                            BinResult.Text = handle.BinOperation(BinInput1.Text, BinInput2.Text, OperLabel.Content.ToString());
                            string exp = string.Format("BIN\n Input1:{0}\n Operator:{1}\n Input2:{2}", BinInput1.Text, OperLabel.Content, BinInput2.Text);
                            WriteHistory history = new WriteHistory(exp, BinResult.Text, HistoryArea);
                        }
                        else if (BCDRadio.IsChecked == true)
                        {
                            BinResult.Text = handle.BCDOperation(BinInput1.Text, BinInput2.Text, OperLabel.Content.ToString());
                            string exp = string.Format("BCD\n Input1:{0}\n Operator:{1}\n Input2:{2}", BinInput1.Text, OperLabel.Content, BinInput2.Text);
                            WriteHistory history = new WriteHistory(exp, BinResult.Text, HistoryArea);
                        }
                        else
                        {
                            BinResult.Text = handle.Excess3Operation(BinInput1.Text, BinInput2.Text, OperLabel.Content.ToString());
                            string exp = string.Format("Excess3\n Input1:{0}\n Operator:{1}\n Input2:{2}", BinInput1.Text, OperLabel.Content, BinInput2.Text);
                            WriteHistory history = new WriteHistory(exp, BinResult.Text, HistoryArea);
                        }
                       
                    }
                }

                else if (CommonBoxGrid.IsVisible)
                {
                    if(string.IsNullOrEmpty(CommonInputBox.Text))
                        MessageBox.Show("No values to calculate\nEnter values in the box", "Invalid input-Error");
                    else
                    {
                        DigitalHandle handle = new DigitalHandle();
                        switch (InputOpLv.SelectedIndex)
                        {
                            case 0:
                                {
                                    ComResult = handle.ParserReturn(CommonInputBox.Text, "HEX");
                                    BINItem.Content = "BIN  " + handle.ConvertTo(ComResult, 2);
                                    CommonResultBox.Text = handle.ConvertTo(ComResult, 16);
                                    OCTItem.Content = "OCT  " + handle.ConvertTo(ComResult, 8);
                                    DECItem.Content = "DEC  " + ComResult;
                                    HEXItem.Content = "HEX  " + handle.ConvertTo(ComResult,16);

                                    string exp = string.Format("HEX\n Input:{0}", CommonInputBox.Text);
                                    WriteHistory history = new WriteHistory(exp, handle.ConvertTo(ComResult,16), HistoryArea);
                                    break;
                                }

                            case 1:
                                {
                                    ComResult = handle.ParserReturn(CommonInputBox.Text, "OCT");
                                    BINItem.Content = "BIN  " + handle.ConvertTo(ComResult, 2);
                                    CommonResultBox.Text = handle.ConvertTo(ComResult, 8);
                                    OCTItem.Content = "OCT  " + handle.ConvertTo(ComResult, 8);
                                    DECItem.Content = "DEC  " + ComResult;
                                    HEXItem.Content = "HEX  " + handle.ConvertTo(ComResult,16);

                                    string exp = string.Format("OCT\n Input:{0}", CommonInputBox.Text);
                                    WriteHistory history = new WriteHistory(exp, handle.ConvertTo(ComResult, 8), HistoryArea);
                                    break;
                                }
                            case 2:
                                {
                                    ComResult = handle.ParserReturn(CommonInputBox.Text, "DEC");
                                    BINItem.Content = "BIN  " + handle.ConvertTo(ComResult, 2);
                                    CommonResultBox.Text = ComResult;
                                    OCTItem.Content = "OCT  " + handle.ConvertTo(ComResult, 8);
                                    DECItem.Content = "DEC  " + ComResult;
                                    HEXItem.Content = "HEX  " + handle.ConvertTo(ComResult, 16);

                                    string exp = string.Format("DEC\n Input:{0}", CommonInputBox.Text);
                                    WriteHistory history = new WriteHistory(exp, ComResult, HistoryArea);
                                    break;
                                }

                            case 3:
                                {
                                    ComResult = handle.ParserReturn(CommonInputBox.Text, "BIN");
                                    BINItem.Content = "BIN  " + handle.ConvertTo(ComResult, 2);
                                    CommonResultBox.Text = handle.ConvertTo(ComResult, 2);
                                    OCTItem.Content = "OCT  " + handle.ConvertTo(ComResult, 8);
                                    DECItem.Content = "DEC  " + ComResult;
                                    HEXItem.Content = "HEX  " + handle.ConvertTo(ComResult,16);

                                    string exp = string.Format("BIN\n Input:{0}", CommonInputBox.Text);
                                    WriteHistory history = new WriteHistory(exp, handle.ConvertTo(ComResult, 2), HistoryArea);

                                    break;
                                }
                        }

                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Invalid input error!\nPlease review your input and try again", "Calculation-Error");
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {

                    if (BinaryBoxGrid.IsVisible)
                    {
                        if (string.IsNullOrEmpty(BinInput1.Text) || string.IsNullOrEmpty(BinInput2.Text))
                            MessageBox.Show("No values to calculate\nEnter values in both boxes", "Invalid input-Error");
                        else
                        {
                            DigitalHandle handle = new DigitalHandle();
                            EqLabel.Visibility = Visibility.Visible;

                            if (Bin.IsChecked == true)
                            {
                                BinResult.Text = handle.BinOperation(BinInput1.Text, BinInput2.Text, OperLabel.Content.ToString());
                                string exp = string.Format("BIN\n Input1:{0}\n Operator:{1}\n Input2:{2}", BinInput1.Text, OperLabel.Content, BinInput2.Text);
                                WriteHistory history = new WriteHistory(exp, BinResult.Text, HistoryArea);
                            }
                            else if (BCDRadio.IsChecked == true)
                            {
                                BinResult.Text = handle.BCDOperation(BinInput1.Text, BinInput2.Text, OperLabel.Content.ToString());
                                string exp = string.Format("BCD\n Input1:{0}\n Operator:{1}\n Input2:{2}", BinInput1.Text, OperLabel.Content, BinInput2.Text);
                                WriteHistory history = new WriteHistory(exp, BinResult.Text, HistoryArea);
                            }
                            else
                            {
                                BinResult.Text = handle.Excess3Operation(BinInput1.Text, BinInput2.Text, OperLabel.Content.ToString());
                                string exp = string.Format("Excess3\n Input1:{0}\n Operator:{1}\n Input2:{2}", BinInput1.Text, OperLabel.Content, BinInput2.Text);
                                WriteHistory history = new WriteHistory(exp, BinResult.Text, HistoryArea);
                            }

                        }
                    }

                    else if (CommonBoxGrid.IsVisible)
                    {
                        if (string.IsNullOrEmpty(CommonInputBox.Text))
                            MessageBox.Show("No values to calculate\nEnter values in the box", "Invalid input-Error");
                        else
                        {
                            DigitalHandle handle = new DigitalHandle();
                            switch (InputOpLv.SelectedIndex)
                            {
                                case 0:
                                    {
                                        ComResult = handle.ParserReturn(CommonInputBox.Text, "HEX");
                                        BINItem.Content = "BIN  " + handle.ConvertTo(ComResult, 2);
                                        CommonResultBox.Text = handle.ConvertTo(ComResult, 16);
                                        OCTItem.Content = "OCT  " + handle.ConvertTo(ComResult, 8);
                                        DECItem.Content = "DEC  " + ComResult;
                                        HEXItem.Content = "HEX  " + handle.ConvertTo(ComResult, 16);

                                        string exp = string.Format("HEX\n Input:{0}", CommonInputBox.Text);
                                        WriteHistory history = new WriteHistory(exp, handle.ConvertTo(ComResult, 16), HistoryArea);
                                        break;
                                    }

                                case 1:
                                    {
                                        ComResult = handle.ParserReturn(CommonInputBox.Text, "OCT");
                                        BINItem.Content = "BIN  " + handle.ConvertTo(ComResult, 2);
                                        CommonResultBox.Text = handle.ConvertTo(ComResult, 8);
                                        OCTItem.Content = "OCT  " + handle.ConvertTo(ComResult, 8);
                                        DECItem.Content = "DEC  " + ComResult;
                                        HEXItem.Content = "HEX  " + handle.ConvertTo(ComResult, 16);

                                        string exp = string.Format("OCT\n Input:{0}", CommonInputBox.Text);
                                        WriteHistory history = new WriteHistory(exp, handle.ConvertTo(ComResult, 8), HistoryArea);
                                        break;
                                    }
                                case 2:
                                    {
                                        ComResult = handle.ParserReturn(CommonInputBox.Text, "DEC");
                                        BINItem.Content = "BIN  " + handle.ConvertTo(ComResult, 2);
                                        CommonResultBox.Text = ComResult;
                                        OCTItem.Content = "OCT  " + handle.ConvertTo(ComResult, 8);
                                        DECItem.Content = "DEC  " + ComResult;
                                        HEXItem.Content = "HEX  " + handle.ConvertTo(ComResult, 16);

                                        string exp = string.Format("DEC\n Input:{0}", CommonInputBox.Text);
                                        WriteHistory history = new WriteHistory(exp, ComResult, HistoryArea);
                                        break;
                                    }

                                case 3:
                                    {
                                        ComResult = handle.ParserReturn(CommonInputBox.Text, "BIN");
                                        BINItem.Content = "BIN  " + handle.ConvertTo(ComResult, 2);
                                        CommonResultBox.Text = handle.ConvertTo(ComResult, 2);
                                        OCTItem.Content = "OCT  " + handle.ConvertTo(ComResult, 8);
                                        DECItem.Content = "DEC  " + ComResult;
                                        HEXItem.Content = "HEX  " + handle.ConvertTo(ComResult, 16);

                                        string exp = string.Format("BIN\n Input:{0}", CommonInputBox.Text);
                                        WriteHistory history = new WriteHistory(exp, handle.ConvertTo(ComResult, 2), HistoryArea);

                                        break;
                                    }
                            }

                        }
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Invalid input error!\nPlease review your input and try again", "Calculation-Error");
                }

            }
            else if (e.Key == Key.OemPlus||e.Key==Key.Add)
            {
                if (BinaryBoxGrid.IsVisible)
                {
                    OperLabel.Content = PlusComBtn.Content;
                    BinInput2.Focusable = true;
                    BinInput2.CaretIndex = BinInput2.CaretIndex;
                    BinInput2.Focus();
                }
            }
            else if (e.Key == Key.OemMinus||e.Key==Key.Subtract)
            {
                if (BinaryBoxGrid.IsVisible)
                {
                    OperLabel.Content = MinusComBtn.Content;
                    BinInput2.Focusable = true;
                    BinInput2.CaretIndex = BinInput2.CaretIndex;
                    BinInput2.Focus();
                }
            }
            else if (e.Key == Key.Multiply)
            {
                if (BinaryBoxGrid.IsVisible)
                {
                    OperLabel.Content = TimesComBtn.Content;
                    BinInput2.Focusable = true;
                    BinInput2.CaretIndex = BinInput2.CaretIndex;
                    BinInput2.Focus();
                }
            }
            else if (e.Key == Key.Divide)
            {
                if (BinaryBoxGrid.IsVisible)
                {
                    OperLabel.Content = "/";
                    BinInput2.Focusable = true;
                    BinInput2.CaretIndex = BinInput2.CaretIndex;
                    BinInput2.Focus();
                }
            }
            else if (e.Key == Key.Back)
            {
                ButtonHandle button = new ButtonHandle();
                button.Delete(Focused());
            }
        }


        //method to add items to combo box
        private void ComboItems(string Op)
        {
            if (FromCombo == null) { }
            else
            {
                FromCombo.Items.Clear();
                ToCombo.Items.Clear();
            

            switch (Op)
            {
                case "Units":
                    {
                        foreach (var item in InfoUnits)
                        {
                            ComboBoxItem boxItem = new ComboBoxItem();
                            boxItem.Background = new SolidColorBrush(Color.FromArgb(Convert.ToByte(255), Convert.ToByte(40), Convert.ToByte(40), Convert.ToByte(40)));
                            boxItem.Foreground = Brushes.Beige;
                            boxItem.Opacity = 0.8;
                            boxItem.BorderThickness = new Thickness(0.0);
                            boxItem.Content = item;
                            FromCombo.Items.Add(boxItem);
                        }

                        foreach (var item in InfoUnits)
                        {
                            ComboBoxItem boxItem = new ComboBoxItem();
                            boxItem.Background = new SolidColorBrush(Color.FromArgb(Convert.ToByte(255), Convert.ToByte(40), Convert.ToByte(40), Convert.ToByte(40)));
                            boxItem.Foreground = Brushes.Beige;
                            boxItem.Opacity = 0.8;
                            boxItem.BorderThickness = new Thickness(0.0);
                            boxItem.Content = item;
                            ToCombo.Items.Add(boxItem);
                        }
                        break;
                    }
                case "BCs":
                    {
                        foreach (var item in BinaryCodes)
                        {
                            ComboBoxItem boxItem = new ComboBoxItem();
                            boxItem.Background = new SolidColorBrush(Color.FromArgb(Convert.ToByte(255), Convert.ToByte(40), Convert.ToByte(40), Convert.ToByte(40)));
                            boxItem.Foreground = Brushes.Beige;
                            boxItem.Opacity = 0.8;
                            boxItem.BorderThickness = new Thickness(0.0);
                            boxItem.Content = item;
                            FromCombo.Items.Add(boxItem);
                        }

                        foreach (var item in BinaryCodes)
                        {
                            ComboBoxItem boxItem = new ComboBoxItem();
                            boxItem.Background = new SolidColorBrush(Color.FromArgb(Convert.ToByte(255), Convert.ToByte(40), Convert.ToByte(40), Convert.ToByte(40)));
                            boxItem.Foreground = Brushes.Beige;
                            boxItem.Opacity = 0.8;
                            boxItem.BorderThickness = new Thickness(0.0);
                            boxItem.Content = item;
                            ToCombo.Items.Add(boxItem);
                        }
                        break;
                    }
                case "Nums":
                    {
                        foreach (var item in NumberSystem)
                        {
                            ComboBoxItem boxItem = new ComboBoxItem();
                            boxItem.Background = new SolidColorBrush(Color.FromArgb(Convert.ToByte(255), Convert.ToByte(40), Convert.ToByte(40), Convert.ToByte(40)));
                            boxItem.Foreground = Brushes.Beige;
                            boxItem.Opacity = 0.8;
                            boxItem.BorderThickness = new Thickness(0.0);
                            boxItem.Content = item;
                            FromCombo.Items.Add(boxItem);
                        }

                        foreach (var item in NumberSystem)
                        {
                            ComboBoxItem boxItem = new ComboBoxItem();
                            boxItem.Background = new SolidColorBrush(Color.FromArgb(Convert.ToByte(255), Convert.ToByte(40), Convert.ToByte(40), Convert.ToByte(40)));
                            boxItem.Foreground = Brushes.Beige;
                            boxItem.Opacity = 0.8;
                            boxItem.BorderThickness = new Thickness(0.0);
                            boxItem.Content = item;
                            ToCombo.Items.Add(boxItem);
                        }
                        break;
                    }

            }
            FromCombo.SelectedIndex = 0;
            ToCombo.SelectedIndex = 0;
        }
        }


        #region Bit toggling hnadler

        int[] Bits = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
             0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0,0,0,0};

        private void BitTog(int index, TextBox box, Button button)
        {
            string Enter, Result = null;
            int parse;

            if (button.Foreground == Brushes.LightBlue)
            {
                Enter = "0";
                button.Content = "0";
                parse = int.Parse(Enter);
                button.Foreground = Brushes.Beige;
            }
            else
            {
                Enter = "1";
                button.Content = "1";
                parse = int.Parse(Enter);
                button.Foreground = Brushes.LightBlue;
            }

            Bits[index] = parse;

            foreach (var item in Bits)
            {
                Result += item.ToString();
            }

            Result = Result.TrimStart('0');

            box.Text = Result;
        }

        #region bit tog buttons events

        private void SetbackTogBtns()
        {
            B1.Content = 0; B1.Foreground = Brushes.Beige; B9.Content = 0; B64.Foreground = Brushes.Beige;
            B2.Content = 0; B2.Foreground = Brushes.Beige; B64.Content = 0; B63.Foreground = Brushes.Beige;
            B3.Content = 0; B3.Foreground = Brushes.Beige; B63.Content = 0; B62.Foreground = Brushes.Beige;
            B4.Content = 0; B4.Foreground = Brushes.Beige; B62.Content = 0; B61.Foreground = Brushes.Beige;
            B5.Content = 0; B5.Foreground = Brushes.Beige; B61.Content = 0; B60.Foreground = Brushes.Beige;
            B6.Content = 0; B6.Foreground = Brushes.Beige; B60.Content = 0; B59.Foreground = Brushes.Beige;
            B7.Content = 0; B7.Foreground = Brushes.Beige; B59.Content = 0; B58.Foreground = Brushes.Beige;
            B8.Content = 0; B8.Foreground = Brushes.Beige; B58.Content = 0; B57.Foreground = Brushes.Beige;
            B10.Content = 0; B9.Foreground = Brushes.Beige; B57.Content = 0; B56.Foreground = Brushes.Beige;
            B11.Content = 0; B10.Foreground = Brushes.Beige; B56.Content = 0; B55.Foreground = Brushes.Beige;
            B12.Content = 0; B11.Foreground = Brushes.Beige; B55.Content = 0; B54.Foreground = Brushes.Beige;
            B13.Content = 0; B12.Foreground = Brushes.Beige; B54.Content = 0; B53.Foreground = Brushes.Beige;
            B14.Content = 0; B13.Foreground = Brushes.Beige; B53.Content = 0; B52.Foreground = Brushes.Beige;
            B15.Content = 0; B14.Foreground = Brushes.Beige; B52.Content = 0; B51.Foreground = Brushes.Beige;
            B16.Content = 0; B15.Foreground = Brushes.Beige; B51.Content = 0; B50.Foreground = Brushes.Beige;
            B17.Content = 0; B16.Foreground = Brushes.Beige; B50.Content = 0; B49.Foreground = Brushes.Beige;
            B18.Content = 0; B17.Foreground = Brushes.Beige; B49.Content = 0; B48.Foreground = Brushes.Beige;
            B19.Content = 0; B18.Foreground = Brushes.Beige; B48.Content = 0; B47.Foreground = Brushes.Beige;
            B20.Content = 0; B19.Foreground = Brushes.Beige; B47.Content = 0; B46.Foreground = Brushes.Beige;
            B21.Content = 0; B20.Foreground = Brushes.Beige; B46.Content = 0; B45.Foreground = Brushes.Beige;
            B22.Content = 0; B21.Foreground = Brushes.Beige; B45.Content = 0; B44.Foreground = Brushes.Beige;
            B23.Content = 0; B22.Foreground = Brushes.Beige; B44.Content = 0; B43.Foreground = Brushes.Beige;
            B24.Content = 0; B23.Foreground = Brushes.Beige; B43.Content = 0; B42.Foreground = Brushes.Beige;
            B25.Content = 0; B24.Foreground = Brushes.Beige; B42.Content = 0; B41.Foreground = Brushes.Beige;
            B26.Content = 0; B25.Foreground = Brushes.Beige; B41.Content = 0; B40.Foreground = Brushes.Beige;
            B27.Content = 0; B26.Foreground = Brushes.Beige; B40.Content = 0; B39.Foreground = Brushes.Beige;
            B28.Content = 0; B27.Foreground = Brushes.Beige; B39.Content = 0; B38.Foreground = Brushes.Beige;
            B29.Content = 0; B28.Foreground = Brushes.Beige; B38.Content = 0; B37.Foreground = Brushes.Beige;
            B30.Content = 0; B29.Foreground = Brushes.Beige; B37.Content = 0; B36.Foreground = Brushes.Beige;
            B31.Content = 0; B30.Foreground = Brushes.Beige; B36.Content = 0; B35.Foreground = Brushes.Beige;
            B32.Content = 0; B31.Foreground = Brushes.Beige; B35.Content = 0; B34.Foreground = Brushes.Beige;
            B33.Content = 0; B32.Foreground = Brushes.Beige; B34.Content = 0; B33.Foreground = Brushes.Beige;
        }
        private void B63_Click(object sender, RoutedEventArgs e)
        {
            BitTog(1, BittogInputBox, B63);
        }

        private void B64_Click(object sender, RoutedEventArgs e)
        {
            BitTog(0, BittogInputBox, B64);
        }

        private void B61_Click(object sender, RoutedEventArgs e)
        {
            BitTog(3, BittogInputBox, B61);
        }

        private void B62_Click(object sender, RoutedEventArgs e)
        {
            BitTog(2, BittogInputBox, B62);
        }

        private void B59_Click(object sender, RoutedEventArgs e)
        {
            BitTog(5, BittogInputBox, B59);
        }

        private void B58_Click(object sender, RoutedEventArgs e)
        {
            BitTog(6, BittogInputBox, B58);
        }

        private void B57_Click(object sender, RoutedEventArgs e)
        {
            BitTog(7, BittogInputBox, B57);
        }

        private void B56_Click(object sender, RoutedEventArgs e)
        {
            BitTog(8, BittogInputBox, B56);
        }

        private void B55_Click(object sender, RoutedEventArgs e)
        {
            BitTog(9, BittogInputBox, B55);
        }

        private void B54_Click(object sender, RoutedEventArgs e)
        {
            BitTog(10, BittogInputBox, B54);
        }

        private void B53_Click(object sender, RoutedEventArgs e)
        {
            BitTog(11, BittogInputBox, B53);
        }

        private void B52_Click(object sender, RoutedEventArgs e)
        {
            BitTog(12, BittogInputBox, B52);
        }

        private void B51_Click(object sender, RoutedEventArgs e)
        {
            BitTog(13, BittogInputBox, B51);
        }

        private void B50_Click(object sender, RoutedEventArgs e)
        {
            BitTog(14, BittogInputBox, B50);
        }

        private void B49_Click(object sender, RoutedEventArgs e)
        {
            BitTog(15, BittogInputBox, B49);
        }

        private void B48_Click(object sender, RoutedEventArgs e)
        {
            BitTog(16, BittogInputBox, B48);
        }

        private void B47_Click(object sender, RoutedEventArgs e)
        {
            BitTog(17, BittogInputBox, B47);
        }

        private void B46_Click(object sender, RoutedEventArgs e)
        {
            BitTog(18, BittogInputBox, B46);
        }

        private void B45_Click(object sender, RoutedEventArgs e)
        {
            BitTog(19, BittogInputBox, B45);
        }

        private void B44_Click(object sender, RoutedEventArgs e)
        {
            BitTog(20, BittogInputBox, B44);
        }

        private void B43_Click(object sender, RoutedEventArgs e)
        {
            BitTog(21, BittogInputBox, B43);
        }

        private void B42_Click(object sender, RoutedEventArgs e)
        {
            BitTog(22, BittogInputBox, B42);
        }

        private void B41_Click(object sender, RoutedEventArgs e)
        {
            BitTog(23, BittogInputBox, B41);
        }

        private void B40_Click(object sender, RoutedEventArgs e)
        {
            BitTog(24, BittogInputBox, B40);
        }

        private void B39_Click(object sender, RoutedEventArgs e)
        {
            BitTog(25, BittogInputBox, B39);
        }

        private void B38_Click(object sender, RoutedEventArgs e)
        {
            BitTog(26, BittogInputBox, B38);
        }

        private void B37_Click(object sender, RoutedEventArgs e)
        {
            BitTog(27, BittogInputBox, B37);
        }

        private void B36_Click(object sender, RoutedEventArgs e)
        {
            BitTog(28, BittogInputBox, B36);
        }

        private void B35_Click(object sender, RoutedEventArgs e)
        {
            BitTog(29, BittogInputBox, B35);
        }

        private void B34_Click(object sender, RoutedEventArgs e)
        {
            BitTog(30, BittogInputBox, B34);
        }

        private void B33_Click(object sender, RoutedEventArgs e)
        {
            BitTog(31, BittogInputBox, B33);
        }

        private void B32_Click(object sender, RoutedEventArgs e)
        {
            BitTog(32, BittogInputBox, B32);
        }

        private void B31_Click(object sender, RoutedEventArgs e)
        {
            BitTog(33, BittogInputBox, B31);
        }

        private void B30_Click(object sender, RoutedEventArgs e)
        {
            BitTog(34, BittogInputBox, B30);
        }

        private void B29_Click(object sender, RoutedEventArgs e)
        {
            BitTog(35, BittogInputBox, B29);
        }

        private void B28_Click(object sender, RoutedEventArgs e)
        {
            BitTog(36, BittogInputBox, B28);
        }

        private void B27_Click(object sender, RoutedEventArgs e)
        {
            BitTog(37, BittogInputBox, B27);
        }

        private void B26_Click(object sender, RoutedEventArgs e)
        {
            BitTog(38, BittogInputBox, B26);
        }

        private void B25_Click(object sender, RoutedEventArgs e)
        {
            BitTog(39, BittogInputBox, B25);
        }

        private void B24_Click(object sender, RoutedEventArgs e)
        {
            BitTog(40, BittogInputBox, B24);
        }

        private void B23_Click(object sender, RoutedEventArgs e)
        {
            BitTog(41, BittogInputBox, B23);
        }

        private void B22_Click(object sender, RoutedEventArgs e)
        {
            BitTog(42, BittogInputBox, B22);
        }

        private void B21_Click(object sender, RoutedEventArgs e)
        {
            BitTog(43, BittogInputBox, B21);
        }

        private void B20_Click(object sender, RoutedEventArgs e)
        {
            BitTog(44, BittogInputBox, B20);
        }

        private void B19_Click(object sender, RoutedEventArgs e)
        {
            BitTog(45, BittogInputBox, B19);
        }

        private void B18_Click(object sender, RoutedEventArgs e)
        {
            BitTog(46, BittogInputBox, B18);
        }

        private void B17_Click(object sender, RoutedEventArgs e)
        {
            BitTog(47, BittogInputBox, B17);
        }

        private void B16_Click(object sender, RoutedEventArgs e)
        {
            BitTog(48, BittogInputBox, B16);
        }

        private void B15_Click(object sender, RoutedEventArgs e)
        {
            BitTog(49, BittogInputBox, B15);
        }

        private void B14_Click(object sender, RoutedEventArgs e)
        {
            BitTog(50, BittogInputBox, B14);
        }

        private void B13_Click(object sender, RoutedEventArgs e)
        {
            BitTog(51, BittogInputBox, B13);
        }

        private void B12_Click(object sender, RoutedEventArgs e)
        {
            BitTog(52, BittogInputBox, B12);
        }

        private void B11_Click(object sender, RoutedEventArgs e)
        {
            BitTog(53, BittogInputBox, B11);
        }

        private void B10_Click(object sender, RoutedEventArgs e)
        {
            BitTog(54, BittogInputBox, B10);
        }

        private void B9_Click(object sender, RoutedEventArgs e)
        {
            BitTog(55, BittogInputBox, B9);
        }

        private void B8_Click(object sender, RoutedEventArgs e)
        {
            BitTog(56, BittogInputBox, B8);
        }

        private void B7_Click(object sender, RoutedEventArgs e)
        {
            BitTog(57, BittogInputBox, B7);
        }

        private void B6_Click(object sender, RoutedEventArgs e)
        {
            BitTog(58, BittogInputBox, B6);
        }

        private void B5_Click(object sender, RoutedEventArgs e)
        {
            BitTog(59, BittogInputBox, B5);
        }

        private void B4_Click(object sender, RoutedEventArgs e)
        {
            BitTog(60, BittogInputBox, B4);
        }

        private void B3_Click(object sender, RoutedEventArgs e)
        {
            BitTog(61, BittogInputBox, B3);
        }

        private void B2_Click(object sender, RoutedEventArgs e)
        {
            BitTog(62, BittogInputBox, B2);
        }

       

        private void B1_Click(object sender, RoutedEventArgs e)
        {
            BitTog(63, BittogInputBox, B1);
        }

       

        private void B60_Click(object sender, RoutedEventArgs e)
        {
            BitTog(4, BittogInputBox, B60);
        }

        #endregion

        private void BittogInputBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            try
            {
           
            DigitalHandle handle = new DigitalHandle();
            string toconv = handle.ConvertFrom(BittogInputBox.Text, 2);
            char[] anyar = { '+', '-', '*', '/', '%','.' };
            int Boxindex = 0;
            if (string.IsNullOrEmpty(Focused().Text))
                Boxindex = Focused().CaretIndex;
            else if(Boxindex!=Focused().Text.Length)
            { Focused().CaretIndex = Focused().Text.Length;Boxindex = Focused().CaretIndex; }


            if(!string.IsNullOrEmpty(Focused().Text)&&!(Focused().Text.Contains("+") || Focused().Text.Contains("/") || Focused().Text.Contains("*") || Focused().Text.Contains("-") || Focused().Text.Contains("%") || Focused().Text.Contains(".")))
            {
                Focused().Text = "";
            }

            if (!string.IsNullOrEmpty(Focused().Text)&&(Focused().Text.Contains("+")|| Focused().Text.Contains("/")|| Focused().Text.Contains("*")|| Focused().Text.Contains("-")|| Focused().Text.Contains("%") || Focused().Text.Contains(".")))
            {
                if (Focused().Text.LastIndexOfAny(anyar) == Focused().Text.Length - 1) { }
                else
                   Focused().Text = Focused().Text.Remove(Focused().Text.LastIndexOfAny(anyar)+1);
            }

            if (Focused() == CommonInputBox)
            {
                string toadd = "";
                switch (InputOpLv.SelectedIndex)
                {
                    case 0: toadd = handle.ConvertTo(toconv, 16); break;
                    case 1: toadd = handle.ConvertTo(toconv, 8); break;
                    case 2: toadd = handle.ConvertTo(toconv, 10); break;
                    case 3: toadd = handle.ConvertTo(toconv, 2); break;
                }

                Focused().Text += toadd;
            }

            else if (Focused() == IpBox)
            {
                    if (BinIpRadio.IsChecked == true)
                        Focused().Text += BittogInputBox.Text;
                    else
                        MessageBox.Show("Please check the BIN mode");
            }
            else
                Focused().Text += BittogInputBox.Text;

            Focused().CaretIndex = Focused().Text.Length;
            Focused().Focus();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Unexpected-Error" + ex.Message, "Invalid input_Error");
            }
        }

        #endregion
    }
}
