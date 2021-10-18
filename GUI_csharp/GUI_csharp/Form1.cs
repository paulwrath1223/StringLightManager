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
//using Newtonsoft.json;
using System.Diagnostics;
using Google.Api.Gax.ResourceNames;

namespace GUI_csharp
{
    public partial class Form1 : Form
    {
        private List<GroupBox> groupBoxes = new List<GroupBox>();
        private List<Arduino> arduinos = new List<Arduino>();
        private int _usedId = 0;

        #region DesignConstants

        private Size _gbSize = new Size(400, 125);
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Init();
            Add_ColorGroupBox();
            //Debug.WriteLine(ArdToJson(arduinos[0]));
            //Debug.Flush();

            Console.WriteLine(cb_arduinoID.SelectedIndex);
        }

        #region DropdownMenu
        private void Init()
        {
            List<Item> items = new List<Item>();
            items.Add(new Item() { Text = "choose ID", Value = "Not chosen" });
            items.Add(new Item() { Text = "id 1", Value = "ValueText2" });
            items.Add(new Item() { Text = "id 2", Value = "ValueText3" });

            cb_arduinoID.DataSource = items;
            cb_arduinoID.DisplayMember = "Text";
            cb_arduinoID.ValueMember = "Value";

        }

        public class Item
        {
            public Item() { }

            public string Value { set; get; }
            public string Text { set; get; }
        }
        #endregion

