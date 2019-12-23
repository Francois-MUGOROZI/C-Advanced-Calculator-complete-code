using Calckit.FileHandle;
using Calckit.GUIsHandle;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Linq;

namespace Calckit.GUIs
{
    /// <summary>
    /// Interaction logic for ConstFormWindow.xaml
    /// </summary>
    public partial class ConstFormWindow : Window
    {
        public ConstFormWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            NameTb.Focus();
        }

        #region Texbox Focus control
        private void NameTb_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NameTb.Focusable = true;
            NameTb.CaretIndex = NameTb.CaretIndex;
            NameTb.Focus();
        }

        private void ValueTb_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ValueTb.Focusable = true;
            ValueTb.CaretIndex = ValueTb.CaretIndex;
            ValueTb.Focus();
        }

        private void DescriptionTb_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DescriptionTb.Focusable = true;
            DescriptionTb.CaretIndex = DescriptionTb.CaretIndex;
            DescriptionTb.Focus();
        }

        private void SearchTB_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SearchTB.Focusable = true;
            SearchTB.CaretIndex = SearchTB.CaretIndex;
            SearchTB.Focus();
        }

        private void SearchTB_GotFocus(object sender, RoutedEventArgs e)
        {
            DescriptionTb.Focusable = false;
            ValueTb.Focusable = false;
            NameTb.Focusable = false;
        }

        private void DescriptionTb_GotFocus(object sender, RoutedEventArgs e)
        {
            SearchTB.Focusable = false;
            ValueTb.Focusable = false;
            NameTb.Focusable = false;
        }

        private void ValueTb_GotFocus(object sender, RoutedEventArgs e)
        {
            DescriptionTb.Focusable = false;
            SearchTB.Focusable = false;
            NameTb.Focusable = false;
        }

        private void NameTb_GotFocus(object sender, RoutedEventArgs e)
        {
            DescriptionTb.Focusable = false;
            ValueTb.Focusable = false;
            SearchTB.Focusable = false;
        }

        private TextBox Focused()
        {
            if (NameTb.Focus())
                return NameTb;
            else if (ValueTb.Focus())
                return ValueTb;
            else if (DescriptionTb.Focus())
                return DescriptionTb;
            else if (SearchTB.Focus())
                return SearchTB;
            else
                return NameTb;
        }


        #endregion


        #region Input buttons events
        private void ZBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn, Focused());
        }

        private void ZBtn1_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn1, Focused());
        }

        private void ZBtn2_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn2, Focused());
        }

        private void ZBtn3_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn3, Focused());
        }

        private void ZBtn4_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn4, Focused());
        }

        private void ZBtn5_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn5, Focused());
        }

        private void ZBtn6_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn6, Focused());
        }

        private void ZBtn7_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn7, Focused());
        }

        private void ZBtn8_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn8, Focused());
        }

        private void ZBtn9_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn9, Focused());
        }

        private void ZBtn10_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn10, Focused());
        }

        private void ZBtn11_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn11, Focused());
        }

        private void ZBtn12_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn12, Focused());
        }

        private void ZBtn13_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn13, Focused());
        }

        private void ZBtn14_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn14, Focused());
        }

        private void ZBtn16_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn16, Focused());
        }

        private void ZBtn17_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn17, Focused());
        }

        private void ZBtn18_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn18, Focused());
        }

        private void ZBtn19_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn19, Focused());
        }

        private void ZBtn20_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn20, Focused());
        }

        private void ZBtn21_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn21, Focused());
        }

        private void ZBtn22_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn22, Focused());
        }

        private void ZBtn23_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn23, Focused());
        }

        private void ZBtn24_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn24, Focused());
        }

        private void ZBtn25_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn25, Focused());
        }

        private void ZBtn26_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn26, Focused());
        }

        private void ZBtn27_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn27, Focused());
        }

        private void ZBtn28_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn28, Focused());
        }

        private void ZBtn29_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn29, Focused());
        }

        private void ZBtn30_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn30, Focused());
        }

        private void ZBtn31_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn31, Focused());
        }

        private void ZBtn32_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn32, Focused());
        }

        private void ZBtn33_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn33, Focused());
        }

        private void ZBtn34_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn34, Focused());
        }

        private void ZBtn35_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn35, Focused());
        }

        private void ZBtn36_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn36, Focused());
        }

        private void ZBtn37_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn37, Focused());
        }

        private void ZBtn38_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn38, Focused());
        }

        private void ZBtn39_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn39, Focused());
        }

        private void ZBtn40_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn40, Focused());
        }

        private void ZBtn41_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn41, Focused());
        }

        private void ZBtn42_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn42, Focused());
        }

        private void ZBtn43_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn43, Focused());
        }

        private void ZBtn44_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn44, Focused());
        }

        private void ZBtn45_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn45, Focused());
        }

        private void ZBtn46_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn46, Focused());
        }

        private void ZBtn47_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn47, Focused());
        }

        private void ZBtn48_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn48, Focused());
        }

        private void ZBtn49_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn49, Focused());
        }

        private void ZBtn50_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn50, Focused());
        }

        private void ZBtn51_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn51, Focused());
        }

        private void ZBtn52_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn52, Focused());
        }

        private void ZBtn53_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn53, Focused());
        }

        private void ZBtn54_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn54, Focused());
        }

        private void ZBtn55_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn55, Focused());
        }

        private void ZBtn56_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn56, Focused());
        }

        private void ZBtn57_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn57, Focused());
        }

        private void ZBtn58_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn58, Focused());
        }

        private void ZBtn59_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn59, Focused());
        }

        private void ZBtn60_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn60, Focused());
        }

        private void ZBtn61_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn61, Focused());
        }

        private void ZBtn62_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn62, Focused());
        }

        private void ZBtn63_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn63, Focused());
        }

        private void ZBtn64_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn64, Focused());
        }

        private void ZBtn65_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn65, Focused());
        }

        private void ZBtn66_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn66, Focused());
        }

        private void ZBtn67_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn67, Focused());
        }

        private void ZBtn68_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn68, Focused());
        }

        private void ZBtn69_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(ZBtn69, Focused());
        }

        private void Symbol_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol, Focused());
        }

        private void Symbol3_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol3, Focused());
        }

        private void Symbol4_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol4, Focused());
        }

        private void Symbol5_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol5, Focused());
        }

        private void Symbol6_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol6, Focused());
        }

        private void Symbol7_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol7, Focused());
        }

        private void Symbol10_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol10, Focused());
        }

        private void Symbol12_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol12, Focused());
        }

        private void Symbol13_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol13, Focused());
        }

        private void Symbol14_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol14, Focused());
        }

        private void Symbol17_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol17, Focused());
        }

        private void Symbol19_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol19, Focused());
        }

        private void Symbol20_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol20, Focused());
        }

        private void Symbol24_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol24, Focused());
        }

        private void Symbol26_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol26, Focused());
        }

        private void Symbol27_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol27, Focused());
        }

        private void Symbol31_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol31, Focused());
        }

        private void Symbol33_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol33, Focused());
        }

        private void Symbol34_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol34, Focused());
        }

        private void Symbol38_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol38, Focused());
        }

        private void Symbol39_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol39, Focused());
        }

        private void Symbol40_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol40, Focused());
        }

        private void Symbol43_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol43, Focused());
        }

        private void Symbol44_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol44, Focused());
        }

        private void Symbol46_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol46, Focused());
        }

        private void Symbol47_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol47, Focused());
        }

        private void Symbol48_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol48, Focused());
        }

        private void Symbol50_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol50, Focused());
        }

        private void Symbol51_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol51, Focused());
        }

        private void Symbol53_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol53, Focused());
        }

        private void Symbol54_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol54, Focused());
        }

        private void Symbol55_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol55, Focused());
        }

        private void Symbol56_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol56, Focused());
        }

        private void Symbol57_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol57, Focused());
        }

        private void Symbol58_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol58, Focused());
        }

        private void Symbol60_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol60, Focused());
        }

        private void Symbol61_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol61, Focused());
        }

        private void Symbol63_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol63, Focused());
        }

        private void Symbol62_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol62, Focused());
        }

        private void Symbol64_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol64, Focused());
        }

        private void Symbol65_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol65, Focused());
        }

        private void Symbol67_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol67, Focused());
        }

        private void Symbol68_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol68, Focused());
        }

        private void Symbol66_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Symbol66, Focused());
        }

        private void Symbol59_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Symbol59, Focused());
        }

        private void Symbol52_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Symbol52, Focused());
        }

        private void Symbol49_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Symbol49, Focused());
        }

        private void Symbol45_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Symbol45, Focused());
        }

        private void Symbol42_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Symbol42, Focused());
        }

        private void Symbol41_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Symbol41, Focused());
        }

        private void Symbol69_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Symbol69, Focused());
        }

        private void Symbol37_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol37, Focused());
        }

        private void Symbol36_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol36, Focused());
        }

        private void Symbol35_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Symbol35, Focused());
        }

        private void Symbol32_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Symbol32, Focused());
        }

        private void Symbol30_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol30, Focused());
        }

        private void Symbol29_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol29, Focused());
        }

        private void Symbol28_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Symbol28, Focused());
        }

        private void Symbol25_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Symbol25, Focused());
        }

        private void Symbol23_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol23, Focused());
        }

        private void Symbol22_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Symbol22, Focused());
        }

        private void Symbol21_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Symbol21, Focused());
        }

        private void Symbol18_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Symbol18, Focused());
        }

        private void Symbol16_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Symbol16, Focused());
        }

        private void Symbol15_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Symbol15, Focused());
        }

        private void Symbol11_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Symbol11, Focused());
        }

        private void Symbol9_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Symbol9, Focused());
        }

        private void Symbol8_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Symbol8, Focused());
        }

        private void Symbol2_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Symbol2, Focused());
        }

        private void Symbol1_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Symbol1, Focused());
        }

        #endregion


        #region Control button event
        private void Keyboardbtn_Click(object sender, RoutedEventArgs e)
        {
            if (InputBtnGrid.IsVisible)
            {
                InputBtnGrid.Visibility = Visibility.Collapsed;
                Keyboardbtn.Background = Brushes.Transparent;
                DataGridGrid.Visibility = Visibility.Visible;
            }
            else
            {
                InputBtnGrid.Visibility = Visibility.Visible;
                Keyboardbtn.Background = Brushes.LightBlue;
                DataGridGrid.Visibility = Visibility.Hidden;
            }
        }

        private void CEBtn_Click(object sender, RoutedEventArgs e)
        {
            Focused().Text = "";
            Focused().Focus();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle handle = new ButtonHandle();
            handle.Delete(Focused());
        }

        private void ButtonCases()
        {
            if (CasesBtn.Content.ToString() == "⇩")
            {
                CasesBtn.Content = "⇧";
                CasesBtn.ToolTip = "To UpperCase";
                ZBtn.Content = ZBtn.Content.ToString().ToLower();
                ZBtn1.Content = ZBtn1.Content.ToString().ToLower();
                ZBtn2.Content = ZBtn2.Content.ToString().ToLower();
                ZBtn7.Content = ZBtn7.Content.ToString().ToLower();
                ZBtn8.Content = ZBtn8.Content.ToString().ToLower();
                ZBtn9.Content = ZBtn9.Content.ToString().ToLower();
                ZBtn10.Content = ZBtn10.Content.ToString().ToLower();
                ZBtn11.Content = ZBtn11.Content.ToString().ToLower();
                ZBtn16.Content = ZBtn16.Content.ToString().ToLower();
                ZBtn17.Content = ZBtn17.Content.ToString().ToLower();
                ZBtn22.Content = ZBtn22.Content.ToString().ToLower();
                ZBtn23.Content = ZBtn23.Content.ToString().ToLower();
                ZBtn28.Content = ZBtn28.Content.ToString().ToLower();
                ZBtn29.Content = ZBtn29.Content.ToString().ToLower();
                ZBtn34.Content = ZBtn34.Content.ToString().ToLower();
                ZBtn35.Content = ZBtn35.Content.ToString().ToLower();
                ZBtn40.Content = ZBtn40.Content.ToString().ToLower();
                ZBtn41.Content = ZBtn41.Content.ToString().ToLower();
                ZBtn46.Content = ZBtn46.Content.ToString().ToLower();
                ZBtn47.Content = ZBtn47.Content.ToString().ToLower();
                ZBtn52.Content = ZBtn52.Content.ToString().ToLower();
                ZBtn53.Content = ZBtn53.Content.ToString().ToLower();
                ZBtn58.Content = ZBtn58.Content.ToString().ToLower();
                ZBtn59.Content = ZBtn59.Content.ToString().ToLower();
                ZBtn65.Content = ZBtn65.Content.ToString().ToLower();


            }
            else
            {
                CasesBtn.Content = "⇩";
                CasesBtn.ToolTip = "To LowerCase";
                ZBtn.Content = ZBtn.Content.ToString().ToUpper();
                ZBtn1.Content = ZBtn1.Content.ToString().ToUpper();
                ZBtn2.Content = ZBtn2.Content.ToString().ToUpper();
                ZBtn7.Content = ZBtn7.Content.ToString().ToUpper();
                ZBtn8.Content = ZBtn8.Content.ToString().ToUpper();
                ZBtn9.Content = ZBtn9.Content.ToString().ToUpper();
                ZBtn10.Content = ZBtn10.Content.ToString().ToUpper();
                ZBtn11.Content = ZBtn11.Content.ToString().ToUpper();
                ZBtn16.Content = ZBtn16.Content.ToString().ToUpper();
                ZBtn17.Content = ZBtn17.Content.ToString().ToUpper();
                ZBtn22.Content = ZBtn22.Content.ToString().ToUpper();
                ZBtn23.Content = ZBtn23.Content.ToString().ToUpper();
                ZBtn28.Content = ZBtn28.Content.ToString().ToUpper();
                ZBtn29.Content = ZBtn29.Content.ToString().ToUpper();
                ZBtn34.Content = ZBtn34.Content.ToString().ToUpper();
                ZBtn35.Content = ZBtn35.Content.ToString().ToUpper();
                ZBtn40.Content = ZBtn40.Content.ToString().ToUpper();
                ZBtn41.Content = ZBtn41.Content.ToString().ToUpper();
                ZBtn46.Content = ZBtn46.Content.ToString().ToUpper();
                ZBtn47.Content = ZBtn47.Content.ToString().ToUpper();
                ZBtn52.Content = ZBtn52.Content.ToString().ToUpper();
                ZBtn53.Content = ZBtn53.Content.ToString().ToUpper();
                ZBtn58.Content = ZBtn58.Content.ToString().ToUpper();
                ZBtn59.Content = ZBtn59.Content.ToString().ToUpper();
                ZBtn65.Content = ZBtn65.Content.ToString().ToUpper();

            }
        }

        private void CasesBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonCases();
        }

        private void NextBtnsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CharGrid.IsVisible)
            {
                CharGrid.Visibility = Visibility.Collapsed;
                SymbolGrid.Visibility = Visibility.Visible;
            }
            else
            {
                CharGrid.Visibility = Visibility.Visible;
                SymbolGrid.Visibility = Visibility.Collapsed;
            }
        }

        #endregion


        //Method to add items to file and data grid
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            XmlHandler handler = new XmlHandler();
            if (string.IsNullOrEmpty(NameTb.Text) || string.IsNullOrEmpty(ValueTb.Text))
                MessageBox.Show("You can't add empty value to file\n  Please input atleast Name and Value", "Invalid input-Error");
            else
            {
                string value1 = NameTb.Text;
                string value2 = ValueTb.Text;
                string value3;
                if (string.IsNullOrEmpty(DescriptionTb.Text))
                    value3 = "No description";
                else
                    value3 = DescriptionTb.Text;

                string FinaVa = value1 + "," + value2 + "," + value3;

                try
                {
                    if (ConstRadio.IsChecked == true)
                        handler.UpdateXmlFile("../../Resources/Constants.xml", FinaVa, "Constants");
                    else if (FormRadio.IsChecked == true)
                        handler.UpdateXmlFile("../../Resources/Formulas.xml", FinaVa, "Formulas");
                    else
                        MessageBox.Show("Please choose whether it is Contant or Formula");
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Adding item failed due to\n  " + ex.Message + "\nPlease make sure file exist or inputs are valid");
                }
            }
        }

        //Method to remove items to file and data grid
        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            string toremove = "";
            if (!string.IsNullOrEmpty(NameTb.Text))
                toremove = NameTb.Text.ToLower();
            else if (!string.IsNullOrEmpty(ValueTb.Text))
                toremove = ValueTb.Text.ToLower();
            else
            {
                MessageBox.Show("Please enter the name or value to remove", "Invalid input-Error"); return;
            }

            XmlHandler handler = new XmlHandler();
            if (ConstRadio.IsChecked == true)
                handler.DeleteItemFromfile("../../Resources/Constants.xml", toremove);
            else
                handler.DeleteItemFromfile("../../Resources/Formulas.xml", toremove);
        }

        //Method to search items from file and data grid
        private void Searchbtn_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void ConstRadio_Checked(object sender, RoutedEventArgs e)
        {
            try
            {

            DataViewer2.Visibility = Visibility.Hidden;
            DataViewer.Visibility = Visibility.Visible;
            }
            catch (Exception)
            {
            }
        }

        private void FormRadio_Checked(object sender, RoutedEventArgs e)
        {
            try
            {

            DataViewer2.Visibility = Visibility.Visible;
            DataViewer.Visibility = Visibility.Hidden;
            }
            catch (Exception)
            {
                
            }
        }

     
    }
}
