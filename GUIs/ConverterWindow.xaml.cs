using Calckit.GUIsHandle;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using TimeConverter;
using UnitsConverter;
using Calckit.Resources;

namespace Calckit.GUIs
{
    /// <summary>
    /// Interaction logic for ConverterWindow.xaml
    /// </summary>
    public partial class ConverterWindow : Window
    {
        /// <summary>
        /// Global variable needed in convertions
        /// </summary>
        List<string> units;
        List<string> unitsMults;
        string SelectedOp;
        string SelectedFrom;
        string SelectedTo;
        string SelMultsFrom;
        string SelMultsTo;
        string Result;
        string Input;
        bool Isstarted = false;

        public ConverterWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ConverterOpListview.SelectedIndex = 0;
            SelectedOp = ConverterOpListview.SelectedItem.ToString().Remove(0, 38);
            UnitsLoading(SelectedOp);
            Convbox1.Focus();
            Isstarted = true;
        }

        //Method for laoding units into combo boxes
        private void UnitsLoading(string SelectedOp)
        {

            try
            {
           
            if (units == null) { }
            else
            {
                units.Clear();
                    if (unitsMults == null) { }
                    else { unitsMults.Clear(); }
            }
                units = new List<string>();
                unitsMults = new List<string>();

            switch (SelectedOp)
            {
                case "Length":
                    {
                        LengthUnits unit = new LengthUnits();
                        MetersMults mults = new MetersMults();
                        var units2 = Enum.GetValues(unit.GetType());
                        var multiples = Enum.GetValues(mults.GetType());
                        foreach(var item in units2)
                        {
                            units.Add(item.ToString());
                        }
                        foreach(var item in multiples)
                        {
                            unitsMults.Add(item.ToString());
                        }
                        break;
                    }

                case "Mass and Weight":
                    {
                        MassUnits unit = new MassUnits();
                        KilogMults mults = new KilogMults();
                        var multiples = Enum.GetValues(mults.GetType());
                        var units2 = Enum.GetValues(unit.GetType());
                        foreach (var item in units2)
                        {
                            units.Add(item.ToString());
                        }
                        foreach (var item in multiples)
                        {
                            unitsMults.Add(item.ToString());
                        }
                            break;
                    }

                case "Power":
                    {
                            PowerUnits unit = new PowerUnits();
                            WattMults mults = new WattMults();
                            var multiples = Enum.GetValues(mults.GetType());
                            var units2 = Enum.GetValues(unit.GetType());
                            foreach (var item in units2)
                            {
                                units.Add(item.ToString());
                            }
                            foreach (var item in multiples)
                            {
                                unitsMults.Add(item.ToString());
                            }
                            break;
                    }
                case "Pressure":
                    {
                        PressureUnits unit = new PressureUnits();
                        PascaMults mults = new PascaMults();
                        var multiples = Enum.GetValues(mults.GetType());
                        var units2 = Enum.GetValues(unit.GetType());
                        foreach (var item in units2)
                        {
                            units.Add(item.ToString());
                        }
                        foreach (var item in multiples)
                        {
                            unitsMults.Add(item.ToString());
                        }
                        break;
                    }
                case "Energy":
                    {
                        EnergyUnits unit = new EnergyUnits();
                        JouleMults mults = new JouleMults();
                        var multiples = Enum.GetValues(mults.GetType());
                        var units2 = Enum.GetValues(unit.GetType());
                        foreach (var item in units2)
                        {
                            units.Add(item.ToString());
                        }
                        foreach (var item in multiples)
                        {
                            unitsMults.Add(item.ToString());
                        }
                        break;
                    }

                case "Temperature":
                    {
                        TemperatureUnits unit = new TemperatureUnits();
                        var units2 = Enum.GetValues(unit.GetType());

                        foreach (var item in units2)
                        {
                            units.Add(item.ToString());
                        }
                            unitsMults.Add("Temperature doesn't have Multiples\n Please choose other option");
                        break;
                    }

                case "Volume":
                    {
                        VolumeUnits unit = new VolumeUnits();
                        M3Mults mults = new M3Mults();
                        var multiples = Enum.GetValues(mults.GetType());
                        var units2 = Enum.GetValues(unit.GetType());
                        foreach (var item in units2)
                        {
                            units.Add(item.ToString());
                        }
                        foreach (var item in multiples)
                        {
                            unitsMults.Add(item.ToString());
                        }
                        break;
                    }

                case "Angle":
                    {
                        AngleUnits unit = new AngleUnits();
                        var units2 = Enum.GetValues(unit.GetType());
                        foreach (var item in units2)
                        {
                            units.Add(item.ToString());
                        }
                            unitsMults.Add("Angle doesn't have Multiples\n Please choose other option");
                            break;
                    }

                case "Area":
                    {
                        AreaUnits unit = new AreaUnits();
                        MetersqrMults mults = new MetersqrMults();
                        var multiples = Enum.GetValues(mults.GetType());
                        var units2 = Enum.GetValues(unit.GetType());
                        foreach (var item in units2)
                        {
                            units.Add(item.ToString());
                        }
                        foreach (var item in multiples)
                        {
                            unitsMults.Add(item.ToString());
                        }
                        break;
                    }
                case "Speed":
                    {
                            SpeedUnits unit = new SpeedUnits();
                            MPSMults mults = new MPSMults();
                            var multiples = Enum.GetValues(mults.GetType());
                            var units2 = Enum.GetValues(unit.GetType());
                            foreach (var item in units2)
                            {
                                units.Add(item.ToString());
                            }
                            foreach (var item in multiples)
                            {
                                unitsMults.Add(item.ToString());
                            }
                            break;
                    }

               case "Time":
                    {
                            TimeUnits unit = new TimeUnits();
                            var units2 = Enum.GetValues(unit.GetType());
                            foreach (var item in units2)
                            {
                                units.Add(item.ToString());
                            }
                            unitsMults.Add("Time doesn't have Multiples\n Please choose other option");
                            break;
                    }
                }
              
                Fromcombo.Items.Clear();
                ToCombo.Items.Clear();
                MultsFromcombo.Items.Clear();
                MultsTocombo.Items.Clear();


                foreach (var v in units)
                {
                    ComboBoxItem boxItem = new ComboBoxItem();
                    boxItem.Background = new SolidColorBrush(Color.FromArgb(System.Convert.ToByte(255), System.Convert.ToByte(40),System. Convert.ToByte(40), System.Convert.ToByte(40)));
                    boxItem.Foreground = Brushes.Beige;
                    boxItem.Opacity = 0.8;
                    boxItem.BorderThickness = new Thickness(0.0);
                    boxItem.Content = v;
                    Fromcombo.Items.Add(boxItem); 

                }

            foreach (var v in units)
            {
                    ComboBoxItem boxItem = new ComboBoxItem();
                    boxItem.Background = new SolidColorBrush(Color.FromArgb(System.Convert.ToByte(255), System.Convert.ToByte(40), System.Convert.ToByte(40), System.Convert.ToByte(40)));
                    boxItem.Foreground = Brushes.Beige;
                    boxItem.Opacity = 0.8;
                    boxItem.BorderThickness = new Thickness(0.0);
                    boxItem.Content = v;
                    ToCombo.Items.Add(boxItem);

                }

            foreach (var v in unitsMults)
            {
                    ComboBoxItem boxItem = new ComboBoxItem();
                    boxItem.Background = new SolidColorBrush(Color.FromArgb(System.Convert.ToByte(255), System.Convert.ToByte(40), System.Convert.ToByte(40), System.Convert.ToByte(40)));
                    boxItem.Foreground = Brushes.Beige;
                    boxItem.Opacity = 0.8;
                    boxItem.BorderThickness = new Thickness(0.0);
                    boxItem.Content = v;
                    MultsFromcombo.Items.Add(boxItem);
                }

            foreach (var v in unitsMults)
            {
                    ComboBoxItem boxItem = new ComboBoxItem();
                    boxItem.Background = new SolidColorBrush(Color.FromArgb(System.Convert.ToByte(255), System.Convert.ToByte(40), System.Convert.ToByte(40), System.Convert.ToByte(40)));
                    boxItem.Foreground = Brushes.Beige;
                    boxItem.Opacity = 0.8;
                    boxItem.BorderThickness = new Thickness(0.0);
                    boxItem.Content = v;
                    MultsTocombo.Items.Add(boxItem);
                }


            Fromcombo.SelectedIndex = 0;
            ToCombo.SelectedIndex = 0;
            MultsFromcombo.SelectedIndex = 0;
            MultsTocombo.SelectedIndex = 0;
            SelectedFrom = Fromcombo.SelectedItem.ToString().Remove(0, 38);
            SelectedTo = ToCombo.SelectedItem.ToString().Remove(0, 38);
            SelMultsFrom = MultsFromcombo.SelectedItem.ToString().Remove(0, 38);
            SelMultsTo = MultsTocombo.SelectedItem.ToString().Remove(0, 38);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: "+ex.Message+"\nPlease Retry","Loading-Content-Error");
            }

        }

