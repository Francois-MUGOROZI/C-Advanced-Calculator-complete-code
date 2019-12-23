using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Calckit.GUIsHandle;
using Calckit.Calculations;

namespace Calckit.GUIs
{
    /// <summary>
    /// Interaction logic for StdCackWindow.xaml
    /// </summary>
    public partial class StdCackWindow : Window
    {
        public StdCackWindow()
        {
            InitializeComponent();
        }

        //Global variables
       
        string Result;
        string InputExp;
        bool MemRead = false;

        private void StdWindow_Loaded(object sender, RoutedEventArgs e)
        {
            InputBox.Focus();
        }

        private void InputBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            InputBox.Focusable = true;
            InputBox.CaretIndex = InputBox.CaretIndex;
            InputBox.Focus();
        }

       

        #region Input buttons
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.BFBtnHandle(Back, InputBox);
        }

        private void Forth_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.BFBtnHandle(Forth, InputBox);
        }


        private void Zero_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Zero, InputBox);
        }

        private void Point_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Point, InputBox);
        }

        private void One_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(One, InputBox);
        }

        private void Two_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Two, InputBox);
        }

        private void Three_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Three, InputBox);
        }

        private void Tento3_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Tento3, InputBox);
        }

        private void Dzero_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Dzero, InputBox);
        }

        private void Lbr_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Lbr, InputBox);
        }

        private void Rbr_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Rbr, InputBox);
        }

        private void Pi_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Pi, InputBox);
        }

        private void E_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(E, InputBox);
        }

        private void Tento_3_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Tento_3, InputBox);
        }

        private void Six_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Six, InputBox);
        }

        private void Five_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Five, InputBox);
        }

        private void Four_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Four, InputBox);
        }

        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Seven, InputBox);
        }

        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Eight, InputBox);
        }

        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Nine, InputBox);
        }

        private void Tento6_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Tento6, InputBox);
        }

        private void Tento_6_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Tento_6, InputBox);
        }

        private void Mod_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Mod, InputBox);
        }

        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Divide, InputBox);
        }

        private void Time_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Time, InputBox);
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Minus, InputBox);
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Plus, InputBox);
        }

        private void Sin_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Sin, InputBox);
        }

        private void Asin_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Asin, InputBox);
        }

        private void Cos_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Cos, InputBox);
        }

        private void Acos_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Acos, InputBox);
        }

        private void Tan_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Tan, InputBox);
        }

        private void Atann_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Atann, InputBox);
        }


        private void Sqrt_Click(object sender, RoutedEventArgs e)
        {
            if (InputBox.CaretIndex != InputBox.Text.Length)
            {
                int index = InputBox.CaretIndex;
                string input = InputBox.Text;
                input = input.Insert(index, "√" + "(" + ")");
                InputBox.Text = input;
                InputBox.CaretIndex = index + 2;
                InputBox.Focus();
            }
            else
            {
                InputBox.Text += "√" + "(" + ")";
                InputBox.CaretIndex = InputBox.Text.Length - 1;
                InputBox.Focus();
            }
        }

        private void Xsqr_Click(object sender, RoutedEventArgs e)
        {
            if (InputBox.CaretIndex != InputBox.Text.Length)
            {
                int index = InputBox.CaretIndex;
                string input = InputBox.Text;
                input = input.Insert(index, "²");
                InputBox.Text = input;
                InputBox.CaretIndex = index + 1;
                InputBox.Focus();
            }
            else
            {
                InputBox.Text += "²";
                InputBox.CaretIndex = InputBox.Text.Length;
                InputBox.Focus();
            }
        }



        private void PlusMinus_Click(object sender, RoutedEventArgs e)
        {
            if (InputBox.Text.First() == '-')
            {
                InputBox.CaretIndex = InputBox.CaretIndex;
                InputBox.Focus();
            }
            else
            {
                InputBox.Text = InputBox.Text.Insert(0, "-");
            }
        }


        private void CE_Click(object sender, RoutedEventArgs e)
        {
            InputBox.Text = "";
            ResultBox.Text = "";
            InputBox.Focus();
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            InputBox.Text = "";
            ResultBox.Text = "";
            Result = "";
            InputExp = "";
            InputBox.Focus();

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.Delete(InputBox);
        }

        private void Ans_Click(object sender, RoutedEventArgs e)
        {
            if (InputBox.CaretIndex != InputBox.Text.Length)
            {
                int index = InputBox.CaretIndex;
                string input = InputBox.Text;
                input = input.Insert(index, Result);
                InputBox.Text = input;
                InputBox.CaretIndex = index + Result.Length + 1;
                InputBox.Focus();
            }
            else
            {
                InputBox.Text += Result;
                InputBox.CaretIndex = InputBox.Text.Length;
                InputBox.Focus();
            }
        }

        private void MC_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.MemHandle(MC, ResultBox, MemoryArea);
        }

        private void MR_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.MemHandle(MR, ResultBox, MemoryArea);
            MemRead = true;
        }

        private void MS_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.MemHandle(MS, ResultBox, MemoryArea);
        }

        private void Mv_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.MemHandle(Mv, ResultBox, MemoryArea);
        }
        #endregion


        /// <summary>
        /// Calculation methods for inverse of input and equal button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Inverse_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            Calculate calculate = new Calculate();
            InputExp = InputBox.Text;
            Result = calculate.Calculator(InputExp, "Degree");
            Result = (1 / double.Parse(Result)).ToString();
            ResultBox.Text = Result;
            ResultBox.Visibility = Visibility.Visible;
            }
            catch (Exception)
            {

                MessageBox.Show("Error: Input expression not supported\nReview it and try again", "Calculation-Error");
            }
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            Calculate calculate = new Calculate();
            InputExp = InputBox.Text;
            Result = calculate.Calculator(InputExp, "Degree");
            ResultBox.Text = Result;
            ResultBox.Visibility = Visibility.Visible;
            }
            catch (Exception)
            {
                MessageBox.Show("Error: Input expression not supported\nReview it and try again", "Calculation-Error");
            }
        }

        private void StdWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {

                    Calculate calculate = new Calculate();
                    InputExp = InputBox.Text;
                    Result = calculate.Calculator(InputExp, "Degree");
                    ResultBox.Text = Result;
                    ResultBox.Visibility = Visibility.Visible;
                }
                catch (Exception)
                {
                    MessageBox.Show("Error: Input expression not supported\nReview it and try again", "Calculation-Error");
                }
            }
        }

        private void MemoryArea_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            try
            {
                int index = MemoryArea.SelectedIndex;
                
                if (MemRead&&index!=-1)
                {
                    InputBox.Text += MemoryArea.Items.GetItemAt(index).ToString();
                    MemRead = false;
                }
            }
            catch (Exception)
            {
            }
            MemoryArea.SelectedIndex = -1;

        }
    }
}
