using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_csharp
{
	class JsonArduino
	{

		public double speed = 0;
		public int colorLength = 0;
		public bool update = true;
		public int numLights = 0;
		public List<RGBColorBasic> colors = new List<RGBColorBasic>();

		public JsonArduino(Arduino joe, List<RGBColorBasic> cs)
		{

			speed = joe._speed;
			numLights = joe._length;
			colors = cs;
			colorLength = cs.Count;
		}


	}
	
}