        private void bttn_Speed_Click(object sender, EventArgs e)
        {
            int speed;
            if (!int.TryParse(tb_Speed.Text, out speed))
                tb_Speed.Text = "";
            else
            {
                double dSpeed = speed / Math.Pow(10, tb_Speed.Text.Length);
                Console.WriteLine(dSpeed);
                if (dSpeed > 1 || dSpeed < 0)
                    tb_Speed.Text = "";
                else
                {
                    lbl_Speed.Text = "Speed: " + dSpeed.ToString();
                    //TODO: save speed to arduino class
                }
            }
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
                Console.WriteLine("Object not found");
                return null;
            }
        }

        #region ColorsPanel

        private void Add_ColorGroupBox()
        {
            GroupBox gb = new GroupBox();
            colorsPanel.Controls.Add(gb);

            Button bttn_ChangeColor = new Button();
            Button bttn_Delete = new Button();

            gb.Controls.Add(bttn_ChangeColor);
            gb.Controls.Add(bttn_Delete);

            bttn_ChangeColor.Text = "Change Color";
            bttn_ChangeColor.Name = "ChangeColor_"+_usedId.ToString();
            bttn_ChangeColor.Location = new Point(20, 20);
            bttn_ChangeColor.BackColor = Color.Gray;
            bttn_ChangeColor.Click += new System.EventHandler(bttn_ChangeColor_Click);

            bttn_Delete.Text = "-";
            bttn_Delete.Name = "Delete_" + _usedId.ToString();
            bttn_Delete.Size = new Size(20, 20);
            bttn_Delete.Location = new Point(_gbSize.Width - bttn_Delete.Size.Width - 5, 20);
            bttn_Delete.BackColor = Color.Gray;
            bttn_Delete.Click += new System.EventHandler(bttn_Delete_Click);


            gb.Size = _gbSize;
            gb.Name = "Color_" + _usedId.ToString();
            gb.Location = new Point(30, 150);

            groupBoxes.Add(gb);
            _usedId++;
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

        private int getId(GroupBox gb)
        {
            int id;
            string[] id_string = gb.Name.Split('_');

            if (!int.TryParse(id_string[1], out id))
            {
                Console.WriteLine("GroupBox id could not be read!");
                return 0;
            }
            else
            {
                return id;
            }
        }

        private int getParentGroupBoxIndex(int id)
        {
            for (int i = 0; i < groupBoxes.Count; i++)
            {
                int gb_id = getId(groupBoxes[i]);
                if (gb_id == id)
                {
                    return i;
                }
            }
            Console.WriteLine("Parent could not be found!");
            return 0;
        }

        private void bttn_ChangeColor_Click(object sender, EventArgs e)
        {
            int id = getId(sender);
            ColorDialog cdlg = new ColorDialog();
            cdlg.ShowDialog();
            Color color = cdlg.Color;
            string RGBValue = RGBConverter(color);
            groupBoxes[getParentGroupBoxIndex(id)].BackColor = color;
            groupBoxes[getParentGroupBoxIndex(id)].Text = RGBValue;
            Console.WriteLine(RGBConverter(color));
            //TODO: Save color value
        }

        private static String RGBConverter(System.Drawing.Color c)
        {
            return "RGB(" + c.R.ToString() + "," + c.G.ToString() + "," + c.B.ToString() + ")";
        }

        private void bttn_Delete_Click(object sender, EventArgs e)
        {
            int id = getId(sender);
            int gb_index = getParentGroupBoxIndex(id);
            colorsPanel.Controls.Remove(groupBoxes[gb_index]);
            groupBoxes.RemoveAt(gb_index);

            //TODO: remove from storage
            //for (int i = 0; i < arduinos.Count; i++)
            //{
            //    if (arduinos[i]._id == id)
            //    {
            //        ar_sequence = i;
            //        break;
            //    }
            //}
            //arduinos.RemoveAt(ar_sequence);
            groupBoxColorsChangeLocation();
        }

        private void bttn_Add_Click(object sender, EventArgs e)
        {
            Add_ColorGroupBox();
            groupBoxColorsChangeLocation();
        }

        private void groupBoxColorsChangeLocation()
        {
            colorsPanel.AutoScroll = false;
            for (int i = 0; i < groupBoxes.Count; i++)
            {
                groupBoxes[i].Location = new Point(30, 20 + i * (_gbSize.Height + 10));
            }

            bttn_Add.Location = new Point((_gbSize.Width+bttn_Add.Size.Width/2)/2, 20 + groupBoxes.Count * (_gbSize.Height + 10));
            colorsPanel.AutoScroll = true;
        }
        #endregion
        
        #region ArduinoPanel
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Add_Arduino();
            arduinoChangeLocations();
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
            Button delete = new Button();

            gb.Controls.Add(speed);
            gb.Controls.Add(speedInput);
            gb.Controls.Add(speedEdit);
            gb.Controls.Add(length);
            gb.Controls.Add(colorList);
            gb.Controls.Add(colorEdit);
            gb.Controls.Add(delete);

            speed.Location = new System.Drawing.Point(35, 30);
            speed.Size = new System.Drawing.Size(80, 20);
            speed.Text = "Speed: ";
            speed.Name = "Speed";

            speedInput.Location = new System.Drawing.Point(120, 30);
            speedInput.Size = new System.Drawing.Size(50, 20);
            speedInput.Name = "SpeedInput";

            speedEdit.Location = new System.Drawing.Point(185, 30);
            speedEdit.Text = "edit";
            speedEdit.Name = "SpeedEdit_" + _usedId.ToString();
            speedEdit.Size = new System.Drawing.Size(40, 20);
            speedEdit.Click += new System.EventHandler(this.buttonSpeedEdit_Click);

            length.Location = new System.Drawing.Point(35, 60);
            length.Text = "Length: 0";
            length.Name = "Length";

            colorList.Location = new System.Drawing.Point(250, 10);
            colorList.Size = new System.Drawing.Size(150, 100);
            colorList.Name = "ColorList";

            colorEdit.Location = new System.Drawing.Point(420, 50);
            colorEdit.Text = "edit";
            colorEdit.Name = "ColorEdit_" + _usedId.ToString();
            colorEdit.Size = new System.Drawing.Size(40, 20);
            colorEdit.Click += new System.EventHandler(this.buttonColorEdit_Click);

            delete.Text = "delete";
            delete.Name = "Delete_" + _usedId.ToString();
            delete.Location = new Point(420, 20);
            delete.Click += new System.EventHandler(this.buttonDelete_Click);


            gb.Size = _gbSize;
            gb.Text = "Arduino_" + _usedId.ToString();
            gb.BackColor = System.Drawing.SystemColors.ActiveBorder;

            groupBoxes.Add(gb);
            arduinos.Add(new Arduino(_usedId));
            _usedId++;
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
        private void buttonColorEdit_Click(object sender, EventArgs e)
        {
            int id = getId(sender);
            arduinoPanel.Visible = false;
            colorsPanel.Visible = true;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int id = getId(sender);
            int gb_sequence = 0;
            int ar_sequence = 0;
            for (int i = 0; i < groupBoxes.Count; i++)
            {
                int gb_id = getId(groupBoxes[i]);
                if (gb_id == id)
                {
                    gb_sequence = i;
                    break;
                }
            }
            arduinoPanel.Controls.Remove(groupBoxes[gb_sequence]);
            groupBoxes.RemoveAt(gb_sequence);
            for (int i = 0; i < arduinos.Count; i++)
            {
                if (arduinos[i]._id == id)
                {
                    ar_sequence = i;
                    break;
                }
            }
            arduinos.RemoveAt(ar_sequence);
            arduinoChangeLocations();
        }

        private void arduinoChangeLocations()
        {
            arduinoPanel.AutoScroll = false;
            for (int i = 0; i < groupBoxes.Count; i++)
            {
                groupBoxes[i].Location = new Point(30, 20 + i * (_gbSize.Height + 10));
            }
            Console.WriteLine("GbCount: "+groupBoxes.Count);

            buttonAdd.Location = new Point(30, 20 + groupBoxes.Count * (_gbSize.Height + 10));
            arduinoPanel.AutoScroll = true;
        }
        #endregion

        #region JsonConvertor
        private string ArdToJson(Arduino ard)
        {
            List<RGBColorBasic> tempColors = new List<RGBColorBasic>();
            tempColors = ColorCompiler(ard._colorList);
            JsonArduino temp = new JsonArduino(ard, tempColors);
            //string jsonOut = JsonConvert.SerializeObject(temp);
            //return jsonOut;
            return "correct this";
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
        #endregion
    }
}
