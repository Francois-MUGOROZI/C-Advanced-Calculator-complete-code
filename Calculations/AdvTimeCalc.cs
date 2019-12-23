using System;
using System.Windows.Controls;

namespace Calckit.Calculations
{
   public class AdvTimeCalc
    {
        public string SS { get; set; }
        public string Mm { get; set; }
        public string HH { get; set; }
        public string DD { get; set; }
        public string WW { get; set; }
        public string MM { get; set; }
        public string YY { get; set; }
        public DateTime Time1 { get; set; }
        public DateTime Time2 { get; set; }
        public DateTime Result { get; private set; }

        public TimeSpan Span { get; private set; }



        public string GetOption(string Selected,char Op)
        {
            switch (Selected)
            {
                case "ss":
                    {
                        if (Op == '+')
                        {
                            Result = Time1.AddSeconds(double.Parse(SS));
                            return Result.ToString();
                        }
                        else if (Op == '-')
                        {

                            Result = Time1.AddSeconds(-double.Parse(SS));
                            return Result.ToString();
                        }
                        else
                            return "Please choose an operator";
                    }

                case "mm":
                    {
                        if (Op == '+')
                        {
                            Result = Time1.AddMinutes(double.Parse(Mm));
                            return Result.ToString();
                        }
                        else if (Op == '-')
                        {

                            Result = Time1.AddMinutes(-double.Parse(Mm));
                            return Result.ToString();
                        }
                        else
                            return "Please choose an operator";
                    }

                case "mm-ss":
                    {
                        if (Op == '+')
                        {
                            Result = Time1.AddMinutes(double.Parse(Mm));
                            Result = Result.AddSeconds(double.Parse(SS));
                            return Result.ToString();
                        }
                        else if (Op == '-')
                        {

                            Result = Time1.AddMinutes(-double.Parse(Mm));
                            Result = Result.AddSeconds(-double.Parse(SS));
                            return Result.ToString();
                        }
                        else
                            return "Please choose an operator";
                    }

                case "hh":
                    {
                        if (Op == '+')
                        {
                            Result = Time1.AddHours(double.Parse(HH));
                            return Result.ToString();
                        }
                        else if (Op == '-')
                        {

                            Result = Time1.AddHours(-double.Parse(HH));
                            return Result.ToString();
                        }
                        else
                            return "Please choose an operator";
                    }

                case "hh-mm":
                    {
                        if (Op == '+')
                        {
                            Result = Time1.AddHours(double.Parse(HH));
                            Result = Result.AddMinutes(double.Parse(Mm));
                            return Result.ToString();
                        }
                        else if (Op == '-')
                        {

                            Result = Time1.AddHours(-double.Parse(HH));
                            Result = Result.AddMinutes(-double.Parse(Mm));
                            return Result.ToString();
                        }
                        else
                            return "Please choose an operator";
                    }

                case "hh-mm-ss":
                    {
                        if (Op == '+')
                        {
                            Result = Time1.AddHours(double.Parse(HH));
                            Result = Result.AddMinutes(double.Parse(Mm));
                            Result = Result.AddSeconds(double.Parse(SS));
                            return Result.ToString();
                        }
                        else if (Op == '-')
                        {

                            Result = Time1.AddHours(-double.Parse(HH));
                            Result = Result.AddMinutes(-double.Parse(Mm));
                            Result = Result.AddSeconds(-double.Parse(SS));
                            return Result.ToString();
                        }
                        else
                            return "Please choose an operator";
                    }

                case "dd":
                    {
                        if (Op == '+')
                        {
                            Result = Time1.AddDays(double.Parse(DD));
                            return Result.ToString();
                        }
                        else if (Op == '-')
                        {

                            Result = Time1.AddDays(-double.Parse(DD));
                            return Result.ToString();
                        }
                        else
                            return "Please choose an operator";
                    }

                case "dd-hh":
                    {
                        if (Op == '+')
                        {
                            Result = Time1.AddDays(double.Parse(DD));
                            Result = Result.AddHours(double.Parse(HH));
                            return Result.ToString();
                        }
                        else if (Op == '-')
                        {

                            Result = Time1.AddDays(-double.Parse(DD));
                            Result = Result.AddHours(-double.Parse(HH));
                            return Result.ToString();
                        }
                        else
                            return "Please choose an operator";
                    }

                case "dd-hh-mm":
                    {
                        if (Op == '+')
                        {
                            Result = Time1.AddDays(double.Parse(DD));
                            Result = Result.AddHours(double.Parse(HH));
                            Result = Result.AddMinutes(double.Parse(Mm));
                            return Result.ToString();
                        }
                        else if (Op == '-')
                        {

                            Result = Time1.AddHours(-double.Parse(HH));
                            Result = Result.AddMinutes(-double.Parse(Mm));
                            Result = Result.AddSeconds(-double.Parse(SS));
                            return Result.ToString();
                        }
                        else
                            return "Please choose an operator";
                    }

                case "ww":
                    {
                        if (Op == '+')
                        {
                            Result = Time1.AddSeconds(double.Parse(WW)*604800);
                            return Result.ToString();
                        }
                        else if (Op == '-')
                        {

                            Result = Time1.AddSeconds(-double.Parse(WW)*604800);
                            return Result.ToString();
                        }
                        else
                            return "Please choose an operator";
                    }

                case "ww-dd":
                    {
                        if (Op == '+')
                        {
                            Result = Time1.AddSeconds(double.Parse(WW)*604800);
                            Result = Result.AddDays(double.Parse(DD));
                            return Result.ToString();
                        }
                        else if (Op == '-')
                        {

                            Result = Time1.AddSeconds(-double.Parse(WW)*604800);
                            Result = Result.AddDays(-double.Parse(DD));
                            return Result.ToString();
                        }
                        else
                            return "Please choose an operator";
                    }

                case "ww-dd-hh":
                    {
                        if (Op == '+')
                        {
                            Result = Time1.AddSeconds(double.Parse(WW)*604800);
                            Result = Result.AddDays(double.Parse(DD));
                            Result = Result.AddHours(double.Parse(HH));
                            return Result.ToString();
                        }
                        else if (Op == '-')
                        {

                            Result = Time1.AddSeconds(-double.Parse(WW)*604800);
                            Result = Result.AddDays(-double.Parse(DD));
                            Result = Result.AddHours(-double.Parse(HH));
                            return Result.ToString();
                        }
                        else
                            return "Please choose an operator";
                    }

                case "MM":
                    {
                        if (Op == '+')
                        {
                            Result = Time1.AddMonths(int.Parse(MM));
                            return Result.ToString();
                        }
                        else if (Op == '-')
                        {

                            Result = Time1.AddMonths(-int.Parse(MM));
                            return Result.ToString();
                        }
                        else
                            return "Please choose an operator";
                    }

                case "MM-ww":
                    {
                        if (Op == '+')
                        {
                            Result = Time1.AddMonths(int.Parse(MM));
                            Result = Result.AddSeconds(double.Parse(WW)*604800);
                            return Result.ToString();
                        }
                        else if (Op == '-')
                        {

                            Result = Time1.AddMonths(-int.Parse(MM));
                            Result = Result.AddSeconds(-double.Parse(WW)*604800);
                            return Result.ToString();
                        }
                        else
                            return "Please choose an operator";
                    }

                case "MM-ww-dd":
                    {
                        if (Op == '+')
                        {
                            Result = Time1.AddMonths(int.Parse(MM));
                            Result = Result.AddSeconds(double.Parse(WW)*604800);
                            Result = Result.AddDays(double.Parse(DD));
                            return Result.ToString();
                        }
                        else if (Op == '-')
                        {

                            Result = Time1.AddMonths(-int.Parse(MM));
                            Result = Result.AddSeconds(-double.Parse(WW)*604800);
                            Result = Result.AddDays(-double.Parse(DD));
                            return Result.ToString();
                        }
                        else
                            return "Please choose an operator";
                    }

                case "yy":
                    {
                        if (Op == '+')
                        {
                            Result = Time1.AddYears(int.Parse(YY));
                            return Result.ToString();
                        }
                        else if (Op == '-')
                        {

                            Result = Time1.AddYears(-int.Parse(YY));
                            return Result.ToString();
                        }
                        else
                            return "Please choose an operator";
                    }

                case "yy-MM":
                    {
                        if (Op == '+')
                        {
                            Result = Time1.AddYears(int.Parse(YY));
                            Result = Result.AddMonths(int.Parse(MM));
                            return Result.ToString();
                        }
                        else if (Op == '-')
                        {

                            Result = Time1.AddYears(-int.Parse(YY));
                            Result = Result.AddMonths(-int.Parse(MM));
                            return Result.ToString();
                        }
                        else
                            return "Please choose an operator";
                    }

                case "yy-MM-ww":
                    {
                        if (Op == '+')
                        {
                            Result = Time1.AddYears(int.Parse(YY));
                            Result = Result.AddMonths(int.Parse(MM));
                            Result = Result.AddSeconds(double.Parse(WW)*604800);
                            return Result.ToString();
                        }
                        else if (Op == '-')
                        {

                            Result = Time1.AddYears(-int.Parse(YY));
                            Result = Result.AddMonths(-int.Parse(MM));
                            Result = Result.AddSeconds(-double.Parse(WW)*604800);
                            return Result.ToString();
                        }
                        else
                            return "Please choose an operator";
                    }

                case "yy-MM-dd":
                    {
                        if (Op == '+')
                        {
                            Result = Time1.AddYears(int.Parse(YY));
                            Result = Result.AddMonths(int.Parse(MM));
                            Result = Result.AddDays(double.Parse(DD));
                            return Result.ToString();
                        }
                        else if (Op == '-')
                        {

                            Result = Time1.AddYears(-int.Parse(YY));
                            Result = Result.AddMonths(-int.Parse(MM));
                            Result = Result.AddDays(-double.Parse(DD));
                            return Result.ToString();
                        }
                        else
                            return "Please choose an operator";
                    }
                case "custom":
                    {
                        if (Op == '-')
                        {
                            if (Time2 > Time1)
                                Span = Time2 - Time1;
                            else if (Time1 > Time2)
                                Span = Time1 - Time2;
                            else
                                Span = Time2 - Time1;

                            return Span.ToString();
                        }
                       
                        else
                            return "This option give difference between dates\nplease use negative";
                    }



                default:
                    {
                        return "Please selected one of option in dropdown";
                    }
            }
        }

