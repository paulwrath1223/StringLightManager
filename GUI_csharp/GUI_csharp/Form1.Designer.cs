
namespace GUI_csharp
{
    partial class Form1
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
            this.colorsPanel = new System.Windows.Forms.Panel();
            this.bttn_Add = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.amongusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Speed = new System.Windows.Forms.Label();
            this.tb_Speed = new System.Windows.Forms.TextBox();
            this.bttn_Speed = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.cb_arduinoID = new System.Windows.Forms.ComboBox();
            this.lengthLabel = new System.Windows.Forms.Label();
            this.lengthButton = new System.Windows.Forms.Button();
            this.lengthTextBox = new System.Windows.Forms.TextBox();
            this.colorsPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // colorsPanel
            // 
            this.colorsPanel.AutoScroll = true;
            this.colorsPanel.Controls.Add(this.bttn_Add);
            this.colorsPanel.Location = new System.Drawing.Point(162, 250);
            this.colorsPanel.Margin = new System.Windows.Forms.Padding(5);
            this.colorsPanel.Name = "colorsPanel";
            this.colorsPanel.Size = new System.Drawing.Size(1357, 782);
            this.colorsPanel.TabIndex = 1;
            // 
            // bttn_Add
            // 
            this.bttn_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttn_Add.ForeColor = System.Drawing.Color.Green;
            this.bttn_Add.Location = new System.Drawing.Point(533, 312);
            this.bttn_Add.Margin = new System.Windows.Forms.Padding(5);
            this.bttn_Add.Name = "bttn_Add";
            this.bttn_Add.Size = new System.Drawing.Size(139, 114);
            this.bttn_Add.TabIndex = 2;
            this.bttn_Add.Text = "+";
            this.bttn_Add.UseVisualStyleBackColor = true;
            this.bttn_Add.Click += new System.EventHandler(this.bttn_Add_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.amongusToolStripMenuItem,
            this.uploadToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(11, 5, 0, 5);
            this.menuStrip1.Size = new System.Drawing.Size(2133, 55);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // amongusToolStripMenuItem
            // 
            this.amongusToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveAsTemplateToolStripMenuItem});
            this.amongusToolStripMenuItem.Name = "amongusToolStripMenuItem";
            this.amongusToolStripMenuItem.Size = new System.Drawing.Size(87, 45);
            this.amongusToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(410, 54);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenArduino);
            // 
            // saveAsTemplateToolStripMenuItem
            // 
            this.saveAsTemplateToolStripMenuItem.Name = "saveAsTemplateToolStripMenuItem";
            this.saveAsTemplateToolStripMenuItem.Size = new System.Drawing.Size(410, 54);
            this.saveAsTemplateToolStripMenuItem.Text = "Save as Template";
            this.saveAsTemplateToolStripMenuItem.Click += new System.EventHandler(this.SaveArduino);
            // 
            // uploadToolStripMenuItem
            // 
            this.uploadToolStripMenuItem.Name = "uploadToolStripMenuItem";
            this.uploadToolStripMenuItem.Size = new System.Drawing.Size(139, 45);
            this.uploadToolStripMenuItem.Text = "Upload";
            this.uploadToolStripMenuItem.Click += new System.EventHandler(this.UploadArduino);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(109, 45);
            this.clearToolStripMenuItem.Text = "Clear";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(397, 86);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "Arduino ID:";
            // 
            // lbl_Speed
            // 
            this.lbl_Speed.AutoSize = true;
            this.lbl_Speed.Location = new System.Drawing.Point(386, 170);
            this.lbl_Speed.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbl_Speed.Name = "lbl_Speed";
            this.lbl_Speed.Size = new System.Drawing.Size(113, 32);
            this.lbl_Speed.TabIndex = 4;
            this.lbl_Speed.Text = "Speed: ";
            // 
            // tb_Speed
            // 
            this.tb_Speed.Location = new System.Drawing.Point(604, 167);
            this.tb_Speed.Margin = new System.Windows.Forms.Padding(5);
            this.tb_Speed.Name = "tb_Speed";
            this.tb_Speed.Size = new System.Drawing.Size(156, 38);
            this.tb_Speed.TabIndex = 5;
            // 
            // bttn_Speed
            // 
            this.bttn_Speed.Location = new System.Drawing.Point(775, 153);
            this.bttn_Speed.Margin = new System.Windows.Forms.Padding(5);
            this.bttn_Speed.Name = "bttn_Speed";
            this.bttn_Speed.Size = new System.Drawing.Size(125, 64);
            this.bttn_Speed.TabIndex = 6;
            this.bttn_Speed.Text = "ok";
            this.bttn_Speed.UseVisualStyleBackColor = true;
            this.bttn_Speed.Click += new System.EventHandler(this.bttn_Speed_Click);
            // 
            // cb_arduinoID
            // 
            this.cb_arduinoID.FormattingEnabled = true;
            this.cb_arduinoID.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cb_arduinoID.Location = new System.Drawing.Point(563, 79);
            this.cb_arduinoID.Margin = new System.Windows.Forms.Padding(5);
            this.cb_arduinoID.Name = "cb_arduinoID";
            this.cb_arduinoID.Size = new System.Drawing.Size(239, 39);
            this.cb_arduinoID.TabIndex = 3;
            this.cb_arduinoID.SelectedIndexChanged += new System.EventHandler(this.cb_arduinoID_SelectedIndexChanged);
            // 
            // lengthLabel
            // 
            this.lengthLabel.AutoSize = true;
            this.lengthLabel.Location = new System.Drawing.Point(930, 82);
            this.lengthLabel.Name = "lengthLabel";
            this.lengthLabel.Size = new System.Drawing.Size(103, 32);
            this.lengthLabel.TabIndex = 7;
            this.lengthLabel.Text = "Length";
            // 
            // lengthButton
            // 
            this.lengthButton.Location = new System.Drawing.Point(1312, 74);
            this.lengthButton.Name = "lengthButton";
            this.lengthButton.Size = new System.Drawing.Size(119, 52);
            this.lengthButton.TabIndex = 8;
            this.lengthButton.Text = "ok";
            this.lengthButton.UseVisualStyleBackColor = true;
            this.lengthButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // lengthTextBox
            // 
            this.lengthTextBox.Location = new System.Drawing.Point(1136, 79);
            this.lengthTextBox.Name = "lengthTextBox";
            this.lengthTextBox.Size = new System.Drawing.Size(147, 38);
            this.lengthTextBox.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2133, 1073);
            this.Controls.Add(this.lengthTextBox);
            this.Controls.Add(this.lengthButton);
            this.Controls.Add(this.lengthLabel);
            this.Controls.Add(this.bttn_Speed);
            this.Controls.Add(this.tb_Speed);
            this.Controls.Add(this.lbl_Speed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_arduinoID);
            this.Controls.Add(this.colorsPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.colorsPanel.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel colorsPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem amongusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsTemplateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_Speed;
        private System.Windows.Forms.TextBox tb_Speed;
        private System.Windows.Forms.Button bttn_Speed;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.Button bttn_Add;
        private System.Windows.Forms.ComboBox cb_arduinoID;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.Label lengthLabel;
        private System.Windows.Forms.Button lengthButton;
        private System.Windows.Forms.TextBox lengthTextBox;
    }
}

