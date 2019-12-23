using System;
using System.Collections.Generic;
using System.Linq;


namespace Calckit.Calculations
{
    public  class DigitalHandle
    {
        #region  Number system converter method

        private static string BaseToDecimal(string input, int basefrom)
        {

            double v1 = 0, v2 = 0;
            if (input.Contains("."))
            {

                string Part1, Part2;
                Part1 = input.Substring(0, input.IndexOf("."));
                Part2 = input.Substring(input.IndexOf(".") + 1);
                for (int i = 0; i < Part1.Length; i++)
                {
                    double v;
                    if (Part1[i] == 'A')
                        v = 10;
                    else if (Part1[i] == 'B')
                        v = 11;
                    else if (Part1[i] == 'C')
                        v = 12;
                    else if (Part1[i] == 'D')
                        v = 13;
                    else if (Part1[i] == 'E')
                        v = 14;
                    else if (Part1[i] == 'F')
                        v = 15;
                    else
                        v = double.Parse(Part1[i].ToString());
                    v = v * double.Parse((Math.Pow(basefrom, Part1.Length - i - 1).ToString()));
                    v1 += v;
                }


                for (int i = 0; i < Part2.Length; i++)
                {

                    double v;
                    if (Part2[i] == 'A')
                        v = 10;
                    else if (Part2[i] == 'B')
                        v = 11;
                    else if (Part2[i] == 'C')
                        v = 12;
                    else if (Part2[i] == 'D')
                        v = 13;
                    else if (Part2[i] == 'E')
                        v = 14;
                    else if (Part2[i] == 'F')
                        v = 15;
                    else
                        v = double.Parse(Part2[i].ToString());
                    if (i == 0)
                        v = v * double.Parse((Math.Pow(basefrom, -1).ToString()));
                    else
                        v = v * double.Parse((Math.Pow(basefrom, -i - 1).ToString()));

                    v2 += v;
                }
            }
            else
            {
                for (int i = 0; i < input.Length; i++)
                {
                    double v;
                    if (input[i] == 'A')
                        v = 10;
                    else if (input[i] == 'B')
                        v = 11;
                    else if (input[i] == 'C')
                        v = 12;
                    else if (input[i] == 'D')
                        v = 13;
                    else if (input[i] == 'E')
                        v = 14;
                    else if (input[i] == 'F')
                        v = 15;
                    else
                        v = double.Parse(input[i].ToString());
                    v = v * double.Parse((Math.Pow(basefrom, input.Length - i - 1).ToString()));
                    v1 += v;
                }
            }

            return (v1 + v2).ToString();
        }
        private static string DecimalToBase(string input,int baseto)
        {
            List<int> Remainder = new List<int>();
            List<int> Remainder2 = new List<int>();
            if (input.Contains("."))
            {
                string part1 = input.Substring(0, input.IndexOf("."));
                string part2 = input.Substring(input.IndexOf("."));
                int value1 = int.Parse(part1);
                double value2 = double.Parse(part2);

                for (; value1 > 0; value1 /= baseto)
                {
                    int rem = value1 % baseto;
                    Remainder.Add(rem);
                }

                double Qu = double.Parse(part2);

                double value = Qu;
                double product;
                int Remainders;

                int count = 0;
                while (value > 0)
                {
                    if (count == 10)
                        break;
                    double res = value * baseto;

                    if (res == 0.0)
                    {
                        break;
                    }

                    else
                    {
                        string part4;
                        string part3;
                        if (!res.ToString().Contains("."))
                        {
                            part3 = res.ToString();
                            part4 = ".0";
                        }
                        else
                        {
                            part4 = res.ToString().Substring(res.ToString().IndexOf("."));
                            part3 = res.ToString().Substring(0, res.ToString().IndexOf("."));
                        }
                        Remainders = int.Parse(part3);
                        Remainder2.Add(Remainders);
                        product = double.Parse(part4);
                    }
                    value = product;
                    count++;
                }
                Remainder.Reverse();
                string top = "";
                foreach (var i in Remainder)
                {
                    if (i == 10)
                        top += "A";
                    else if (i == 11)
                        top += "B";
                    else if (i == 12)
                        top += "C";
                    else if (i == 13)
                        top += "D";
                    else if (i == 14)
                        top += "E";
                    else if (i == 15)
                        top += "F";
                    else
                        top += i.ToString();
                }
                top += ".";
                foreach(var i in Remainder2)
                {
                    if (i == 10)
                        top += "A";
                    else if (i == 11)
                        top += "B";
                    else if (i == 12)
                        top += "C";
                    else if (i == 13)
                        top += "D";
                    else if (i == 14)
                        top += "E";
                    else if (i == 15)
                        top += "F";
                    else
                        top += i.ToString();
                }

                return top;

            }
            else
            {
                int value1 = int.Parse(input);
                for (; value1 > 0; value1 /= baseto)
                {
                    int rem = value1 % baseto;
                    Remainder.Add(rem);
                }
                Remainder.Reverse();
                string top = "";
                foreach(var i in Remainder)
                {
                    if (i == 10)
                        top += "A";
                    else if (i == 11)
                        top += "B";
                    else if (i == 12)
                        top += "C";
                    else if (i == 13)
                        top += "D";
                    else if (i == 14)
                        top += "E";
                    else if (i == 15)
                        top += "F";
                    else
                        top += i.ToString();
                }
                return top;
            }
        }

