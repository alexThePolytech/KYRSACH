using KYRSACH.Operator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KYRSACH
{
    public partial class FormAddFunction : Form
    {
        Dictionary<string, string> functions = new Dictionary<string, string>();

        public FormAddFunction()
        {
            InitializeComponent();
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            bool correctness = true;
            try
            {
                string inputText = box_Definition.Text.Trim();
            var inputArray = inputText.Split(' ');
            int countOp = 0, countCl = 0;

            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i] == "(")
                    countOp++;
                else if (inputArray[i] == ")")
                    countCl++;
            }
            if (countOp != countCl)
                throw new Exception("Parenthesis Error. Some of the parenthesis doesn't match.");
            foreach(var op in inputArray)
            {
                if(!Token.IsNumber(op) && !Token.IsConstant(op) && !Token.IsFunction(op) &&
                    !Token.IsLeftParenthesis(op) && !Token.IsRightParenthesis(op) &&
                    !Token.IsAddedFunction(op) && !Token.IsOperator(op) && op != "x")
                {
                    throw new Exception("Expression is not correct. Check the spelling.");
                        
                }
                if(op == inputArray.Last() && (!Token.IsNumber(op) && !Token.IsRightParenthesis(op) && op != "x"))
                    {
                        throw new Exception("Expression is not finished.");
                    }
            }
            }
            catch (Exception exp)
            {
                //box_Name.Text = String.Empty;
                //box_Definition.Text = String.Empty;
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                correctness = false;
            }
            if (correctness)
            {
            functions.Add(box_Name.Text, box_Definition.Text);
            this.Close();
            }
        }

        public Dictionary<string, string> GetNewFunction()
        {
            return functions;
        } 
    }
}
