namespace KYRSACH
{
    partial class HelpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
            this.button_Close = new System.Windows.Forms.Button();
            this.label_Second = new System.Windows.Forms.Label();
            this.pictureBox_Main = new System.Windows.Forms.PictureBox();
            this.label_Main = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Main)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Close
            // 
            this.button_Close.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Close.Location = new System.Drawing.Point(361, 173);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 30);
            this.button_Close.TabIndex = 7;
            this.button_Close.Text = "Close";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // label_Second
            // 
            this.label_Second.Font = new System.Drawing.Font("Consolas", 8F);
            this.label_Second.Location = new System.Drawing.Point(233, 88);
            this.label_Second.Name = "label_Second";
            this.label_Second.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_Second.Size = new System.Drawing.Size(219, 93);
            this.label_Second.TabIndex = 6;
            this.label_Second.Text = "Any inapropriative use may lead to an unexpected or undesireable behavior";
            // 
            // pictureBox_Main
            // 
            this.pictureBox_Main.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Main.Image")));
            this.pictureBox_Main.Location = new System.Drawing.Point(11, 48);
            this.pictureBox_Main.Name = "pictureBox_Main";
            this.pictureBox_Main.Size = new System.Drawing.Size(164, 157);
            this.pictureBox_Main.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Main.TabIndex = 5;
            this.pictureBox_Main.TabStop = false;
            // 
            // label_Main
            // 
            this.label_Main.AutoSize = true;
            this.label_Main.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.label_Main.Location = new System.Drawing.Point(80, 10);
            this.label_Main.Name = "label_Main";
            this.label_Main.Size = new System.Drawing.Size(369, 33);
            this.label_Main.TabIndex = 4;
            this.label_Main.Text = "Made by Oleksii Uzhva (c)2022";
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 214);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.label_Second);
            this.Controls.Add(this.pictureBox_Main);
            this.Controls.Add(this.label_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "HelpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HelpForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Main)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.Label label_Second;
        private System.Windows.Forms.PictureBox pictureBox_Main;
        private System.Windows.Forms.Label label_Main;
    }
}