        public string ConvertFrom(string input,int from)
        {
            return BaseToDecimal(input, from);
        }
        public string ConvertTo(string input, int to)
        {
            return DecimalToBase(input, to);
        }
        #endregion

        #region Binary code converter methods

        public string CodeConverter(string input,string From,string to)
        {
            switch (to)
            {
                case "Binary-Code":
                    {
                        if (From == "Decimal")
                            return DecimalToBase(input, 2);
                        else if (From == "Binary-Code")
                            return input;
                        else if (From == "Gray-Code")
                            return GrayToBinary(input);
                        else if (From == "1's Complement")
                            return OnesComplemToBin(input);
                        else if (From == "2's Complement")
                            return OnesComplemToBin(TwosCompToOnesComp(input));
                        else
                            return "operation not supported!";
                    }
                case "Gray-Code":
                    {
                        if (From == "Decimal")
                            return BinaryToGray(DecimalToBase(input, 2));
                        else if (From == "Binary-Code")
                            return BinaryToGray(input);
                        else if (From == "Gray-Code")
                            return input;
                        else
                            return "Operation not supported";
                    }
                case "Excess3-Code":
                    {
                        if (From == "Decimal")
                            return DecimalToCode(input,"Excess3-Code");
                        else if (From == "BCD-Code")
                            return BCDToExcess3(input);
                        else if (From == "Excess3-Code")
                            return input;
                        else
                            return "OPeration not supported";
                    }
                case "BCD-Code":
                    {
                        if (From == "Decimal")
                            return DecimalToBCD(input);
                        else if (From == "Excess3-Code")
                            return Excess3ToBCD(input);
                        else if (From == "BCD-Code")
                            return input;
                        else
                            return "Operation not supported";
                    }
                case "1's Complement":
                    {
                        if (From == "Binary-Code")
                            return BinaryToOnesComplem(input);
                        else if (From == "2's Complement")
                            return TwosCompToOnesComp(input);
                        else if (From == "Decimal")
                            return DecimalToCode(input, "1's Complement");
                        else if (From == "1's Complement")
                            return input;
                        else
                            return "Operation not supported";
                    }
                case "2's Complement":
                    {
                        if (From == "Binary-Code")
                            return BinaryToTwosComplem(input);
                        else if (From == "1's Complement")
                            return OnesCompToTwosComp(input);
                        else if (From == "Decimal")
                            return DecimalToCode(input, "2's Complement");
                        else if (From == "2's Complement")
                            return input;
                        else
                            return "operation not supported";
                    }
                case "Decimal":
                    {
                        if (From == "Decimal")
                            return input;
                        else if (From == "Excess3-Code")
                            return CodeToDecimal(input, "Excess3-Code");
                        else if (From == "Gray-Code")
                            return CodeToDecimal(input, "Gray-Code");
                        else if (From == "BCD-Code")
                            return BCDToDecimal(input);
                        else if (From == "1's Complement")
                            return CodeToDecimal(input, "1's Complement");
                        else if (From == "2's Complement")
                            return CodeToDecimal(input, "2's Complement");
                        else if (From == "Binary-Code")
                            return CodeToDecimal(input, "Binary-Code");
                        else
                            return "Operation not supported";
                    }

                default: return "No option selected!";
            }
        }

