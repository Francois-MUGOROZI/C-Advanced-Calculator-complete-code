using System;
using xFunc.Maths;

namespace Calckit.Calculations
{
   public class Calculate
   {
        public string Calculator(string input,string Opselected)
        {

            switch (Opselected)
            {
                case "Degree":
                    {
                        Processor processor = new Processor(new Processor().Lexer, new Processor().Parser, new Processor().Simplifier,
                            new Processor().Differentiator, new Processor().TypeAnalyzer, new xFunc.Maths.Expressions.ExpressionParameters(xFunc.Maths.Expressions.AngleMeasurement.Degree));
                        input = CleanExp(input);
                        input = processor.Solve(input).ToString();
                        return input;
                    }
                case "Radian":
                    {
                        Processor processor = new Processor(new Processor().Lexer, new Processor().Parser, new Processor().Simplifier,
                                                   new Processor().Differentiator, new Processor().TypeAnalyzer, new xFunc.Maths.Expressions.ExpressionParameters(xFunc.Maths.Expressions.AngleMeasurement.Radian));
                        input = CleanExp(input);
                        input = processor.Solve(input).ToString();
                        return input;
                    }
                case "Grad":
                    {
                        Processor processor = new Processor(new Processor().Lexer, new Processor().Parser, new Processor().Simplifier,
                           new Processor().Differentiator, new Processor().TypeAnalyzer, new xFunc.Maths.Expressions.ExpressionParameters(xFunc.Maths.Expressions.AngleMeasurement.Gradian));
                        input = CleanExp(input);
                        input = processor.Solve(input).ToString();
                        return input;
                    }
                default:
                    return "Please choose option between:" +
                        "Deg,Rad,Grad";
            }
                

        }

