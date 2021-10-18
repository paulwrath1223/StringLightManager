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
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
            if(client == null)
            {
                MessageBox.Show("failed to connect to database");
            }

            Init();
            Add_ColorGroupBox();
            groupBoxColorsChangeLocation();
            //Debug.WriteLine(ArdToJson(arduinos[0]));
            //Debug.Flush();

            Console.WriteLine(cb_arduinoID.SelectedIndex);


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
            //UploadArduino(testArduino);

            #endregion
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
                    _arduino._speed = dSpeed;
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
            bttn_ChangeColor.BackColor = Color.Gray;
            bttn_ChangeColor.Click += new System.EventHandler(bttn_ChangeColor_Click);

            bttn_Delete.Text = "-";
            bttn_Delete.Name = "Delete_" + _usedId.ToString();
            bttn_Delete.Size = new Size(20, 20);
            bttn_Delete.Location = new Point(_gbSize.Width - bttn_Delete.Size.Width - 5, 20);
            bttn_Delete.BackColor = Color.Gray;
            bttn_Delete.Click += new System.EventHandler(bttn_Delete_Click);

            lbl_KeyFrames.Text = "0";
            lbl_KeyFrames.Location = new Point(_gbSize.Width / 2, _gbSize.Height / 2);
            lbl_KeyFrames.Name = "lbl_KeyFrames";
            lbl_KeyFrames.BackColor = Color.Gray;
            lbl_KeyFrames.Size = new Size(60, 40);
            lbl_KeyFrames.Font = new Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            tb_KeyFrames.Location = new Point(_gbSize.Width/2 - tb_KeyFrames.Size.Width/2, 20);
            tb_KeyFrames.Name = "tb_KeyFrames";

            bttn_KeyFrames.Text = "ok";
            bttn_KeyFrames.Name = "KeyFrames_" + _usedId.ToString();
            bttn_KeyFrames.Size = new Size(50, 30);
            bttn_KeyFrames.Location = new Point(tb_KeyFrames.Location.X+tb_KeyFrames.Size.Width + 10, tb_KeyFrames.Location.Y);
            bttn_KeyFrames.BackColor = Color.Gray;
            bttn_KeyFrames.Click += new System.EventHandler(bttn_KeyFrames_Click);

            gb.Size = _gbSize;
            gb.Name = "Color_" + _usedId.ToString();
            gb.Location = new Point(30, 150);

            int[] rgb = {255, 255, 255};
            _arduino._colorList.Add(new RGBColor(rgb, 0));
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
            //TODO: Save color value
            _arduino._colorList[getParentGroupBoxIndex(id)]._rgb = RGBtoInt(RGBValue);
        }

        private static String RGBConverter(System.Drawing.Color c)
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

        private void bttn_Delete_Click(object sender, EventArgs e)
        {
            int id = getId(sender);
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
            groupBoxColorsChangeLocation();
            printArduino();
        }

        private void bttn_KeyFrames_Click(object sender, EventArgs e)
        {
            int id = getId(sender);
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

        private void printArduino()
        {
            Console.WriteLine("Arduino" + _arduino._id);
            Console.WriteLine("Speed: " + _arduino._speed);
            Console.WriteLine("Length: " + _arduino._length);
            Console.WriteLine("Colors:");
            foreach (var color in _arduino._colorList)
            {
                for (int i = 0; i < color._rgb.Length; i++)
                {
                    Console.Write(color._rgb[i]+",");
                }

                Console.WriteLine("Frames: "+color._transitionFrames);
            }

            Console.WriteLine("--------------------------------------");
        }

        #region JsonConvertor

        private async void GetLength(int id)
        {
            returnedLength = -1;
            FirebaseResponse response = await client.GetAsync("Arduino/" + id);
            Data obj = response.ResultAs<Data>();
            returnedLength = obj.numLights;
        }

        private async void UploadArduino(Arduino ard)
        {
            List<RGBColorBasic> tempColors = new List<RGBColorBasic>();
            tempColors = ColorCompiler(ard._colorList);
            //JsonArduino temp = new JsonArduino(ard, tempColors);
            //string jsonOut = JsonConvert.SerializeObject(temp);

            var data = new Data
            {
                colorLength = tempColors.Count,
                colors = tempColors,
                speed = ard._speed,
                numLights = ard._length,
                update = 1
            };

            FirebaseResponse response = await client.GetAsync("Arduino" + ard._id + "/");
            Data obj = response.ResultAs<Data>();


            if (obj != null)
            {
                FirebaseResponse response1 = await client.UpdateAsync("Arduino" + ard._id + "/", data);
                response1.ResultAs<Data>();

                MessageBox.Show("Arduino " + ard._id + " updated.");
            }
            else
            {

                //if id does not yet exist
                SetResponse response1 = await client.SetAsync("Arduino" + ard._id + "/", data);
                response1.ResultAs<Data>();

                MessageBox.Show("Arduino " + ard._id + " created.");

            }
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


        private void OpenArduino ()
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

        }

        private void SaveArduino ()
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
