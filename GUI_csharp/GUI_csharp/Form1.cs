﻿using System;
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
using System.Windows.Input;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Google.Api.Gax.ResourceNames;


namespace GUI_csharp
{
    public partial class Form1 : Form
    {
        public int returnedLength = -1;
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "xnsxVJEbZchsxN2XPCkxAPhlZXdvWBt318oq98jh",
            BasePath = "https://light-data1-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;

        private List<GroupBox> groupBoxes = new List<GroupBox>();
        private Arduino _arduino = new Arduino(0);
        private int _usedId = 0;

        #region DesignConstants
        private Size _gbSize = new Size(400, 125);
        Color backColor = Color.FromArgb(64, 64, 64);
        Color foreColor = Color.FromArgb(224, 224, 224);
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DarkMode();
            client = new FireSharp.FirebaseClient(config);
            if(client == null)
            {
                MessageBox.Show("failed to connect to database");
            }


            Init();
            //Add_ColorGroupBox();
            groupBoxColorsChangeLocation();
            //Debug.WriteLine(ArdToJson(arduinos[0]));
            //Debug.Flush();

            Console.WriteLine(cb_arduinoID.SelectedIndex);
            Console.WriteLine("dropDown: "+cb_arduinoID.ValueMember);


            #region testing

            //List<RGBColor> culus = new List<RGBColor>();
            //int[] coloos = { 100, 150, 50 };
            //culus.Add(new RGBColor(coloos, 10));
            //coloos[0] = 250;
            //coloos[1] = 10;
            //coloos[2] = 63;
            //culus.Add(new RGBColor(coloos, 10));
            //coloos[0] = 200;
            //coloos[1] = 30;
            //coloos[2] = 75;
            //culus.Add(new RGBColor(coloos, 10));
            //Arduino testArduino = new Arduino(0);
            //testArduino._length = 20;
            //testArduino._speed = 0.7;
            //testArduino._colorList = culus;
            //_arduino = testArduino;
            //UploadArduino(new Button(), new EventArgs());

            #endregion
        }

        private void DarkMode()
        {
            //menu Strip
            menuStrip1.BackColor = backColor;
            amongusToolStripMenuItem.BackColor = backColor;
            amongusToolStripMenuItem.ForeColor = foreColor; 
            clearToolStripMenuItem.BackColor = backColor;
            clearToolStripMenuItem.ForeColor = foreColor;
            uploadToolStripMenuItem.BackColor = backColor;
            uploadToolStripMenuItem.ForeColor = foreColor;
            openToolStripMenuItem.BackColor = backColor;
            openToolStripMenuItem.ForeColor = foreColor;
            saveAsTemplateToolStripMenuItem.BackColor = backColor;
            saveAsTemplateToolStripMenuItem.ForeColor = foreColor;

            //dropDownMenu
            cb_arduinoID.BackColor = backColor;
            cb_arduinoID.ForeColor = foreColor;
           // cb_arduinoID.Margin = {0, 0, 0, 0};

            //labels
            lbl_Speed.ForeColor = foreColor;
            lengthLabel.ForeColor = foreColor;

            //Toolboxes
            tb_Speed.ForeColor = foreColor;
            tb_Speed.BackColor = backColor;
            lengthTextBox.ForeColor = foreColor;
            lengthTextBox.BackColor = backColor;
        }