        public string Calculator2(string input)
        {
            Processor processor = new Processor();
            input = CleanExp(input);
            input = processor.Solve(input).ToString();
            return input;
        }

      
        private static string Func2Check(string first,string input,string value,int length)
        {
            
            for (int i=0;i<input.Length;i++)
            {
                if (input.Length - i < 3)
                    break;
                else
                {
                    if (input.Substring(i, 3) == first)
                    {
                        input = input.Remove(i, length);
                        input = input.Insert(i, value);
                    }
                }
            }
            return input;
        }
        private static string CleanExp(string exp)
        {
            //powers clean up
            if (exp.Contains("⁻³")||exp.Contains("⁻⁶"))
            {
                for(int i=0;i<exp.Length;i++)
                {
                    if(exp[i]== '⁻'&&exp[i+1]== '³')
                    {
                        exp = exp.Remove(i, 2);
                        exp = exp.Insert(i, "^(-3)");
                    }
                    if(exp[i]== '⁻'&&exp[i+1]== '⁶')
                    {
                        exp = exp.Remove(i, 2);
                        exp = exp.Insert(i, "^(-6)");
                    }
                }
            }
            exp = exp.Replace("²", "^2");
            exp = exp.Replace("⁴", "^4");
            exp = exp.Replace("⁵", "^5");
            exp = exp.Replace("³", "^3");
            exp = exp.Replace("÷", "/");
            exp = exp.Replace("⁶", "^6");


            ///<summary >
            ///Cleanup exp and convert input string format to library equivalent
            ///</summary>

            //Trigonometric
            if (exp.Contains("sin⁻¹"))
            {
                for (int i = 0; i < exp.Length; i++)
                {
                    int dif = exp.Length - i;
                    if (exp[i] == 's' && exp[i + 4] == '¹' && exp[i + 2] == 'n' && dif > 5)
                    {
                        exp = exp.Remove(i, 5);
                        exp = exp.Insert(i, "arcsin");
                    }
                }
            }

            if (exp.Contains("cos⁻¹"))
            {
                for (int i = 0; i < exp.Length; i++)
                {
                    int dif = exp.Length - i;
                    if (exp[i] == 'c' && exp[i + 4] == '¹' && exp[i + 2] == 's' && dif > 5)
                    {
                        exp = exp.Remove(i, 5);
                        exp = exp.Insert(i, "arccos");
                    }
                }
            }
            if (exp.Contains("tan⁻¹"))
            {
                for (int i = 0; i < exp.Length; i++)
                {
                    int dif = exp.Length - i;
                    if (exp[i] == 't' && exp[i + 4] == '¹' && exp[i + 2] == 'n' && dif > 5)
                    {
                        exp = exp.Remove(i, 5);
                        exp = exp.Insert(i, "arctan");
                    }
                }
            }

            if (exp.Contains("sec⁻¹"))
            {
                for (int i = 0; i < exp.Length; i++)
                {
                    int dif = exp.Length - i;
                    if (exp[i] == 's' && exp[i + 4] == '¹' && exp[i + 2] == 'c' && dif > 5)
                    {
                        exp = exp.Remove(i, 5);
                        exp = exp.Insert(i, "arcsec");
                    }
                }
            }

            if (exp.Contains("csc⁻¹"))
            {
                for (int i = 0; i < exp.Length; i++)
                {
                    int dif = exp.Length - i;
                    if (exp[i] == 'c' && exp[i + 4] == '¹' && exp[i + 2] == 'c' && dif > 5)
                    {
                        exp = exp.Remove(i, 5);
                        exp = exp.Insert(i, "arccsc");
                    }
                }
            }

            if (exp.Contains("cot⁻¹"))
            {
                for (int i = 0; i < exp.Length; i++)
                {
                    int dif = exp.Length - i;
                    if (exp[i] == 'c' && exp[i + 4] == '¹' && exp[i + 2] == 't' && dif > 5)
                    {
                        exp = exp.Remove(i, 5);
                        exp = exp.Insert(i, "arccot");
                    }
                }

            }




            //others

            if (exp.Contains("conj"))
                exp = Func2Check("con", exp, "conjugate", 4);
            if (exp.Contains("rec"))
                exp = Func2Check("rec", exp, "reciprocal", 3);
            if (exp.Contains("prod"))
                exp = Func2Check("pro", exp, "product", 4);
            if (exp.Contains("inv"))
                exp = Func2Check("inv", exp, "inverse", 3);
            if (exp.Contains("trans"))
                exp = Func2Check("tra", exp, "transpose", 5);
            if (exp.Contains("simp"))
                exp = Func2Check("sim", exp, "simplify", 4);
            if (exp.Contains("log₁₀"))
            {

                for (int i=0;i<exp.Length;i++)
                {    if (exp.Length - i < 5)
                        break;

                     if (exp[i] == 'l' && exp[i + 4] == '₀')
                     {
                        exp = exp.Remove(i, 5);
                        exp = exp.Insert(i + 1, "10,");
                        exp = exp.Insert(i, "log");
                     }    
                }
            }

            if (exp.Contains("logₐ"))
            {

                for (int i = 0; i < exp.Length; i++)
                {
                    if (exp.Length - i < 5)
                        break;

                    if (exp[i] == 'l' && exp[i + 3] == 'ₐ')
                    {
                        exp = exp.Remove(i, 4);
                        exp = exp.Insert(i, "log");
                    }
                }
            }
            exp = exp.Replace("∑", "sum");
          
      
            exp = exp.Replace("√", "sqrt");

            //parsing paranthesis
            if (exp.Length > 2)
            {
                for (int i = 0; i < exp.Length; i++)
                {
                    int checleng = exp.Length - i;

                    if (checleng > 1)
                    {
                        if ((Char.IsNumber(exp[i]) || exp[i] == 'π' || exp[i] == '%' || exp[i] == '!' || exp[i] == ')') && exp[i + 1] == '(')
                            exp = exp.Insert(i + 1, "*");

                        if (Char.IsLetter(exp[i]) && Char.IsNumber(exp[i + 1]))
                            exp = exp.Insert(i, "*");
                        if (Char.IsNumber(exp[i]) && Char.IsLetter(exp[i + 1]))
                            exp = exp.Insert(i+1, "*");
                    }

                    if (i != 0)
                    {
                        if ((Char.IsNumber(exp[i]) || exp[i] == 'π' || exp[i] == '%' || exp[i] == '!'||Char.IsLetter(exp[i])) && exp[i - 1] == ')')
                            exp = exp.Insert(i, "*");
                    }

                    if (checleng > 4)
                    {
                        if ((exp.Substring(i, 3) == "tao" || exp.Substring(i, 3) == "phi") && (Char.IsLetter(exp[i + 3]) || Char.IsNumber(exp[i + 3]) || exp[i + 3] == '('))
                            exp = exp.Insert(i + 3, "*");
                    }

                    if (i != 0&&checleng>4)
                    {
                        if ((exp.Substring(i, 3) == "tao" || exp.Substring(i, 3) == "phi") && (Char.IsLetter(exp[i - 1]) || Char.IsNumber(exp[i - 1]) || exp[i - 1] == ')'))
                            exp = exp.Insert(i, "*");
                    }
                }
            }

            return exp;
        }

   }
}
