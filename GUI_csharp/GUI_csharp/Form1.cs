using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Newtonsoft.Json;
using System.Diagnostics;
using Firebase.Database;
using Firebase.Database.Query;


namespace GUI_csharp
{
    public partial class Form1 : Form
    {
        private List<GroupBox> groupBoxes = new List<GroupBox>();
        private List<Arduino> arduinos = new List<Arduino>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            colorsPanel.Visible = false;
            Add_Arduino();
            Control l = FindControl(groupBoxes[0], "Speed"); ;
            l.Text = "Speed";
            //Debug.WriteLine(ArdToJson(arduinos[0]));
            //Debug.Flush();


        }

        private void Add_Arduino()
        {
            GroupBox gb = new GroupBox();
            arduinoPanel.Controls.Add(gb);

            Label speed = new Label();
            TextBox speedInput = new TextBox();
            Button speedEdit = new Button();
            Label length = new Label();
            ListBox colorList = new ListBox();
            Button colorEdit = new Button();

            gb.Controls.Add(speed);
            gb.Controls.Add(speedInput);
            gb.Controls.Add(speedEdit);
            gb.Controls.Add(length);
            gb.Controls.Add(colorList);
            gb.Controls.Add(colorEdit);

            speed.Location = new System.Drawing.Point(35, 30);
            speed.Size = new System.Drawing.Size(80, 20);
            speed.Text = "Speed: ";
            speed.Name = "Speed";
            speedInput.Location = new System.Drawing.Point(120, 30);
            speedInput.Size = new System.Drawing.Size(50, 20);
            speedInput.Name = "SpeedInput";
            speedEdit.Location = new System.Drawing.Point(185, 30);
            speedEdit.Text = "edit";
            speedEdit.Name = "SpeedEdit_" + groupBoxes.Count.ToString();
            speedEdit.Size = new System.Drawing.Size(40, 20);
            speedEdit.Click += new System.EventHandler(this.buttonSpeedEdit_Click);
            length.Location = new System.Drawing.Point(35, 60);
            length.Text = "Length: 0";
            length.Name = "Length";
            colorList.Location = new System.Drawing.Point(250, 10);
            colorList.Size = new System.Drawing.Size(150, 100);
            colorList.Name = "ColorList";
            colorEdit.Location = new System.Drawing.Point(420, 30);
            colorEdit.Text = "edit";
            colorEdit.Name = "ColorEdit_" + groupBoxes.Count.ToString();
            colorEdit.Size = new System.Drawing.Size(40, 20);
            colorEdit.Click += new System.EventHandler(this.buttonColorEdit_Click);

            gb.Location = new System.Drawing.Point(25, 200);
            gb.Size = new System.Drawing.Size(450, 125);
            gb.Text = "Arduino" + groupBoxes.Count;
            gb.BackColor = System.Drawing.SystemColors.ActiveBorder;

            groupBoxes.Add(gb);
            arduinos.Add(new Arduino(arduinos.Count));
        }

        public static Control FindControl(/*this*/ Control parent, string name)
        {
            if (parent == null || string.IsNullOrEmpty(name))
            {
                return null;
            }

            Control[] controls = parent.Controls.Find(name, true);
            if (controls.Length > 0)
            {
                return controls[0];
            }
            else
            {
                return null;
            }
        }


        private int getId(object sender)
        {
            //Getting id of the groupbox
            int id;
            var b = (Button)sender;
            string[] id_string = b.Name.Split('_');

            if (!int.TryParse(id_string[1], out id))
            {
                Console.WriteLine("Button id could not be read!");
                return 0;
            }
            else
            {
                return id;
            }
        }
        private void buttonSpeedEdit_Click(object sender, EventArgs e)
        {
            //extracting textBox value and converting to double, updating groupBox controls
            int id = getId(sender);
            Control textBox = FindControl(groupBoxes[id], "SpeedInput");
            Control label = FindControl(groupBoxes[id], "Speed");
            int speed;
            if (!int.TryParse(textBox.Text, out speed))
                textBox.Text = "";
            else
            {
                double dSpeed =  speed/Math.Pow(10, textBox.Text.Length);
                Console.WriteLine(dSpeed);
                if (dSpeed > 1 || dSpeed < 0)
                    textBox.Text = "";
                else
                {
                    label.Text = "Speed: " + dSpeed.ToString();
                    arduinos[id]._speed = dSpeed;
                }
            }
        }

