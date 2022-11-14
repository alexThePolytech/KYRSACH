namespace KYRSACH
{
    partial class Form_FillIdentifiers
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
            this.label_Variables = new System.Windows.Forms.Label();
            this.box_Input = new System.Windows.Forms.TextBox();
            this.button_Go = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_Variables
            // 
            this.label_Variables.AutoSize = true;
            this.label_Variables.Location = new System.Drawing.Point(22, 29);
            this.label_Variables.Name = "label_Variables";
            this.label_Variables.Size = new System.Drawing.Size(0, 20);
            this.label_Variables.TabIndex = 0;
            // 
            // box_Input
            // 
            this.box_Input.Location = new System.Drawing.Point(147, 29);
            this.box_Input.Name = "box_Input";
            this.box_Input.Size = new System.Drawing.Size(120, 26);
            this.box_Input.TabIndex = 1;
            // 
            // button_Go
            // 
            this.button_Go.Location = new System.Drawing.Point(167, 77);
            this.button_Go.Name = "button_Go";
            this.button_Go.Size = new System.Drawing.Size(75, 31);
            this.button_Go.TabIndex = 2;
            this.button_Go.Text = "Go";
            this.button_Go.UseVisualStyleBackColor = true;
            this.button_Go.Click += new System.EventHandler(this.button_Go_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 117);
            this.Controls.Add(this.button_Go);
            this.Controls.Add(this.box_Input);
            this.Controls.Add(this.label_Variables);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fill Identifiers";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Variables;
        private System.Windows.Forms.TextBox box_Input;
        private System.Windows.Forms.Button button_Go;
    }
}