        private static string BinaryToGray(string input)
        {
            List<int> Bin = new List<int>();
            int count = 0;
            foreach (var i in input)
            {
                if (count == 0)
                    Bin.Add(int.Parse(i.ToString()));
                else
                {
                    int next = int.Parse(input[count].ToString());
                    int prev = int.Parse(input[count - 1].ToString());
                    int re = next + prev;
                    if (re == 2)
                        Bin.Add(0);
                    else
                        Bin.Add(re);

                }
                count++;
            }
            string top = "";
            foreach (var i in Bin)
            {
                top += i.ToString();
            }

            return top;
        }
        private static string BinaryToOnesComplem(string input)
        {
            int leng = input.Length;
            List<int> Bin = new List<int>();
            foreach (var i in input)
            {
                int re;
                int v = int.Parse(i.ToString());
                if (v == 0)
                    re = 1;
                else
                    re = 0;

                Bin.Add(re);
            }
            string top = "";
            foreach (var i in Bin)
            {
                top += i.ToString();
            }
            if (top.Length < leng)
            {
                int c = top.Length;
                for (int i = 0; i < leng - c; i++)
                {
                    top = top.Insert(0, "0");
                }
            }
            return top;
        }
        private static string BinaryToTwosComplem(string input)
        {
            int leng = input.Length;
            List<int> Bin = new List<int>();
            foreach (var i in input)
            {
                int re;
                int v = int.Parse(i.ToString());
                if (v == 0)
                    re = 1;
                else
                    re = 0;

                Bin.Add(re);
            }
            string top = "";
            foreach (var i in Bin)
            {
                top += i.ToString();
            }
            string v2 = BaseToDecimal(top, 2);
            int res = int.Parse(v2) + 1;
            string ret = DecimalToBase(res.ToString(), 2);
            if (ret.Length < leng)
            {
                int c = ret.Length;
                for (int j = 0; j < leng - c; j++)
                    ret = ret.Insert(0, "0");
            }
            return ret;

        }
        private static string BinaryToExcess3(string input)
        {
            string Dec = BaseToDecimal(input, 2);
            string Result = "";

            foreach(var i in Dec)
            {
                int v = int.Parse(i.ToString()) + 3;
                string res = DecimalToBase(v.ToString(), 2);

                if (res.Length < 4)
                {
                    int leng =4- res.Length;
                    while (leng > 0)
                        res = res.Insert(0, "0");
                }
                Result += res;
            }
            return Result;
        }
        private static string GrayToBinary(string input)
        {
            List<int> Bin = new List<int>();
            int count = 0;
            foreach (var i in input)
            {
                if (count == 0)
                    Bin.Add(int.Parse(i.ToString()));
                else
                {
                    int next = int.Parse(input[count].ToString());
                    int prev = Bin.Last();
                    int re = next + prev;
                    if (re == 2)
                        Bin.Add(0);
                    else
                        Bin.Add(re);

                }
                count++;
            }
            string top = "";
            foreach (var i in Bin)
            {
                top += i.ToString();
            }

            return top;
        }
        private static string Excess3ToBCD(string input)
        {
            string va = CodeToDecimal(input, "Excess3-Code");
            return DecimalToBCD(va);
        }
        private static string BCDToExcess3(string input)
        {
            string sub = BCDToDecimal(input);
            string top = "";
            foreach(var i in sub)
            {
                string res = (int.Parse(i.ToString()) + 3).ToString();
                string r = DecimalToBase(res,2);
                if (r.Length < 4)
                {
                    int leng = 4 - r.Length;
                    while (leng > 0)
                    {
                        r = r.Insert(0, "0");
                        leng--;
                    }
                }
                top += r;
            }
            return top;
        }
        private static string BCDToDecimal(string input)
        {
            List<int> Bin = new List<int>();
            var Lsub = input.ToList();
            Lsub.Reverse();
            string sub = "";
            foreach (var l in Lsub)
                sub += l.ToString();
            int count = 0;
            for (int i = 0; i < sub.Length; i++)
            {
                string sub2 = "";
                while (count < 4)
                {
                    if (sub.Length < 4)
                    {
                        int c = sub.Length;
                        for (int j = 0; j < 4 - c; j++)
                            sub = sub.Insert(0, "0");
                    }
                    sub2 += sub[count];
                    count++;
                }
                var forsub2 = sub2.ToList();
                forsub2.Reverse();
                sub2 = "";
                foreach (var item in forsub2)
                {
                    sub2 += item.ToString();

                }
                string res = BaseToDecimal(sub2, 2);

                Bin.Add(int.Parse(res.ToString()));

                sub = sub.Remove(0, count);
                count = 0;

            }
            string top = "";
            Bin.Reverse();
            foreach (var k in Bin)
                top += k.ToString();


            return top;
        }
        private static string DecimalToBCD(string input)
        {
            List<string> Bin = new List<string>();

            foreach (var i in input)
            {
                string res = DecimalToBase(i.ToString(), 2);
                if (res.Length < 4)
                {
                    int leng =4- res.Length;
                    while (leng > 0)
                    {
                        res = res.Insert(0, "0");
                        leng--;
                    }
                }
                Bin.Add(res);

            }
            string top = "";
            foreach (var v in Bin)
                top += v.ToString();
            return top;
        }
        private static string OnesComplemToBin(string input)
        {
            return BinaryToOnesComplem(input);
        }
        private static string OnesCompToTwosComp(string input)
        {
            int v = int.Parse(BaseToDecimal(input, 2)) + 1;
            return DecimalToBase(v.ToString(), 2);
        }
        private static string TwosCompToOnesComp(string input)
        {
            int v = int.Parse(BaseToDecimal(input, 2)) - 1;
            return DecimalToBase(v.ToString(), 2);
        }
        private static string CodeToDecimal(string input,string codefrom)
        {
            switch (codefrom)
            {
                case "Binary-Code":
                    return BaseToDecimal(input, 2);

                case "Gray-Code":
                    {
                        return BaseToDecimal(input, 2);
                    }
                case "1's Complement":
                    return BaseToDecimal(OnesComplemToBin(input), 2);

                case "2's Complement":
                    return BaseToDecimal(OnesComplemToBin(TwosCompToOnesComp(input)), 2);

                case "BCD-Code":
                    {
                        List<int> Bin = new List<int>();
                        var Lsub = input.ToList();
                        Lsub.Reverse();
                        string sub = "";
                        foreach (var l in Lsub)
                            sub += l.ToString();
                        int count = 0;
                        for (int i = 0; i < sub.Length; i++)
                        {
                            string sub2 = "";
                            while (count < 4)
                            {
                                if (sub.Length < 4)
                                {
                                    int c = sub.Length;
                                    for (int j = 0; j < 4 - c; j++)
                                        sub = sub.Insert(0, "0");
                                }
                                sub2 += sub[count];
                                count++;
                            }
                            var forsub2 = sub2.ToList();
                            forsub2.Reverse();
                            sub2 = "";
                            foreach (var item in forsub2)
                            {
                                sub2 += item.ToString();

                            }
                            string res = BaseToDecimal(sub2, 2);

                            Bin.Add(int.Parse(res.ToString()));

                            sub = sub.Remove(0, count);
                            count = 0;

                        }
                        string top = "";
                        Bin.Reverse();
                        foreach (var k in Bin)
                            top += k.ToString();

                       
                        return top;
                    }

                case "Excess3-Code":
                    {
                        List<int> Bin = new List<int>();
                        var Lsub = input.ToList();
                        Lsub.Reverse();
                        string sub = "";
                        foreach (var l in Lsub)
                            sub += l.ToString();
                        int count = 0;
                        for (int i = 0; i < sub.Length; i++)
                        {
                            string sub2 = "";
                            while (count < 4)
                            {
                                if (sub.Length < 4)
                                {
                                    int c = sub.Length;
                                    for (int j = 0; j < 4 - c; j++)
                                        sub = sub.Insert(0, "0");
                                }
                                sub2 += sub[count];
                                count++;
                            }
                            var forsub2 = sub2.ToList();
                            forsub2.Reverse();
                            sub2 = "";
                            foreach (var item in forsub2)
                            {
                                sub2 += item.ToString();

                            }
                            string res = BaseToDecimal(sub2, 2);

                            Bin.Add(int.Parse(res.ToString()));

                            sub = sub.Remove(0, count);
                            count = 0;

                        }
                        string top = "";
                        Bin.Reverse();
                        foreach (var k in Bin)
                            top += (int.Parse(k.ToString()) - 3).ToString();


                        return top;
                    }

                default:return "No option selected!";
            }
        }
        private static string DecimalToCode(string input,string codeto)
        {
            switch (codeto)
            {
                case "Binary-Code": return DecimalToBase(input, 2);
                case "Gray-Code":
                    {
                        string inputSub = DecimalToBase(input, 2);
                        List<int> Bin = new List<int>();
                        int count = 0;
                        foreach (var i in inputSub)
                        {
                            if (count == 0)
                                Bin.Add(int.Parse(i.ToString()));
                            else
                            {
                                int next = int.Parse(inputSub[count].ToString());
                                int prev = int.Parse(inputSub[count - 1].ToString());
                                int re = next + prev;
                                if (re == 2)
                                    Bin.Add(0);
                                else
                                    Bin.Add(re);

                            }
                            count++;
                        }
                        string top = "";
                        foreach (var i in Bin)
                        {
                            top += i.ToString();
                        }

                        return top;
                    }

                case "1's Complement":
                    {
                        string inputSub = DecimalToBase(input, 2);
                        List<int> Bin = new List<int>();
                        foreach (var i in inputSub)
                        {
                            int re;
                            int v = int.Parse(i.ToString());
                            if (v == 0)
                                re = 1;
                            else
                                re = 0;

                            Bin.Add(re);
                        }
                        string top = "";
                        foreach (var i in Bin)
                        {
                            top += i.ToString();
                        }
                        return top;
                    }

                case "2's Complement":
                    {
                        string inputSub = DecimalToBase(input, 2);
                        int leng = inputSub.Length;
                        List<int> Bin = new List<int>();
                        foreach (var i in inputSub)
                        {
                            int re;
                            int v = int.Parse(i.ToString());
                            if (v == 0)
                                re = 1;
                            else
                                re = 0;

                            Bin.Add(re);
                        }
                        string top = "";
                        foreach (var i in Bin)
                        {
                            top += i.ToString();
                        }
                        string v2 = BaseToDecimal(top, 2);
                        int res = int.Parse(v2) + 1;
                        string ret = DecimalToBase(res.ToString(), 2);
                        if (ret.Length < leng)
                        {
                            int c = ret.Length;
                            for (int j = 0; j < leng - c; j++)
                                ret = ret.Insert(0, "0");
                        }
                        return ret;

                    }

                case "BCD-Code":
                    {
                        List<string> Bin = new List<string>();

                        foreach(var i in input)
                        {
                            string res = DecimalToBase(i.ToString(), 2);
                            if (res.Length < 4)
                            {
                                int leng =4- res.Length;
                                while (leng > 0)
                                {
                                    res = res.Insert(0, "0");
                                    leng--;
                                }
                            }
                            Bin.Add(res);

                        }
                        string top = "";
                        foreach (var v in Bin)
                            top += v.ToString();
                        return top;
                    }

                case "Excess3-Code":
                    {
                        string top = "";
                        foreach(var i in input)
                        {
                            string re = (int.Parse(i.ToString()) + 3).ToString();
                            string v = DecimalToBase(re,2);
                            if (v.Length < 4)
                            {
                                int leng = 4 - v.Length;
                                while (leng > 0)
                                {
                                    v = v.Insert(0, "0");
                                    leng--;
                                }
                            }
                            top += v;
                        }
                        return top;
                    }

                default: return "No option selected!";

            }
        }
        #endregion

