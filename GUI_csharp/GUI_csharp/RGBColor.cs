using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_csharp
{
    class RGBColor
    {
        public int[] _rgb = {0, 0, 0};
        public int _transitionFrames;

        RGBColor(int[] rgb, int transitionFrames)
        {
            _rgb = rgb;
            _transitionFrames = transitionFrames;
        }
    }
}
