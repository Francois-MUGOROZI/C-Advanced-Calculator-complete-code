using Calckit.GUIsHandle;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using TimeConverter;
using Calckit.Calculations;

namespace Calckit.GUIs
{
    /// <summary>
    /// Interaction logic for DateTimeWindow.xaml
    /// </summary>
    public partial class DateTimeWindow : Window
    {
        //global variables 
        string ComResult;
        string AdvResult;
        char Operator;
        string From;
        string To;
        string SelectedOp;
        AdvTimeCalc calc = new AdvTimeCalc();
        public DateTimeWindow()
        {
            InitializeComponent();
        }

      

        #region contrilling text boxes
        private void SSTb_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SSTb.Focusable = true;
            SSTb.CaretIndex = SSTb.CaretIndex;
            SSTb.Focus();
        }

        private void MmTb_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MmTb.Focusable = true;
            MmTb.CaretIndex = SSTb.CaretIndex;
            MmTb.Focus();
        }

        private void HHTb_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HHTb.Focusable = true;
            HHTb.CaretIndex = SSTb.CaretIndex;
            HHTb.Focus();
        }

        private void DDTb_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DDTb.Focusable = true;
            DDTb.CaretIndex = SSTb.CaretIndex;
            DDTb.Focus();
        }

        private void WWTb_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WWTb.Focusable = true;
            WWTb.CaretIndex = SSTb.CaretIndex;
            WWTb.Focus();
        }

        private void MMTb_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            MMTb.Focusable = true;
            MMTb.CaretIndex = SSTb.CaretIndex;
            MMTb.Focus();
        }

        private void YYTb_MouseDown(object sender, MouseButtonEventArgs e)
        {
            YYTb.Focusable = true;
            YYTb.CaretIndex = SSTb.CaretIndex;
            YYTb.Focus();
        }

        private void YYTb2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            YYTb2.Focusable = true;
            YYTb2.CaretIndex = SSTb.CaretIndex;
            YYTb2.Focus();
        }

        private void MMTb2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MMTb2.Focusable = true;
            MMTb2.CaretIndex = SSTb.CaretIndex;
            MMTb2.Focus();
        }

        private void WWTb2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WWTb2.Focusable = true;
            WWTb2.CaretIndex = SSTb.CaretIndex;
            WWTb2.Focus();
        }

        private void DDTb2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DDTb2.Focusable = true;
            DDTb2.CaretIndex = SSTb.CaretIndex;
            DDTb2.Focus();
        }

        private void HHTb2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HHTb2.Focusable = true;
            HHTb2.CaretIndex = SSTb.CaretIndex;
            HHTb2.Focus();
        }

        private void MmTb2_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            MmTb2.Focusable = true;
            MmTb2.CaretIndex = SSTb.CaretIndex;
            MmTb2.Focus();
        }

        private void SSTb2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SSTb2.Focusable = true;
            SSTb2.CaretIndex = SSTb.CaretIndex;
            SSTb2.Focus();
        }

        private void InputTB1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            InputTB1.Focusable = true;
            InputTB1.CaretIndex = SSTb.CaretIndex;
            InputTB1.Focus();
        }

        private void InputTB2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            InputTB2.Focusable = true;
            InputTB2.CaretIndex = SSTb.CaretIndex;
            InputTB2.Focus();
        }

        private void Supinput1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Supinput1.Focusable = true;
            Supinput1.CaretIndex = SSTb.CaretIndex;
            Supinput1.Focus();
        }

        private void Supinput2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Supinput2.Focusable = true;
            Supinput2.CaretIndex = SSTb.CaretIndex;
            Supinput2.Focus();
        }

        private void Supinput3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Supinput3.Focusable = true;
            Supinput3.CaretIndex = SSTb.CaretIndex;
            Supinput3.Focus();
        }

        private void Supinput3_GotFocus(object sender, RoutedEventArgs e)
        {
            Supinput3.CaretIndex = Supinput3.CaretIndex;
            Supinput3.Focus();

            InputTB1.Focusable = false;
            InputTB2.Focusable = false;
            Supinput1.Focusable = false;
            Supinput2.Focusable = false;
           

            SSTb.Focusable = false;
            SSTb2.Focusable = false;
            MmTb.Focusable = false;
            MmTb2.Focusable = false;
            HHTb.Focusable = false;
            HHTb2.Focusable = false;
            DDTb.Focusable = false;
            DDTb2.Focusable = false;
            WWTb.Focusable = false;
            WWTb2.Focusable = false;
            MMTb.Focusable = false;
            MMTb2.Focusable = false;
            YYTb.Focusable = false;
            YYTb2.Focusable = false;
            try
            {

            FromBox.Focusable = false;
            }
            catch (Exception)
            {
            }
        }

        private void FromBox_GotFocus(object sender, RoutedEventArgs e)
        {
            FromBox.CaretIndex = FromBox.CaretIndex;
            FromBox.Focus();

            InputTB1.Focusable = false;
            InputTB2.Focusable = false;
            Supinput1.Focusable = false;
            Supinput2.Focusable = false;
            Supinput3.Focusable = false;

            SSTb.Focusable = false;
            SSTb2.Focusable = false;
            MmTb.Focusable = false;
            MmTb2.Focusable = false;
            HHTb.Focusable = false;
            HHTb2.Focusable = false;
            DDTb.Focusable = false;
            DDTb2.Focusable = false;
            WWTb.Focusable = false;
            WWTb2.Focusable = false;
            MMTb.Focusable = false;
            MMTb2.Focusable = false;
            YYTb.Focusable = false;
            YYTb2.Focusable = false;

        }

        private void FromBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FromBox.Focusable = true;
            FromBox.CaretIndex = SSTb.CaretIndex;
            FromBox.Focus();
        }

        private void Supinput2_GotFocus(object sender, RoutedEventArgs e)
        {
            Supinput2.CaretIndex = Supinput2.CaretIndex;
            Supinput2.Focus();

            InputTB1.Focusable = false;
            InputTB2.Focusable = false;
            Supinput1.Focusable = false;
            FromBox.Focusable = false;
            Supinput3.Focusable = false;

            SSTb.Focusable = false;
            SSTb2.Focusable = false;
            MmTb.Focusable = false;
            MmTb2.Focusable = false;
            HHTb.Focusable = false;
            HHTb2.Focusable = false;
            DDTb.Focusable = false;
            DDTb2.Focusable = false;
            WWTb.Focusable = false;
            WWTb2.Focusable = false;
            MMTb.Focusable = false;
            MMTb2.Focusable = false;
            YYTb.Focusable = false;
            YYTb2.Focusable = false;
        }

        private void Supinput1_GotFocus(object sender, RoutedEventArgs e)
        {
            Supinput1.CaretIndex = Supinput1.CaretIndex;
            Supinput1.Focus();

            InputTB1.Focusable = false;
            InputTB2.Focusable = false;
            FromBox.Focusable = false;
            Supinput2.Focusable = false;
            Supinput3.Focusable = false;

            SSTb.Focusable = false;
            SSTb2.Focusable = false;
            MmTb.Focusable = false;
            MmTb2.Focusable = false;
            HHTb.Focusable = false;
            HHTb2.Focusable = false;
            DDTb.Focusable = false;
            DDTb2.Focusable = false;
            WWTb.Focusable = false;
            WWTb2.Focusable = false;
            MMTb.Focusable = false;
            MMTb2.Focusable = false;
            YYTb.Focusable = false;
            YYTb2.Focusable = false;
        }

        private void InputTB2_GotFocus(object sender, RoutedEventArgs e)
        {
            InputTB2.CaretIndex = InputTB2.CaretIndex;
            InputTB2.Focus();

            InputTB1.Focusable = false;
            FromBox.Focusable = false;
            Supinput1.Focusable = false;
            Supinput2.Focusable = false;
            Supinput3.Focusable = false;

            SSTb.Focusable = false;
            SSTb2.Focusable = false;
            MmTb.Focusable = false;
            MmTb2.Focusable = false;
            HHTb.Focusable = false;
            HHTb2.Focusable = false;
            DDTb.Focusable = false;
            DDTb2.Focusable = false;
            WWTb.Focusable = false;
            WWTb2.Focusable = false;
            MMTb.Focusable = false;
            MMTb2.Focusable = false;
            YYTb.Focusable = false;
            YYTb2.Focusable = false;
        }

        private void InputTB1_GotFocus(object sender, RoutedEventArgs e)
        {
            InputTB1.CaretIndex = InputTB1.CaretIndex;
            InputTB1.Focus();

            FromBox.Focusable = false;
            InputTB2.Focusable = false;
            Supinput1.Focusable = false;
            Supinput2.Focusable = false;
            Supinput3.Focusable = false;

            SSTb.Focusable = false;
            SSTb2.Focusable = false;
            MmTb.Focusable = false;
            MmTb2.Focusable = false;
            HHTb.Focusable = false;
            HHTb2.Focusable = false;
            DDTb.Focusable = false;
            DDTb2.Focusable = false;
            WWTb.Focusable = false;
            WWTb2.Focusable = false;
            MMTb.Focusable = false;
            MMTb2.Focusable = false;
            YYTb.Focusable = false;
            YYTb2.Focusable = false;
            
        }

        private void YYTb2_GotFocus(object sender, RoutedEventArgs e)
        {
            YYTb2.CaretIndex = YYTb2.CaretIndex;
            YYTb2.Focus();

            FromBox.Focusable = false;
            InputTB2.Focusable = false;
            Supinput1.Focusable = false;
            Supinput2.Focusable = false;
            Supinput3.Focusable = false;

            SSTb.Focusable = false;
            SSTb2.Focusable = false;
            MmTb.Focusable = false;
            MmTb2.Focusable = false;
            HHTb.Focusable = false;
            HHTb2.Focusable = false;
            DDTb.Focusable = false;
            DDTb2.Focusable = false;
            WWTb.Focusable = false;
            WWTb2.Focusable = false;
            MMTb.Focusable = false;
            MMTb2.Focusable = false;
            YYTb.Focusable = false;
            InputTB1.Focusable = false;
        }

        private void MMTb2_GotFocus(object sender, RoutedEventArgs e)
        {
            MMTb2.CaretIndex = MMTb2.CaretIndex;
            MMTb2.Focus();

            FromBox.Focusable = false;
            InputTB2.Focusable = false;
            Supinput1.Focusable = false;
            Supinput2.Focusable = false;
            Supinput3.Focusable = false;

            SSTb.Focusable = false;
            SSTb2.Focusable = false;
            MmTb.Focusable = false;
            MmTb2.Focusable = false;
            HHTb.Focusable = false;
            HHTb2.Focusable = false;
            DDTb.Focusable = false;
            DDTb2.Focusable = false;
            WWTb.Focusable = false;
            WWTb2.Focusable = false;
            MMTb.Focusable = false;
            InputTB1.Focusable = false;
            YYTb.Focusable = false;
            YYTb2.Focusable = false;
        }

        private void WWTb2_GotFocus(object sender, RoutedEventArgs e)
        {
            WWTb2.CaretIndex = WWTb2.CaretIndex;
            WWTb2.Focus();

            FromBox.Focusable = false;
            InputTB2.Focusable = false;
            Supinput1.Focusable = false;
            Supinput2.Focusable = false;
            Supinput3.Focusable = false;

            SSTb.Focusable = false;
            SSTb2.Focusable = false;
            MmTb.Focusable = false;
            MmTb2.Focusable = false;
            HHTb.Focusable = false;
            HHTb2.Focusable = false;
            DDTb.Focusable = false;
            DDTb2.Focusable = false;
            WWTb.Focusable = false;
            InputTB1.Focusable = false;
            MMTb.Focusable = false;
            MMTb2.Focusable = false;
            YYTb.Focusable = false;
            YYTb2.Focusable = false;
        }

        private void DDTb2_GotFocus(object sender, RoutedEventArgs e)
        {
            DDTb2.CaretIndex = DDTb2.CaretIndex;
            DDTb2.Focus();

            FromBox.Focusable = false;
            InputTB2.Focusable = false;
            Supinput1.Focusable = false;
            Supinput2.Focusable = false;
            Supinput3.Focusable = false;

            SSTb.Focusable = false;
            SSTb2.Focusable = false;
            MmTb.Focusable = false;
            MmTb2.Focusable = false;
            HHTb.Focusable = false;
            HHTb2.Focusable = false;
            DDTb.Focusable = false;
            InputTB1.Focusable = false;
            WWTb.Focusable = false;
            WWTb2.Focusable = false;
            MMTb.Focusable = false;
            MMTb2.Focusable = false;
            YYTb.Focusable = false;
            YYTb2.Focusable = false;
        }

        private void HHTb2_GotFocus(object sender, RoutedEventArgs e)
        {
            HHTb2.CaretIndex = HHTb2.CaretIndex;
            HHTb2.Focus();

            FromBox.Focusable = false;
            InputTB2.Focusable = false;
            Supinput1.Focusable = false;
            Supinput2.Focusable = false;
            Supinput3.Focusable = false;

            SSTb.Focusable = false;
            SSTb2.Focusable = false;
            MmTb.Focusable = false;
            MmTb2.Focusable = false;
            HHTb.Focusable = false;
            InputTB1.Focusable = false;
            DDTb.Focusable = false;
            DDTb2.Focusable = false;
            WWTb.Focusable = false;
            WWTb2.Focusable = false;
            MMTb.Focusable = false;
            MMTb2.Focusable = false;
            YYTb.Focusable = false;
            YYTb2.Focusable = false;
        }

        private void MmTb2_GotFocus_1(object sender, RoutedEventArgs e)
        {
            MmTb2.CaretIndex = MmTb2.CaretIndex;
            MmTb2.Focus();

            FromBox.Focusable = false;
            InputTB2.Focusable = false;
            Supinput1.Focusable = false;
            Supinput2.Focusable = false;
            Supinput3.Focusable = false;

            SSTb.Focusable = false;
            SSTb2.Focusable = false;
            MmTb.Focusable = false;
            InputTB1.Focusable = false;
            HHTb.Focusable = false;
            HHTb2.Focusable = false;
            DDTb.Focusable = false;
            DDTb2.Focusable = false;
            WWTb.Focusable = false;
            WWTb2.Focusable = false;
            MMTb.Focusable = false;
            MMTb2.Focusable = false;
            YYTb.Focusable = false;
            YYTb2.Focusable = false;
        }

        private void SSTb2_GotFocus(object sender, RoutedEventArgs e)
        {
            SSTb2.CaretIndex = SSTb2.CaretIndex;
            SSTb2.Focus();

            FromBox.Focusable = false;
            InputTB2.Focusable = false;
            Supinput1.Focusable = false;
            Supinput2.Focusable = false;
            Supinput3.Focusable = false;

            SSTb.Focusable = false;
            InputTB1.Focusable = false;
            MmTb.Focusable = false;
            MmTb2.Focusable = false;
            HHTb.Focusable = false;
            HHTb2.Focusable = false;
            DDTb.Focusable = false;
            DDTb2.Focusable = false;
            WWTb.Focusable = false;
            WWTb2.Focusable = false;
            MMTb.Focusable = false;
            MMTb2.Focusable = false;
            YYTb.Focusable = false;
            YYTb2.Focusable = false;
        }

        private void SSTb_GotFocus(object sender, RoutedEventArgs e)
        {
            SSTb.CaretIndex = SSTb.CaretIndex;
            SSTb.Focus();

            FromBox.Focusable = false;
            InputTB2.Focusable = false;
            Supinput1.Focusable = false;
            Supinput2.Focusable = false;
            Supinput3.Focusable = false;

            InputTB1.Focusable = false;
            SSTb2.Focusable = false;
            MmTb.Focusable = false;
            MmTb2.Focusable = false;
            HHTb.Focusable = false;
            HHTb2.Focusable = false;
            DDTb.Focusable = false;
            DDTb2.Focusable = false;
            WWTb.Focusable = false;
            WWTb2.Focusable = false;
            MMTb.Focusable = false;
            MMTb2.Focusable = false;
            YYTb.Focusable = false;
            YYTb2.Focusable = false;
        }

        private void MmTb_GotFocus(object sender, RoutedEventArgs e)
        {
            MmTb.CaretIndex = MmTb.CaretIndex;
            MmTb.Focus();

            FromBox.Focusable = false;
            InputTB2.Focusable = false;
            Supinput1.Focusable = false;
            Supinput2.Focusable = false;
            Supinput3.Focusable = false;

            SSTb.Focusable = false;
            SSTb2.Focusable = false;
            InputTB1.Focusable = false;
            MmTb2.Focusable = false;
            HHTb.Focusable = false;
            HHTb2.Focusable = false;
            DDTb.Focusable = false;
            DDTb2.Focusable = false;
            WWTb.Focusable = false;
            WWTb2.Focusable = false;
            MMTb.Focusable = false;
            MMTb2.Focusable = false;
            YYTb.Focusable = false;
            YYTb2.Focusable = false;
        }

        private void HHTb_GotFocus(object sender, RoutedEventArgs e)
        {
            HHTb.CaretIndex = HHTb.CaretIndex;
            HHTb.Focus();

            FromBox.Focusable = false;
            InputTB2.Focusable = false;
            Supinput1.Focusable = false;
            Supinput2.Focusable = false;
            Supinput3.Focusable = false;

            SSTb.Focusable = false;
            SSTb2.Focusable = false;
            MmTb.Focusable = false;
            MmTb2.Focusable = false;
            InputTB1.Focusable = false;
            HHTb2.Focusable = false;
            DDTb.Focusable = false;
            DDTb2.Focusable = false;
            WWTb.Focusable = false;
            WWTb2.Focusable = false;
            MMTb.Focusable = false;
            MMTb2.Focusable = false;
            YYTb.Focusable = false;
            YYTb2.Focusable = false;
        }

        private void DDTb_GotFocus(object sender, RoutedEventArgs e)
        {
            DDTb.CaretIndex = DDTb.CaretIndex;
            DDTb.Focus();

            FromBox.Focusable = false;
            InputTB2.Focusable = false;
            Supinput1.Focusable = false;
            Supinput2.Focusable = false;
            Supinput3.Focusable = false;

            SSTb.Focusable = false;
            SSTb2.Focusable = false;
            MmTb.Focusable = false;
            MmTb2.Focusable = false;
            HHTb.Focusable = false;
            HHTb2.Focusable = false;
            InputTB1.Focusable = false;
            DDTb2.Focusable = false;
            WWTb.Focusable = false;
            WWTb2.Focusable = false;
            MMTb.Focusable = false;
            MMTb2.Focusable = false;
            YYTb.Focusable = false;
            YYTb2.Focusable = false;
        }

        private void WWTb_GotFocus(object sender, RoutedEventArgs e)
        {
            WWTb.CaretIndex = WWTb.CaretIndex;
            WWTb.Focus();

            FromBox.Focusable = false;
            InputTB2.Focusable = false;
            Supinput1.Focusable = false;
            Supinput2.Focusable = false;
            Supinput3.Focusable = false;

            SSTb.Focusable = false;
            SSTb2.Focusable = false;
            MmTb.Focusable = false;
            MmTb2.Focusable = false;
            HHTb.Focusable = false;
            HHTb2.Focusable = false;
            DDTb.Focusable = false;
            DDTb2.Focusable = false;
            InputTB1.Focusable = false;
            WWTb2.Focusable = false;
            MMTb.Focusable = false;
            MMTb2.Focusable = false;
            YYTb.Focusable = false;
            YYTb2.Focusable = false;
        }

        private void MMTb_GotFocus_1(object sender, RoutedEventArgs e)
        {
            MMTb.CaretIndex = MMTb.CaretIndex;
            MMTb.Focus();

            FromBox.Focusable = false;
            InputTB2.Focusable = false;
            Supinput1.Focusable = false;
            Supinput2.Focusable = false;
            Supinput3.Focusable = false;

            SSTb.Focusable = false;
            SSTb2.Focusable = false;
            MmTb.Focusable = false;
            MmTb2.Focusable = false;
            HHTb.Focusable = false;
            HHTb2.Focusable = false;
            DDTb.Focusable = false;
            DDTb2.Focusable = false;
            WWTb.Focusable = false;
            WWTb2.Focusable = false;
            InputTB1.Focusable = false;
            MMTb2.Focusable = false;
            YYTb.Focusable = false;
            YYTb2.Focusable = false;
        }

        private void YYTb_GotFocus(object sender, RoutedEventArgs e)
        {
            YYTb.CaretIndex = YYTb.CaretIndex;
            YYTb.Focus();

            FromBox.Focusable = false;
            InputTB2.Focusable = false;
            Supinput1.Focusable = false;
            Supinput2.Focusable = false;
            Supinput3.Focusable = false;

            SSTb.Focusable = false;
            SSTb2.Focusable = false;
            MmTb.Focusable = false;
            MmTb2.Focusable = false;
            HHTb.Focusable = false;
            HHTb2.Focusable = false;
            DDTb.Focusable = false;
            DDTb2.Focusable = false;
            WWTb.Focusable = false;
            WWTb2.Focusable = false;
            MMTb.Focusable = false;
            MMTb2.Focusable = false;
            InputTB1.Focusable = false;
            YYTb2.Focusable = false;
        }


      private void TextIputView(TextBox textBox,TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]");
            if (textBox.Text.Contains(".") && e.Text == ".")
                e.Handled = true;
            else
                e.Handled = regex.IsMatch(e.Text);
        }


        private void SSTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextIputView(SSTb, e);
        }

        private void MmTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextIputView(MmTb, e);
        }

        private void HHTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextIputView(HHTb, e);
        }

        private void DDTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextIputView(DDTb, e);
        }

        private void WWTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextIputView(WWTb, e);
        }

        private void MMTb_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            TextIputView(MMTb, e);
        }

        private void YYTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextIputView(YYTb, e);
        }

        private void YYTb2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextIputView(YYTb2, e);
        }

        private void MMTb2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextIputView(MMTb2, e);
        }

        private void WWTb2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextIputView(WWTb2, e);
        }

        private void DDTb2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextIputView(DDTb2, e);
        }

        private void HHTb2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextIputView(HHTb2, e);
        }

        private void MmTb2_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            TextIputView(MmTb2, e);
        }

        private void SSTb2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextIputView(SSTb2, e);
        }

        private void FromBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextIputView(FromBox, e);
        }
        #endregion


        //mathod that return focused box
        private TextBox Focused()
        {
            if (SSTb.Focus())
                return SSTb;
            else if (SSTb2.Focus())
                return SSTb2;
            else if (MmTb.Focus())
                return MmTb;
            else if (MmTb2.Focus())
                return MmTb2;
            else if (DDTb.Focus())
                return DDTb;
            else if (DDTb2.Focus())
                return DDTb2;
            else if (HHTb.Focus())
                return HHTb;
            else if (HHTb2.Focus())
                return HHTb2;
            else if (WWTb.Focus())
                return WWTb;
            else if (WWTb2.Focus())
                return WWTb2;
            else if (MMTb.Focus())
                return MMTb;
            else if (MMTb2.Focus())
                return MMTb2;
            else if (YYTb.Focus())
                return YYTb;
            else if (YYTb2.Focus())
                return YYTb2;
            else if (InputTB1.Focus())
                return InputTB1;
            else if (InputTB2.Focus())
                return InputTB2;
            else if (Supinput1.Focus())
                return Supinput1;
            else if (Supinput2.Focus())
                return Supinput2;
            else if (Supinput3.Focus())
                return Supinput3;
            else if (FromBox.Focus())
                return FromBox;
            else
                return SSTb;
        }


        #region Input buttonmethods
        private void CommonRadio_Checked(object sender, RoutedEventArgs e)
        {
            try
            {

                CommonGrid.Visibility = Visibility.Visible;
                AdvGrid.Visibility = Visibility.Hidden;
                ComResOpCombo.Visibility = Visibility.Visible;
                DetailBtn.Visibility = Visibility.Hidden;
                DPicker.Visibility = Visibility.Hidden;
            }
            catch (Exception)
            {
            }
            
        }

        private void AdvRadio_Checked(object sender, RoutedEventArgs e)
        {
            CommonGrid.Visibility = Visibility.Collapsed;
            AdvGrid.Visibility = Visibility.Visible;
            ComResOpCombo.Visibility = Visibility.Collapsed;
            DetailBtn.Visibility = Visibility.Visible;
            DPicker.Visibility = Visibility.Visible;
        }

        private void CE_Click(object sender, RoutedEventArgs e)
        {
            TextBox box = Focused();
            box.Text = "";
            box.Focus();
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            if (CommonGrid.IsVisible)
            {
                SSTb.Text = "";
                SSTb2.Text = "";
                MmTb.Text = "";
                MmTb2.Text = "";
                HHTb.Text = "";
                HHTb2.Text = "";
                DDTb.Text = "";
                DDTb2.Text = "";
                WWTb.Text = "";
                WWTb2.Text = "";
                MMTb.Text = "";
                MMTb2.Text = "";
                YYTb.Text = "";
                YYTb2.Text = "";

                ResultTb.Text = "";
                ComResult = "";

            }
            else if (AdvGrid.IsVisible)
            {
                InputTB1.Text = "";
                InputTB2.Text = "";
                Supinput1.Text = "";
                Supinput2.Text = "";
                Supinput3.Text = "";
                ResultTb.Text = "";
                AdvResult = "";
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            TextBox box = Focused();
            ButtonHandle button = new ButtonHandle();
            button.Delete(box);
        }

        private void Ans_Click(object sender, RoutedEventArgs e)
        {
            
            TextBox box = Focused();
            if (CommonGrid.IsVisible)
            {
                box.Text = ComResult;
            }
            else if (AdvGrid.IsVisible)
                box.Text = AdvResult;
            
        }

        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            TextBox box = Focused();
            button.NumBtnHandle(Seven, box);
        }

        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            TextBox box = Focused();
            button.NumBtnHandle(Eight, box);
        }

        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            TextBox box = Focused();
            button.NumBtnHandle(Nine, box);
        }

        private void Four_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            TextBox box = Focused();
            button.NumBtnHandle(Four, box);
        }

        private void Five_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            TextBox box = Focused();
            button.NumBtnHandle(Five, box);
        }

        private void Six_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            TextBox box = Focused();
            button.NumBtnHandle(Six, box);
        }

        private void One_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            TextBox box = Focused();
            button.NumBtnHandle(One, box);
        }

        private void Two_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            TextBox box = Focused();
            button.NumBtnHandle(Two, box);
        }

        private void Three_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            TextBox box = Focused();
            button.NumBtnHandle(Three, box);
        }

        private void Zero_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            TextBox box = Focused();
            button.NumBtnHandle(Zero, box);
        }

        private void Slash_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            TextBox box = Focused();
            button.NumBtnHandle(Slash, box);
        }

        private void Colon_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            TextBox box = Focused();
            button.NumBtnHandle(Colon, box);
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            Operator = '-';
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            Operator = '+';
        }

