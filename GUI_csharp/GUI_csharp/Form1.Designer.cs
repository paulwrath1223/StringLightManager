
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
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorsPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // colorsPanel
            // 
            this.colorsPanel.AutoScroll = true;
            this.colorsPanel.Controls.Add(this.bttn_Add);
            this.colorsPanel.Location = new System.Drawing.Point(136, 104);
            this.colorsPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.colorsPanel.Name = "colorsPanel";
            this.colorsPanel.Size = new System.Drawing.Size(509, 328);
            this.colorsPanel.TabIndex = 1;
            // 
            // bttn_Add
            // 
            this.bttn_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttn_Add.ForeColor = System.Drawing.Color.Green;
            this.bttn_Add.Location = new System.Drawing.Point(200, 131);
            this.bttn_Add.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bttn_Add.Name = "bttn_Add";
            this.bttn_Add.Size = new System.Drawing.Size(52, 48);
            this.bttn_Add.TabIndex = 2;
            this.bttn_Add.Text = "+";
            this.bttn_Add.UseVisualStyleBackColor = true;
            this.bttn_Add.Click += new System.EventHandler(this.bttn_Add_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.amongusToolStripMenuItem,
            this.uploadToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // amongusToolStripMenuItem
            // 
            this.amongusToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveAsTemplateToolStripMenuItem});
            this.amongusToolStripMenuItem.Name = "amongusToolStripMenuItem";
            this.amongusToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.amongusToolStripMenuItem.Text = "File";
            // 
            // saveAsTemplateToolStripMenuItem
            // 
            this.saveAsTemplateToolStripMenuItem.Name = "saveAsTemplateToolStripMenuItem";
            this.saveAsTemplateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsTemplateToolStripMenuItem.Text = "Save as Template";
            // 
            // uploadToolStripMenuItem
            // 
            this.uploadToolStripMenuItem.Name = "uploadToolStripMenuItem";
            this.uploadToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.uploadToolStripMenuItem.Text = "Upload";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.clearToolStripMenuItem.Text = "Clear";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(248, 35);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Arduino ID:";
            // 
            // lbl_Speed
            // 
            this.lbl_Speed.AutoSize = true;
            this.lbl_Speed.Location = new System.Drawing.Point(248, 73);
            this.lbl_Speed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Speed.Name = "lbl_Speed";
            this.lbl_Speed.Size = new System.Drawing.Size(44, 13);
            this.lbl_Speed.TabIndex = 4;
            this.lbl_Speed.Text = "Speed: ";
            // 
            // tb_Speed
            // 
            this.tb_Speed.Location = new System.Drawing.Point(336, 69);
            this.tb_Speed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_Speed.Name = "tb_Speed";
            this.tb_Speed.Size = new System.Drawing.Size(61, 20);
            this.tb_Speed.TabIndex = 5;
            // 
            // bttn_Speed
            // 
            this.bttn_Speed.Location = new System.Drawing.Point(400, 67);
            this.bttn_Speed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bttn_Speed.Name = "bttn_Speed";
            this.bttn_Speed.Size = new System.Drawing.Size(47, 27);
            this.bttn_Speed.TabIndex = 6;
            this.bttn_Speed.Text = "ok";
            this.bttn_Speed.UseVisualStyleBackColor = true;
            this.bttn_Speed.Click += new System.EventHandler(this.bttn_Speed_Click);
            // 
            // cb_arduinoID
            // 
            this.cb_arduinoID.FormattingEnabled = true;
            this.cb_arduinoID.Location = new System.Drawing.Point(310, 32);
            this.cb_arduinoID.Margin = new System.Windows.Forms.Padding(2);
            this.cb_arduinoID.Name = "cb_arduinoID";
            this.cb_arduinoID.Size = new System.Drawing.Size(92, 21);
            this.cb_arduinoID.TabIndex = 3;
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bttn_Speed);
            this.Controls.Add(this.tb_Speed);
            this.Controls.Add(this.lbl_Speed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_arduinoID);
            this.Controls.Add(this.colorsPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
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
    }
}