        //Binary arthimetic method
        public string BinOperation(string input1,string input2,string op)
        {
            double v1 = double.Parse(BaseToDecimal(input1, 2));
            double v2 = double.Parse(BaseToDecimal(input2, 2));

            switch (op)
            {
                case "+":return DecimalToBase((v1 + v2).ToString(), 2);
                case "-": {
                        double re = v1 - v2;
                        if (re < 0)
                        {
                            string res = re.ToString().TrimStart('-');
                            res = DecimalToBase(res, 2);


                            int leng = res.Length;
                            List<int> Bin = new List<int>();
                            foreach (var i in res)
                            {
                                int rep;
                                int v = int.Parse(i.ToString());
                                if (v == 0)
                                    rep = 1;
                                else
                                    rep = 0;

                                Bin.Add(rep);
                            }
                            string top = "";
                            foreach (var i in Bin)
                            {
                                top += i.ToString();
                            }
                            string v3 = BaseToDecimal(top, 2);
                            int rest = int.Parse(v3) + 1;
                            string ret = DecimalToBase(rest.ToString(), 2);
                            if (ret.Length < leng)
                            {
                                int c = ret.Length;
                                for (int j = 0; j < leng - c; j++)
                                    ret = ret.Insert(0, "0");
                            }

                            ret = ret.Insert(0, "1");
                            return ret;
                        }

                        else return DecimalToBase(re.ToString(), 2);

                    } 
                case "*": return DecimalToBase((v1 * v2).ToString(), 2);
                case "/": return DecimalToBase((v1 / v2).ToString(), 2);
                case "%": return DecimalToBase((v1 % v2).ToString(), 2);

                default:return "No operator!";
            }
        }

