using Godot;
using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public partial class TileMap : Godot.TileMap
{
	private TileMap tilemap;
	private Vector2 mouse;
	private Vector2I newcell;
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
		
		if (@event.IsActionPressed("click")) {
			mouse = GetLocalMousePosition();
			var mappos = tilemap.LocalToMap(mouse);
			var cell = tilemap.GetCellTileData(0, mappos);
			var xorg = cell.TextureOrigin[0];
			if (xorg == 0) {
				xorg = 1;
			} else if (xorg == 1) {
				xorg = 0;
			}
			newcell = new Vector2I(xorg,cell.TextureOrigin[1]);
			tilemap.SetCell(0, newcell, 0, mappos);
		}
    }

}