#endregion

        private void Input1OpCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (Input1OpCombo.SelectedIndex == 0)
                InputTB1.Text = DateTime.Now.ToString();
            else if (Input1OpCombo.SelectedIndex == 1)
                InputTB1.Text = DateTime.Now.AddHours(-24).ToString();
            else if (Input1OpCombo.SelectedIndex == 2)
                InputTB1.Text = DateTime.Now.AddHours(24).ToString();
            else if (Input1OpCombo.SelectedIndex == 3)
                InputTB1.Text = "";
        }

        private void Input2OpCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedOp = Input2OpCombo.SelectedItem.ToString().Remove(0, 38);
            Supinput1.Text = "";
            Supinput2.Text = "";
            Supinput3.Text = "";
            InputTB2.Text = "";
            int Index = Input2OpCombo.SelectedIndex;
            if (Index == 0 || Index == 1 || Index == 9 || Index == 12 || Index == 3 || Index == 15 || Index == 6)
            {
                Supinput3.Visibility = Visibility.Visible;
                Supinput2.Visibility = Visibility.Hidden;
                Supinput1.Visibility = Visibility.Hidden;
                InputTB2.Visibility = Visibility.Hidden;
                Supinput3.Focusable = true;
                Supinput3.Focus();
            }

           else if (Index == 5 || Index == 8 || Index == 17 || Index == 18 || Index == 11 || Index == 14)
            {
                Supinput3.Visibility = Visibility.Visible;
                Supinput2.Visibility = Visibility.Visible;
                Supinput1.Visibility = Visibility.Visible;
                InputTB2.Visibility = Visibility.Hidden;
                Supinput1.Focusable = true;
                Supinput1.Focus();
            }

            else if (Index==19)
            {
                Supinput3.Visibility = Visibility.Hidden;
                Supinput2.Visibility = Visibility.Hidden;
                Supinput1.Visibility = Visibility.Hidden;
                InputTB2.Visibility = Visibility.Visible;
                InputTB2.Focusable = true;
                InputTB2.Focus();
            }

            else  
            {
                Supinput3.Visibility = Visibility.Visible;
                Supinput2.Visibility = Visibility.Visible;
                Supinput1.Visibility = Visibility.Hidden;
                InputTB2.Visibility = Visibility.Hidden;
                Supinput2.Focusable = true;
                Supinput2.Focus();
            }
        }

        private void ComResOpCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ComResult)) { }
                else { 
                TimeunitsConverter converter = new TimeunitsConverter();
                ResultTb.Text = converter.Resultoption(int.Parse(ComResult), ComResOpCombo.SelectedItem.ToString().Remove(0, 38));
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occured: " + ex.Message + "\nPlease try again", "Calculation-Error");
            }
        }

        private void FromCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FromBox.Text == "")
            {
                ToBox.Text = "";
            }
            else
            {
                try
                {
                    From = FromCombo.SelectedItem.ToString().Remove(0, 38);
                    if (string.IsNullOrEmpty(To)) { }
                    else
                    {
                        TimeunitsConverter converter = new TimeunitsConverter();
                        ToBox.Text = converter.Convert(double.Parse(FromBox.Text), From, To).ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occured: " + ex.Message + "\nPlease make sure input is valid and try again", "Calculation-Error");
                }
            }
        }

        private void ToCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FromBox.Text == "")
            {
                ToBox.Text = "";
            }
            else
            {
                try
                {
                    To = ToCombo.SelectedItem.ToString().Remove(0, 38);
                    if (string.IsNullOrEmpty(From)) { }
                    else
                    {
                        TimeunitsConverter converter = new TimeunitsConverter();
                        ToBox.Text = converter.Convert(double.Parse(FromBox.Text), From, To).ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occured: " + ex.Message + "\nPlease make sure input is valid and try again", "Calculation-Error");
                }
            }
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
           
            if (CommonGrid.IsVisible)
            {
                try
                {
                    ComResult = ComTimecalc();
                    ResultTb.Text = ComResult;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Calculation failed:" + ex.Message + "\nMake sure input is valid and try again","Calculation_Error");
                }
            }
            else
            {
                try
                {
                    
                    switch (SelectedOp)
                    {
                        case "ss":
                            {
                                calc.SS = Supinput3.Text;
                                break;
                            }

                        case "mm":
                            {
                                calc.Mm = Supinput3.Text;
                                break;
                            }

                        case "mm-ss":
                            {
                                calc.Mm = Supinput2.Text;
                                calc.SS = Supinput3.Text;
                                break;
                            }

                        case "hh":
                            {
                                calc.HH = Supinput3.Text;
                                break;
                            }

                        case "hh-mm":
                            {
                                calc.HH = Supinput2.Text;
                                calc.Mm = Supinput3.Text;
                                break;
                            }

                        case "hh-mm-ss":
                            {
                                calc.HH = Supinput1.Text;
                                calc.Mm = Supinput2.Text;
                                calc.SS = Supinput3.Text;
                                break;
                            }

                        case "dd":
                            {
                                calc.DD = Supinput3.Text;
                                break;
                            }

                        case "dd-hh":
                            {
                                calc.DD = Supinput2.Text;
                                calc.HH = Supinput3.Text;
                                break;
                            }

                        case "dd-hh-mm":
                            {
                                calc.DD = Supinput1.Text;
                                calc.HH = Supinput2.Text;
                                calc.Mm = Supinput3.Text;
                                break;
                            }

                        case "ww":
                            {
                                calc.WW = Supinput3.Text;
                                break;
                            }

                        case "ww-dd":
                            {
                                calc.WW = Supinput2.Text;
                                calc.DD = Supinput3.Text;
                                break;
                            }

                        case "ww-dd-hh":
                            {
                                calc.WW = Supinput1.Text;
                                calc.DD = Supinput2.Text;
                                calc.HH = Supinput3.Text;
                                break;
                            }

                        case "MM":
                            {
                                calc.MM = Supinput3.Text;
                                break;
                            }

                        case "MM-ww":
                            {
                                calc.MM = Supinput2.Text;
                                calc.WW = Supinput3.Text;
                                break;
                            }

                        case "MM-ww-dd":
                            {
                                calc.MM = Supinput1.Text;
                                calc.WW = Supinput2.Text;
                                calc.DD = Supinput3.Text;
                                break;
                            }

                        case "yy":
                            {
                                calc.YY = Supinput3.Text;
                                break;
                            }

                        case "yy-MM":
                            {
                                calc.YY = Supinput2.Text;
                                calc.MM = Supinput3.Text;
                                break;
                            }

                        case "yy-MM-ww":
                            {
                                calc.YY = Supinput1.Text;
                                calc.MM = Supinput2.Text;
                                calc.WW = Supinput3.Text;
                                break;
                            }

                        case "yy-MM-dd":
                            {
                                calc.YY = Supinput1.Text;
                                calc.MM = Supinput2.Text;
                                calc.DD = Supinput3.Text;
                                break;
                            }
                        case "custom":
                            {
                                calc.Time2 = DateTime.Parse(InputTB2.Text);
                                break;
                            }

                        default:
                            {
                                break;
                            }
                    }

                    calc.Time1 = DateTime.Parse(InputTB1.Text);

                    AdvResult = calc.GetOption(SelectedOp, Operator);

                    ResultTb.Text = AdvResult;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Calculation failed:" + ex.Message + "\nMake sure input is valid and try again", "Calculation_Error");
                }
            }
        }

        private string ComTimecalc()
        {
            double s1, s2, m1, m2, h1, h2, d1, d2, w1, w2, M1, M2, y1, y2;
            if (SSTb.Text == "")
                s1 = 0;
            else
                s1 = double.Parse(SSTb.Text);

            if (SSTb2.Text == "")
                s2 = 0;
            else
                s2 = double.Parse(SSTb2.Text);

            if (MmTb.Text == "")
                m1 = 0;
            else
                m1 = double.Parse(MmTb.Text);

            if (MmTb2.Text == "")
                m2 = 0;
            else
                m2 = double.Parse(MmTb2.Text);

            if (HHTb.Text == "")
                h1 = 0;
            else
                h1 = double.Parse(HHTb.Text);

            if (HHTb2.Text == "")
                h2 = 0;
            else
                h2 = double.Parse(HHTb2.Text);

            if (DDTb.Text == "")
                d1 = 0;
            else
                d1 = double.Parse(DDTb.Text);

            if (DDTb2.Text == "")
                d2 = 0;
            else
                d2 = double.Parse(DDTb2.Text);

            if (WWTb.Text == "")
                w1 = 0;
            else
                w1 = double.Parse(WWTb.Text);

            if (WWTb2.Text == "")
                w2 = 0;
            else
                w2 = double.Parse(WWTb2.Text);

            if (MMTb.Text == "")
                M1 = 0;
            else
                M1 = double.Parse(MMTb.Text);

            if (MMTb2.Text == "")
                M2 = 0;
            else
                M2 = double.Parse(MMTb2.Text);

            if (YYTb.Text == "")
                y1 = 0;
            else
                y1 = double.Parse(YYTb.Text);

            if (YYTb2.Text == "")
                y2 = 0;
            else
                y2 = double.Parse(YYTb2.Text);


            m1 = m1 * 60; m2 = m2 * 60; h1 = h1 * 3600; h2 = h2 * 3600; d1 = d1 * 86400; d2 = d2 * 86400;
            w1 = w1 * 604800; w2 = w2 * 604800; M1 = M1 * 2548800;M2 = M2 * 2548800; y1 = y1 * 31557600;y2 = y2 * 31557600;

            double r1 = s1 + m1 + h1 + d1 + w1 + M1 + y1;
            double r2 = s2 + m2 + h2 + d2 + w2 + M2 + y2;

            switch (Operator)
            {
                case '+':
                    {
                        return (r1 + r2).ToString();
                    }
                case '-':
                    {
                        return (r1 - r2).ToString();
                    }
                default:
                    {
                        return "Please choose operator";
                    }
            }
        }
       

        private void DetailBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DetailBlock.IsVisible)
            {
                DetailBlock.Visibility = Visibility.Hidden;
                DetailBtn.Background = Brushes.Transparent;
            }
            else
            {
              
                try
                {
                    if (InputTB2.Text == ""&&Supinput1.Text==""&&Supinput2.Text==""&&Supinput3.Text=="")
                    {
                        calc.DateDetailGen(DetailBlock, DateTime.Parse(InputTB1.Text));
                    }
                    else if (SelectedOp == "custom")
                    {
                        calc.TimeDiffDetail(DetailBlock, calc.Time1, calc.Time2);
                    }
                    else
                        calc.DetailGen(calc.Time1, calc.Result, SelectedOp, Operator, DetailBlock);
                }
                catch (Exception ex)
                {

                    DetailBlock.Text = "Unexpected error occured:\n" + ex.Message + "\nPlease make sure you enter correct datetime\n" +
                        "and select one of option in dropdown menus";
                }
                DetailBtn.Background = Brushes.LightBlue;
                DetailBlock.Visibility = Visibility.Visible;
            }
        }

        private void DPicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (InputTB1.Focus() && Input1OpCombo.SelectedIndex == 3)
                InputTB1.Text = DPicker.Text;
            else if (InputTB2.Focus())
                InputTB2.Text = DPicker.Text;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                if (CommonGrid.IsVisible)
                {
                    try
                    {
                        ComResult = ComTimecalc();
                        ResultTb.Text = ComResult;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Calculation failed:" + ex.Message + "\nMake sure input is valid and try again", "Calculation_Error");
                    }
                }
                else
                {
                    try
                    {

                        switch (SelectedOp)
                        {
                            case "ss":
                                {
                                    calc.SS = Supinput3.Text;
                                    break;
                                }

                            case "mm":
                                {
                                    calc.Mm = Supinput3.Text;
                                    break;
                                }

                            case "mm-ss":
                                {
                                    calc.Mm = Supinput2.Text;
                                    calc.SS = Supinput3.Text;
                                    break;
                                }

                            case "hh":
                                {
                                    calc.HH = Supinput3.Text;
                                    break;
                                }

                            case "hh-mm":
                                {
                                    calc.HH = Supinput2.Text;
                                    calc.Mm = Supinput3.Text;
                                    break;
                                }

                            case "hh-mm-ss":
                                {
                                    calc.HH = Supinput1.Text;
                                    calc.Mm = Supinput2.Text;
                                    calc.SS = Supinput3.Text;
                                    break;
                                }

                            case "dd":
                                {
                                    calc.DD = Supinput3.Text;
                                    break;
                                }

                            case "dd-hh":
                                {
                                    calc.DD = Supinput2.Text;
                                    calc.HH = Supinput3.Text;
                                    break;
                                }

                            case "dd-hh-mm":
                                {
                                    calc.DD = Supinput1.Text;
                                    calc.HH = Supinput2.Text;
                                    calc.Mm = Supinput3.Text;
                                    break;
                                }

                            case "ww":
                                {
                                    calc.WW = Supinput3.Text;
                                    break;
                                }

                            case "ww-dd":
                                {
                                    calc.WW = Supinput2.Text;
                                    calc.DD = Supinput3.Text;
                                    break;
                                }

                            case "ww-dd-hh":
                                {
                                    calc.WW = Supinput1.Text;
                                    calc.DD = Supinput2.Text;
                                    calc.HH = Supinput3.Text;
                                    break;
                                }

                            case "MM":
                                {
                                    calc.MM = Supinput3.Text;
                                    break;
                                }

                            case "MM-ww":
                                {
                                    calc.MM = Supinput2.Text;
                                    calc.WW = Supinput3.Text;
                                    break;
                                }

                            case "MM-ww-dd":
                                {
                                    calc.MM = Supinput1.Text;
                                    calc.WW = Supinput2.Text;
                                    calc.DD = Supinput3.Text;
                                    break;
                                }

                            case "yy":
                                {
                                    calc.YY = Supinput3.Text;
                                    break;
                                }

                            case "yy-MM":
                                {
                                    calc.YY = Supinput2.Text;
                                    calc.MM = Supinput3.Text;
                                    break;
                                }

                            case "yy-MM-ww":
                                {
                                    calc.YY = Supinput1.Text;
                                    calc.MM = Supinput2.Text;
                                    calc.WW = Supinput3.Text;
                                    break;
                                }

                            case "yy-MM-dd":
                                {
                                    calc.YY = Supinput1.Text;
                                    calc.MM = Supinput2.Text;
                                    calc.DD = Supinput3.Text;
                                    break;
                                }
                            case "custom":
                                {
                                    calc.Time2 = DateTime.Parse(InputTB2.Text);
                                    break;
                                }

                            default:
                                {
                                    break;
                                }
                        }

                        calc.Time1 = DateTime.Parse(InputTB1.Text);

                        AdvResult = calc.GetOption(SelectedOp, Operator);

                        ResultTb.Text = AdvResult;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Calculation failed:" + ex.Message + "\nMake sure input is valid and try again", "Calculation_Error");
                    }
                }
            }
            else if (e.Key == Key.OemPlus || e.Key == Key.Add)
            {
                Operator = '+';
            }
            else if(e.Key==Key.OemMinus||e.Key==Key.Subtract)
                Operator = '-';
           
        }

       
    }
}
