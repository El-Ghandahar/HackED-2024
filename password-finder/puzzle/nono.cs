using Godot;
using System;

public partial class nono : Control
{
	[Export]
	public PackedScene FillMod { get; set;}
	public PackedScene CrossMod { get; set;}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
