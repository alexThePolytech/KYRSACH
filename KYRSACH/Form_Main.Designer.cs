namespace KYRSACH
{
    partial class Form_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.richTextBox_Result = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.evaluateFromTextFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.functionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.howToUseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_Clean = new System.Windows.Forms.Button();
            this.result = new System.Windows.Forms.Button();
            this.divide = new System.Windows.Forms.Button();
            this.multiply = new System.Windows.Forms.Button();
            this.plus = new System.Windows.Forms.Button();
            this.minus = new System.Windows.Forms.Button();
            this.sevenButton = new System.Windows.Forms.Button();
            this.eigthButton = new System.Windows.Forms.Button();
            this.nineButton = new System.Windows.Forms.Button();
            this.fourButton = new System.Windows.Forms.Button();
            this.fiveButton = new System.Windows.Forms.Button();
            this.sixButton = new System.Windows.Forms.Button();
            this.oneButton = new System.Windows.Forms.Button();
            this.twoButton = new System.Windows.Forms.Button();
            this.threeButton = new System.Windows.Forms.Button();
            this.zeroButton = new System.Windows.Forms.Button();
            this.button_LeftArrow = new System.Windows.Forms.Button();
            this.button_sin = new System.Windows.Forms.Button();
            this.button_cos = new System.Windows.Forms.Button();
            this.button_tan = new System.Windows.Forms.Button();
            this.button_ctan = new System.Windows.Forms.Button();
            this.button_exp = new System.Windows.Forms.Button();
            this.button_sqrt = new System.Windows.Forms.Button();
            this.button_ln = new System.Windows.Forms.Button();
            this.button_log = new System.Windows.Forms.Button();
            this.button_leftParenthesis = new System.Windows.Forms.Button();
            this.button_rightParenthesis = new System.Windows.Forms.Button();
            this.comboBox_addedFunctions = new System.Windows.Forms.ComboBox();
            this.panel_Identifiers = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button_Pi = new System.Windows.Forms.Button();
            this.button_AddVariable = new System.Windows.Forms.Button();
            this.box_Variable = new System.Windows.Forms.TextBox();
            this.button_Pow = new System.Windows.Forms.Button();
            this.button_right = new System.Windows.Forms.Button();
            this.button_Delete = new System.Windows.Forms.Button();
            this.button_Variables = new System.Windows.Forms.Button();
            this.button_Dot = new System.Windows.Forms.Button();
            this.label_AssignVariables = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel_Identifiers.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox_Result
            // 
            this.richTextBox_Result.Font = new System.Drawing.Font("Arial Narrow", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_Result.Location = new System.Drawing.Point(0, 36);
            this.richTextBox_Result.Name = "richTextBox_Result";
            this.richTextBox_Result.Size = new System.Drawing.Size(354, 103);
            this.richTextBox_Result.TabIndex = 0;
            this.richTextBox_Result.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainToolStripMenuItem,
            this.addToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(354, 36);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mainToolStripMenuItem
            // 
            this.mainToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.evaluateFromTextFileToolStripMenuItem});
            this.mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            this.mainToolStripMenuItem.Size = new System.Drawing.Size(54, 30);
            this.mainToolStripMenuItem.Text = "File";
            // 
            // evaluateFromTextFileToolStripMenuItem
            // 
            this.evaluateFromTextFileToolStripMenuItem.Name = "evaluateFromTextFileToolStripMenuItem";
            this.evaluateFromTextFileToolStripMenuItem.Size = new System.Drawing.Size(285, 34);
            this.evaluateFromTextFileToolStripMenuItem.Text = "Evaluate from text file";
            this.evaluateFromTextFileToolStripMenuItem.Click += new System.EventHandler(this.evaluateFromTextFileToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.functionToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(62, 30);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // functionToolStripMenuItem
            // 
            this.functionToolStripMenuItem.Name = "functionToolStripMenuItem";
            this.functionToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.functionToolStripMenuItem.Text = "Function";
            this.functionToolStripMenuItem.Click += new System.EventHandler(this.functionToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.howToUseToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 30);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(205, 34);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // howToUseToolStripMenuItem
            // 
            this.howToUseToolStripMenuItem.Name = "howToUseToolStripMenuItem";
            this.howToUseToolStripMenuItem.Size = new System.Drawing.Size(205, 34);
            this.howToUseToolStripMenuItem.Text = "How to use";
            // 
            // button_Clean
            // 
            this.button_Clean.Location = new System.Drawing.Point(261, 339);
            this.button_Clean.Name = "button_Clean";
            this.button_Clean.Size = new System.Drawing.Size(49, 35);
            this.button_Clean.TabIndex = 37;
            this.button_Clean.Text = "C";
            this.button_Clean.UseVisualStyleBackColor = true;
            this.button_Clean.Click += new System.EventHandler(this.button_Clean_Click);
            // 
            // result
            // 
            this.result.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.result.Location = new System.Drawing.Point(317, 276);
            this.result.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(35, 98);
            this.result.TabIndex = 36;
            this.result.Text = "&=";
            this.result.UseVisualStyleBackColor = true;
            this.result.Click += new System.EventHandler(this.result_Click);
            // 
            // divide
            // 
            this.divide.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.divide.Location = new System.Drawing.Point(245, 205);
            this.divide.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.divide.Name = "divide";
            this.divide.Size = new System.Drawing.Size(35, 35);
            this.divide.TabIndex = 35;
            this.divide.Text = "&/";
            this.divide.UseVisualStyleBackColor = true;
            this.divide.Click += new System.EventHandler(this.divide_Click);
            // 
            // multiply
            // 
            this.multiply.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.multiply.Location = new System.Drawing.Point(281, 205);
            this.multiply.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.multiply.Name = "multiply";
            this.multiply.Size = new System.Drawing.Size(35, 35);
            this.multiply.TabIndex = 34;
            this.multiply.Text = "&*";
            this.multiply.UseVisualStyleBackColor = true;
            this.multiply.Click += new System.EventHandler(this.multiply_Click);
            // 
            // plus
            // 
            this.plus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.plus.Location = new System.Drawing.Point(317, 205);
            this.plus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.plus.Name = "plus";
            this.plus.Size = new System.Drawing.Size(35, 35);
            this.plus.TabIndex = 33;
            this.plus.Text = "&+";
            this.plus.UseVisualStyleBackColor = true;
            this.plus.Click += new System.EventHandler(this.plus_Click);
            // 
            // minus
            // 
            this.minus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.minus.Location = new System.Drawing.Point(317, 241);
            this.minus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.minus.Name = "minus";
            this.minus.Size = new System.Drawing.Size(35, 35);
            this.minus.TabIndex = 32;
            this.minus.Text = "&-";
            this.minus.UseVisualStyleBackColor = true;
            this.minus.Click += new System.EventHandler(this.minus_Click);
            // 
            // sevenButton
            // 
            this.sevenButton.Location = new System.Drawing.Point(132, 244);
            this.sevenButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sevenButton.Name = "sevenButton";
            this.sevenButton.Size = new System.Drawing.Size(61, 32);
            this.sevenButton.TabIndex = 31;
            this.sevenButton.Text = "&7";
            this.sevenButton.UseVisualStyleBackColor = true;
            this.sevenButton.Click += new System.EventHandler(this.sevenButton_Click);
            // 
            // eigthButton
            // 
            this.eigthButton.Location = new System.Drawing.Point(194, 243);
            this.eigthButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.eigthButton.Name = "eigthButton";
            this.eigthButton.Size = new System.Drawing.Size(61, 32);
            this.eigthButton.TabIndex = 30;
            this.eigthButton.Text = "&8";
            this.eigthButton.UseVisualStyleBackColor = true;
            this.eigthButton.Click += new System.EventHandler(this.eigthButton_Click);
            // 
            // nineButton
            // 
            this.nineButton.Location = new System.Drawing.Point(255, 243);
            this.nineButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nineButton.Name = "nineButton";
            this.nineButton.Size = new System.Drawing.Size(61, 32);
            this.nineButton.TabIndex = 29;
            this.nineButton.Text = "&9";
            this.nineButton.UseVisualStyleBackColor = true;
            this.nineButton.Click += new System.EventHandler(this.nineButton_Click);
            // 
            // fourButton
            // 
            this.fourButton.Location = new System.Drawing.Point(132, 277);
            this.fourButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fourButton.Name = "fourButton";
            this.fourButton.Size = new System.Drawing.Size(61, 32);
            this.fourButton.TabIndex = 28;
            this.fourButton.Text = "&4";
            this.fourButton.UseVisualStyleBackColor = true;
            this.fourButton.Click += new System.EventHandler(this.fourButton_Click);
            // 
            // fiveButton
            // 
            this.fiveButton.Location = new System.Drawing.Point(194, 276);
            this.fiveButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fiveButton.Name = "fiveButton";
            this.fiveButton.Size = new System.Drawing.Size(61, 32);
            this.fiveButton.TabIndex = 27;
            this.fiveButton.Text = "&5";
            this.fiveButton.UseVisualStyleBackColor = true;
            this.fiveButton.Click += new System.EventHandler(this.fiveButton_Click);
            // 
            // sixButton
            // 
            this.sixButton.Location = new System.Drawing.Point(255, 276);
            this.sixButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sixButton.Name = "sixButton";
            this.sixButton.Size = new System.Drawing.Size(61, 32);
            this.sixButton.TabIndex = 26;
            this.sixButton.Text = "&6";
            this.sixButton.UseVisualStyleBackColor = true;
            this.sixButton.Click += new System.EventHandler(this.sixButton_Click);
            // 
            // oneButton
            // 
            this.oneButton.Location = new System.Drawing.Point(132, 309);
            this.oneButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.oneButton.Name = "oneButton";
            this.oneButton.Size = new System.Drawing.Size(61, 31);
            this.oneButton.TabIndex = 25;
            this.oneButton.Text = "&1";
            this.oneButton.UseVisualStyleBackColor = true;
            this.oneButton.Click += new System.EventHandler(this.oneButton_Click);
            // 
            // twoButton
            // 
            this.twoButton.Location = new System.Drawing.Point(194, 308);
            this.twoButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.twoButton.Name = "twoButton";
            this.twoButton.Size = new System.Drawing.Size(61, 32);
            this.twoButton.TabIndex = 24;
            this.twoButton.Text = "&2";
            this.twoButton.UseVisualStyleBackColor = true;
            this.twoButton.Click += new System.EventHandler(this.twoButton_Click);
            // 
            // threeButton
            // 
            this.threeButton.Location = new System.Drawing.Point(255, 308);
            this.threeButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.threeButton.Name = "threeButton";
            this.threeButton.Size = new System.Drawing.Size(61, 32);
            this.threeButton.TabIndex = 23;
            this.threeButton.Text = "&3";
            this.threeButton.UseVisualStyleBackColor = true;
            this.threeButton.Click += new System.EventHandler(this.threeButton_Click);
            // 
            // zeroButton
            // 
            this.zeroButton.Location = new System.Drawing.Point(194, 342);
            this.zeroButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.zeroButton.Name = "zeroButton";
            this.zeroButton.Size = new System.Drawing.Size(61, 32);
            this.zeroButton.TabIndex = 22;
            this.zeroButton.Text = "&0";
            this.zeroButton.UseVisualStyleBackColor = true;
            this.zeroButton.Click += new System.EventHandler(this.zeroButton_Click);
            // 
            // button_LeftArrow
            // 
            this.button_LeftArrow.Location = new System.Drawing.Point(132, 206);
            this.button_LeftArrow.Name = "button_LeftArrow";
            this.button_LeftArrow.Size = new System.Drawing.Size(30, 34);
            this.button_LeftArrow.TabIndex = 39;
            this.button_LeftArrow.Text = "←";
            this.button_LeftArrow.UseVisualStyleBackColor = true;
            this.button_LeftArrow.Click += new System.EventHandler(this.button_CleanExpression_Click);
            // 
            // button_sin
            // 
            this.button_sin.Location = new System.Drawing.Point(3, 344);
            this.button_sin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_sin.Name = "button_sin";
            this.button_sin.Size = new System.Drawing.Size(61, 32);
            this.button_sin.TabIndex = 40;
            this.button_sin.Text = "sin";
            this.button_sin.UseVisualStyleBackColor = true;
            this.button_sin.Click += new System.EventHandler(this.button_sin_Click);
            // 
            // button_cos
            // 
            this.button_cos.Location = new System.Drawing.Point(3, 312);
            this.button_cos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_cos.Name = "button_cos";
            this.button_cos.Size = new System.Drawing.Size(61, 32);
            this.button_cos.TabIndex = 41;
            this.button_cos.Text = "cos";
            this.button_cos.UseVisualStyleBackColor = true;
            this.button_cos.Click += new System.EventHandler(this.button_cos_Click);
            // 
            // button_tan
            // 
            this.button_tan.Location = new System.Drawing.Point(3, 280);
            this.button_tan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_tan.Name = "button_tan";
            this.button_tan.Size = new System.Drawing.Size(61, 32);
            this.button_tan.TabIndex = 42;
            this.button_tan.Text = "tan";
            this.button_tan.UseVisualStyleBackColor = true;
            this.button_tan.Click += new System.EventHandler(this.button_tan_Click);
            // 
            // button_ctan
            // 
            this.button_ctan.Location = new System.Drawing.Point(3, 248);
            this.button_ctan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_ctan.Name = "button_ctan";
            this.button_ctan.Size = new System.Drawing.Size(61, 32);
            this.button_ctan.TabIndex = 43;
            this.button_ctan.Text = "ctan";
            this.button_ctan.UseVisualStyleBackColor = true;
            this.button_ctan.Click += new System.EventHandler(this.button_ctan_Click);
            // 
            // button_exp
            // 
            this.button_exp.Location = new System.Drawing.Point(63, 280);
            this.button_exp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_exp.Name = "button_exp";
            this.button_exp.Size = new System.Drawing.Size(61, 32);
            this.button_exp.TabIndex = 44;
            this.button_exp.Text = "exp";
            this.button_exp.UseVisualStyleBackColor = true;
            this.button_exp.Click += new System.EventHandler(this.button_exp_Click);
            // 
            // button_sqrt
            // 
            this.button_sqrt.Location = new System.Drawing.Point(63, 248);
            this.button_sqrt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_sqrt.Name = "button_sqrt";
            this.button_sqrt.Size = new System.Drawing.Size(61, 32);
            this.button_sqrt.TabIndex = 45;
            this.button_sqrt.Text = "sqrt";
            this.button_sqrt.UseVisualStyleBackColor = true;
            this.button_sqrt.Click += new System.EventHandler(this.button_sqrt_Click);
            // 
            // button_ln
            // 
            this.button_ln.Location = new System.Drawing.Point(63, 344);
            this.button_ln.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_ln.Name = "button_ln";
            this.button_ln.Size = new System.Drawing.Size(61, 32);
            this.button_ln.TabIndex = 46;
            this.button_ln.Text = "ln";
            this.button_ln.UseVisualStyleBackColor = true;
            this.button_ln.Click += new System.EventHandler(this.button_ln_Click);
            // 
            // button_log
            // 
            this.button_log.Location = new System.Drawing.Point(63, 312);
            this.button_log.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_log.Name = "button_log";
            this.button_log.Size = new System.Drawing.Size(61, 32);
            this.button_log.TabIndex = 47;
            this.button_log.Text = "log";
            this.button_log.UseVisualStyleBackColor = true;
            this.button_log.Click += new System.EventHandler(this.button_log_Click);
            // 
            // button_leftParenthesis
            // 
            this.button_leftParenthesis.Location = new System.Drawing.Point(3, 217);
            this.button_leftParenthesis.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_leftParenthesis.Name = "button_leftParenthesis";
            this.button_leftParenthesis.Size = new System.Drawing.Size(61, 32);
            this.button_leftParenthesis.TabIndex = 48;
            this.button_leftParenthesis.Text = "(";
            this.button_leftParenthesis.UseVisualStyleBackColor = true;
            this.button_leftParenthesis.Click += new System.EventHandler(this.button_leftParenthesis_Click);
            // 
            // button_rightParenthesis
            // 
            this.button_rightParenthesis.Location = new System.Drawing.Point(63, 217);
            this.button_rightParenthesis.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_rightParenthesis.Name = "button_rightParenthesis";
            this.button_rightParenthesis.Size = new System.Drawing.Size(61, 32);
            this.button_rightParenthesis.TabIndex = 49;
            this.button_rightParenthesis.Text = ")";
            this.button_rightParenthesis.UseVisualStyleBackColor = true;
            this.button_rightParenthesis.Click += new System.EventHandler(this.button_rightParenthesis_Click);
            // 
            // comboBox_addedFunctions
            // 
            this.comboBox_addedFunctions.FormattingEnabled = true;
            this.comboBox_addedFunctions.Location = new System.Drawing.Point(3, 193);
            this.comboBox_addedFunctions.Name = "comboBox_addedFunctions";
            this.comboBox_addedFunctions.Size = new System.Drawing.Size(121, 28);
            this.comboBox_addedFunctions.TabIndex = 50;
            this.comboBox_addedFunctions.SelectionChangeCommitted += new System.EventHandler(this.comboBox_addedFunctions_SelectionChangeCommitted);
            // 
            // panel_Identifiers
            // 
            this.panel_Identifiers.Controls.Add(this.button1);
            this.panel_Identifiers.Controls.Add(this.button_Pi);
            this.panel_Identifiers.Controls.Add(this.button_AddVariable);
            this.panel_Identifiers.Controls.Add(this.box_Variable);
            this.panel_Identifiers.Location = new System.Drawing.Point(3, 193);
            this.panel_Identifiers.Name = "panel_Identifiers";
            this.panel_Identifiers.Size = new System.Drawing.Size(126, 183);
            this.panel_Identifiers.TabIndex = 51;
            this.panel_Identifiers.Visible = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(32, 115);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 26);
            this.button1.TabIndex = 59;
            this.button1.Text = "e";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_Pi
            // 
            this.button_Pi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Pi.Location = new System.Drawing.Point(4, 115);
            this.button_Pi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_Pi.Name = "button_Pi";
            this.button_Pi.Size = new System.Drawing.Size(29, 26);
            this.button_Pi.TabIndex = 57;
            this.button_Pi.Text = "π";
            this.button_Pi.UseVisualStyleBackColor = true;
            this.button_Pi.Click += new System.EventHandler(this.button_Pi_Click);
            // 
            // button_AddVariable
            // 
            this.button_AddVariable.Location = new System.Drawing.Point(31, 54);
            this.button_AddVariable.Name = "button_AddVariable";
            this.button_AddVariable.Size = new System.Drawing.Size(61, 24);
            this.button_AddVariable.TabIndex = 57;
            this.button_AddVariable.Text = "Add";
            this.button_AddVariable.UseVisualStyleBackColor = true;
            this.button_AddVariable.Click += new System.EventHandler(this.button_AddVariable_Click);
            // 
            // box_Variable
            // 
            this.box_Variable.Location = new System.Drawing.Point(12, 21);
            this.box_Variable.Name = "box_Variable";
            this.box_Variable.Size = new System.Drawing.Size(100, 26);
            this.box_Variable.TabIndex = 0;
            // 
            // button_Pow
            // 
            this.button_Pow.Location = new System.Drawing.Point(132, 342);
            this.button_Pow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_Pow.Name = "button_Pow";
            this.button_Pow.Size = new System.Drawing.Size(30, 32);
            this.button_Pow.TabIndex = 52;
            this.button_Pow.Text = "^";
            this.button_Pow.UseVisualStyleBackColor = true;
            this.button_Pow.Click += new System.EventHandler(this.button_Pow_Click);
            // 
            // button_right
            // 
            this.button_right.Location = new System.Drawing.Point(162, 206);
            this.button_right.Name = "button_right";
            this.button_right.Size = new System.Drawing.Size(30, 34);
            this.button_right.TabIndex = 53;
            this.button_right.Text = "→";
            this.button_right.UseVisualStyleBackColor = true;
            this.button_right.Click += new System.EventHandler(this.button_right_Click);
            // 
            // button_Delete
            // 
            this.button_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button_Delete.Location = new System.Drawing.Point(191, 205);
            this.button_Delete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(55, 35);
            this.button_Delete.TabIndex = 55;
            this.button_Delete.Text = "del";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // button_Variables
            // 
            this.button_Variables.Location = new System.Drawing.Point(3, 161);
            this.button_Variables.Name = "button_Variables";
            this.button_Variables.Size = new System.Drawing.Size(61, 24);
            this.button_Variables.TabIndex = 56;
            this.button_Variables.Text = "Vars";
            this.button_Variables.UseVisualStyleBackColor = true;
            this.button_Variables.Click += new System.EventHandler(this.button_Variables_Click);
            // 
            // button_Dot
            // 
            this.button_Dot.Location = new System.Drawing.Point(163, 342);
            this.button_Dot.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_Dot.Name = "button_Dot";
            this.button_Dot.Size = new System.Drawing.Size(30, 32);
            this.button_Dot.TabIndex = 57;
            this.button_Dot.Text = ".";
            this.button_Dot.UseVisualStyleBackColor = true;
            this.button_Dot.Click += new System.EventHandler(this.button_Dot_Click);
            // 
            // label_AssignVariables
            // 
            this.label_AssignVariables.AutoSize = true;
            this.label_AssignVariables.Font = new System.Drawing.Font("Arial Narrow", 9F);
            this.label_AssignVariables.Location = new System.Drawing.Point(11, 142);
            this.label_AssignVariables.Name = "label_AssignVariables";
            this.label_AssignVariables.Size = new System.Drawing.Size(0, 22);
            this.label_AssignVariables.TabIndex = 58;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(116, 161);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 59;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // Form_Main
            // 
            this.ClientSize = new System.Drawing.Size(354, 380);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label_AssignVariables);
            this.Controls.Add(this.button_Dot);
            this.Controls.Add(this.button_Variables);
            this.Controls.Add(this.button_Delete);
            this.Controls.Add(this.button_right);
            this.Controls.Add(this.button_Pow);
            this.Controls.Add(this.panel_Identifiers);
            this.Controls.Add(this.comboBox_addedFunctions);
            this.Controls.Add(this.button_rightParenthesis);
            this.Controls.Add(this.button_leftParenthesis);
            this.Controls.Add(this.button_log);
            this.Controls.Add(this.button_ln);
            this.Controls.Add(this.button_sqrt);
            this.Controls.Add(this.button_exp);
            this.Controls.Add(this.button_ctan);
            this.Controls.Add(this.button_tan);
            this.Controls.Add(this.button_cos);
            this.Controls.Add(this.button_sin);
            this.Controls.Add(this.button_LeftArrow);
            this.Controls.Add(this.button_Clean);
            this.Controls.Add(this.result);
            this.Controls.Add(this.divide);
            this.Controls.Add(this.multiply);
            this.Controls.Add(this.plus);
            this.Controls.Add(this.minus);
            this.Controls.Add(this.sevenButton);
            this.Controls.Add(this.eigthButton);
            this.Controls.Add(this.nineButton);
            this.Controls.Add(this.fourButton);
            this.Controls.Add(this.fiveButton);
            this.Controls.Add(this.sixButton);
            this.Controls.Add(this.oneButton);
            this.Controls.Add(this.twoButton);
            this.Controls.Add(this.threeButton);
            this.Controls.Add(this.zeroButton);
            this.Controls.Add(this.richTextBox_Result);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculator";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseHover += new System.EventHandler(this.Form1_MouseHover);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel_Identifiers.ResumeLayout(false);
            this.panel_Identifiers.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox_Result;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem evaluateFromTextFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem functionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem howToUseToolStripMenuItem;
        private System.Windows.Forms.Button button_Clean;
        private System.Windows.Forms.Button result;
        private System.Windows.Forms.Button divide;
        private System.Windows.Forms.Button multiply;
        private System.Windows.Forms.Button plus;
        private System.Windows.Forms.Button minus;
        private System.Windows.Forms.Button sevenButton;
        private System.Windows.Forms.Button eigthButton;
        private System.Windows.Forms.Button nineButton;
        private System.Windows.Forms.Button fourButton;
        private System.Windows.Forms.Button fiveButton;
        private System.Windows.Forms.Button sixButton;
        private System.Windows.Forms.Button oneButton;
        private System.Windows.Forms.Button twoButton;
        private System.Windows.Forms.Button threeButton;
        private System.Windows.Forms.Button zeroButton;
        private System.Windows.Forms.Button button_LeftArrow;
        private System.Windows.Forms.Button button_sin;
        private System.Windows.Forms.Button button_cos;
        private System.Windows.Forms.Button button_tan;
        private System.Windows.Forms.Button button_ctan;
        private System.Windows.Forms.Button button_exp;
        private System.Windows.Forms.Button button_sqrt;
        private System.Windows.Forms.Button button_ln;
        private System.Windows.Forms.Button button_log;
        private System.Windows.Forms.Button button_leftParenthesis;
        private System.Windows.Forms.Button button_rightParenthesis;
        private System.Windows.Forms.ComboBox comboBox_addedFunctions;
        private System.Windows.Forms.Panel panel_Identifiers;
        private System.Windows.Forms.Button button_Pow;
        private System.Windows.Forms.Button button_right;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.Button button_AddVariable;
        private System.Windows.Forms.TextBox box_Variable;
        private System.Windows.Forms.Button button_Variables;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_Pi;
        private System.Windows.Forms.Button button_Dot;
        private System.Windows.Forms.Label label_AssignVariables;
        private System.Windows.Forms.Button button2;
    }
}

