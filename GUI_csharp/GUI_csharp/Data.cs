using System.Collections.Generic;

namespace GUI_csharp
{
    internal class Data
    {
        public int colorLength { get; set; }
        public List<RGBColorBasic> colors { get; set; }
        public double speed { get; set; }
        public int numLights { get; set; }
        public bool update { get; set; }
    }
}