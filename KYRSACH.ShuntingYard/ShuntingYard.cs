using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KYRSACH.Operator;
using Tokenizer;

namespace ShuntingYard
{
    public static class ShuntingYard
    {
        public static Queue<string> GetPostfixQueue(string input)
        {
            var outputQueue = new Queue<string>();
            var operandStack = new Stack<string>();
            //var inputArray = input.Split(' ');
            var inputArray = Tokenizer.Tokenizer.Tokenize(input);
            inputArray = AdjustMonoperations(inputArray);
            int countOp = 0, countCl = 0;

            for(int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i] == "(")
                    countOp++;
                else if (inputArray[i] == ")")
                    countCl++;
            }
            if (countOp != countCl)
                throw new Exception("Parenthesis Error. Some of the parenthesis doesn't match");

            foreach (var token in inputArray)
            {
                if (Token.IsNumber(token))
                {
                    outputQueue.Enqueue(token);
                    continue;
                }

                if (Token.IsConstant(token))
                {
                    outputQueue.Enqueue(Token.ReplaceConstant(token));
                    continue;
                }

                if (Token.IsLeftParenthesis(token) || Token.IsFunction(token))
                {
                    operandStack.Push(token);
                    continue;
                }

                if (Token.IsRightParenthesis(token))
                {
                    while (!Token.IsLeftParenthesis(operandStack.Peek()))
                    {
                        outputQueue.Enqueue(operandStack.Pop());
                    }

                    operandStack.Pop();
                    continue;
                }

                while (operandStack.Any() && Token.IsGreaterPrecedence(operandStack.Peek(), token)
                                          && Token.IsLeftAssociated(token))
                {
                    outputQueue.Enqueue(operandStack.Pop());
                }

                operandStack.Push(token);
            }

            while (operandStack.Count > 0)
                outputQueue.Enqueue(operandStack.Pop());

            return outputQueue;
        }

        public static string InfixToPostfixString(string infixString)
        {
            var queue = GetPostfixQueue(infixString);
            var builder = new StringBuilder();

            while (queue.Any())
                builder.Append(queue.Dequeue() + " ");

            return builder.ToString();
        }

        public static  List<string> CheckForNovelty(string input)
        {
            var inputArray = Tokenizer.Tokenizer.Tokenize(input);
            //string[] result = new string[inputArray.Length];
            //System.Array result = gcnew System.Array;
            List<string> result = new List<string>();
            foreach (var op in inputArray)
            {
                if(!Token.IsNumber(op) && !Token.IsConstant(op) && 
                   !Token.IsFunction(op) && !Token.IsOperator(op) &&
                   !result.Contains(op) && !Token.IsAddedFunction(op) &&
                   !Token.IsLeftParenthesis(op) && !Token.IsRightParenthesis(op) &&
                   op != " ")
                {  
                    result.Add(op);
                }
            }


            return result;
        }

        public static string[] AdjustMonoperations(string[] input)
        {
            List<string> tmp = new List<string>(input);
            int counter = 0;
            foreach(var op in tmp)
            {
                if(counter == 0)
                {
                if (op == "-" && Token.IsNumber(tmp[counter + 1]))
                    {
                        tmp[counter + 1] = "-" + tmp[counter + 1];
                        tmp.RemoveAt(counter);
                    }
                }
                else if(counter <tmp.Count-1)
                {
                    if (op == "-" && Token.IsNumber(tmp[counter + 1]) && !Token.IsNumber(tmp[counter - 1]))
                    {
                        tmp[counter + 1] = "-" + tmp[counter + 1];
                        tmp.RemoveAt(counter);
                    }
                }
                counter++;
            }
        input = tmp.ToArray();
            //var inputArray = input.Split(' ');
            //int counter = 0;
            //for (int i = 0; i < inputArray.Length; i++)
            //{
            //    if (inputArray[i] == "-" && i > 0 && !Token.IsNumber(inputArray[i-1]) &&
            //        Token.IsNumber(inputArray[i+1]))
            //    {
                    
            //        return input.Remove(counter + 1, 1);
            //    }   //2 ^ ( - 2 )
            //    else if(inputArray[i] == "-" && Token.IsNumber(inputArray[i + 1]))
            //    {
                    
            //        return input.Remove(counter + 1, 1);
            //    }
            //    counter += 1 + inputArray[i].Length;
            //}
            return input;
        }
    }
}