        public  string BCDOperation(string input1, string input2, string op)
        {
            if (input1.Length < input2.Length)
            {
                int lengdif = input2.Length - input1.Length;
                while (lengdif > 0)
                {
                    input1 = input1.Insert(0, "0");
                    lengdif--;
                }
            }
            if (input2.Length < input1.Length)
            {
                int lengdif = input1.Length - input2.Length;
                while (lengdif > 0)
                {
                    input2 = input2.Insert(0, "0");
                    lengdif--;
                }
            }

            var list1 = input1.ToList();
            var list2 = input2.ToList();

            List<string> Res = new List<string>();
            List<string> Res2 = new List<string>();

            string val1 = "", val2 = "";
            int c = 0;
            foreach (var item in list1)
            {
                val1 += item.ToString();
                val2 += list2[c].ToString();
                c++;
            }

            int count = 0;
            for (int i = 0; i < val1.Length; i++)
            {
                int length = val1.Length;
                string sub = "", sub2 = "";
                while (count < 4)
                {
                    sub += val1[count].ToString();
                    sub2 += val2[count].ToString();
                    count++;
                }
                val1 = val1.Remove(0, count);
                val2 = val2.Remove(0, count);

                sub = BaseToDecimal(sub, 2);
                sub2 = BaseToDecimal(sub2, 2);

                Res.Add(sub);
                Res2.Add(sub2);

                count = 0;

            }


            string va = "", vb = "";
            foreach (var g in Res)
                va += g.ToString();
            foreach (var h in Res2)
                vb += h.ToString();

            //operation

            int num1 = int.Parse(va), num2 = int.Parse(vb);

            string Numres;
            switch (op)
            {
                case "+":
                    {
                        Numres = (num1 + num2).ToString();
                        break;
                    }
                case "-":
                    {
                        Numres  = (num1 - num2).ToString();
                        if (double.Parse(Numres) < 0)
                        {
                            string res = Numres.TrimStart('-');
                            res = DecimalToBase(res, 2);


                            int leng = res.Length;
                            List<int> Bin = new List<int>();
                            foreach (var i in res)
                            {
                                int rep;
                                int vd = int.Parse(i.ToString());
                                if (vd == 0)
                                    rep = 1;
                                else
                                    rep = 0;

                                Bin.Add(rep);
                            }
                            string top = "";
                            foreach (var i in Bin)
                            {
                                top += i.ToString();
                            }
                            string v3 = BaseToDecimal(top, 2);
                            int rest = int.Parse(v3) + 1;
                            string ret = DecimalToBase(rest.ToString(), 2);
                            if (ret.Length < leng)
                            {
                                int cd = ret.Length;
                                for (int j = 0; j < leng - cd; j++)
                                    ret = ret.Insert(0, "0");
                            }

                            ret = ret.Insert(0, "1");
                            return ret;
                        }

                        else return DecimalToBase(Numres, 2);
                    }
                case "*":
                    {
                        Numres = (num1 * num2).ToString();
                        break;
                    }
                case "/":
                    {
                        Numres = (num1 / num2).ToString();
                        break;
                    }
                default: return "No operator!";
            }

            //encode to equavalent BCD

            string v = "";
            foreach (var d in Numres)
            {
                string vd = DecimalToBase(d.ToString(), 2);
                if (vd.Length < 4)
                {
                    int cv = 4 - vd.Length;
                    while (cv > 0)
                    {
                        vd = vd.Insert(0, "0");
                        cv--;
                    }
                }
                v += vd;
            }

            return v;

        }

