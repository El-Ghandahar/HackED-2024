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
				if (Check(checksum) == "Success"){
					GetNode("WordMark").AddChild(Word.Instantiate());
					complete = true;
				}
				else if (TileMap.markId == 0){

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
    }

	public string Check(Array key){
		Node targ;
		var result = 0;
		var filled = 0;
		for (var i = 1; i <= 25; i++){
			targ = GetNode("./ColorRect2/Board/"+i);
			if (targ.GetChildCount() > 0){
				if (targ.GetChild(0).GetClass() == "Filled"){
					for (var a = 1; a < key.Length; a++){
						var k = key.GetValue(a).ToString;
						if (i.ToString == k) {
							result++;
						}
					}
				}
			}
		}
		if (result == key.Length && filled == key.Length){
			return "Success";
		}
		else {
			return "";
		}
	}
}
