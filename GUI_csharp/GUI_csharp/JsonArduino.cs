using System;

public class JsonArduino
{
	public int ID = 0;
	public double speed = 0;
	public int length = 0;
	public bool _update = true;
	public List<RGBColorBasic> _colorList = new List<RGBColorBasic>();

	public JsonArduino(Arduino joe)
	{
		
	}
}
