using System;
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
            Debug.WriteLine(ArdToJson(arduinos[0]));
            Debug.Flush();


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

        private string ArdToJson(Arduino ard)
        {
            string jsonOut = JsonConvert.SerializeObject(ard);
            return jsonOut;
        }

        private RGBColorBasic[] ColorCompiler(RGBColor[] colorsIn)
        {
            List<RGBColorBasic> colorsOut = new List<RGBColorBasic>();
            RGBColor currentColor = colorsIn[0];
            RGBColor nextColor = colorsIn[1];
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
                    nextColor = colorsIn[0];
                }
                else
                {
                    nextColor = colorsIn[index + 1];
                }
                currentColor = colorsIn[index];
                dr = (currentColor._r - nextColor._r)/currentColor._transitionFrames;
                dg = (currentColor._g - nextColor._g)/ currentColor._transitionFrames;
                db = (currentColor._b - nextColor._b)/ currentColor._transitionFrames;
                rs.Add(currentColor._r);
                gs.Add(currentColor._g);
                bs.Add(currentColor._b);
                for (int index2 = 0; index2 < currentColor._transitionFrames; index2++)
                {
                    rs.Add(currentColor._r + (index2 * dr));
                    gs.Add(currentColor._g + (index2 * dg));
                    bs.Add(currentColor._b + (index2 * db));
                }
            }
        }

        private string ArdJsonCompiler(string[] ards)
        {
            string output = "{\"Arduino\":\n [";
            for (int index = 0; index < (ards.Count())-1; index++)
            {
                output += (ards[index] + ",\n    {");
            }
            output += (ards[ards.Count()] + "\n  ]\n}");
            return output;
        }

            private void buttonColorEdit_Click(object sender, EventArgs e)
        {
            int id = getId(sender);
            arduinoPanel.Visible = false;
            colorsPanel.Visible = true;
        }
    }
}