        private void Conveteroptionbtn_Click(object sender, RoutedEventArgs e)
        {
            if (ConverterOpListview.IsVisible == true)
            {
                ConverterOpListview.Visibility = Visibility.Collapsed;
            }
            else
            {
                ConverterOpListview.Visibility = Visibility.Visible;
                ConverterOpListview.ScrollIntoView(ConverterOpListview.SelectedItem);
            }
        }

        private void Convbox1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Convbox1.Focusable = true;
            Convbox1.CaretIndex = Convbox1.CaretIndex;
            Convbox1.Focus();
            Convbox2.Focusable = false;
        }

        private void Convbox1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.eπ10³⁻³xp⁶-]");

            if (Convbox1.Text.Contains(".") && e.Text == ".")
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = regex.IsMatch(e.Text);
            }
        }

        private void Unitsradio_Checked(object sender, RoutedEventArgs e)
        {
            Fromcombo.Visibility = Visibility.Visible;
            ToCombo.Visibility = Visibility.Visible;
            MultsFromcombo.Visibility = Visibility.Collapsed;
            MultsTocombo.Visibility = Visibility.Collapsed;
            Convbox1.CaretIndex = Convbox1.CaretIndex;
            Convbox1.Focus();
        }

        private void Multsradio_Checked(object sender, RoutedEventArgs e)
        {
            Fromcombo.Visibility = Visibility.Collapsed;
            ToCombo.Visibility = Visibility.Collapsed;
            MultsFromcombo.Visibility = Visibility.Visible;
            MultsTocombo.Visibility = Visibility.Visible;
            Convbox1.CaretIndex = Convbox1.CaretIndex;
            Convbox1.Focus();
        }


        #region Input buttons methods
        private void Zero_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Zero, Convbox1);
        }

        private void Point_Click(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex("[^0-9.eπ10³⁻³xp⁶-]");

            if (Convbox1.Text.Contains("."))
            {
                e.Handled = true;
                Convbox1.CaretIndex = Convbox1.CaretIndex;
                Convbox1.Focus();
            }
            else
            {
                ButtonHandle button = new ButtonHandle();
                button.NumBtnHandle(Point, Convbox1);
                
            }
           
        }

        private void DZero_Click(object sender, RoutedEventArgs e)
        {

            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(DZero, Convbox1);
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Minus, Convbox1);
        }

        private void Tento3_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Tento3, Convbox1);
        }

        private void Tento6_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Tento6, Convbox1);
        }

        private void Tento_6_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Tento_6, Convbox1);
        }

        private void Tento_3_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Tento_3, Convbox1);
        }

        private void Pi_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Pi, Convbox1);
        }

        private void Three_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Three, Convbox1);
        }

        private void Two_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Two, Convbox1);
        }

        private void One_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(One, Convbox1);
        }

        private void Four_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Four, Convbox1);
        }

        private void Five_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Five, Convbox1);
        }

        private void Six_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Six, Convbox1);
        }

        private void E_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(E, Convbox1);
        }

        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Seven, Convbox1);
        }

        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Eight, Convbox1);
        }

        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.NumBtnHandle(Nine, Convbox1);
        }

        private void Exp_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.FuncBtnHandle(Exp, Convbox1);
        }

        private void Xto_Click(object sender, RoutedEventArgs e)
        {
            if (Convbox1.CaretIndex != Convbox1.Text.Length)
            {
                int index = Convbox1.CaretIndex;
                string input = Convbox1.Text;
                input = input.Insert(index, "^");
                Convbox1.Text = input;
                Convbox1.CaretIndex = index + 1;
                Convbox1.Focus();
            }
            else
            {
                Convbox1.Text +="^";
                Convbox1.CaretIndex = Convbox1.Text.Length;
                Convbox1.Focus();
            }
        }

        private void CE_Click(object sender, RoutedEventArgs e)
        {
            Convbox1.Text = "";
            Convbox1.Focus();
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            Convbox1.Text = "";
            Convbox2.Text = "";
            Result = "";
            Convbox1.Focus();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.Delete(Convbox1);
        }

        #endregion


        #region Memory buttons methods
        private void Mv_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.MemHandle(Mv, Convbox2, MemoryArea);
        }

        private void MS_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.MemHandle(MS, Convbox2, MemoryArea);
        }

        private void MR_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.MemHandle(MR, Convbox1, MemoryArea);
        }

        private void MC_Click(object sender, RoutedEventArgs e)
        {
            ButtonHandle button = new ButtonHandle();
            button.MemHandle(MC, Convbox2, MemoryArea);
        }

        #endregion


        private void ConverterOpListview_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (ConverterOpListview.IsVisible)
            {
                Conveteroptionbtn.Background = Brushes.LightBlue;
            }
            else
                Conveteroptionbtn.Background = Brushes.Transparent;
        }

      
        #region Listview selection changed event and convert
        private void ConverterOpListview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedFrom = "";
            SelectedTo = "";
            SelMultsTo = "";
            SelMultsFrom = "";
            SelectedOp = ConverterOpListview.SelectedItem.ToString().Remove(0, 38);
            ConvertOptLabel.Content = SelectedOp;
            UnitsLoading(SelectedOp);
            ConverterOpListview.Visibility = Visibility.Hidden;
        }
        private void Fromcombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedTo == "") { }
            else
            {
                if (Isstarted && !Fromcombo.Items.IsEmpty)
                {
                    try
                    {
                        Calculations.Calculate calculate = new Calculations.Calculate();
                        SelectedFrom = Fromcombo.SelectedItem.ToString().Remove(0, 38);
                        Input = Convbox1.Text;
                        double re = double.Parse(calculate.Calculator(Input,"Degree"));
                        Convert(re);
                        Convbox2.Text = Result;
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Unexpected Error: " + ex.Message + "\nPlease Try again", "Calculation-Error");
                    }

                }
            }
        }

        private void Convert(double value)
        {
            switch (SelectedOp)
            {
                case "Length":
                    {
                        LengthunitConverter unit = new LengthunitConverter();
                        Result = unit.Convert(value, SelectedFrom, SelectedTo).ToString();
                        break;
                    }

                case "Mass and Weight":
                    {
                        MassConverter unit = new MassConverter();
                        Result = unit.Convert(value, SelectedFrom, SelectedTo).ToString();
                        break;
                    }

                case "Power":
                    {
                        PowerConverter unit = new PowerConverter();
                        Result = unit.Convert(value, SelectedFrom, SelectedTo).ToString();
                        break;
                    }
                case "Pressure":
                    {
                        PressureConverter unit = new PressureConverter();
                        Result = unit.Convert(value, SelectedFrom, SelectedTo).ToString();
                        break;
                    }
                case "Energy":
                    {
                        EnergyConveter unit = new EnergyConveter();
                        Result = unit.Convert(value, SelectedFrom, SelectedTo).ToString();
                        break;
                    }

                case "Temperature":
                    {
                        TemperatureConverter unit = new TemperatureConverter();
                        Result = unit.Convert(value, SelectedFrom, SelectedTo).ToString();
                        break;
                    }

                case "Volume":
                    {
                        VolumeConverter unit = new VolumeConverter();
                        Result = unit.Convert(value, SelectedFrom, SelectedTo).ToString();
                        break;
                    }

                case "Angle":
                    {
                        AngleConverter unit = new AngleConverter();
                        Result = unit.Convert(value, SelectedFrom, SelectedTo).ToString();
                        break;
                    }

                case "Area":
                    {
                        AreaConverter unit = new AreaConverter();
                        Result = unit.Convert(value, SelectedFrom, SelectedTo).ToString();
                        break;
                    }
                case "Speed":
                    {
                        SpeedConverter unit = new SpeedConverter();
                        Result = unit.Convert(value, SelectedFrom, SelectedTo).ToString();
                        break;
                    }

                case "Time":
                    {
                        TimeunitsConverter unit = new TimeunitsConverter();
                        Result = unit.Convert(value, SelectedFrom, SelectedTo).ToString();
                        break;
                    }
            }
        }

        private void ToCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedFrom == "") { }
            else {

                if (Isstarted && !ToCombo.Items.IsEmpty)
                {
                    try
                    {
                        Calculations.Calculate calculate = new Calculations.Calculate();
                        SelectedTo = ToCombo.SelectedItem.ToString().Remove(0, 38);
                        Input = Convbox1.Text;
                        double re = double.Parse(calculate.Calculator(Input, "Degree"));
                        Convert(re);
                        Convbox2.Text = Result;
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Unexpected Error: " + ex.Message + "\nPlease Try again", "Calculation-Error");
                    }

                }
            }
        }

        private void Convbox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Unitsradio.IsChecked == true)
            {
                if (SelectedFrom == "" || SelectedTo == "") { }
                else
                {
                    try
                    {
                        Calculations.Calculate calculate = new Calculations.Calculate();
                        Input = Convbox1.Text;
                        double re = double.Parse(calculate.Calculator(Input, "Degree"));
                        Convert(re);
                        Convbox2.Text = Result;
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            else if (Multsradio.IsChecked == true)
            {
                try
                {

                    Calculations.Calculate calculate = new Calculations.Calculate();
                    SelMultsTo = MultsTocombo.SelectedItem.ToString().Remove(0, 38);
                    Input = Convbox1.Text;
                    double re = double.Parse(calculate.Calculator(Input, "Degree"));
                    if (SelectedOp == "Volume" || SelectedOp == "Speed" || SelectedOp == "Area")
                        ConvMults(re, "");
                    else
                        ConvMults(re, "To");
                    Convbox2.Text = Result;
                }
                catch (Exception )
                {

                }
            }
        }
        private void MultsFromcombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelMultsTo == "") { }
            else
            {
                if (Isstarted && !MultsFromcombo.Items.IsEmpty)
                {
                    try
                    {
                        Calculations.Calculate calculate = new Calculations.Calculate();
                        SelMultsFrom = MultsFromcombo.SelectedItem.ToString().Remove(0, 38);
                        Input = Convbox1.Text;
                        double re =double.Parse( calculate.Calculator(Input, "Degree"));

                        if (SelectedOp == "Volume" || SelectedOp == "Speed" || SelectedOp == "Area")
                            ConvMults(re, "");
                        else
                            ConvMults(re, "From");
                        Convbox2.Text = Result;
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Unexpected Error: " + ex.Message + "\nPlease Try again", "Calculation-Error");
                    }
                }
            }
        }

        private void MultsTocombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelMultsFrom == "") { }
            else
            {
                if (Isstarted && !MultsFromcombo.Items.IsEmpty)
                {
                    try
                    {
                        Calculations.Calculate calculate = new Calculations.Calculate();
                        SelMultsTo = MultsTocombo.SelectedItem.ToString().Remove(0, 38);
                        Input = Convbox1.Text;
                        double re = double.Parse(calculate.Calculator(Input, "Degree"));
                        if (SelectedOp == "Volume" || SelectedOp == "Speed" || SelectedOp == "Area")
                            ConvMults(re, "");
                        else
                            ConvMults(re, "To");
                        Convbox2.Text = Result;
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Unexpected Error: " + ex.Message + "\nPlease Try again", "Calculation-Error");
                    }
                }
            }
        }

        private void ConvMults(double value,string Lv)
        {
            if (Lv == "From")
            {
                if (SelectedOp == "Length" || SelectedOp == "Mass and Weight" || SelectedOp == "Energy" || SelectedOp == "Power" || SelectedOp == "Pressure")
                {
                    string from = SelMultsFrom.Remove(3);
                    string to = SelMultsTo.Remove(3);
                    UnitsprefixConverter converter = new UnitsprefixConverter();

                    if (SelMultsFrom.Contains("Deca"))
                    {
                        if (SelMultsTo.Contains("Deca"))
                            Result = converter.Convert(value, "Deca", "Deca").ToString();
                        else if (SelMultsTo == "Meters" || SelMultsTo == "Pascal" || SelMultsTo == "Kilograms" || SelMultsTo == "Joules" ||
                            SelMultsTo == "Watts")
                            Result = converter.Convert(value, "Deca", PrefixUnits.Baseunit.ToString()).ToString();
                        else
                            Result = converter.Convert(value, "Deca", to).ToString();
                    }

                    else if (SelMultsFrom == "Meters" || SelMultsFrom == "Pascal" || SelMultsFrom == "Watts"
                              || SelMultsFrom == "Kilograms" || SelMultsFrom == "Joules")
                    {
                        if (SelMultsTo.Contains("Deca"))
                            Result = converter.Convert(value, PrefixUnits.Baseunit.ToString(), "Deca").ToString();
                        else if (SelMultsTo == "Meters" || SelMultsTo == "Pascal" || SelMultsTo == "Watts"
                           || SelMultsTo == "Kilograms" || SelMultsTo == "Joules")
                        {
                            Result = converter.Convert(value, PrefixUnits.Baseunit.ToString(), PrefixUnits.Baseunit.ToString()).ToString();
                        }
                        else
                        {
                            Result = converter.Convert(value, PrefixUnits.Baseunit.ToString(), to).ToString();
                        }

                    }

                    else
                    {
                        Result = converter.Convert(value, from, to).ToString();
                    }

                }

            }

            else if (Lv == "To")
            {
                if (SelectedOp == "Length" || SelectedOp == "Mass and Weight" || SelectedOp == "Energy" || SelectedOp == "Power" || SelectedOp == "Pressure")
                {
                    string from = SelMultsFrom.Remove(3);
                    string to = SelMultsTo.Remove(3);
                    UnitsprefixConverter converter = new UnitsprefixConverter();

                    if (SelMultsTo.Contains("Deca"))
                    {
                        if (SelMultsFrom.Contains("Deca"))
                            Result = converter.Convert(value, "Deca", "Deca").ToString();
                        else if (SelMultsFrom == "Meters" || SelMultsFrom == "Pascal" || SelMultsFrom == "Kilograms" || SelMultsFrom == "Joules" ||
                            SelMultsFrom == "Watts")
                            Result = converter.Convert(value, PrefixUnits.Baseunit.ToString(), "Deca").ToString();
                        else
                            Result = converter.Convert(value, to, "Deca").ToString();
                    }

                    else if (SelMultsTo == "Meters" || SelMultsTo == "Pascal" || SelMultsTo == "Watts"
                              || SelMultsTo == "Kilograms" || SelMultsTo == "Joules")
                    {
                        if (SelMultsFrom.Contains("Deca"))
                            Result = converter.Convert(value, "Deca", PrefixUnits.Baseunit.ToString()).ToString();
                        else if (SelMultsFrom == "Meters" || SelMultsFrom == "Pascal" || SelMultsFrom == "Watts"
                           || SelMultsFrom == "Kilograms" || SelMultsFrom == "Joules")
                        {
                            Result = converter.Convert(value, PrefixUnits.Baseunit.ToString(), PrefixUnits.Baseunit.ToString()).ToString();
                        }
                        else
                        {
                            Result = converter.Convert(value, from, PrefixUnits.Baseunit.ToString()).ToString();
                        }

                    }

                    else
                    {
                        Result = converter.Convert(value, from, to).ToString();
                    }

                }
            }

            else { 
                 if (SelectedOp == "Speed")
                {
                    MPSConverter converter = new MPSConverter();
                    Result = converter.Convert(value, SelMultsFrom, SelMultsTo).ToString();
                }
                else if (SelectedOp == "Volume")
                {
                    M3MultsConverter converter = new M3MultsConverter();
                    Result = converter.Convert(value, SelMultsFrom, SelMultsTo).ToString();
                }
                else if (SelectedOp == "Area")
                {
                    M2MultsConverter converter = new M2MultsConverter();
                    Result = converter.Convert(value, SelMultsFrom, SelMultsTo).ToString();
                }
            }
            
        }
        #endregion


    }
}

