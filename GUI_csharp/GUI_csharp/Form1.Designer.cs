
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.amongusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Speed = new System.Windows.Forms.Label();
            this.tb_Speed = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.cb_arduinoID = new System.Windows.Forms.ComboBox();
            this.lengthLabel = new System.Windows.Forms.Label();
            this.lengthTextBox = new System.Windows.Forms.TextBox();
            this.lbl_id = new System.Windows.Forms.Label();
            this.turnArduinosOnOffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // colorsPanel
            // 
            this.colorsPanel.AutoScroll = true;
            this.colorsPanel.Location = new System.Drawing.Point(81, 180);
            this.colorsPanel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.colorsPanel.Name = "colorsPanel";
            this.colorsPanel.Size = new System.Drawing.Size(678, 353);
            this.colorsPanel.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.amongusToolStripMenuItem,
            this.uploadToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.turnArduinosOnOffToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(962, 30);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // amongusToolStripMenuItem
            // 
            this.amongusToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.amongusToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveAsTemplateToolStripMenuItem});
            this.amongusToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.amongusToolStripMenuItem.Name = "amongusToolStripMenuItem";
            this.amongusToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.amongusToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(207, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenArduino);
            // 
            // saveAsTemplateToolStripMenuItem
            // 
            this.saveAsTemplateToolStripMenuItem.Name = "saveAsTemplateToolStripMenuItem";
            this.saveAsTemplateToolStripMenuItem.Size = new System.Drawing.Size(207, 26);
            this.saveAsTemplateToolStripMenuItem.Text = "Save as Template";
            this.saveAsTemplateToolStripMenuItem.Click += new System.EventHandler(this.SaveArduino);
            // 
            // uploadToolStripMenuItem
            // 
            this.uploadToolStripMenuItem.Name = "uploadToolStripMenuItem";
            this.uploadToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.uploadToolStripMenuItem.Text = "Upload";
            this.uploadToolStripMenuItem.Click += new System.EventHandler(this.UploadArduino);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.clearToolStripMenuItem.Text = "Clear";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Arduino ID:";
            // 
            // lbl_Speed
            // 
            this.lbl_Speed.AutoSize = true;
            this.lbl_Speed.Location = new System.Drawing.Point(260, 94);
            this.lbl_Speed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Speed.Name = "lbl_Speed";
            this.lbl_Speed.Size = new System.Drawing.Size(57, 17);
            this.lbl_Speed.TabIndex = 4;
            this.lbl_Speed.Text = "Speed: ";
            // 
            // tb_Speed
            // 
            this.tb_Speed.Location = new System.Drawing.Point(369, 92);
            this.tb_Speed.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tb_Speed.Name = "tb_Speed";
            this.tb_Speed.Size = new System.Drawing.Size(80, 22);
            this.tb_Speed.TabIndex = 5;
            this.tb_Speed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_Speed_KeyDown);
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
            this.cb_arduinoID.Location = new System.Drawing.Point(369, 44);
            this.cb_arduinoID.Margin = new System.Windows.Forms.Padding(0);
            this.cb_arduinoID.Name = "cb_arduinoID";
            this.cb_arduinoID.Size = new System.Drawing.Size(122, 24);
            this.cb_arduinoID.TabIndex = 3;
            this.cb_arduinoID.SelectedIndexChanged += new System.EventHandler(this.cb_arduinoID_SelectedIndexChanged);
            // 
            // lengthLabel
            // 
            this.lengthLabel.AutoSize = true;
            this.lengthLabel.Location = new System.Drawing.Point(270, 135);
            this.lengthLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lengthLabel.Name = "lengthLabel";
            this.lengthLabel.Size = new System.Drawing.Size(52, 17);
            this.lengthLabel.TabIndex = 7;
            this.lengthLabel.Text = "Length";
            // 
            // lengthTextBox
            // 
            this.lengthTextBox.Location = new System.Drawing.Point(369, 135);
            this.lengthTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.lengthTextBox.Name = "lengthTextBox";
            this.lengthTextBox.Size = new System.Drawing.Size(76, 22);
            this.lengthTextBox.TabIndex = 9;
            this.lengthTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lengthTextBox_KeyDown);
            // 
            // lbl_id
            // 
            this.lbl_id.AutoSize = true;
            this.lbl_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_id.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbl_id.Location = new System.Drawing.Point(242, 36);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Size = new System.Drawing.Size(111, 32);
            this.lbl_id.TabIndex = 10;
            this.lbl_id.Text = "ID: null";
            // 
            // turnArduinosOnOffToolStripMenuItem
            // 
            this.turnArduinosOnOffToolStripMenuItem.Name = "turnArduinosOnOffToolStripMenuItem";
            this.turnArduinosOnOffToolStripMenuItem.Size = new System.Drawing.Size(165, 24);
            this.turnArduinosOnOffToolStripMenuItem.Text = "Turn Arduinos On/Off";
            this.turnArduinosOnOffToolStripMenuItem.Click += new System.EventHandler(this.turnArduinosOnOffToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(962, 545);
            this.Controls.Add(this.lbl_id);
            this.Controls.Add(this.lengthTextBox);
            this.Controls.Add(this.lengthLabel);
            this.Controls.Add(this.tb_Speed);
            this.Controls.Add(this.lbl_Speed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_arduinoID);
            this.Controls.Add(this.colorsPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "String Light Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.ComboBox cb_arduinoID;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.Label lengthLabel;
        private System.Windows.Forms.TextBox lengthTextBox;
        private System.Windows.Forms.Label lbl_id;
        private System.Windows.Forms.ToolStripMenuItem turnArduinosOnOffToolStripMenuItem;
    }
}

