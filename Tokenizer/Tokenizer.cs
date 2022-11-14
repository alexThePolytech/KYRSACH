using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tokenizer
{
    public static class Tokenizer
    {
        public static string[] Tokenize(string expression)
        {
            List<string> result = new List<string>();
            List<string> tokens = new List<string>();

            tokens.Add("^\\(");// matches opening bracket
            tokens.Add("^([\\d.\\d]+)"); // matches floating point numbers
            tokens.Add("^[*+/-]+");
            tokens.Add("^[&|<=>!^]+"/*"^([-+]? ?(\\d+|\\(\\g<1>\\))( ?[-+*\\/] ?\\g<1>)?)$"*/); // matches operators and other special characters
            tokens.Add("^[\\w]+"); // matches words and integers
            //tokens.Add("^[,]"); // matches ,
            tokens.Add("^[\\)]"); // matches closing bracket

            expression = expression.Replace(" ", "");

            while (0 != expression.Length)
            {
                bool foundMatch = false;

                foreach (string token in tokens)
                {
                    Match match = Regex.Match(expression, token);
                    //MatchCollection match = Regex.Matches(expression, token);
                    if (false == match.Success)
                    {
                        continue;
                    }

                    result.Add(match.Value);
                    expression = Regex.Replace(expression, token, "");
                    foundMatch = true;

                    break;
                }

                if (false == foundMatch)
                {
                    break;
                }
            }
            return result.ToArray();
        }
    }
}
