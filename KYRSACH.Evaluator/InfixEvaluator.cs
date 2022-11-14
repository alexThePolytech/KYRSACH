using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using KYRSACH.Operator;
using ShuntingYard;

namespace KYRSACH.Evaluator
{
    public static class InfixEvaluator
    {
        public static double EvaluateInfix(Queue<string> postfix)
        {
            var resultStack = new Stack<double>();

            while (postfix.Any())
            {
                var currentToken = postfix.Dequeue();

                if (Token.IsNumber(currentToken))
                {
                    resultStack.Push(double.Parse(currentToken, new System.Globalization.CultureInfo("en-US")));
                    continue;
                }

                if (Token.IsOperator(currentToken))
                {
                    var val1 = resultStack.Pop();
                    var val2 = resultStack.Pop();
                    var output = Token.Evaluate(val2, val1, currentToken);
                    resultStack.Push(output);
                    continue;
                }

                if (Token.IsFunction(currentToken))
                {
                    var value = resultStack.Pop();
                    var result = Token.Evaluate(value, currentToken);
                    resultStack.Push(result);
                }
            }

            return resultStack.Pop();
        }

        public static double EvaluateInfix(string infixString)
        {

            var resultStack = new Stack<double>();
            try
            {
            var postfixQueue = ShuntingYard.ShuntingYard.GetPostfixQueue(infixString);


            while (postfixQueue.Any())
            {
                var currentToken = postfixQueue.Dequeue();

                if (Token.IsNumber(currentToken))
                {
                    resultStack.Push(double.Parse(currentToken, new System.Globalization.CultureInfo("en-US")));
                    continue;
                }

                if (Token.IsOperator(currentToken))
                {
                    var val1 = resultStack.Pop();
                    var val2 = resultStack.Pop();
                    var output = Token.Evaluate(val2, val1, currentToken);
                    resultStack.Push(output);
                    continue;
                }

                if (Token.IsFunction(currentToken))
                {
                    var value = resultStack.Pop();
                    var result = Token.Evaluate(value, currentToken);
                    resultStack.Push(result);
                    continue;
                }

                if (Token.IsAddedFunction(currentToken))
                {
                    var value = resultStack.Pop();
                    Dictionary<string, string> AddedFunctions = Token.GetAddedFunctions();
                    double result = 0;
                    foreach (var function in AddedFunctions.Keys)
                    {
                        if (currentToken == function)
                        {
                            string infixFunc = AddedFunctions[function];
                            infixFunc = infixFunc.Replace("x", Convert.ToString(value));
                            result = EvaluateInfix(infixFunc);
                        }
                    }
                        resultStack.Push(result);
                }
            }
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return resultStack.Pop();
        }


    }
    }
