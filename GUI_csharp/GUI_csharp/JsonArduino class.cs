using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_csharp
{
	class JsonArduino
	{
		public int ID = 0;
		public double speed = 0;
		public int length = 0;
		public bool update = true;
		public List<RGBColorBasic> colors = new List<RGBColorBasic>();

		public JsonArduino(Arduino joe, List<RGBColorBasic> cs)
		{
			ID = joe._id;
			speed = joe._speed;
			length = joe._length;
			colors = cs;
		}


	}
	
}