        public TimeSpan SpanedTime()
        {
            if (Time2 > Time1)
                return Span = Time2 - Time1;
            else if (Time1 > Time2)
                return Span = Time1 - Time2;
            else
                return Time2 - Time1;
        }


        public void DateDetailGen(TextBox block,DateTime date)
        {
            string Title = "Details for DateTime Specified" + "\n____________________________________";

            string DateComplete = date.ToLongDateString();
            string Dayow = date.DayOfWeek.ToString();
            string dayofy = date.DayOfYear.ToString();
            string wofy = (int.Parse(dayofy) / 7).ToString();
            string mont = date.Month.ToString();
            string year = date.Year.ToString();
            string Time = date.TimeOfDay.ToString();
            string timeUTC = date.ToUniversalTime().ToString();
            string timecomp = date.ToLongTimeString();
            string Century = (int.Parse(year) / 100).ToString();
            string Mel = (int.Parse(year) / 1000).ToString();

            string Toprint = "";
            //Arrays

            string[] Name = { "InputDateTime:","CompleteDate:","CompleteTime:","DayofWeek:","DayofYear:","WeekofYear:","Month:","Year:",
            "TimeUTC:","TimeLocal:","Century:","Mellenium:"};

            string[] Value = { date.ToString(), DateComplete, timecomp, Dayow, dayofy, wofy, mont, year, timeUTC, Time, Century, Mel };

            //Looping

            for (int i = 0; i < Name.Length; i++)
            {
                Toprint += string.Format("{0,0} {1,30}\n", Name[i], Value[i]);
            }

            block.Text = string.Format("{0,0}\n\n {1,0} {2,30}\n\n {3,0}", Title, "Property", "Value", Toprint);
        }

