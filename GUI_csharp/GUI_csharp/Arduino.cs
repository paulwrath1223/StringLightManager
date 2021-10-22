using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_csharp
{
    class Arduino
    {
        public int _id;
        public double _speed;
        public int _length;
        public List<RGBColor> _colorList = new List<RGBColor>();


        public Arduino(int id)
        {
            _id = id;
        }

        public string printArduino()
        {
            string output = "";
            output += "Arduino" + _id + "\n";
            output += "Speed: " + _speed + "\n";
            output += "Length: " + _length + "\n";
            output += "Colors:" + "\n";
            foreach (var color in _colorList)
            {
                output += color._r + ", " + color._g + ", " + color._b;
                output += "; Frames: " + color._transitionFrames + "\n";
            }

            return output;
        }



    }
}
