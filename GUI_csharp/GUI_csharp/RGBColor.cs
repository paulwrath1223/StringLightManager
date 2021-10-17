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

        RGBColor(int[] rgb, int transitionFrames)
        {
            _r = rgb[0];
            _g = rgb[1];
            _b = rgb[2];
            _rgb = [ _r, _g, _b ];  // how do that?
            _transitionFrames = transitionFrames;
        }
    }
}
