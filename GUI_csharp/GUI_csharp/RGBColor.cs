using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_csharp
{
    class RGBColor
    {
        public int[] _rgb = { 0, 0, 0 };
        public int _r = 0;
        public int _g = 0;
        public int _b = 0;
        public int _transitionFrames;

        public RGBColor(int r, int g, int b, int transitionFrames)
        {
            _rgb[0] = r;
            _rgb[1] = g;
            _rgb[2] = b;
            _r = r;
            _g = g;
            _b = b;

            _transitionFrames = transitionFrames;
        }

        public void SetRGB(int r, int g, int b)
        {
            _rgb[0] = r;
            _rgb[1] = g;
            _rgb[2] = b;
            _r = r;
            _g = g;
            _b = b;
        }

        public int[] GetRGB()
        {
            return _rgb;
        }
    }
}
