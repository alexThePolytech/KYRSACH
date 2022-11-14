using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KYRSACH
{
    public partial class Form_FillIdentifiers : Form
    {
        string mainList;
        Dictionary<string, double> outMain = new Dictionary<string, double>();
        public Form_FillIdentifiers()
        {
            InitializeComponent();
        }

        public Form_FillIdentifiers(string input)
        {
            InitializeComponent();
            mainList = input;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //Form1 frm = new Form1();
            //List<string> inputList = Form1.CheckFunc();

                label_Variables.Text += mainList;

        }

        private void button_Go_Click(object sender, EventArgs e)
        {
            var output = box_Input.Text.Trim();
            //List<double> outt = new List<double>();
            //foreach (var op in output)
            //{
            //    outMain.Add(mainList[0], Convert.ToDouble(op));
            //}

            for(int i = 0; i < output.Length; i++)
            {
                outMain.Add(mainList, Convert.ToDouble(output, new System.Globalization.CultureInfo("en-US")));
            }

            this.Close();
        }
        
        
        public Dictionary<string, double> getAssigned()
        {
            return outMain;
        }
    }
}