        #region UpperControls
        private void Init()
        {
            List<Item> items = new List<Item>();
            items.Add(new Item() { Text = "choose ID", Value = null });
            for (int counter = 0; counter < 20; counter++)
            {
                items.Add(new Item() { Text = counter.ToString(), Value = counter.ToString() });
            }



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

        private void tb_Speed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bttn_Speed_Click(new Button(), EventArgs.Empty);
            }
        }

        private void lengthTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(new Button(), EventArgs.Empty);
            }
        }

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
                    _arduino._speed = dSpeed;
                    //_arduino._id = getIdFromDropDown();

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int.TryParse(lengthTextBox.Text, out _arduino._length);
            lengthLabel.Text = "length: " + _arduino._length.ToString();
        }

        private async void updateLengthFromId()
        {
            //GetLength(getIdFromDropDown());
            GetLength(_arduino._id);
            int dotCount = 0;
            string loadingText = "Loading";
            while (returnedLength == -1)
            {
                dotCount++;
                if (dotCount == 4)
                {
                    dotCount = 0;
                    loadingText = "Loading";
                }
                loadingText += ".";
                await Task.Delay(25);
                lengthLabel.Text = loadingText;
            }
            _arduino._length = returnedLength;
            lengthLabel.Text = "Length: " + returnedLength.ToString();
        }

        private void cb_arduinoID_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("ID changed");
            if (int.TryParse(cb_arduinoID.Text, out _arduino._id))
            {
                lbl_id.Text = "ID: " + _arduino._id;
                updateLengthFromId();
            }
        }
        #endregion

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

        private void Add_AddButton()
        {
            Button bttn_Add = new Button();
            colorsPanel.Controls.Add(bttn_Add);
            bttn_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            bttn_Add.ForeColor = System.Drawing.Color.Green;
            bttn_Add.BackColor = backColor;
            bttn_Add.Location = new System.Drawing.Point(30, 30);
            bttn_Add.Margin = new System.Windows.Forms.Padding(5);
            bttn_Add.Name = "bttn_Add";
            bttn_Add.Size = new System.Drawing.Size(70, 60);
            bttn_Add.TabIndex = 2;
            bttn_Add.Text = "+";
            bttn_Add.UseVisualStyleBackColor = true;
            bttn_Add.Click += new System.EventHandler(this.bttn_Add_Click);
        }

        private void Add_ColorGroupBox()
        {
            GroupBox gb = new GroupBox();
            colorsPanel.Controls.Add(gb);

            Button bttn_ChangeColor = new Button();
            Button bttn_Delete = new Button();
            Label lbl_KeyFrames = new Label();
            TextBox tb_KeyFrames = new TextBox();
            Button bttn_KeyFrames = new Button();

            gb.Controls.Add(bttn_ChangeColor);
            gb.Controls.Add(bttn_Delete);
            gb.Controls.Add(lbl_KeyFrames);
            gb.Controls.Add(tb_KeyFrames);
            gb.Controls.Add(bttn_KeyFrames);

            bttn_ChangeColor.Text = "Change Color";
            bttn_ChangeColor.Name = "ChangeColor_"+_usedId.ToString();
            bttn_ChangeColor.Location = new Point(20, 20);
            bttn_ChangeColor.BackColor = backColor;
            bttn_ChangeColor.ForeColor = foreColor;
            bttn_ChangeColor.Click += new System.EventHandler(bttn_ChangeColor_Click);

            bttn_Delete.Text = "-";
            bttn_Delete.Name = "Delete_" + _usedId.ToString();
            bttn_Delete.Size = new Size(20, 20);
            bttn_Delete.Location = new Point(_gbSize.Width - bttn_Delete.Size.Width - 5, 20);
            bttn_Delete.BackColor = backColor;
            bttn_Delete.ForeColor = foreColor; 
            bttn_Delete.Click += new System.EventHandler(bttn_Delete_Click);

            lbl_KeyFrames.Text = "0";
            lbl_KeyFrames.Location = new Point(_gbSize.Width / 2, _gbSize.Height / 2);
            lbl_KeyFrames.Name = "lbl_KeyFrames";
            lbl_KeyFrames.BackColor = backColor;
            lbl_KeyFrames.ForeColor = foreColor;
            lbl_KeyFrames.Size = new Size(60, 40);
            lbl_KeyFrames.Font = new Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            tb_KeyFrames.Location = new Point(_gbSize.Width/2 - tb_KeyFrames.Size.Width/2, 20);
            tb_KeyFrames.Name = "tb_KeyFrames";
            tb_KeyFrames.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_KeyFrames_KeyDown);
            tb_KeyFrames.BackColor = backColor;
            tb_KeyFrames.ForeColor = foreColor;

            bttn_KeyFrames.Text = "ok";
            bttn_KeyFrames.Name = "KeyFrames_" + _usedId.ToString();
            bttn_KeyFrames.Size = new Size(50, 30);
            bttn_KeyFrames.Location = new Point(tb_KeyFrames.Location.X+tb_KeyFrames.Size.Width + 10, tb_KeyFrames.Location.Y);
            bttn_KeyFrames.BackColor = backColor;
            bttn_KeyFrames.ForeColor = foreColor;
            bttn_KeyFrames.Click += new System.EventHandler(bttn_KeyFrames_Click);

            gb.Size = _gbSize;
            gb.Name = "Color_" + _usedId.ToString();
            gb.Location = new Point(30, 150);
            gb.BackColor = Color.Black;

            int[] rgb = {255, 255, 255};
            groupBoxes.Add(gb);
            _usedId++;
        }

        private int getId(Button sender)
        {
            //Getting id of the groupbox
            int id;
            var b = (Button)sender;
            string[] id_string = b.Name.Split('_');

            if (!int.TryParse(id_string[1], out id))
            {
                Console.WriteLine("Button id could not be read!");
                return -1;
            }
            else
            {
                return id;
            }
        }

        private int getId(TextBox sender)
        {
            int id;
            string[] id_string = sender.Name.Split('_');

            if (!int.TryParse(id_string[1], out id))
            {
                Console.WriteLine("TextBox id could not be read!");
                return -1;
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
                return -1;
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
            return -1;
        }

        private void bttn_ChangeColor_Click(object sender, EventArgs e)
        {
            int id = getId(((Button)sender));
            ColorDialog cdlg = new ColorDialog();
            cdlg.ShowDialog();
            Color color = cdlg.Color;
            string RGBValue = RGBConverter(color);
            groupBoxes[getParentGroupBoxIndex(id)].BackColor = color;
            groupBoxes[getParentGroupBoxIndex(id)].Text = RGBValue;
            //TODO: Save color value
            int[] rgbArray = RGBtoInt(RGBValue);
            _arduino._colorList[getParentGroupBoxIndex(id)].SetRGB(rgbArray[0], rgbArray[1], rgbArray[2]);
        }

        private string RGBConverter(System.Drawing.Color c)
        {
            return "RGB(" + c.R.ToString() + "," + c.G.ToString() + "," + c.B.ToString() + ")";
        }

        private int[] RGBtoInt(string color)
        {
            int[] rgb = new int[3];
            string a = color.Split('(')[1];
            string b = a.Split(')')[0];
            string[] c = b.Split(',');
            for (int i = 0; i < c.Length; i++)
            {
                int.TryParse(c[i], out rgb[i]);
            }

            return rgb;
        }

        private string RGBtoString(int[] rgb)
        {
            string strRGB = "RGB("+ rgb[0]+","+rgb[1]+","+rgb[2]+")";
            return strRGB;
        }

        private void bttn_Delete_Click(object sender, EventArgs e)
        {
            int id = getId((Button)sender);
            int gb_index = getParentGroupBoxIndex(id);
            colorsPanel.Controls.Remove(groupBoxes[gb_index]);
            groupBoxes.RemoveAt(gb_index);
            //TODO: remove from storage
            _arduino._colorList.RemoveAt(gb_index);

            
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
            _arduino._colorList.Add(new RGBColor(255, 255, 255, 0));
            groupBoxColorsChangeLocation();
            printArduino();
        }

        //private int getIdFromDropDown()
        //{
            
        //    string str_id = cb_arduinoID.Text;
        //    Console.WriteLine("ID selected: "+str_id);
        //    int id = 0;
        //    if (!int.TryParse(str_id, out id))
        //    {
        //        MessageBox.Show("Please choose valid id!");
        //        return 0;
        //    }
        //    return id;
            
        //}

        private void bttn_KeyFrames_Click(object sender, EventArgs e)
        {
            int id = getId((Button)sender);
            int gb_index = getParentGroupBoxIndex(id);
            Console.WriteLine("GB_index: "+gb_index);
            int keyFrames;
            Control tb_KeyFrames = FindControl(groupBoxes[gb_index], "tb_KeyFrames");
            Control lbl_KeyFrames = FindControl(groupBoxes[gb_index], "lbl_KeyFrames");
            if (int.TryParse(tb_KeyFrames.Text, out keyFrames))
            {
                lbl_KeyFrames.Text = keyFrames.ToString();
                Console.WriteLine("KeyFrames: "+keyFrames);
                //TODO: save to database
                _arduino._colorList[gb_index]._transitionFrames = keyFrames;
            }
            tb_KeyFrames.Text = "";

        }

        private void tb_KeyFrames_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int id = getId((TextBox)sender);
                int gb_index = getParentGroupBoxIndex(id);
                Console.WriteLine("GB_index: " + gb_index);
                int keyFrames;
                Control tb_KeyFrames = FindControl(groupBoxes[gb_index], "tb_KeyFrames");
                Control lbl_KeyFrames = FindControl(groupBoxes[gb_index], "lbl_KeyFrames");
                if (int.TryParse(tb_KeyFrames.Text, out keyFrames))
                {
                    lbl_KeyFrames.Text = keyFrames.ToString();
                    Console.WriteLine("KeyFrames: " + keyFrames);
                    //TODO: save to database
                    _arduino._colorList[gb_index]._transitionFrames = keyFrames;
                }
                tb_KeyFrames.Text = "";
            }
        }

        private void groupBoxColorsChangeLocation()
        {
            colorsPanel.AutoScroll = false;
            for (int i = 0; i < groupBoxes.Count; i++)
            {
                groupBoxes[i].Location = new Point(30, 20 + i * (_gbSize.Height + 10));
            }

            Control bttn_Add = FindControl(colorsPanel, "bttn_Add");
            bttn_Add.Location = new Point((_gbSize.Width+bttn_Add.Size.Width/2)/2, 20 + groupBoxes.Count * (_gbSize.Height + 10));
            colorsPanel.AutoScroll = true;
        }

        private void updateColorsPanelFromData()
        {
            groupBoxes.Clear();
            colorsPanel.Controls.Clear();
            Add_AddButton();
            cb_arduinoID.Text = _arduino._id.ToString();
            lbl_Speed.Text = "Speed: " + _arduino._speed;
            for (int i = 0; i < _arduino._colorList.Count; i++)
            {
                Add_ColorGroupBox();
                groupBoxes[i].Text = RGBtoString(_arduino._colorList[i]._rgb);
                Color color = new Color();
                color = Color.FromArgb(_arduino._colorList[i]._rgb[0], _arduino._colorList[i]._rgb[1],
                    _arduino._colorList[i]._rgb[2]);
                groupBoxes[i].BackColor = color;
                Control lbl_KeyFrames = FindControl(groupBoxes[i], "lbl_KeyFrames");
                lbl_KeyFrames.Text = _arduino._colorList[i]._transitionFrames.ToString();
            }
            groupBoxColorsChangeLocation();

        }
        #endregion

        private string printArduino()
        {
            string output = "";
            output += "Arduino" + _arduino._id + "\n";
            output += "Speed: " + _arduino._speed + "\n";
            output += "Length: " + _arduino._length + "\n";
            output += "Colors:" + "\n";
            foreach (var color in _arduino._colorList)
            {
                output += color._r + ", " + color._g + ", " + color._b;
                output += "; Frames: "+color._transitionFrames + "\n";
            }

            return output;
        }

        #region JsonConvertor

        private async void GetLength(int id)
        {
            Console.WriteLine("Get length for ID " + id);
            returnedLength = -1;
            FirebaseResponse response = await client.GetAsync("Arduino" + id + "/");
            Console.WriteLine("response: " + response);
            Data obj = response.ResultAs<Data>();
            Console.WriteLine("obj: " + obj);
            returnedLength = obj.numLights;
            //returnedLength = 50;
        }

        private async void UploadArduino(object sender, EventArgs e)
        {
            List<RGBColorBasic> tempColors = new List<RGBColorBasic>();
            tempColors = ColorCompiler(_arduino._colorList);
            //JsonArduino temp = new JsonArduino(ard, tempColors);
            //string jsonOut = JsonConvert.SerializeObject(temp);

            var data = new Data
            {
                colorLength = tempColors.Count,
                colors = tempColors,
                speed = _arduino._speed,
                numLights = _arduino._length,
                update = true
            };

            FirebaseResponse response = await client.GetAsync("Arduino" + _arduino._id + "/");
            Data obj = response.ResultAs<Data>();

            //Making sure user wants to upload
            string title = "Do you want to upload this Arduino?";
            string message = printArduino();
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.No)
            {
                return;
            }

            if (obj != null)
            {
                FirebaseResponse response2 = await client.DeleteAsync("Arduino" + _arduino._id + "/");
                response2.ResultAs<Data>();

                MessageBox.Show("Arduino " + _arduino._id + " updated.");
            }

            //if id does not yet exist
            SetResponse response1 = await client.SetAsync("Arduino" + _arduino._id + "/", data);
            response1.ResultAs<Data>();

            MessageBox.Show("Arduino " + _arduino._id + " created.");

        }

        private List<RGBColorBasic> ColorCompiler(List<RGBColor> colorsIn)
        {
            List<RGBColorBasic> colorsOut = new List<RGBColorBasic>();
            RGBColor CurrentColor;
            RGBColor NextColor;
            float dr;
            float dg;
            float db;
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
                dr = (float)(NextColor._r - CurrentColor._r) / (float)(CurrentColor._transitionFrames - 1);
                dg = (float)(NextColor._g - CurrentColor._g) / (float)(CurrentColor._transitionFrames - 1);
                db = (float)(NextColor._b - CurrentColor._b) / (float)(CurrentColor._transitionFrames - 1);
                for (int index2 = 0; index2 < CurrentColor._transitionFrames; index2++)
                {
                    rs.Add(CurrentColor._r + (int)((float)index2 * dr));
                    gs.Add(CurrentColor._g + (int)((float)index2 * dg));
                    bs.Add(CurrentColor._b + (int)((float)index2 * db));
                }
            }
            for(int index3 = 0; index3 < rs.Count; index3++)
            {
                colorsOut.Add(new RGBColorBasic(rs[index3], gs[index3], bs[index3]));
            }
            return colorsOut;
        }


        private void OpenArduino(object sender, EventArgs e)
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
                _arduino = arduin;
            }
            Console.WriteLine("Arduino opened");
            updateLengthFromId();
            updateColorsPanelFromData();

        }

        private void SaveArduino (object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Title = "Select save location";
            save.Filter = "Arduino Config Files (*.acf)|*.acf| All files (*.*)|*.*";
            if(save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamWriter write = new StreamWriter(File.Create(save.FileName));
                string json = JsonConvert.SerializeObject(_arduino);
                write.Write(json);
                write.Dispose();
            }
        }

        #endregion




    }
}
