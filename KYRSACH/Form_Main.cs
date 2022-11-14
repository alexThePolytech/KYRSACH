using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShuntingYard;
using KYRSACH.Evaluator;
using System.Security.Principal;
using KYRSACH.Operator;
using System.Linq.Expressions;
using Mathos.Parser;

namespace KYRSACH
{

    public partial class Form_Main : Form
    {
        public List<string> unasignedVariables;
        public Dictionary<string, double> assignedVariables = new Dictionary<string, double>();
        public Dictionary<string, string> AddedFunctions;
        List<string> infixExpression = new List<string>();
        int numOfExpressions = 0;
        int insertPos = 0, infixPos = 0, varSelected = 0;

        public Form_Main()
        {
            InitializeComponent();
            infixExpression.Add("");
        }

        private void button_Evaluate_Click(object sender, EventArgs e)
        {

        }

        public List<string> CheckFunc()
        {
            return unasignedVariables;
        }

        public void SetVariables(Dictionary<string, double> input)
        {
            assignedVariables = input;
        }

        private void button_AddFormula_Click(object sender, EventArgs e)
        {
            FormAddFunction f = new FormAddFunction();
            f.ShowDialog();
            AddedFunctions = f.GetNewFunction();
            foreach(var op in AddedFunctions.Keys)
            {
                Token.AddFunction(op, AddedFunctions[op]);
            }
            
        }

        private void mainToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        string OpenFromFile()
        {
            OpenFileDialog fText = new OpenFileDialog();
            fText.Filter = "TXT (*.TXT)|*.txt";
            if (fText.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string[] tmp = System.IO.File.ReadAllLines(fText.FileName);
                return tmp[0];
            }
            return null;
        }

        private void evaluateFromTextFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            infixExpression.Add(OpenFromFile());
            numOfExpressions = infixExpression.Count - 1;

            
            //unasignedVariables = ShuntingYard.ShuntingYard.CheckForNovelty(infixExpression[numOfExpressions]);


            if (unasignedVariables.Count != 0)
            {
                //ask user to fill x's and replase them in original string
                MessageBox.Show("You have some unassigned identifiers, you can assign them now", "Identifiers", MessageBoxButtons.OK, MessageBoxIcon.Information);

                foreach (var key in unasignedVariables)
                {

                    Form_FillIdentifiers f = new Form_FillIdentifiers(key);
                    f.ShowDialog();
                    Dictionary<string, double> tmp = f.getAssigned();
                    assignedVariables.Add(key, tmp[key]);
                }
                int counter = 0;
                foreach (string variable in assignedVariables.Keys)
                {
                    infixExpression[numOfExpressions] = infixExpression[numOfExpressions].Replace(variable, Convert.ToString(assignedVariables[variable]));
                    label_AssignVariables.Text += unasignedVariables[counter] + "=" + assignedVariables[variable] + "\n";
                    counter++;
                }
            }
            richTextBox_Result.Text = infixExpression[numOfExpressions] + "\n= ";
            richTextBox_Result.Text += Convert.ToString(Evaluator.InfixEvaluator.EvaluateInfix(infixExpression[numOfExpressions])) + "\n";
            insertPos = richTextBox_Result.TextLength;
            infixPos = 0;
            varSelected = 0;
            numOfExpressions++;
        }

        private void functionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

