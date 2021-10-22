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
    }
}
