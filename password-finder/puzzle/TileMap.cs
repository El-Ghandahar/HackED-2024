using Godot;
using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public partial class TileMap : Godot.TileMap
{
	public static float markId = 0;
	private TileMap tilemap;
	private Vector2 mouse;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		tilemap = GetNode("../Board") as TileMap;
	}

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}

    public override void _Input(InputEvent @event)
    {
		
		if (@event.IsActionPressed("click")||@event.IsActionPressed("rightclick")) {
			mouse = GetLocalMousePosition();
			var mappos = tilemap.LocalToMap(mouse);
			var center = tilemap.MapToLocal(mappos);
			markId = (center.X-224)/64+(center.Y-160)/64*5;
		}
    }

}