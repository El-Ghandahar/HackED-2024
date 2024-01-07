using Godot;
using System;
using System.Collections;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;

public partial class nono : Control
{
	[Export]
	public PackedScene FillMod { get; set;}
	[Export]
	public PackedScene CrossMod { get; set;}
	[Export]
	public PackedScene Word { get; set;}
	public int[] checksum;
	private bool complete = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		checksum = new int[] {1,5,6,7,10,11,13,15,16,19,20,21,25};
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
    public override void _Input(InputEvent @event)
    {
		if (complete == false) {
			if (@event.IsActionPressed("click")){

				if (TileMap.markId <= 25 && TileMap.markId > 0) {
				var _target = GetNode("./ColorRect2/Board/"+TileMap.markId);
					if (_target.GetChildCount()>0){
						if (_target.GetChild(0).GetMeta("filled").AsBool() == true) {
							_target.GetChild(0).QueueFree();
							TileMap.markId = 0;
						} else {
							_target.GetChild(0).QueueFree();
							_target.AddChild(CrossMod.Instantiate());
							TileMap.markId = 0;
						}
					} else {
						_target.AddChild(FillMod.Instantiate());
						TileMap.markId = 0;
					}
				}
			}
			else if (@event.IsActionPressed("right click")){
				if (TileMap.markId <= 25 && TileMap.markId > 0) {
					var _target = GetNode("./ColorRect2/Board/"+TileMap.markId);
					if (_target.GetChildCount()>0){
						if (_target.GetChild(0).GetMeta("filled").AsBool() == false) {
							_target.GetChild(0).QueueFree();
							TileMap.markId = 0;
						} else {
							_target.GetChild(0).QueueFree();
							_target.AddChild(CrossMod.Instantiate());
							TileMap.markId = 0;
						}
					} else {
						_target.AddChild(CrossMod.Instantiate());
						TileMap.markId = 0;
					}
				}
			}
			if (Check(checksum) == "Success"){
				GetNode("WordMark").AddChild(Word.Instantiate());
				complete = true;
			}
			
		}
    }

	public string Check(Array key){
		//init vars
		Node targ; //markers
		var result = 0;
		var filled = 0;

		for (var i = 0; i < 25; i++){ //check every marker
			targ = GetNode("./ColorRect2/Board/"+(i+1)); //define marker
			if (targ.GetChildCount() > 0){	// make sure it has kids
				if (targ.GetChild(0).GetMeta("filled").AsBool() == true){	// right type of kids
					for (var a = 0; a < key.Length; a++){	// check if correct marker
						var k = key.GetValue(a).ToString();
						if ((i+1).ToString() == k) {
							result++;	// increment correct marker count
						}
					}
					filled++; // increment markers filled
				}
			}
		}
		GD.Print(result+","+filled);
		if (result == key.Length && filled == key.Length){
			return "Success";
		}
		else {
			return "";
		}
	}
}