        public string Excess3Operation(string input1,string input2,string op)
        {
            string bcd = Excess3ToBCD(input1);
            string bcd2 = Excess3ToBCD(input2);

            string bcdfinal = BCDOperation(bcd, bcd2, op);
            
            return BCDToExcess3(bcdfinal);
        }


        //Binary parser method
        private static string ParseBinToDecimal(string input)
        {
            string Value = "";

            int c = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsSymbol(input[i]) || Char.IsPunctuation(input[i])
                  )
                {
                    Value += input[i].ToString();
                    c++;
                }
                else if (Char.IsNumber(input[i]))
                {
                    string v = "";
                    for (int j = 0; j < input.Length; j++)
                    {
                        if (Char.IsNumber(input[j]))
                        {
                            v += input[j];
                            c++;
                            continue;
                        }
                        else
                            break;
                    }
                    v = BaseToDecimal(v, 2);
                    Value += v;
                }

                input = input.Remove(0, c);
                c = 0; i = -1;
            }

            return Value;
        }
        private static string ParseHexToDecimal(string input)
        {
            string Value = "";

            int c = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsSymbol(input[i]) || Char.IsPunctuation(input[i])
                  )
                {
                    Value += input[i].ToString();
                    c++;
                }
                else if (Char.IsNumber(input[i]) || Char.IsLetter(input[i]))
                {
                    string v = "";
                    for (int j = 0; j < input.Length; j++)
                    {
                        if (Char.IsNumber(input[j]) || Char.IsLetter(input[j]))
                        {
                            v += input[j];
                            c++;
                            continue;
                        }
                        else
                            break;
                    }
                    v = BaseToDecimal(v, 16);
                    Value += v;
                }

                input = input.Remove(0, c);
                c = 0; i = -1;
            }

            return Value;
        }
        private static string ParseOctoToDecimal(string input)
        {
            string Value = "";

            int c = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsSymbol(input[i]) || Char.IsPunctuation(input[i])
                  )
                {
                    Value += input[i].ToString();
                    c++;
                }
                else if (Char.IsNumber(input[i]))
                {
                    string v = "";
                    for (int j = 0; j < input.Length; j++)
                    {
                        if (Char.IsNumber(input[j]))
                        {
                            v += input[j];
                            c++;
                            continue;
                        }
                        else
                            break;
                    }
                    v = BaseToDecimal(v, 8);
                    Value += v;
                }

                input = input.Remove(0, c);
                c = 0; i = -1;
            }

            return Value;
        }

        private static string Inputparser(string input,string Op)
        {
            Calculate calculate = new Calculate();
            switch (Op)
            {
                case "BIN":
                    {
                        return calculate.Calculator2(ParseBinToDecimal(input));
                    }
                case "OCT":
                    {
                        return calculate.Calculator2(ParseOctoToDecimal(input));
                    }
                case "HEX":
                    {
                        return calculate.Calculator2(ParseHexToDecimal(input));
                    }
                case "DEC":
                    {
                        return calculate.Calculator2(input);
                    }
                default:return calculate.Calculator2(input);
            }
        }

        public string ParserReturn(string input,string Op)
        {
            return Inputparser(input, Op);
        }
    }
}
