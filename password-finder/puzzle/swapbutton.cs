using Godot;
using System;
using System.Security.Cryptography.X509Certificates;
public partial class swapbutton : Button
{
	public static string mode = "Fill";
	public Node self;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		self = GetNode("../Button");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var mark = GetNode("mode");
		bool pressed = ButtonPressed;
		if (mode == "Fill") {
			if (pressed){
				mode = "Cross";
			}
		} else if (mode == "Cross") {
			if (pressed) {
				mode = "Fill";
			}
			

		}
	}
}
