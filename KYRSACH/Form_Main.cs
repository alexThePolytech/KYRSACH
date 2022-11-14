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
        //List<string> infixExpression = new List<string>();
        string infixExpression;
        int numOfExpressions = 0;
        int insertPos = 0, infixPos = 0, varSelected = 0;
        bool isEnd = false;

        public Form_Main()
        {
            InitializeComponent();
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
            infixExpression = OpenFromFile();
            //numOfExpressions = infixExpression.Count - 1;

            
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
                    infixExpression = infixExpression.Replace(variable, Convert.ToString(assignedVariables[variable]));
                    label_AssignVariables.Text += unasignedVariables[counter] + "=" + assignedVariables[variable] + "\n";
                    counter++;
                }
            }
            richTextBox_Result.Text = infixExpression[numOfExpressions] + "\n= ";
            richTextBox_Result.Text += Convert.ToString(Evaluator.InfixEvaluator.EvaluateInfix(infixExpression)) + "\n";
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
            if (isEnd)
            {
                richTextBox_Result.Text = String.Empty;
                isEnd = false;
            }
            insertPos = richTextBox_Result.SelectionStart;
            richTextBox_Result.Text = richTextBox_Result.Text.Insert(insertPos, token);

            insertPos += token.Length;
            richTextBox_Result.SelectionStart = insertPos;

            infixExpression = richTextBox_Result.Text;
        }

        private void oneButton_Click(object sender, EventArgs e)
        {
            AppendToInfixExpresion("1");
        }

        private void twoButton_Click(object sender, EventArgs e)
        {
            AppendToInfixExpresion("2");
        }

        private void threeButton_Click(object sender, EventArgs e)
        { 
            AppendToInfixExpresion("3");
        }

        private void fourButton_Click(object sender, EventArgs e)
        {
            AppendToInfixExpresion("4");
        }

        private void fiveButton_Click(object sender, EventArgs e)
        {
            AppendToInfixExpresion("5");
        }

        private void sixButton_Click(object sender, EventArgs e)
        {
            AppendToInfixExpresion("6");
        }

        private void sevenButton_Click(object sender, EventArgs e)
        {
            AppendToInfixExpresion("7");
        }

        private void eigthButton_Click(object sender, EventArgs e)
        {
            AppendToInfixExpresion("8");
        }

        private void nineButton_Click(object sender, EventArgs e)
        {
            AppendToInfixExpresion("9");
        }

        private void zeroButton_Click(object sender, EventArgs e)
        {
             AppendToInfixExpresion("0");
        }

        private void divide_Click(object sender, EventArgs e)
        {
            AppendToInfixExpresion("/");
        }

        private void multiply_Click(object sender, EventArgs e)
        {
            AppendToInfixExpresion("*");
        }

        private void plus_Click(object sender, EventArgs e)
        {
            AppendToInfixExpresion("+");
        }

        private void minus_Click(object sender, EventArgs e)
        {
            AppendToInfixExpresion("-");
        }

        private void result_Click(object sender, EventArgs e)
        {
            try
            {
                var infixExpression = (richTextBox_Result.Text);

                if (infixExpression != String.Empty)
                {
                    infixExpression = infixExpression.Trim();
                    unasignedVariables = ShuntingYard.ShuntingYard.CheckForNovelty(infixExpression);
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
                            infixExpression = infixExpression.Replace(variable, Convert.ToString(assignedVariables[variable]));
                            label_AssignVariables.Text += unasignedVariables[counter] + "=" + assignedVariables[variable] + " ";
                            counter++;
                            
                        }
                    }
                    //infixExpression = ShuntingYard.ShuntingYard.AdjustMonoperations(infixExpression);
                }

                //richTextBox_Result.Text = ShuntingYard.ShuntingYard.InfixToPostfixString(infixExpression[0]) + "\n";
                var result = Evaluator.InfixEvaluator.EvaluateInfix(infixExpression);
                richTextBox_Result.Text += "\n= " + Convert.ToString(result) + "\n";
                numOfExpressions++;
                //insertPos = richTextBox_Result.Text.Length;
                insertPos = 0;
                //insertPos += 4 + Convert.ToString(result).Length;
                assignedVariables.Clear();
                isEnd = true;
            }
            catch (Exception exc)
            {
                string Message = exc.Message;
                MessageBox.Show(Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void button_ln_Click(object sender, EventArgs e)
        {
            AppendToInfixExpresion("ln");
            AppendToInfixExpresion("(");
        }

        private void button_log_Click(object sender, EventArgs e)
        {
            AppendToInfixExpresion("log");
            AppendToInfixExpresion("(");
        }

        private void button_exp_Click(object sender, EventArgs e)
        {
            AppendToInfixExpresion("exp");
            AppendToInfixExpresion("(");
        }

        private void button_sqrt_Click(object sender, EventArgs e)
        {
            AppendToInfixExpresion("sqrt");
            AppendToInfixExpresion("(");
        }

        private void button_ctan_Click(object sender, EventArgs e)
        {
            AppendToInfixExpresion("ctan");
            AppendToInfixExpresion("(");
        }

        private void button_tan_Click(object sender, EventArgs e)
        {
            AppendToInfixExpresion("tan");
            AppendToInfixExpresion("(");
        }

        private void button_cos_Click(object sender, EventArgs e)
        {
            AppendToInfixExpresion("cos");
            AppendToInfixExpresion("(");
        }

        private void button_sin_Click(object sender, EventArgs e)
        {
            AppendToInfixExpresion("sin");
            AppendToInfixExpresion("(");
        }

        private void button_rightParenthesis_Click(object sender, EventArgs e)
        {
            AppendToInfixExpresion(")");
        }

        private void button_leftParenthesis_Click(object sender, EventArgs e)
        {
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
            insertPos++;
            richTextBox_Result.SelectionStart = insertPos;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            insertPos--;
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if(richTextBox_Result.SelectionStart > 0)
            {
            richTextBox_Result.Text = richTextBox_Result.Text.Remove(richTextBox_Result.SelectionStart - 1, 1);
            infixExpression = richTextBox_Result.Text;
            }
        }

        private void button_Clean_Click(object sender, EventArgs e)
        {
            richTextBox_Result.Text = String.Empty;
            infixExpression = String.Empty;
            insertPos = 0;    
        }

        private void button_Pow_Click(object sender, EventArgs e)
        {
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
            insertPos += variable.Length;
            AppendToInfixExpresion(variable);
        }

        private void button_Pi_Click(object sender, EventArgs e)
        {
            AppendToInfixExpresion("pi");
        }

        private void button1_Click(object sender, EventArgs e)
        {
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

        private void richTextBox_Result_TextChanged(object sender, EventArgs e)
        {         
            infixExpression = richTextBox_Result.Text;           
        }

        private void richTextBox_Result_KeyDown(object sender, KeyEventArgs e)
        {
            if (isEnd)
            {
                richTextBox_Result.Text = String.Empty;
                isEnd = false;
            }
        }

        //Left Arrow
        private void button_CleanExpression_Click(object sender, EventArgs e)
        {
            insertPos--;
            richTextBox_Result.SelectionStart = insertPos;
        }

        private void comboBox_addedFunctions_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int index = comboBox_addedFunctions.SelectedIndex;
            AppendToInfixExpresion(Convert.ToString(comboBox_addedFunctions.Items[index]));
            AppendToInfixExpresion("(");
        }
    }
}