        public void TimeDiffDetail(TextBox block,DateTime Input1,DateTime Input2)
        {
            string Title = "Details for difference between dates" + "\n____________________________________";
          

            TimeSpan span = SpanedTime();
            string days = span.Days.ToString();
            string Min = span.Minutes.ToString();
            string sec = span.Seconds.ToString();
            string Totdays = span.TotalDays.ToString();
            string TotMin = span.TotalMinutes.ToString();
            string Totsec = span.TotalSeconds.ToString();
            string Hour = span.Hours.ToString();
            string Tothour = span.TotalHours.ToString();
            string Dur = span.Duration().ToString();
            string Res = span.ToString();

            //Array of names

            string[] Names = {"Time1:","Time2:","Operation:","Result:","Days:","Hours:","Mins:","Secs:","Totaldays:","TotalHours:","TotalMins:",
            "TotalSecs:","Duration:"};
            string[] Value = { Input1.ToString(), Input2.ToString(), "Difference", Res, days, Hour, Min, sec, Totdays, Tothour, TotMin, Totsec, Dur };

            //Looping arrays

            string Toprint = "";

           for (int i = 0; i < Names.Length;i++) {
                Toprint += string.Format("{0,0} {1,30}\n", Names[i], Value[i]);
            }


            block.Text = string.Format("{0,0}\n\n {1,0} {2,30}\n\n {3,0}", Title, "Property", "Value", Toprint);

        }

