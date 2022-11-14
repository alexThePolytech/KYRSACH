// See https://aka.ms/new-console-template for more information
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
namespace TheMain
{

class Tokenizer
{

public static string[] Tokenize(string expression)
{
    List<string> result = new List<string>();
    List<string> tokens = new List<string>();

    tokens.Add("(^\\()");// matches opening bracket
    tokens.Add("(^([\\d.\\d]+))"); // matches floating point numbers
    tokens.Add("(^[&|<=>!]+)"); // matches operators and other special characters
    tokens.Add("(^[\\w]+)"); // matches words and integers
    tokens.Add("(^[,])"); // matches ,
    tokens.Add("(^[\\)])"); // matches closing bracket
    tokens.Add("(?!\\+)(?:\"((?:\\\\\"|[^\"])*)\"?)"); // matches quoted string

    while (0 != expression.Length)
    {
        bool foundMatch = false;

        foreach (string token in tokens)
        {
            Match match = Regex.Match(expression, token);
            if (false == match.Success)
            {
                continue;
            }

            result.Add(match.Groups[1].Value);
            expression = Regex.Replace(expression, token, "");
            foundMatch = true;

            expression = Regex.Replace(expression, @"\s*\+\s*", "");    // Remove concatenation

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

