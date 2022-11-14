using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace KYRSACH.Operator
{
    public static class Token
    {
        private static readonly string[] Operators = { "^", "*", "/", "+", "-" };
        private static string[] Functions = { "sin", "cos", "tan", "ctan", "sqrt", "exp", "ln", "log" };
        private static readonly string[] Constants = { "e", "pi" };
        private static Dictionary<string, string> AddedFunctions = new Dictionary<string, string>() /*{ { "crat", "sin ( x ) + cos ( x ) * 4" } }*/;

        public static int Precedence(string token)
        {
            if (token == "^")
                return 4;
            else if (token == "sin")
                return 4;
            else if (token == "cos")
                return 4;
            else if (token == "tan")
                return 4;
            else if (token == "ctan")
                return 4;
            else if (token == "sqrt")
                return 4;
            else if (token == "exp")
                return 4;
            else if (token == "ln")
                return 4;
            else if (token == "log")
                return 4;
            else if (IsAddedFunction(token))
                return 4;
            else if (token == "*")
                return 3;
            else if (token == "/")
                return 3;
            else if (token == "+")
                return 2;
            else if (token == "-")
                return 2;
            else
                return 0;
            //        return token switch
            //    {
            //        "^" => 4,
            //        "sin" => 4,
            //        "cos" => 4,
            //        "tan" => 4,
            //        "ctan" => 4,
            //        "sqrt" => 4,
            //        "exp" => 4,
            //        "ln" => 4,
            //        "log" => 4,
            //        "*" => 3,
            //        "/" => 3,
            //        "+" => 2,
            //        "-" => 2,
            //        _ => 0
            //    };
        }

        public static string ReplaceConstant(string token)
        {
            if (token == "e")
                return Math.E.ToString(CultureInfo.CurrentCulture);
            else if (token == "pi")
                return Math.PI.ToString(CultureInfo.CurrentCulture);
            else
                return "0";
            //return token switch
            //{
            //    "e" => Math.E.ToString(CultureInfo.CurrentCulture),
            //    "pi" => Math.PI.ToString(CultureInfo.CurrentCulture),
            //    _ => "0"
            //};
        }

        public static double Evaluate(double value1, double value2, string token)
        {
            if (token == "+")
                return value1 + value2;
            else if (token == "-")
                return value1 - value2;
            else if (token == "*")
                return value1 * value2;
            else if (token == "/")
                return value1 / value2;
            else if (token == "^")
                return Math.Pow(value1, value2);
            else
                return 0;
            //return token switch
            //{
            //    "+" => value1 + value2,
            //    "-" => value1 - value2,
            //    "*" => value1 * value2,
            //    "/" => value1 / value2,
            //    "^" => Math.Pow(value1, value2),
            //    _ => 0
            //};
        }

        public static double Evaluate(double value, string token)
        {
            if (token == "sin")                
                return Math.Sin(value * (Math.PI/180));
            else if (token == "cos")
                return Math.Cos(value * (Math.PI/180));
            else if (token == "tan")
                return Math.Tan(value * (Math.PI/ 180));
            else if (token == "ctan")
                return 1 / Math.Tan(value * (Math.PI / 180 ));
            else if (token == "sqrt")
                return Math.Sqrt(value);
            else if (token == "exp")
                return Math.Exp(value);
            else if (token == "ln")
                return Math.Log(value);
            else if (token == "log")
                return Math.Log10(value);
            else
                return 0;
            //return token switch
            //{
            //    "sin" => Math.Sin(value),
            //    "cos" => Math.Cos(value),
            //    "tan" => Math.Tan(value),
            //    "ctan" => 1 / Math.Tan(value),
            //    "sqrt" => Math.Sqrt(value),
            //    "exp" => Math.Exp(value),
            //    "ln" => Math.Log(value),
            //    "log" => Math.Log10(value),
            //    _ => 0
            //};
        }

        //public static double EvaluateAdded(double value, string token)
        //{
        //    foreach(var key in AddedFunctions.Keys)
        //    {
        //        if (token == key)
        //        {
        //            string infixFunc = AddedFunctions[key];
        //            infixFunc = infixFunc.Replace("x", Convert.ToString(value));
        //            return Infix
        //        }
        //    }
        //}

        //public static void AddFunction(string key, string value)
        //{
        //    AddedFunctions.Add(key, value);
        //}

        public static string Associativity(string token)
        {
            return token == "^" ? "Right" : "Left";
        }

        public static bool IsOperator(string token)
        {
            return Operators.Contains(token);
        }

        public static bool IsFunction(string token)
        {
            return Functions.Contains(token);
        }

        public static bool IsNumber(string token)
        {
            bool isNumber = false;
            if(double.TryParse(token, NumberStyles.Float, new System.Globalization.CultureInfo("en-US"), out _) || token == ".")
                isNumber = true;
            //return double.TryParse(token, NumberStyles.Float, new System.Globalization.CultureInfo("en-US"), out _);
            return isNumber;
        }

        public static bool IsLeftParenthesis(string token)
        {
            return token == "(";
        }

        public static bool IsRightParenthesis(string token)
        {
            return token == ")";
        }

        public static bool IsLeftAssociated(string token)
        {
            return Associativity(token) == "Left";
        }

        public static bool IsGreaterPrecedence(string token1, string token2)
        {
            return Precedence(token1) >= Precedence(token2);
        }

        public static bool IsConstant(string token)
        {
            return Constants.Contains(token);
        }

        public static bool IsAddedFunction(string token)
        {
            return AddedFunctions.ContainsKey(token);
        }

        public static void AddFunction(string name, string definition)
        {
            AddedFunctions.Add(name, definition);
        } 

        public static Dictionary<string, string> GetAddedFunctions()
        {
            return AddedFunctions;
        }
    }
}