            FormAddFunction f = new FormAddFunction();
            f.ShowDialog();
            AddedFunctions = f.GetNewFunction();
            foreach(var op in comboBox_addedFunctions.Items)
                {
                    foreach(var kp in AddedFunctions.Keys)
                    {
                        if ((string)op == kp)
                            throw new Exception("The function is alredy present. Try entering new function.");
                    }
                }
            int counter = AddedFunctions.Count;
            int i = 1;
            foreach(var op in AddedFunctions.Keys)
            {
                if (i == counter)
                {
                    Token.AddFunction(op, AddedFunctions[op]);
                    comboBox_addedFunctions.Items.Add(op);
                }
                i++;
            }

            }
            catch(Exception exc)
            {
                string Message = exc.Message;
                MessageBox.Show(Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void AppendToInfixExpresion(string token)
        {
            if(infixExpression.Count - 1 < numOfExpressions)
                infixExpression.Add("");
            if (infixExpression[numOfExpressions] == string.Empty)
            {
                if (Token.IsNumber(token))
                {
                    infixExpression[numOfExpressions] = infixExpression[numOfExpressions].Insert(infixPos, token);
                    infixPos += token.Length;

                }
                else 
                {
                    infixExpression[numOfExpressions] = infixExpression[numOfExpressions].Insert(infixPos, " " + token + " ");
                    infixPos += token.Length + 2;
                    varSelected++;

                }

                
            }
            else if (Token.IsNumber(token))
            {
                var expression = infixExpression[numOfExpressions].Split(' ');
                //if (varSelected != 0)
                if (!Token.IsNumber(expression[varSelected]) && infixPos != 0)   //8 + sqrt( 9 )
                {

                    varSelected++; //!!!!! може важливо, протестити
                }

                infixExpression[numOfExpressions] = infixExpression[numOfExpressions].Insert(infixPos, token);
                infixPos += token.Length;

            }
            else 
            {
                if (infixPos < infixExpression[numOfExpressions].Length - 1)
                {
                    if (infixExpression[numOfExpressions][infixPos - 1] == ' ' &&
                         infixExpression[numOfExpressions][infixPos + 1] == ' ' &&
                         infixExpression[numOfExpressions][infixPos] == ' ')
                    {
                        infixExpression[numOfExpressions] = infixExpression[numOfExpressions].Insert(infixPos, token);
                        infixPos += token.Length;
                        varSelected++;
                        
                    }
                    else if (infixExpression[numOfExpressions][infixPos - 1] == ' ')
                    {
                        infixExpression[numOfExpressions] = infixExpression[numOfExpressions].Insert(infixPos, token + " ");
                        infixPos += token.Length + 1;
                        varSelected++;
                    }
                    else if (infixExpression[numOfExpressions][infixPos - 1] != ' ' && infixExpression[numOfExpressions][infixPos] == ' ')
                    {
                        infixExpression[numOfExpressions] = infixExpression[numOfExpressions].Insert(infixPos, " " + token);
                        infixPos += token.Length + 1;
                        varSelected++;
                    }
                    else
                    {
                        infixExpression[numOfExpressions] = infixExpression[numOfExpressions].Insert(infixPos, " " + token + " ");
                        infixPos += token.Length + 2;
                        varSelected++;
                    }

                }
                else
                {
                    if (infixExpression[numOfExpressions][infixPos - 1] == ' ')
                    {
                        infixExpression[numOfExpressions] = infixExpression[numOfExpressions].Insert(infixPos, token + " ");
                        infixPos += token.Length + 1;
                        varSelected++;
                    }
                    else
                    {
                        infixExpression[numOfExpressions] = infixExpression[numOfExpressions].Insert(infixPos, " " + token + " ");
                        infixPos += token.Length + 2;
                        varSelected++;
                    }
                }
                
            }
        }

        private void oneButton_Click(object sender, EventArgs e)
        {
            richTextBox_Result.Text = richTextBox_Result.Text.Insert(insertPos, "1");
            insertPos++;
            AppendToInfixExpresion("1");
        }

        private void twoButton_Click(object sender, EventArgs e)
        {
            richTextBox_Result.Text = richTextBox_Result.Text.Insert(insertPos, "2");
            insertPos++;
            AppendToInfixExpresion("2");
        }

        private void threeButton_Click(object sender, EventArgs e)
        {
            richTextBox_Result.Text = richTextBox_Result.Text.Insert(insertPos, "3");
            insertPos++;
            AppendToInfixExpresion("3");
        }

        private void fourButton_Click(object sender, EventArgs e)
        {
            richTextBox_Result.Text = richTextBox_Result.Text.Insert(insertPos, "4");
            insertPos++;
            AppendToInfixExpresion("4");
        }

        private void fiveButton_Click(object sender, EventArgs e)
        {

            richTextBox_Result.Text = richTextBox_Result.Text.Insert(insertPos, "5");
            insertPos++;
            AppendToInfixExpresion("5");

        }

        private void sixButton_Click(object sender, EventArgs e)
        {
            richTextBox_Result.Text = richTextBox_Result.Text.Insert(insertPos, "6");
            insertPos++;
            AppendToInfixExpresion("6");
        }

        private void sevenButton_Click(object sender, EventArgs e)
        {
            richTextBox_Result.Text = richTextBox_Result.Text.Insert(insertPos, "7");
            insertPos++;
            AppendToInfixExpresion("7");
        }

        private void eigthButton_Click(object sender, EventArgs e)
        {
            richTextBox_Result.Text = richTextBox_Result.Text.Insert(insertPos, "8");
            insertPos++;
            AppendToInfixExpresion("8");
        }

        private void nineButton_Click(object sender, EventArgs e)
        {
            richTextBox_Result.Text = richTextBox_Result.Text.Insert(insertPos, "9");
            insertPos++;
            AppendToInfixExpresion("9");
        }

        private void zeroButton_Click(object sender, EventArgs e)
        {
            richTextBox_Result.Text = richTextBox_Result.Text.Insert(insertPos, "0");
            insertPos++;
            AppendToInfixExpresion("0");
        }

        private void divide_Click(object sender, EventArgs e)
        {
            richTextBox_Result.Text = richTextBox_Result.Text.Insert(insertPos, "/");
            insertPos++;
            AppendToInfixExpresion("/");
        }

        private void multiply_Click(object sender, EventArgs e)
        {
            richTextBox_Result.Text = richTextBox_Result.Text.Insert(insertPos, "*");
            insertPos++;
            AppendToInfixExpresion("*");
        }

        private void plus_Click(object sender, EventArgs e)
        {
            richTextBox_Result.Text = richTextBox_Result.Text.Insert(insertPos, "+");
            insertPos++;
            AppendToInfixExpresion("+");
        }

        private void minus_Click(object sender, EventArgs e)
        {
            richTextBox_Result.Text = richTextBox_Result.Text.Insert(insertPos, "-");
            insertPos++;
            AppendToInfixExpresion("-");
        }

        private void button_percent_Click(object sender, EventArgs e)
        {
            richTextBox_Result.Text = richTextBox_Result.Text.Insert(insertPos, "%");
            insertPos++;
            AppendToInfixExpresion("%");
        }

        private void result_Click(object sender, EventArgs e)
        {
            try
            {
                var infixExpression1 = (richTextBox_Result.Text);

                if (infixExpression1 != String.Empty)
                {
                    infixExpression1 = infixExpression1.Trim();
                    unasignedVariables = ShuntingYard.ShuntingYard.CheckForNovelty(infixExpression1);
                    if (unasignedVariables.Count != 0)
                    {
                        //ask user to fill x's and replase them in original string
                        MessageBox.Show("You have some unassigned identifiers, you can assign them now", "Identifiers", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        foreach(var key in unasignedVariables)
                        {

                            Form_FillIdentifiers f = new Form_FillIdentifiers(key);
                            f.ShowDialog();
                            Dictionary<string, double> tmp = f.getAssigned();
                            assignedVariables.Add(key, tmp[key]);
                        }
                        int counter = 0;
                        foreach (string variable in assignedVariables.Keys)
                        {
                            infixExpression1 = infixExpression1.Replace(variable, Convert.ToString(assignedVariables[variable]));
                            label_AssignVariables.Text += unasignedVariables[counter] + "=" + assignedVariables[variable] + " ";
                            counter++;
                        }
                    }
                    //infixExpression1 = ShuntingYard.ShuntingYard.AdjustMonoperations(infixExpression1);
                }

            //richTextBox_Result.Text = ShuntingYard.ShuntingYard.InfixToPostfixString(infixExpression1[0]) + "\n";
            var result = Evaluator.InfixEvaluator.EvaluateInfix(infixExpression1);
            richTextBox_Result.Text += "\n= " + Convert.ToString(result) + "\n";
            numOfExpressions++;
            insertPos = richTextBox_Result.Text.Length;
            //insertPos += 4 + Convert.ToString(result).Length;
            infixPos = 0;
            varSelected = 0;
                assignedVariables.Clear();
            }
            catch (Exception exc)
            {
                string Message = exc.Message;
                MessageBox.Show(Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void button_ln_Click(object sender, EventArgs e)
        {
            richTextBox_Result.Text = richTextBox_Result.Text.Insert(insertPos, "ln(");
            AppendToInfixExpresion("ln");
            insertPos += 3;
            AppendToInfixExpresion("(");
        }

        private void button_log_Click(object sender, EventArgs e)
        {
            richTextBox_Result.Text = richTextBox_Result.Text.Insert(insertPos, "log(");
            insertPos += 4;
            AppendToInfixExpresion("log");
            AppendToInfixExpresion("(");
        }

        private void button_exp_Click(object sender, EventArgs e)
        {
            richTextBox_Result.Text = richTextBox_Result.Text.Insert(insertPos, "exp(");
            insertPos += 4;
            AppendToInfixExpresion("exp");
            AppendToInfixExpresion("(");
        }

        private void button_sqrt_Click(object sender, EventArgs e)
        {
            richTextBox_Result.Text = richTextBox_Result.Text.Insert(insertPos, "sqrt(");
            insertPos += 5;
            AppendToInfixExpresion("sqrt");
            AppendToInfixExpresion("(");
        }

        private void button_ctan_Click(object sender, EventArgs e)
        {
            richTextBox_Result.Text = richTextBox_Result.Text.Insert(insertPos, "ctan(");
            insertPos += 5;
            AppendToInfixExpresion("ctan");
            AppendToInfixExpresion("(");
        }

        private void button_tan_Click(object sender, EventArgs e)
        {
            richTextBox_Result.Text = richTextBox_Result.Text.Insert(insertPos, "tan(");
            insertPos += 4;
            AppendToInfixExpresion("tan");
            AppendToInfixExpresion("(");
        }

        private void button_cos_Click(object sender, EventArgs e)
        {
            richTextBox_Result.Text = richTextBox_Result.Text.Insert(insertPos, "cos(");
            insertPos += 4;
            AppendToInfixExpresion("cos");
            AppendToInfixExpresion("(");
        }

        private void button_sin_Click(object sender, EventArgs e)
        {
            richTextBox_Result.Text = richTextBox_Result.Text.Insert(insertPos, "sin(");
            insertPos += 4;
            AppendToInfixExpresion("sin");
            AppendToInfixExpresion("(");
        }

        private void button_rightParenthesis_Click(object sender, EventArgs e)
        {
            richTextBox_Result.Text = richTextBox_Result.Text.Insert(insertPos, ")");
            insertPos += 1;
            AppendToInfixExpresion(")");
            //infixExpression[numOfExpressions] = infixExpression[numOfExpressions].Trim();
        }

        private void button_leftParenthesis_Click(object sender, EventArgs e)
        {
            richTextBox_Result.Text = richTextBox_Result.Text.Insert(insertPos, "(");
            insertPos += 1;
            AppendToInfixExpresion("(");
        }

        private void Form1_MouseHover(object sender, EventArgs e)
        {
            richTextBox_Result.Focus();
            richTextBox_Result.SelectionStart = insertPos;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int iinndexx = richTextBox_Result.SelectionStart;
        }

        private void button_right_Click(object sender, EventArgs e)
        {
            if (!(infixExpression.Count - 1 < numOfExpressions))
            {
                if (infixExpression[numOfExpressions] != String.Empty && infixExpression[numOfExpressions][0] != ' ')
                {
                    if (infixExpression[numOfExpressions][infixExpression[numOfExpressions].Length - 1] != ' ')
                    {
                        infixExpression[numOfExpressions] += ' ';
                    }
                    var expression = infixExpression[numOfExpressions].Split(' ');
                    if (varSelected < expression.Count() - 1 || varSelected < expression.Count())
                    {
                        int cursor = richTextBox_Result.SelectionStart;
                        if (infixPos < infixExpression[numOfExpressions].Length - 1)
                        {

                            string token = expression[varSelected];
                            if (Token.IsNumber(token) && Token.IsNumber(Convert.ToString(infixExpression[numOfExpressions][infixPos + 1]))/*infixExpression[numOfExpressions][infixPos + 1] != ' '*/)
                            {
                                //infixPos += expression[varSelected + 1].Length + 1;
                                infixPos++;
                                insertPos++;
                                //varSelected++;
                            }
                            else if (Token.IsNumber(token) && infixExpression[numOfExpressions][infixPos + 1] == ' ') //2 + 3 - 8
                            {
                                //infixPos -= 1;
                                infixPos += 1;
                                //varSelected += 1;
                                insertPos++;
                            }
                            //infixPos -= token.Length;                                     //9 + ( 11 * 6 )
                            else if (infixExpression[numOfExpressions][infixPos + 2] == ' ') //( 1 + 6 ) * 8
                            {                                                               //1 + sqrt ( 9 )
                                token = expression[varSelected + 1];
                                infixPos += (token.Length + 2);
                                if (varSelected < expression.Count() - 1 || varSelected < expression.Count())
                                    varSelected += 2;
                                insertPos += token.Length;
                            }
                            else /*(infixExpression[numOfExpressions][infixPos + 3] == ' ')*/
                            {
                                infixPos += (token.Length + 1);
                                if (varSelected < expression.Count() - 1 || varSelected < expression.Count())
                                    varSelected++;
                                insertPos += token.Length;
                            }

                        }
                        richTextBox_Result.SelectionStart = insertPos;
                    }
                    else if (infixExpression.Count > numOfExpressions && infixPos < infixExpression[numOfExpressions].Length)
                    {

                        string tok = expression[varSelected];
                        richTextBox_Result.SelectionStart += tok.Length;
                        insertPos += tok.Length;
                        infixPos += tok.Length;
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (!(infixExpression.Count - 1 < numOfExpressions))
            {
            var expression = infixExpression[numOfExpressions].Split(' ');
            string token = expression[varSelected];
                if (infixExpression[numOfExpressions] != String.Empty && infixPos >= token.Length + 2)
                {



                    if (infixExpression[numOfExpressions][infixPos - 2] == '(')    //1 + sqrt ( 9 )
                    {
                        infixExpression[numOfExpressions] = infixExpression[numOfExpressions].Remove(infixPos - 3, 2);
                        infixPos -= 2;
                        insertPos--;
                        richTextBox_Result.Text = richTextBox_Result.Text.Remove(insertPos, 1);
                        if (varSelected > 0)
                            varSelected--;
                    }
                    else if (infixExpression[numOfExpressions][infixPos - 1] == '(')
                    {
                        infixExpression[numOfExpressions] = infixExpression[numOfExpressions].Remove(infixPos - 2, 2);
                        infixPos -= 2;
                        insertPos--;
                        if (varSelected > 0)
                            varSelected--;
                        richTextBox_Result.Text = richTextBox_Result.Text.Remove(insertPos, 1);
                    }
                    else if (infixExpression[numOfExpressions][infixPos - 2] == ')')
                    {
                        infixExpression[numOfExpressions] = infixExpression[numOfExpressions].Remove(infixPos - 3, 2);
                        infixPos -= 2;
                        insertPos--;
                        if (varSelected > 0)
                            varSelected--;
                        richTextBox_Result.Text = richTextBox_Result.Text.Remove(insertPos, 1);
                    }
                    else if (infixExpression[numOfExpressions][infixPos - 1] == ')')
                    {
                        infixExpression[numOfExpressions] = infixExpression[numOfExpressions].Remove(infixPos - 2, 2);
                        infixPos -= 2;
                        insertPos--;
                        if (varSelected > 0)
                            varSelected--;
                        richTextBox_Result.Text = richTextBox_Result.Text.Remove(insertPos, 1);
                    }
                    else if (Token.IsNumber(token) && infixPos <= infixExpression[numOfExpressions].Length - 1 &&Token.IsNumber(Convert.ToString(infixExpression[numOfExpressions][infixPos])) && infixExpression[numOfExpressions][infixPos-1] != ' ')
                    {
                        infixExpression[numOfExpressions] = infixExpression[numOfExpressions].Remove(infixPos - 1, 1);
                        infixPos--;
                        insertPos--;
                        richTextBox_Result.Text = richTextBox_Result.Text.Remove(insertPos, 1);
                    }
                    //else if(Token.IsNumber(token) && Token.IsNumber(Convert.ToString(infixExpression[numOfExpressions][infixPos])) && infixExpression[numOfExpressions][infixPos - 1] == ' ')
                    else if (Token.IsNumber(token) /*&& Token.IsNumber(Convert.ToString(infixExpression[numOfExpressions][infixPos]))*/ && infixExpression[numOfExpressions][infixPos - 1] == ' ')
                    {
                        string token2 = expression[varSelected - 1];
                        infixExpression[numOfExpressions] = infixExpression[numOfExpressions].Remove(infixPos - 2 - token2.Length, token.Length + 2);
                        infixPos -= token2.Length - 2;
                        insertPos--;
                        if (varSelected > 1)
                            varSelected -= 2;
                        else if (varSelected > 0)
                            varSelected--;
                        richTextBox_Result.Text = richTextBox_Result.Text.Remove(insertPos, 1);
                    }

                    else if (Token.IsNumber(expression[varSelected - 1]))
                    {                                                                                //2 ^ 
                        infixExpression[numOfExpressions] = infixExpression[numOfExpressions].Remove(infixPos - 1 - token.Length, token.Length + 1);
                        infixPos -= token.Length + 2;
                        insertPos -= token.Length;
                        if (varSelected > 0)
                            varSelected--;
                        richTextBox_Result.Text = richTextBox_Result.Text.Remove(insertPos, token.Length);
                    }
                    else
                    {
                        infixExpression[numOfExpressions] = infixExpression[numOfExpressions].Remove(infixPos - 1 - token.Length, token.Length + 1);
                        infixPos -= token.Length + 1;
                        insertPos -= token.Length;
                        if (varSelected > 0)
                            varSelected--;
                        richTextBox_Result.Text = richTextBox_Result.Text.Remove(insertPos, token.Length);
                    }
                }
                else if(infixExpression[numOfExpressions] != String.Empty && infixPos >= token.Length)
                {
                    //var expression = infixExpression[numOfExpressions].Split(' ');
                    //string token = expression[varSelected];

                    if (infixExpression[numOfExpressions][infixPos - 1] == '(')
                    {
                        infixExpression[numOfExpressions] = infixExpression[numOfExpressions].Remove(infixPos - 2, 2);
                        infixPos -= 2;
                        insertPos--;
                        if (varSelected > 0)
                            varSelected--;
                        richTextBox_Result.Text = richTextBox_Result.Text.Remove(insertPos, 1);
                    }

                    else if (infixExpression[numOfExpressions][infixPos - 1] == ')')
                    {
                        infixExpression[numOfExpressions] = infixExpression[numOfExpressions].Remove(infixPos - 2, 2);
                        infixPos -= 2;
                        insertPos--;
                        if (varSelected > 0)
                            varSelected--;
                        richTextBox_Result.Text = richTextBox_Result.Text.Remove(insertPos, 1);
                    }
                    else if (Token.IsNumber(token) && infixExpression[numOfExpressions][infixPos - 1] != ' ')
                    {
                        infixExpression[numOfExpressions] = infixExpression[numOfExpressions].Remove(infixPos - 1, 1);
                        infixPos--;
                        insertPos--;
                        richTextBox_Result.Text = richTextBox_Result.Text.Remove(insertPos, 1);
                    }
                    else if (Token.IsNumber(token) && infixExpression[numOfExpressions][infixPos - 1] == ' ')
                    {
                        string token2 = expression[varSelected - 1];
                        infixExpression[numOfExpressions] = infixExpression[numOfExpressions].Remove(infixPos - 2 - token2.Length, token.Length + 2);
                        infixPos -= token2.Length - 2;
                        insertPos--;
                        if (varSelected > 1)
                            varSelected -= 2;
                        else if (varSelected > 0)
                            varSelected--;
                        richTextBox_Result.Text = richTextBox_Result.Text.Remove(insertPos, 1);
                    }

                    else if (infixPos >= token.Length + 1)
                    {                                                                                //2 ^ 
                        infixExpression[numOfExpressions] = infixExpression[numOfExpressions].Remove(infixPos - 1 - token.Length, token.Length + 1);
                        infixPos -= token.Length + 1;
                        insertPos -= token.Length;
                        if (varSelected > 0)
                            varSelected--;
                        richTextBox_Result.Text = richTextBox_Result.Text.Remove(insertPos, token.Length);
                    }
                    else
                    {
                        infixExpression[numOfExpressions] = infixExpression[numOfExpressions].Remove(infixPos - token.Length, token.Length + 1);
                        infixPos -= token.Length + 1;
                        insertPos -= token.Length;
                        if (varSelected > 0)
                            varSelected--;
                        richTextBox_Result.Text = richTextBox_Result.Text.Remove(insertPos, token.Length);

                    }
                }
            }
        }

        private void button_Clean_Click(object sender, EventArgs e)
        {
            if (!(infixExpression.Count - 1 < numOfExpressions) && infixExpression[numOfExpressions] != String.Empty)
            {
                var expressions = infixExpression[numOfExpressions].Split(' ');
                foreach(var op in expressions)
                {
                    insertPos -= op.Length;
                }
            //insertPos -= expressions.Count();
            richTextBox_Result.Text = richTextBox_Result.Text.Remove(insertPos);
            infixExpression[numOfExpressions] = String.Empty;
            infixPos = 0;
            varSelected = 0;
            }
        }

        private void button_Pow_Click(object sender, EventArgs e)
        {
            richTextBox_Result.Text = richTextBox_Result.Text.Insert(insertPos, "^(");
            insertPos += 2;
            AppendToInfixExpresion("^");
            AppendToInfixExpresion("(");
        }

        private void button_Variables_Click(object sender, EventArgs e)
        {
            if (panel_Identifiers.Visible == false)
                panel_Identifiers.Visible = true;
            else
                panel_Identifiers.Visible = false;
        }

        private void button_AddVariable_Click(object sender, EventArgs e)
        {
            string variable = box_Variable.Text;
            richTextBox_Result.Text = richTextBox_Result.Text.Insert(insertPos, variable);
            insertPos += variable.Length;
            AppendToInfixExpresion(variable);
        }

        private void button_Pi_Click(object sender, EventArgs e)
        {
            richTextBox_Result.Text = richTextBox_Result.Text.Insert(insertPos, "pi");
            insertPos += 2;
            AppendToInfixExpresion("pi");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox_Result.Text = richTextBox_Result.Text.Insert(insertPos, "e");
            insertPos += 1;
            AppendToInfixExpresion("e");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpForm f = new HelpForm();
            f.ShowDialog();
        }

        private void button_AddFormula_Click_1(object sender, EventArgs e)
        {
            //Exception tp = new Exception()
        }

        private void button_Dot_Click(object sender, EventArgs e)
        {
            richTextBox_Result.Text = richTextBox_Result.Text.Insert(insertPos, ".");
            insertPos++;
            AppendToInfixExpresion(".");
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            label_AssignVariables.Text = String.Empty;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //var parser = new MathParser();
            //double result = parser.Parse("sin(10)");
            //richTextBox_Result.Text = Convert.ToString(result);

            var result = Tokenizer.Tokenizer.Tokenize("23.1+11");
            //richTextBox_Result.Text = Convert.ToString(result);
        }

        //Left Arrow
        private void button_CleanExpression_Click(object sender, EventArgs e)
        {   
            if(varSelected > 0)
            {


                int cursor = richTextBox_Result.SelectionStart;
                var expression = infixExpression[numOfExpressions].Trim().Split(' ');
                string token = expression[varSelected];
                if(infixPos >= 3)
                {


                    if (Token.IsNumber(token) && infixExpression[numOfExpressions][infixPos - 1] != ' ')
                    {
                        infixPos -= 1;
                        insertPos--;
                    }

                    else if (Token.IsNumber(token) && infixExpression[numOfExpressions][infixPos - 1] == ' ' &&//8 + 8 "
                        !Token.IsNumber(Convert.ToString(infixExpression[numOfExpressions][infixPos - 2])))
                    {
                        //infixPos -= 1;
                        infixPos -= expression[varSelected - 1].Length + 2;
                        if (varSelected > 1)
                            varSelected -= 2;
                        else if (varSelected > 0)
                            varSelected--;
                        insertPos--;
                    }

                    else if (infixExpression[numOfExpressions][infixPos - 3] == ' ')//1 + sqrt ( 9 ) 
                    {
                        infixPos -= (token.Length + 2);
                        if (varSelected > 0)
                            varSelected--;
                        insertPos -= token.Length;
                    }
                    else
                    {
                        infixPos -= (token.Length + 1);
                        if (varSelected > 0)
                            varSelected--;
                        insertPos -= token.Length;
                    }
                }
                else if(infixPos > 0)
                {


                    if (Token.IsNumber(token) && infixExpression[numOfExpressions][infixPos - 1] != ' ')
                    {
                        infixPos -= 1;
                        insertPos--;
                    }
                    else if (Token.IsNumber(token) && infixExpression[numOfExpressions][infixPos - 1] == ' ')
                    {
                        //infixPos -= 1;
                        infixPos -= expression[varSelected - 1].Length + 1;
                        if (varSelected > 1)
                            varSelected -= 2;
                        else if (varSelected > 0)
                            varSelected--;
                        insertPos--;
                    }
                    else
                    {
                        infixPos -= (token.Length + 1);
                        if (varSelected > 0)
                            varSelected--;
                        insertPos -= token.Length;
                    }
                
                }
                richTextBox_Result.SelectionStart = insertPos;


            }
            else if(infixExpression.Count > numOfExpressions && infixPos > 0)
            {

                var expression = infixExpression[numOfExpressions].Split(' ');
                string token = expression[varSelected];
                if (Token.IsNumber(token))
                {                   
                    insertPos--;
                    infixPos--;
                }
                else
                {
                richTextBox_Result.SelectionStart -= token.Length;
                insertPos -= token.Length;
                infixPos -= token.Length;
                }
            }
            richTextBox_Result.SelectionStart = insertPos;
        }

        private void comboBox_addedFunctions_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int index = comboBox_addedFunctions.SelectedIndex;
            richTextBox_Result.Text += Convert.ToString(comboBox_addedFunctions.Items[index]) + "(";
            insertPos += Convert.ToString(comboBox_addedFunctions.Items[index]).Length;
            insertPos++;
            AppendToInfixExpresion(Convert.ToString(comboBox_addedFunctions.Items[index]));
            AppendToInfixExpresion("(");
        }
    }
}