        public void DetailGen( DateTime date1,DateTime date,string OpSelected,char op,TextBox block)
        {
            string Title = "Details for Date calculation between dates" + "\n______________________________________________";

            string in1 = date1.ToString();
            string res = date.ToString();
            string in2;

            switch (OpSelected)
            {
                case "ss":
                    {
                        in2 = SS;
                        break;
                    }

                case "mm":
                    {
                        in2 = Mm;
                        break;
                    }

                case "mm-ss":
                    {
                        in2 = Mm + ":" + SS;
                        break;
                    }

                case "hh":
                    {
                        in2 = HH;
                        break;
                    }

                case "hh-mm":
                    {
                        in2 = HH + ":" + Mm;
                        break;
                    }

                case "hh-mm-ss":
                    {
                        in2 = HH + ":" + Mm + ":" + SS;
                        break;
                    }

                case "dd":
                    {
                        in2 = DD;
                        break;
                    }

                case "dd-hh":
                    {
                        in2 = DD + ":" + HH;
                        break;
                    }

                case "dd-hh-mm":
                    {
                        in2 = DD + ":" + HH + ":" + Mm;
                        break;
                    }

                case "ww":
                    {
                        in2 = WW;
                        break;
                    }

                case "ww-dd":
                    {
                        in2 = WW + ":" + DD;
                        break;
                    }

                case "ww-dd-hh":
                    {
                        in2 = WW + ":" + DD + ":" + HH;
                        break;
                    }

                case "MM":
                    {
                        in2 = MM;
                        break;
                    }

                case "MM-ww":
                    {
                        in2 = MM + ":" + WW;
                        break;
                    }

                case "MM-ww-dd":
                    {
                        in2 = MM + ":" + WW + ":" + DD;
                        break;
                    }

                case "yy":
                    {
                        in2 = YY;
                        break;
                    }

                case "yy-MM":
                    {
                        in2 = YY + ":" + MM;
                        break;
                    }

                case "yy-MM-ww":
                    {
                        in2 = YY + ":" + MM + ":" + WW;
                        break;
                    }

                case "yy-MM-dd":
                    {
                        in2 = YY + ":" + MM + ":" + DD;
                        break;
                    }
     
                default:
                    {
                        in2 = "Please selected one of option in dropdown";
                        break;
                    }
            }

            
            string DateComplete = date.ToLongDateString();
            string Dayow = date.DayOfWeek.ToString();
            string dayofy = date.DayOfYear.ToString();
            string wofy = (int.Parse(dayofy) / 7).ToString();
            string mont = date.Month.ToString();
            string year = date.Year.ToString();
            string Time = date.TimeOfDay.ToString();
            string timeUTC = date.ToUniversalTime().ToString();
            string timecomp = date.ToLongTimeString();
            string Century = (int.Parse(year) / 100).ToString();
            string Mel = (int.Parse(year) / 1000).ToString();

            string Toprint = "";
            //Arrays

            string[] Name = { "Input1:","Input2:","Operator:","Result:","CompleteTime:","DayofWeek:","DayofYear:","WeekofYear:","Month:","Year:",
            "UTC:","Time:","Century:","Mellenium:"};

            string[] Value = { in1,in2 + " " + OpSelected,op.ToString(), DateComplete, timecomp, Dayow, dayofy, wofy, mont, year, timeUTC, Time, Century, Mel };

            //Looping

            for (int i = 0; i < Name.Length; i++)
            {
                Toprint += string.Format("{0,0} {1,30}\n", Name[i], Value[i]);
            }
            block.Text = string.Format("{0,0}\n\n {1,0} {2,30}\n\n {3,0}", Title, "Property", "Value", Toprint);
        }
    }
}
