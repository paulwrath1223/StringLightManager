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

        public RGBColor(int[] rgbIn, int transitionFrames)
        {
            _r = rgbIn[0];
            _g = rgbIn[1];
            _b = rgbIn[2];
            _rgb = rgbIn;  // how do that?
            _transitionFrames = transitionFrames;
        }
    }
}
