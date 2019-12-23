using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Calckit.FileHandle;
using Calckit.GUIsHandle;
using Calckit.Calculations;


namespace Calckit.GUIs
{
    /// <summary>
    /// Interaction logic for Scientific_Calckit.xaml
    /// </summary>
    public partial class Scientific_Calckit : Window
    {

        //Global variables
       
        string Result;
        string InputsExpr;
        string Opsel;
        Window window;
        Window ConstWindow;
        Window converter ;
        Window help  ;
        string path = "";

        bool MemRead = false; bool MemPlus = false,  MemMinus = false;

        public Scientific_Calckit()
        {
            InitializeComponent();
        }


        #region The override methods for window loaded, closing,activated and closed
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InputBox.Focus();
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
                        save.SaveAs(HistArea);
                    }
                    else
                    {
                        path = settings.DefaultPath + "\\History-Calckit.txt";
                        save.Save(path, HistArea);
                    }
                }
                else
                {
                    save.Save(path, HistArea);
                }
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            InputBox.Focus();
        }

       

        #endregion



        #region Menu Item click events methods
        //File Menu Subitems methods
       

        private void NewItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            Scientific_Calckit scientific_ = new Scientific_Calckit();
            scientific_.Show();
            scientific_.Activate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load window\n" + ex + "\nPlease Try again or result app", "Loading error");

            }
        }

        private void SaveItem_Click(object sender, RoutedEventArgs e)
        {
            SaveHistHandle save = new SaveHistHandle();
            save.Save(path, HistArea);
            
        }

        private void SaveasItem_Click(object sender, RoutedEventArgs e)
        {
            SaveHistHandle save = new SaveHistHandle();
            save.SaveAs(HistArea);
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

        //Edit Menu subitem methods
        private void CutItem_Click(object sender, RoutedEventArgs e)
        {
            if (HistArea.IsVisible == true)
            {
                HistArea.Cut();
            }
            else if (InputBox.Focus())
            {
                InputBox.Cut();
            }
        }

        private void CopyItem_Click(object sender, RoutedEventArgs e)
        {
            if (HistArea.IsVisible == true)
            {
                HistArea.Copy();
            }
            else if (InputBox.Focus())
            {
                InputBox.Copy();
            }
        }

        private void PasteItem_Click(object sender, RoutedEventArgs e)
        {
            if (HistArea.IsVisible == true)
            {
                HistArea.Paste();
            }
            else if (InputBox.Focus())
            {
                InputBox.Paste();
            }
        }

        private void ClrmemItem_Click(object sender, RoutedEventArgs e)
        {
            MemoryArea.Items.Clear();
        }

        private void ClrHisItem_Click(object sender, RoutedEventArgs e)
        {
            HistArea.Document.Blocks.Clear();
        }


        //View menu item methods
      

        private void MemoItem_Click(object sender, RoutedEventArgs e)
        {
            MemoryArea.Visibility = Visibility.Visible;
        }

        private void HistItem_Click(object sender, RoutedEventArgs e)
        {
            HistArea.Visibility = Visibility.Visible;
            HistClear.Visibility = Visibility.Visible;
            HistSave.Visibility = Visibility.Visible;
        }


        //Tools menu item methods
        private void ConvItem_Click(object sender, RoutedEventArgs e)
        {
            ConverterWindow window = new ConverterWindow();
            if (converter == null)
            {
                converter = window;
                converter.Show();
                converter.Activate();
            }
            else
            {
                converter.Close();
                converter = window;
                converter.Show();
                converter.Activate();
            }
        }

        private void DigItem_Click(object sender, RoutedEventArgs e)
        {
            DigitalWindow std = new DigitalWindow();
            if (window != null)
            {
                window.Close(); window = null;
            }
            window = std;
            window.Show();
            window.Activate();
            Close();
        }

        private void DateItem_Click(object sender, RoutedEventArgs e)
        {
            DateTimeWindow std = new DateTimeWindow();
            if (window != null)
            {
                window.Close(); window = null;
            }
            window = std;
            window.Show();
            window.Activate();
        }

        private void CharItem_Click(object sender, RoutedEventArgs e)
        {

            ColorWindow std = new ColorWindow();
            if (window != null)
            {
                window.Close(); window = null;
            }
            window = std;
            window.Show();
            window.Activate();
        }

        private void ConstFormItem_Click(object sender, RoutedEventArgs e)
        {
            ConstFormWindow window = new ConstFormWindow();
            if (ConstWindow == null)
            {
                ConstWindow = window;
                ConstWindow.Show();
                ConstWindow.Activate();
            }
            else
            {
                ConstWindow.Close();
                ConstWindow = window;
                ConstWindow.Show();
                ConstWindow.Activate();
            }
        }

        private void SettingItem_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow window = new HelpWindow();
            if (help == null)
            {
                help = window;
                help.Show();
                help.Activate();
            }
            else
            {
                help.Close();
                help = window;
                help.Show();
                help.Activate();
            }
        }

        private void StdItem_Click(object sender, RoutedEventArgs e)
        {
            StdCackWindow std = new StdCackWindow();
            if (window != null)
            {
                window.Close(); window = null;
            }
            window = std;
            window.Show();
            window.Activate();
        }

        //help menu item methods
        private void UserguideItem_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow window = new HelpWindow();
            if (help == null)
            {
                window.HelpTab.IsSelected = true;
                help = window;
                help.Show();
                help.Activate();
            }
            else
            {
                window.HelpTab.IsSelected = true;
                help.Close();
                help = window;
                help.Show();
                help.Activate();
            }
        }

        private void AboutItem_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow window = new HelpWindow();
            window.AboutTab.IsSelected = true;
            if (help == null)
            {
                help = window;
                help.Show();
                help.Activate();
            }
            else
            {
                help.Close();
                help = window;
                help.Show();
                help.Activate();
            }
        }


        #endregion


        #region Op,Hist controls methods
        private void OpBtn_Click(object sender, RoutedEventArgs e)
        {
            if (OpLv.IsVisible == true)
            {
                OpLv.Visibility = Visibility.Hidden;
            }
            else
            {
                OpLv.Visibility = Visibility.Visible;
                OpLv.ScrollIntoView(OpLv.SelectedIndex);
            }
        }

        private void HisvBtn_Click(object sender, RoutedEventArgs e)
        {
            if (HistArea.IsVisible == true)
            {
                HistArea.Visibility = Visibility.Hidden;
                HistClear.Visibility = Visibility.Collapsed;
                HistSave.Visibility = Visibility.Collapsed;
            }
            else
            {
                HistArea.Visibility = Visibility.Visible;
                HistClear.Visibility = Visibility.Visible;
                HistSave.Visibility = Visibility.Visible;
            }
        }

        private void HistClear_Click(object sender, RoutedEventArgs e)
        {
            HistArea.Document.Blocks.Clear();
        }

        private void HistSave_Click(object sender, RoutedEventArgs e)
        {
            SaveHistHandle save = new SaveHistHandle();
            save.Save(path, HistArea);
        }

        private void HistArea_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (HistArea.IsVisible)
            {
                HisvBtn.Background = Brushes.LightBlue;
            }
            else
            {
                HisvBtn.Background = Brushes.Transparent;
            }
        }

        private void OpLv_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (OpLv.IsVisible)
            {
                OpBtn.Background = Brushes.LightBlue;
            }
            else
            {
                OpBtn.Background = Brushes.Transparent;
            }
        }

        private void OpLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = OpLv.SelectedIndex;
            switch (index)
            {
                case 0:
                    {
                        StdCackWindow std = new StdCackWindow();
                        if (window != null)
                        {
                            window.Close(); window = null;
                        }
                        window = std;
                        window.Show();
                        window.Activate();
                        break;
                    }

              

                case 1:
                    {
                        DigitalWindow std = new DigitalWindow();
                        if (window != null)
                        {
                            window.Close(); window = null;
                        }
                        window = std;
                        window.Show();
                        window.Activate();
                        Close();
                        break;
                    }
                case 2:
                    {
                        ConverterWindow window = new ConverterWindow();
                        if (converter == null)
                        {
                            converter = window;
                            converter.Show();
                            converter.Activate();
                        }
                        else
                        {
                            converter.Close();
                            converter = window;
                            converter.Show();
                            converter.Activate();
                        }
                        break;
                    }
                case 3:
                    {
                        DateTimeWindow std = new DateTimeWindow();
                        if (window != null)
                        {
                            window.Close(); window = null;
                        }
                        window = std;
                        window.Show();
                        window.Activate();
                        
                        break;
                    }

                case 4:
                    {
                        ColorWindow std = new ColorWindow();
                        if (window != null)
                        {
                            window.Close(); window = null;
                        }
                        window = std;
                        window.Show();
                        window.Activate();
                        break;
                    }

                case 5:
                    {
                        ConstFormWindow window = new ConstFormWindow();
                        if (ConstWindow == null)
                        {
                            ConstWindow = window;
                            ConstWindow.Show();
                            ConstWindow.Activate();
                        }
                        else
                        {
                            ConstWindow.Close();
                            ConstWindow = window;
                            ConstWindow.Show();
                            ConstWindow.Activate();
                        }
                        break;
                    }
            }
            OpLv.Visibility = Visibility.Hidden;
        }

        private void MemoryArea_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (MemoryArea.IsVisible)
            {
                Mv.Background = Brushes.LightBlue;
            }
            else
            {
                Mv.Background = Brushes.Transparent;
            }
        }

        #endregion


        #region Inputbox Controls methods
        private void InputBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            InputBox.Focusable = true;
            InputBox.CaretIndex = InputBox.CaretIndex;
            InputBox.Focus();
        }

        private void Deg_Checked(object sender, RoutedEventArgs e)
        {
            Opsel = "Degree";
        }

        private void Rad_Checked(object sender, RoutedEventArgs e)
        {
            Opsel = "Radian";
        }

        private void Grad_Checked(object sender, RoutedEventArgs e)
        {
            Opsel = "Grad";
        }

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


        #endregion


        #region Memory control buttons methods

        private void MemoryArea_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                int index = MemoryArea.SelectedIndex;

                if (index == -1) { }
                else
                {
                    if (MemRead)
                    {
                        InputBox.Text += MemoryArea.Items.GetItemAt(index).ToString();
                    }

                    else if (MemPlus)
                    {
                        string va = MemoryArea.Items.GetItemAt(index).ToString();
                        string vb = (double.Parse(Result) + double.Parse(va)).ToString();
                        MemoryArea.Items.Insert(index, vb);
                        MemoryArea.Items.Refresh();

                    }

                    else if (MemMinus)
                    {
                        MemoryArea.Items.RemoveAt(index);
                    }
                }
                MemoryArea.SelectedIndex = -1;
                MemoryArea.Visibility = Visibility.Hidden;

            }
            catch (Exception)
            {

            }
        }

        private void MC_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.MemHandle(MC, null, MemoryArea);
        }

        private void Mminus_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.MemHandle(Mminus, null, MemoryArea);
            MemMinus = true; MemPlus = false;MemRead = false;
        }

        private void Mplus_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.MemHandle(Mplus, ResultTb, MemoryArea);
            MemMinus = false;  MemPlus = true; MemRead = false;
        }

        private void MR_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.MemHandle(MR, InputBox, MemoryArea);
            MemMinus = false; MemPlus = false; MemRead = true;
        }

        private void MS_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.MemHandle(MS, ResultTb, MemoryArea);
        }

      

        private void Mv_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.MemHandle(Mv, null, MemoryArea);
        }

        #endregion


        //Clear Input box buttons methos

        private void CE_Click(object sender, RoutedEventArgs e)
        {
            InputBox.Text = "";
            ResultTb.Text = "";
            ResultTb.Visibility = Visibility.Hidden;
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            InputBox.Text = "";
            MemoryArea.Items.Clear();
            Result = "";
            InputsExpr = "";
            ResultTb.Text = "";
            ResultTb.Visibility = Visibility.Hidden;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.Delete(InputBox);
        }

        #region Numbers input buttons methods
        private void Ans_Click(object sender, RoutedEventArgs e)
        {
            InputBox.Text += Result;
        }

        private void Modulo_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Modulo, InputBox);
        }

        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Divide, InputBox);
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

        private void Four_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Four, InputBox);
        }

        private void Five_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Five, InputBox);
        }

        private void Six_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Six, InputBox);
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

        private void PlusMinus_Click(object sender, RoutedEventArgs e)
        {
            if (InputBox.Text.First() == '-')
            {
                InputBox.Text =  InputBox.Text.TrimStart('-');
                InputBox.CaretIndex = InputBox.CaretIndex;
                InputBox.Focus();
            }
            else
            {
                string input = InputBox.Text;
                input= input.Insert(0, "-");
                InputBox.Text = input;
                InputBox.CaretIndex = InputBox.CaretIndex;
                InputBox.Focus();
            }
        }

        private void Factorial_Click(object sender, RoutedEventArgs e)
        {
            if (InputBox.CaretIndex != InputBox.Text.Length)
            {
                int index = InputBox.CaretIndex;
                string input = InputBox.Text;
                input = input.Insert(index, "!");
                InputBox.Text = input;
                InputBox.CaretIndex = index + 1;
                InputBox.Focus();
            }
            else
            {
                InputBox.Text += "!";
                InputBox.CaretIndex = InputBox.Text.Length;
                InputBox.Focus();
            }
        }

        private void E_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(E, InputBox);
        }

        private void Pi_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Pi, InputBox);
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

        private void Tao_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Tao, InputBox);
        }

        private void Phi_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Phi, InputBox);
        }

        private void Times_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Times, InputBox);
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
        private void Comma_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Comma, InputBox);
        }

        private void LeftBr_Click(object sender, RoutedEventArgs e)
        {
            if (InputBox.CaretIndex != InputBox.Text.Length)
            {
                int index = InputBox.CaretIndex;
                string input = InputBox.Text;
                input = input.Insert(index, "(");
                InputBox.Text = input;
                InputBox.CaretIndex = index + 1;
                InputBox.Focus();
            }
            else
            {
                InputBox.Text += "(";
                InputBox.CaretIndex = InputBox.Text.Length;
                InputBox.Focus();
            }
        }

        private void RightBr_Click(object sender, RoutedEventArgs e)
        {
            if (InputBox.CaretIndex != InputBox.Text.Length)
            {
                int index = InputBox.CaretIndex;
                string input = InputBox.Text;
                input = input.Insert(index, ")");
                InputBox.Text = input;
                InputBox.CaretIndex = index + 1;
                InputBox.Focus();
            }
            else
            {
                InputBox.Text += ")";
                InputBox.CaretIndex = InputBox.Text.Length;
                InputBox.Focus();
            }
        }



        #endregion


        #region Function buttons methods

        private void Round_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Sum, InputBox);
        }
        private void Simplify_Click_1(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Simplify, InputBox);
        }
        private void Yto3_Click(object sender, RoutedEventArgs e)
        {
            if (InputBox.CaretIndex != InputBox.Text.Length)
            {
                int index = InputBox.CaretIndex;
                string input = InputBox.Text;
                input = input.Insert(index, "³");
                InputBox.Text = input;
                InputBox.CaretIndex = index + 1;
                InputBox.Focus();
            }
            else
            {
                InputBox.Text += "³";
                InputBox.CaretIndex = InputBox.Text.Length;
                InputBox.Focus();
            }
        }

        private void Yto4_Click(object sender, RoutedEventArgs e)
        {
            if (InputBox.CaretIndex != InputBox.Text.Length)
            {
                int index = InputBox.CaretIndex;
                string input = InputBox.Text;
                input = input.Insert(index, "⁴");
                InputBox.Text = input;
                InputBox.CaretIndex = index + 1;
                InputBox.Focus();
            }
            else
            {
                InputBox.Text += "⁴";
                InputBox.CaretIndex = InputBox.Text.Length;
                InputBox.Focus();
            }
        }

        private void Yto5_Click(object sender, RoutedEventArgs e)
        {
            if (InputBox.CaretIndex != InputBox.Text.Length)
            {
                int index = InputBox.CaretIndex;
                string input = InputBox.Text;
                input = input.Insert(index, "⁵");
                InputBox.Text = input;
                InputBox.CaretIndex = index + 1;
                InputBox.Focus();
            }
            else
            {
                InputBox.Text += "⁵";
                InputBox.CaretIndex = InputBox.Text.Length;
                InputBox.Focus();
            }
        }

        private void Yton_Click(object sender, RoutedEventArgs e)
        {
            if (InputBox.CaretIndex != InputBox.Text.Length)
            {
                int index = InputBox.CaretIndex;
                string input = InputBox.Text;
                input = input.Insert(index, "^");
                InputBox.Text = input;
                InputBox.CaretIndex = index + 1;
                InputBox.Focus();
            }
            else
            {
                InputBox.Text += "^";
                InputBox.CaretIndex = InputBox.Text.Length;
                InputBox.Focus();
            }
        }

        private void Inverse_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            Calculate calculate = new Calculate();
            InputsExpr = InputBox.Text;
            Result = calculate.Calculator(InputsExpr,Opsel);
            Result = (1 / double.Parse(Result)).ToString();
            ResultTb.Text = Result;
            ResultTb.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message + "\nReview it and try again", "Calculation-Error");
            }
        }

        private void Texto3_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Texto3, InputBox);
        }

        private void Tentom3_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Tentom3, InputBox);
        }

        private void Tentox_Click(object sender, RoutedEventArgs e)
        {
            if (InputBox.CaretIndex != InputBox.Text.Length)
            {
                int index = InputBox.CaretIndex;
                string input = InputBox.Text;
                input = input.Insert(index, "10^");
                InputBox.Text = input;
                InputBox.CaretIndex = index + 3;
                InputBox.Focus();
            }
            else
            {
                InputBox.Text += "10^";
                InputBox.CaretIndex = InputBox.Text.Length;
                InputBox.Focus();
            }
        }

        private void Sqrt_Click(object sender, RoutedEventArgs e)
        {
            if (InputBox.CaretIndex != InputBox.Text.Length)
            {
                int index = InputBox.CaretIndex;
                string input = InputBox.Text;
                input = input.Insert(index, "√()");
                InputBox.Text = input;
                InputBox.CaretIndex = index + 2;
                InputBox.Focus();
            }
            else
            {
                InputBox.Text += "√()";
                InputBox.CaretIndex = InputBox.Text.Length - 1;
                InputBox.Focus();
            }
        }

        private void Cubroot_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Roots, InputBox);
        }

        private void Foroot_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Rounds, InputBox);
        }

        private void Etox_Click(object sender, RoutedEventArgs e)
        {
            if (InputBox.CaretIndex != InputBox.Text.Length)
            {
                int index = InputBox.CaretIndex;
                string input = InputBox.Text;
                input = input.Insert(index, "e^");
                InputBox.Text = input;
                InputBox.CaretIndex = index + 2;
                InputBox.Focus();
            }
            else
            {
                InputBox.Text += "e^";
                InputBox.CaretIndex = InputBox.Text.Length;
                InputBox.Focus();
            }
        }

        private void Ln_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Ln, InputBox);
        }

        private void Log_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Log, InputBox);
        }

        private void Loga_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Loga, InputBox);
        }

        private void Exp_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Exp, InputBox);
        }

        private void Sin_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Sin, InputBox);
        }

        private void Cos_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Cos, InputBox);
        }

        private void Tan_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Tan, InputBox);
        }

        private void Cot_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Cot, InputBox);
        }

        private void Asin_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Asin, InputBox);
        }

        private void Acos_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Acos, InputBox);
        }

        private void Atan_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Atan, InputBox);
        }

        private void More_Click(object sender, RoutedEventArgs e)
        {
            FuncBtn1.Visibility = Visibility.Hidden;
            FuncBtn2.Visibility = Visibility.Visible;
        }

        private void I_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(I, InputBox);
        }

        private void Conj_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Conj, InputBox);
        }

        private void Recp_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Recp, InputBox);
        }

        private void Phase_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Phase, InputBox);
        }

        private void Real_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Real, InputBox);
        }

        private void Abs_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Abs, InputBox);
        }

        private void Im_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Im, InputBox);
        }

        private void Ceil_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Ceil, InputBox);
        }

        private void Deriv_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Deriv, InputBox);
        }

        private void Floor_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Floor, InputBox);
        }

        private void GCD_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(GCD, InputBox);
        }

        private void LCM_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(LCM, InputBox);
        }

        private void LB_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(LB, InputBox);
        }

        private void LG_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(LG, InputBox);
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Del, InputBox);
        }

       

        private void Secinv_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Secinv, InputBox);
        }

        private void Cscinv_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Cscinv, InputBox);
        }

        private void Acot_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Acot, InputBox);
        }

       

        private void Sec_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Sec, InputBox);
        }

        private void Cosec_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Cosec, InputBox);
        }

        private void Cosh_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Cosh, InputBox);
        }

        private void More2_Click(object sender, RoutedEventArgs e)
        {
            FuncBtn2.Visibility = Visibility.Hidden;
            FuncBtn3.Visibility = Visibility.Visible;
        }

        private void Sinh_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Sinh, InputBox);
        }

        private void Tanh_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Tanh, InputBox);
        }

        private void Sech_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Sech, InputBox);
        }

        private void Coth_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Coth, InputBox);
        }

        private void Asinh_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Asinh, InputBox);
        }

        private void Atanh_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Atanh, InputBox);
        }

        private void Asech_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Asech, InputBox);
        }

        private void Acoth_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Acoth, InputBox);
        }

        private void Acosh_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Acosh, InputBox);
        }

        private void Csch_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Csch, InputBox);
        }

        private void ACsch_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(ACsch, InputBox);
        }

        private void Avg_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Avg, InputBox);
        }

        private void Count_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Count, InputBox);
        }

        private void Max_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Max, InputBox);
        }

        private void Min_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Min, InputBox);
        }

        private void Product_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Product, InputBox);
        }

        private void Std_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Std, InputBox);
        }

        private void Stdp_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Stdp, InputBox);
        }

        private void Var_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Var, InputBox);
        }

        private void Varp_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Varp, InputBox);
        }

       

        private void Sum_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Sum, InputBox);
        }

        private void More3_Click(object sender, RoutedEventArgs e)
        {
            FuncBtn3.Visibility = Visibility.Hidden;
            FuncBtn4.Visibility = Visibility.Visible;
        }

        private void Simplify_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Simplify, InputBox);
        }

        private void Determinant_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Determinant, InputBox);
        }

        private void Inversemat_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Inversemat, InputBox);
        }

        private void Transpose_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Transpose, InputBox);
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

        private void More4_Click(object sender, RoutedEventArgs e)
        {
            FuncBtn4.Visibility = Visibility.Hidden;
            FuncBtn1.Visibility = Visibility.Visible;
        }

        #endregion


        //Equal button and calculations
        private void Equal_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
            Calculate calculate = new Calculate();
            InputsExpr = InputBox.Text;
            Result = calculate.Calculator(InputsExpr,Opsel);
            ResultTb.Text = Result;
            ResultTb.Visibility = Visibility.Visible;

             WriteHistory history = new WriteHistory(InputsExpr, Result, HistArea);

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex.Message + "\nReview it and try again", "Calculation-Error");
            }


        }

       

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    Calculate calculate = new Calculate();
                    InputsExpr = InputBox.Text;
                    Result = calculate.Calculator(InputsExpr, Opsel);
                    ResultTb.Text = Result;
                    ResultTb.Visibility = Visibility.Visible;

                    WriteHistory history = new WriteHistory(InputsExpr, Result, HistArea);

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error:"+ex.Message+"\nReview it and try again", "Calculation-Error");
                }
            }
        }

       
    }
}
