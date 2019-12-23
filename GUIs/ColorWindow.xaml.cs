using Calckit.GUIsHandle;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Calckit.Calculations;
using Color = System.Windows.Media.Color;
using System.Windows.Media;

namespace Calckit.GUIs
{
    /// <summary>
    /// Interaction logic for CharColorWindow.xaml
    /// </summary>
    public partial class ColorWindow : Window
    {
        char Operator;
        string Result;
        Color ResultColor;
        Color From;

        public ColorWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Color1Tb.Focus();
            ToBox.Text = "";
        }

       

        private void Window_Closed(object sender, EventArgs e)
        {

        }


        #region Controlling Texbox and radio buttons
        private void Color1Tb_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Color1Tb.Focusable = true;
            Color1Tb.CaretIndex = Color1Tb.CaretIndex;
            Color1Tb.Focus();
        }

        private void Color2Tb_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Color2Tb.Focusable = true;
            Color2Tb.CaretIndex = Color2Tb.CaretIndex;
            Color2Tb.Focus();
        }

        private void FromBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FromBox.Focusable = true;
            FromBox.CaretIndex = FromBox.CaretIndex;
            FromBox.Focus();
        }

        private void FromBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Color1Tb.Focusable = false;
            Color2Tb.Focusable = false;
        }

        private void Color1Tb_GotFocus(object sender, RoutedEventArgs e)
        {
            Color2Tb.Focusable = false;
            FromBox.Focusable = false;
        }

        private void Color2Tb_GotFocus(object sender, RoutedEventArgs e)
        {
            Color1Tb.Focusable = false;
            FromBox.Focusable = false;
        }

        private void Hexradio_Checked(object sender, RoutedEventArgs e)
        {
            try
            {

            ABtn.IsEnabled = true;
            BBtn.IsEnabled = true;
            CBtn.IsEnabled = true;
            DBtn.IsEnabled = true;
            EBtn.IsEnabled = true;
            FBtn.IsEnabled = true;
            HBtn.IsEnabled = true;
            CommBtn.IsEnabled = false;

            Color1Tb.Text = "";
            Color2Tb.Text = "";
            ResultTb.Text = "";
            OperLabel.Content = "";
            }
            catch (Exception)
            {
            }
        }

        private void RGBradio_Checked(object sender, RoutedEventArgs e)
        {
            ABtn.IsEnabled = false;
            BBtn.IsEnabled = false;
            CBtn.IsEnabled = false;
            DBtn.IsEnabled = false;
            EBtn.IsEnabled = false;
            FBtn.IsEnabled = false;
            HBtn.IsEnabled = false;
            CommBtn.IsEnabled = true;

            Color1Tb.Text = "";
            Color2Tb.Text = "";
            ResultTb.Text = "";
            OperLabel.Content = "";
        }

        private void Color1Tb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9#A-Fa-f,]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Color2Tb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9#A-Fa-f,]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void FromBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9#A-Fa-f,]");
            e.Handled = regex.IsMatch(e.Text);
        }


        #endregion


        #region Input buttons handle
        private TextBox Focused()
        {
            if (Color1Tb.Focus())
                return Color1Tb;
            else if (Color2Tb.Focus())
                return Color2Tb;
            else if (FromBox.Focus())
                return FromBox;
            else
                return Color1Tb;
        }
        private void HBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(HBtn, Focused());
        }

        private void CommBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(CommBtn, Focused());
        }

        private void ZeroBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZeroBtn, Focused());
        }

        private void EBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(EBtn, Focused());
        }

        private void FBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(FBtn, Focused());
        }

        private void OneBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(OneBtn, Focused());
        }

        private void TwoBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(TwoBtn, Focused());
        }

        private void ThreeBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ThreeBtn, Focused());
        }

        private void CBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(CBtn, Focused());
        }

        private void DBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(DBtn, Focused());
        }

        private void FourBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(FourBtn, Focused());
        }

        private void FiveBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(FiveBtn, Focused());
        }

        private void SixBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(SixBtn, Focused());
        }

        private void ABtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ABtn, Focused());
        }

        private void BBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(BBtn, Focused());
        }

        private void SevenBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(SevenBtn, Focused());
        }

        private void EigBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(EigBtn, Focused());
        }

        private void NineBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(NineBtn, Focused());
        }

        private void MinusBtn_Click(object sender, RoutedEventArgs e)
        {
            Operator = '-';
            OperLabel.Content = MinusBtn.Content;
            Color2Tb.Focusable = true;
            Color2Tb.Focus();
        }

        private void PlusBtn_Click(object sender, RoutedEventArgs e)
        {
            Operator = '+';
            OperLabel.Content = PlusBtn.Content;
            Color2Tb.Focusable = true;
            Color2Tb.Focus();
        }

        private void TimesBtn_Click(object sender, RoutedEventArgs e)
        {
            Operator = '*';
            OperLabel.Content = TimesBtn.Content;
            Color2Tb.Focusable = true;
            Color2Tb.Focus();
        }

        private void CEBtn_Click(object sender, RoutedEventArgs e)
        {
            Focused().Text = "";
            Focused().Focus();
        }

        private void ClBtn_Click(object sender, RoutedEventArgs e)
        {
            Color2Tb.Text = "";
            Color1Tb.Text = "";
            FromBox.Text = "";
            ResultTb.Text = "";
            ToBox.Text = "";
            OperLabel.Content = "";
            Color1Tb.Focusable = true;
            Color1Tb.Focus();
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.Delete(Focused());
        }

        #endregion

        private void ColorPDefbtn_Click(object sender, RoutedEventArgs e)
        {
            if (ColorList.IsVisible)
            {
                ColorList.Visibility = Visibility.Hidden;
                ColorPDefbtn.Background = System.Windows.Media. Brushes.Transparent;
            }
            else
            {
                ColorList.Visibility = Visibility.Visible;
                ColorList.ScrollIntoView(ColorList.SelectedItem);
                ColorPDefbtn.Background = System.Windows.Media.Brushes.LightBlue;
            }
        }

        private void ColorPickbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            PickColorHandle pickColor = new PickColorHandle();
            pickColor.Options = ColorPickerWPF.Code.ColorPickerDialogOptions.LoadCustomPalette;
                if (Hexradio.IsChecked == true)
                    pickColor.PickColorButton_OnClick(Focused());
                else
                {
                    ColorsConverter converter = new ColorsConverter();
                    pickColor.PickColorButton_OnClick(Focused());
                    Focused().Text = RGBValues(converter.FromHex(Focused().Text));
                }
               
            }
            catch (Exception)
            {
            }
        }

        private void EqualBtn_Click(object sender, RoutedEventArgs e)
        {
            ColorsConverter colors = new ColorsConverter();
            Color color1=new Color(), color2=new Color();
            float coef = 0;
                try
                {
                
                    if (Hexradio.IsChecked == true)
                    {
                            color1 = colors.FromHex(Color1Tb.Text);
                        if (Operator != '*')
                            color2 = colors.FromHex(Color2Tb.Text);
                        else
                            coef = float.Parse(Color2Tb.Text);
                    }
                    else if (RGBradio.IsChecked == true)
                    {
                            int r1 = int.Parse(Color1Tb.Text.Substring(0, Color1Tb.Text.IndexOf(",")));
                            int b1 = int.Parse(Color1Tb.Text.Substring(Color1Tb.Text.LastIndexOf(",") + 1));
                            int g1 = int.Parse(Color1Tb.Text.Substring(Color1Tb.Text.IndexOf(",") + 1, (Color1Tb.Text.Length - r1.ToString().Length - b1.ToString().Length - 2)));
                    color1 = colors.RGBTOColor(r1, g1, b1);
                        if (Operator != '*')
                        {
                            int r2 = int.Parse(Color2Tb.Text.Substring(0, Color1Tb.Text.IndexOf(",")));
                            int b2 = int.Parse(Color2Tb.Text.Substring(Color2Tb.Text.LastIndexOf(",") + 1));
                            int g2 = int.Parse(Color2Tb.Text.Substring(Color2Tb.Text.IndexOf(",") + 1, (Color2Tb.Text.Length - r2.ToString().Length - b2.ToString().Length - 2)));

                            color2 = colors.RGBTOColor(r2, g2, b2);
                        }
                            
                        else
                            coef = float.Parse(Color2Tb.Text);

                       
                    }
                 Result = colors.ColorOperation(color1, color2, Operator, coef);
                 ResultTb.Text = Result;
                 ResultColor = colors.FromHex(Result);
                  
                }
                catch (Exception ex)
                {
                MessageBox.Show("Error: " + ex.Message + "\nPlease enter value like #ffffff or 255,255,255");
                }
            
        }

        private void Color1Tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ColorsConverter colors = new ColorsConverter();

            if (Hexradio.IsChecked == true)
            {
                try
                {
                    Color color = colors.FromHex(Color1Tb.Text);
                    COlorLabel.Background = new SolidColorBrush(color);
                }
                catch (Exception)
                {
                }
            }
            else if (RGBradio.IsChecked == true)
            {
                try
                {
                int r1 = int.Parse(Color1Tb.Text.Substring(0, Color1Tb.Text.IndexOf(",")));
                int b1 = int.Parse(Color1Tb.Text.Substring(Color1Tb.Text.LastIndexOf(",") + 1));
                int g1 = int.Parse(Color1Tb.Text.Substring(Color1Tb.Text.IndexOf(",") + 1, (Color1Tb.Text.Length - r1.ToString().Length - b1.ToString().Length - 2)));
                Color color = colors.RGBTOColor(r1,g1,b1);
                COlorLabel.Background = new SolidColorBrush(color);

                }
                catch (Exception)
                {
                }
            }
            else
            { MessageBox.Show("Please Check one of Buttons HEX or RGB", "Option mismatch error"); }
        }

        private void Color2Tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ColorsConverter colors = new ColorsConverter();

            if (Hexradio.IsChecked == true)
            {
                try
                {
                    Color color = colors.FromHex(Color2Tb.Text);
                    COlorLabel2.Background = new SolidColorBrush(color);
                }
                catch (Exception)
                {
                }
            }
            else if (RGBradio.IsChecked == true)
            {
                try
                {
                    int r1 = int.Parse(Color2Tb.Text.Substring(0, Color2Tb.Text.IndexOf(",")));
                    int b1 = int.Parse(Color2Tb.Text.Substring(Color2Tb.Text.LastIndexOf(",") + 1));
                    int g1 = int.Parse(Color2Tb.Text.Substring(Color2Tb.Text.IndexOf(",") + 1, (Color2Tb.Text.Length - r1.ToString().Length - b1.ToString().Length - 2)));
                    Color color = colors.RGBTOColor(r1, g1, b1);
                    COlorLabel2.Background = new SolidColorBrush(color);

                }
                catch (Exception)
                {
                }
            }
            else
            { MessageBox.Show("Please Check one of Buttons HEX or RGB", "Option mismatch error"); }
        }

        private void ResultTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ColorsConverter colors = new ColorsConverter();
                try
                {
                    Color color = colors.FromHex(ResultTb.Text);
                    COlorLabel3.Background = new SolidColorBrush(color);
                }
                catch (Exception)
                {
                }
            
           
        }

        private void FromBox_TextChanged(object sender, TextChangedEventArgs e)
        {

                string Input = FromBox.Text;
                ColorsConverter converter = new ColorsConverter();
                switch (FromCombo.SelectedIndex)
                {
                    case 0:
                        {
                        try
                        {

                            From = converter.FromHex(Input);
                        }
                        catch (Exception)
                        {
                        }
                            break;
                        }
                    case 1:
                        {
                            try
                            {

                                int r1 = int.Parse(Input.Substring(0, Input.IndexOf(",")));
                                int b1 = int.Parse(Input.Substring(Input.LastIndexOf(",") + 1));
                                int g1 = int.Parse(Input.Substring(Input.IndexOf(",") + 1, (Input.Length - r1.ToString().Length - b1.ToString().Length - 2)));
                                From = converter.RGBTOColor(r1, g1, b1);
                            }
                            catch (Exception)
                            {
                            
                            }
                            break;
                        }
                    case 2:
                        {
                            try
                            {

                                int a = int.Parse(Input.Substring(0, Input.IndexOf(",")));
                                int b = int.Parse(Input.Substring(Input.LastIndexOf(",") + 1));
                                string Rest = Input.Substring(Input.IndexOf(",") + 1, Input.LastIndexOf(","));
                                int r = int.Parse(Rest.Substring(0, Rest.IndexOf(",")));
                                int g = int.Parse(Rest.Substring(Rest.IndexOf(",") + 1));
                                From = Color.FromArgb(Convert.ToByte(a), Convert.ToByte(r), Convert.ToByte(g), Convert.ToByte(b));
                            }
                            catch (Exception)
                            {
                            }
                            break;
                        }
                    case 3:
                        {
                            try
                            {

                                int r1 = int.Parse(Input.Substring(0, Input.IndexOf(",")));
                                int b1 = int.Parse(Input.Substring(Input.LastIndexOf(",") + 1));
                                int g1 = int.Parse(Input.Substring(Input.IndexOf(",") + 1, (Input.Length - r1.ToString().Length - b1.ToString().Length - 2)));
                                From = converter.FromHSL(r1, g1, b1);
                            }
                            catch (Exception)
                            {

                            }
                            break;
                        }
                    case 4:
                        {
                            try
                            {

                                int a = int.Parse(Input.Substring(0, Input.IndexOf(",")));
                                float b = float.Parse(Input.Substring(Input.LastIndexOf(",") + 1));
                                string Rest = Input.Substring(Input.IndexOf(",") + 1, Input.LastIndexOf(","));
                                float r = float.Parse(Rest.Substring(0, Rest.IndexOf(",")));
                                float g = float.Parse(Rest.Substring(Rest.IndexOf(",") + 1));

                                From = converter.FromAhsb(a, r, g, b);
                            }
                            catch (Exception)
                            {
                           
                            }
                            break;
                        }
                
                }

            try
            {
                ConvColLabel.Background = new SolidColorBrush(From);
            }
            catch (Exception)
            {
            }
        }

        private void ResCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           

            switch (ResCombo.SelectedIndex)
            {
                case 0:
                    {
                        ResultTb.Text = Result;
                        break;
                    }
                case 1:
                    {
                        string r = ResultColor.R.ToString();
                        string g = ResultColor.G.ToString();
                        string b = ResultColor.B.ToString();
                        ResultTb.Text = r + "," + g + "," + b;
                        break;
                    }
                case 2:
                    {
                        string a = ResultColor.A.ToString();
                        string r = ResultColor.R.ToString();
                        string g = ResultColor.G.ToString();
                        string b = ResultColor.B.ToString();
                        ResultTb.Text =a+","+ r + "," + g + "," + b;
                        break;
                    }
            }
        }

        private void ColorList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ColorList.SelectedIndex;
            if (Hexradio.IsChecked == true)
            {
                ColorsConverter converter = new ColorsConverter();
                try
                {
                    Focused().Text = converter.Tohex(FromPredColor(index));
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                try
                {
                    Focused().Text = RGBValues(FromPredColor(index));
                }
                catch (Exception)
                {

                    throw;
                }
            }

            ColorList.Visibility = Visibility.Hidden;
            ColorPDefbtn.Background = System.Windows.Media.Brushes.Transparent;

        }


        //method for predefined color choice
        private Color FromPredColor(int index)
        {
            switch (index)
            {
                case 0: return System.Windows.Media.Brushes.AliceBlue.Color;
                case 1: return System.Windows.Media.Brushes.PaleGoldenrod.Color;
                case 2: return System.Windows.Media.Brushes.Orchid.Color;
                case 3: return System.Windows.Media.Brushes.OrangeRed.Color;
                case 4: return System.Windows.Media.Brushes.Orange.Color;
                case 5: return System.Windows.Media.Brushes.OliveDrab.Color;
                case 6: return System.Windows.Media.Brushes.Olive.Color;
                case 7: return System.Windows.Media.Brushes.OldLace.Color;
                case 8: return System.Windows.Media.Brushes.Navy.Color;
                case 9: return System.Windows.Media.Brushes.NavajoWhite.Color;
                case 10: return System.Windows.Media.Brushes.Moccasin.Color;
                case 11: return System.Windows.Media.Brushes.MistyRose.Color;
                case 12: return System.Windows.Media.Brushes.MintCream.Color;
                case 13: return System.Windows.Media.Brushes.MidnightBlue.Color;
                case 14: return System.Windows.Media.Brushes.MediumVioletRed.Color;
                case 15: return System.Windows.Media.Brushes.MediumTurquoise.Color;
                case 16: return System.Windows.Media.Brushes.MediumSpringGreen.Color;
                case 17: return System.Windows.Media.Brushes.MediumSlateBlue.Color;
                case 18: return System.Windows.Media.Brushes.LightSkyBlue.Color;
                case 19: return System.Windows.Media.Brushes.LightSlateGray.Color;
                case 20: return System.Windows.Media.Brushes.LightSteelBlue.Color;
                case 21: return System.Windows.Media.Brushes.LightYellow.Color;
                case 22: return System.Windows.Media.Brushes.Lime.Color;
                case 23: return System.Windows.Media.Brushes.LimeGreen.Color;
                case 24: return System.Windows.Media.Brushes.PaleGreen.Color;
                case 25: return System.Windows.Media.Brushes.Linen.Color;
                case 26: return System.Windows.Media.Brushes.Maroon.Color;
                case 27: return System.Windows.Media.Brushes.MediumAquamarine.Color;
                case 28: return System.Windows.Media.Brushes.MediumBlue.Color;
                case 29: return System.Windows.Media.Brushes.MediumOrchid.Color;
                case 30: return System.Windows.Media.Brushes.MediumPurple.Color;
                case 31: return System.Windows.Media.Brushes.MediumSeaGreen.Color;
                case 32: return System.Windows.Media.Brushes.Magenta.Color;
                case 33: return System.Windows.Media.Brushes.PaleTurquoise.Color;
                case 34: return System.Windows.Media.Brushes.PaleVioletRed.Color;
                case 35: return System.Windows.Media.Brushes.PapayaWhip.Color;
                case 36: return System.Windows.Media.Brushes.SlateGray.Color;
                case 37: return System.Windows.Media.Brushes.Snow.Color;
                case 38: return System.Windows.Media.Brushes.SpringGreen.Color;
                case 39: return System.Windows.Media.Brushes.SteelBlue.Color;
                case 40: return System.Windows.Media.Brushes.Tan.Color;
                case 41: return System.Windows.Media.Brushes.Teal.Color;
                case 42: return System.Windows.Media.Brushes.SlateBlue.Color;
                case 43: return System.Windows.Media.Brushes.Thistle.Color;
                case 44: return System.Windows.Media.Brushes.Transparent.Color;
                case 45: return System.Windows.Media.Brushes.Turquoise.Color;
                case 46: return System.Windows.Media.Brushes.Violet.Color;
                case 47: return System.Windows.Media.Brushes.Wheat.Color;
                case 48: return System.Windows.Media.Brushes.White.Color;
                case 49: return System.Windows.Media.Brushes.WhiteSmoke.Color;
                case 50: return System.Windows.Media.Brushes.Tomato.Color;
                case 51: return System.Windows.Media.Brushes.LightSeaGreen.Color;
                case 52: return System.Windows.Media.Brushes.SkyBlue.Color;
                case 53: return System.Windows.Media.Brushes.Sienna.Color;
                case 54: return System.Windows.Media.Brushes.PeachPuff.Color;
                case 55: return System.Windows.Media.Brushes.Peru.Color;
                case 56: return System.Windows.Media.Brushes.Pink.Color;
                case 57: return System.Windows.Media.Brushes.Plum.Color;
                case 58: return System.Windows.Media.Brushes.PowderBlue.Color;
                case 59: return System.Windows.Media.Brushes.Purple.Color;
                case 60: return System.Windows.Media.Brushes.Silver.Color;
                case 61: return System.Windows.Media.Brushes.Red.Color;
                case 62: return System.Windows.Media.Brushes.RoyalBlue.Color;
                case 63: return System.Windows.Media.Brushes.SaddleBrown.Color;
                case 64: return System.Windows.Media.Brushes.Salmon.Color;
                case 65: return System.Windows.Media.Brushes.SandyBrown.Color;
                case 66: return System.Windows.Media.Brushes.SeaGreen.Color;
                case 67: return System.Windows.Media.Brushes.SeaShell.Color;
                case 68: return System.Windows.Media.Brushes.RosyBrown.Color;
                case 69: return System.Windows.Media.Brushes.Yellow.Color;
                case 70: return System.Windows.Media.Brushes.LightSalmon.Color;
                case 71: return System.Windows.Media.Brushes.LightGreen.Color;
                case 72: return System.Windows.Media.Brushes.DarkRed.Color;
                case 73: return System.Windows.Media.Brushes.DarkOrchid.Color;
                case 74: return System.Windows.Media.Brushes.DarkOrange.Color;
                case 75: return System.Windows.Media.Brushes.DarkOliveGreen.Color;
                case 76: return System.Windows.Media.Brushes.DarkMagenta.Color;
                case 77: return System.Windows.Media.Brushes.DarkKhaki.Color;
                case 78: return System.Windows.Media.Brushes.DarkGreen.Color;
                case 79: return System.Windows.Media.Brushes.DarkGray.Color;
                case 80: return System.Windows.Media.Brushes.DarkGoldenrod.Color;
                case 81: return System.Windows.Media.Brushes.DarkCyan.Color;
                case 82: return System.Windows.Media.Brushes.DarkBlue.Color;
                case 83: return System.Windows.Media.Brushes.Cyan.Color;
                case 84: return System.Windows.Media.Brushes.Crimson.Color;
                case 85: return System.Windows.Media.Brushes.Cornsilk.Color;
                case 86: return System.Windows.Media.Brushes.CornflowerBlue.Color;
                case 87: return System.Windows.Media.Brushes.Coral.Color;
                case 88: return System.Windows.Media.Brushes.Chocolate.Color;
                case 89: return System.Windows.Media.Brushes.AntiqueWhite.Color;
                case 90: return System.Windows.Media.Brushes.Aqua.Color;
                case 91: return System.Windows.Media.Brushes.Aquamarine.Color;
                case 92: return System.Windows.Media.Brushes.Azure.Color;
                case 93: return System.Windows.Media.Brushes.Beige.Color;
                case 94: return System.Windows.Media.Brushes.Bisque.Color;
                case 95: return System.Windows.Media.Brushes.DarkSalmon.Color;
                case 96: return System.Windows.Media.Brushes.Black.Color;
                case 97: return System.Windows.Media.Brushes.Blue.Color;
                case 98: return System.Windows.Media.Brushes.BlueViolet.Color;
                case 99: return System.Windows.Media.Brushes.Brown.Color;
                case 100: return System.Windows.Media.Brushes.BurlyWood.Color;
                case 101: return System.Windows.Media.Brushes.CadetBlue.Color;
                case 102: return System.Windows.Media.Brushes.Chartreuse.Color;
                case 103: return System.Windows.Media.Brushes.BlanchedAlmond.Color;
                case 104: return System.Windows.Media.Brushes.DarkSeaGreen.Color;
                case 105: return System.Windows.Media.Brushes.DarkSlateBlue.Color;
                case 106: return System.Windows.Media.Brushes.DarkSlateGray.Color;
                case 107: return System.Windows.Media.Brushes.HotPink.Color;
                case 108: return System.Windows.Media.Brushes.IndianRed.Color;
                case 109: return System.Windows.Media.Brushes.Indigo.Color;
                case 110: return System.Windows.Media.Brushes.Ivory.Color;
                case 111: return System.Windows.Media.Brushes.Khaki.Color;
                case 112: return System.Windows.Media.Brushes.Lavender.Color;
                case 113: return System.Windows.Media.Brushes.Honeydew.Color;
                case 114: return System.Windows.Media.Brushes.LavenderBlush.Color;
                case 115: return System.Windows.Media.Brushes.LemonChiffon.Color;
                case 116: return System.Windows.Media.Brushes.LightBlue.Color;
                case 117: return System.Windows.Media.Brushes.LightCoral.Color;
                case 118: return System.Windows.Media.Brushes.LightCyan.Color;
                case 119: return System.Windows.Media.Brushes.LightGoldenrodYellow.Color;
                case 120: return System.Windows.Media.Brushes.LightGray.Color;
                case 121: return System.Windows.Media.Brushes.LawnGreen.Color;
                case 122: return System.Windows.Media.Brushes.LightPink.Color;
                case 123: return System.Windows.Media.Brushes.GreenYellow.Color;
                case 124: return System.Windows.Media.Brushes.Gray.Color;
                case 125: return System.Windows.Media.Brushes.DarkTurquoise.Color;
                case 126: return System.Windows.Media.Brushes.DarkViolet.Color;
                case 127: return System.Windows.Media.Brushes.DeepPink.Color;
                case 128: return System.Windows.Media.Brushes.DeepSkyBlue.Color;
                case 129: return System.Windows.Media.Brushes.DimGray.Color;
                case 130: return System.Windows.Media.Brushes.DodgerBlue.Color;
                case 131: return System.Windows.Media.Brushes.Green.Color;
                case 132: return System.Windows.Media.Brushes.Firebrick.Color;
                case 133: return System.Windows.Media.Brushes.ForestGreen.Color;
                case 134: return System.Windows.Media.Brushes.Fuchsia.Color;
                case 135: return System.Windows.Media.Brushes.Gainsboro.Color;
                case 136: return System.Windows.Media.Brushes.GhostWhite.Color;
                case 137: return System.Windows.Media.Brushes.Gold.Color;
                case 138: return System.Windows.Media.Brushes.Goldenrod.Color;
                case 139: return System.Windows.Media.Brushes.FloralWhite.Color;
                case 140: return System.Windows.Media.Brushes.YellowGreen.Color;
                default:return new Color();
            }
        }

        //Method for creating RGB value
        private string RGBValues(Color color)
        {
            return color.R.ToString() + "," + color.G.ToString() + "," + color.B.ToString();
        }

        private void FromCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FromBox.Text = "";
            ToBox.Text = "";
            FromBox.Focus();
            ConvColLabel.Background = null;
        }

        private void ToCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (From == null) { }
            else{
                ColorsConverter converter = new ColorsConverter();
                try
                {
                    switch (ToCombo.SelectedIndex)
                    {
                        case 0:
                            ToBox.Text = converter.Tohex(From);
                            break;
                        case 1:
                            ToBox.Text = RGBValues(From);
                            break;
                        case 2:
                            Color newc = new Color();
                            newc.A = From.A;
                            newc.R = From.R;
                            newc.G = From.G;
                            newc.B = From.B;
                            ToBox.Text = newc.A.ToString() + "," + newc.R.ToString() + "," + newc.G.ToString() + "," + newc.B.ToString();
                            break;
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error: " + ex.Message + "\nPlease correct error and try again");
                }
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ColorsConverter colors = new ColorsConverter();
                Color color1 = new Color(), color2 = new Color();
                float coef = 0;
                try
                {

                    if (Hexradio.IsChecked == true)
                    {
                        color1 = colors.FromHex(Color1Tb.Text);
                        if (Operator != '*')
                            color2 = colors.FromHex(Color2Tb.Text);
                        else
                            coef = float.Parse(Color2Tb.Text);
                    }
                    else if (RGBradio.IsChecked == true)
                    {
                        int r1 = int.Parse(Color1Tb.Text.Substring(0, Color1Tb.Text.IndexOf(",")));
                        int b1 = int.Parse(Color1Tb.Text.Substring(Color1Tb.Text.LastIndexOf(",") + 1));
                        int g1 = int.Parse(Color1Tb.Text.Substring(Color1Tb.Text.IndexOf(",") + 1, (Color1Tb.Text.Length - r1.ToString().Length - b1.ToString().Length - 2)));
                        color1 = colors.RGBTOColor(r1, g1, b1);
                        if (Operator != '*')
                        {
                            int r2 = int.Parse(Color2Tb.Text.Substring(0, Color1Tb.Text.IndexOf(",")));
                            int b2 = int.Parse(Color2Tb.Text.Substring(Color2Tb.Text.LastIndexOf(",") + 1));
                            int g2 = int.Parse(Color2Tb.Text.Substring(Color2Tb.Text.IndexOf(",") + 1, (Color2Tb.Text.Length - r2.ToString().Length - b2.ToString().Length - 2)));

                            color2 = colors.RGBTOColor(r2, g2, b2);
                        }

                        else
                            coef = float.Parse(Color2Tb.Text);


                    }
                    Result = colors.ColorOperation(color1, color2, Operator, coef);
                    ResultTb.Text = Result;
                    ResultColor = colors.FromHex(Result);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message + "\nPlease enter value like #ffffff or 255,255,255");
                }

            }
            else if (e.Key == Key.OemPlus || e.Key == Key.Add)
            {
                Operator = '+';
                OperLabel.Content = PlusBtn.Content;
                Color2Tb.Focusable = true;
                Color2Tb.Focus();
            }
            else if (e.Key == Key.OemMinus || e.Key == Key.Subtract)
            {
                Operator = '-';
                OperLabel.Content = MinusBtn.Content;
                Color2Tb.Focusable = true;
                Color2Tb.Focus();
            }
            else if (e.Key == Key.Multiply)
            {
                Operator = '*';
                OperLabel.Content = TimesBtn.Content;
                Color2Tb.Focusable = true;
                Color2Tb.Focus();
            }
            else
            {
                if (ColorList.IsVisible)
                {
                    foreach(var i in ColorList.Items)
                    {
                        if (i.ToString().Remove(0, 38).StartsWith(e.Key.ToString()))
                        {
                            ColorList.ScrollIntoView(i);
                            return;
                        }
                    }
                }
            }
        }
    }
}