        private void UploadArduino(Arduino ard)
        {
            List<RGBColorBasic> tempColors = new List<RGBColorBasic>();
            tempColors = ColorCompiler(ard._colorList);
            JsonArduino temp = new JsonArduino(ard, tempColors);
            string jsonOut = JsonConvert.SerializeObject(temp);
            
        }

        private List<RGBColorBasic> ColorCompiler(List<RGBColor> colorsIn)
        {
            List<RGBColorBasic> colorsOut = new List<RGBColorBasic>();
            RGBColor CurrentColor;
            RGBColor NextColor;
            int dr;
            int dg;
            int db;
            List<int> rs = new List<int>();
            List<int> gs = new List<int>();
            List<int> bs = new List<int>();
            for (int index = 0; index < colorsIn.Count(); index++)
            {
                if(index + 1 == colorsIn.Count())
                {
                    NextColor = colorsIn[0];
                }
                else
                {
                    NextColor = colorsIn[index + 1];
                }
                CurrentColor = colorsIn[index];
                dr = (CurrentColor._r - NextColor._r)/ CurrentColor._transitionFrames;
                dg = (CurrentColor._g - NextColor._g)/ CurrentColor._transitionFrames;
                db = (CurrentColor._b - NextColor._b)/ CurrentColor._transitionFrames;
                rs.Add(CurrentColor._r);
                gs.Add(CurrentColor._g);
                bs.Add(CurrentColor._b);
                for (int index2 = 0; index2 < CurrentColor._transitionFrames; index2++)
                {
                    rs.Add(CurrentColor._r + (index2 * dr));
                    gs.Add(CurrentColor._g + (index2 * dg));
                    bs.Add(CurrentColor._b + (index2 * db));
                }
            }
            for(int index3 = 0; index3 < rs.Count; index3++)
            {
                colorsOut.Add(new RGBColorBasic(rs[index3], gs[index3], bs[index3]));
            }
            return colorsOut;
        }

        //private string ArdJsonCompiler(string[] ards)
        //{
        //    string output = "{\"Arduino\":\n [";
        //    for (int index = 0; index < (ards.Count())-1; index++)
        //    {
        //        output += (ards[index] + ",\n    {");
        //    }
        //    output += (ards[ards.Count()] + "\n  ]\n}");
        //    return output;
        //}


        private Arduino OpenArduino ()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Select file";
            open.Filter = "Arduino Config Files (*.acf)|*.acf| All files (*.*)|*.*";
            if(open.ShowDialog() == DialogResult.OK)
            {
                StreamReader read = new StreamReader(File.OpenRead(open.FileName));
                string jsonForm = read.ReadToEnd();
                read.Dispose();
                Arduino arduin = JsonConvert.DeserializeObject<Arduino>(jsonForm);
                return arduin;
            }
            return null;
        }

        private void saveArduino (Arduino input)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Title = "Select save location";
            save.Filter = "Arduino Config Files (*.acf)|*.acf| All files (*.*)|*.*";
            if(save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamWriter write = new StreamWriter(File.Create(save.FileName));
                string json = JsonConvert.SerializeObject(input);
                write.Write(json);
                write.Dispose();
            }
        }

        private void buttonColorEdit_Click(object sender, EventArgs e)
        {
            int id = getId(sender);
            arduinoPanel.Visible = false;
            colorsPanel.Visible = true;
        }
    }
}
