using Godot;
using System;

public partial class nono : Control
{
	[Export]
	public PackedScene FillMod { get; set;}
	[Export]
	public PackedScene CrossMod { get; set;}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (TileMap.markId == 0){

		}
		else if (TileMap.markId <= 25 && TileMap.markId > 0) {
			var _target = GetNode("./ColorRect2/Board/"+TileMap.markId);
			if (swapbutton.mode == "Fill"){
				if (_target.GetChildCount()>0){
					if (_target.GetChild(0) != null) {
						_target.GetChild(0).QueueFree();
						TileMap.markId = 0;
					}
				} else {
					_target.AddChild(FillMod.Instantiate());
					TileMap.markId = 0;
				}
			}
			else if (swapbutton.mode == "Cross"){
				if (_target.GetChildCount()>0){
					if (_target.GetChild(0) != null) {
						_target.GetChild(0).QueueFree();
						TileMap.markId = 0;
					}
				} else {
					_target.AddChild(CrossMod.Instantiate());
					TileMap.markId = 0;
				}
			}
		}
	}
}
