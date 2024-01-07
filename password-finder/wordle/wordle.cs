using Godot;
using System;
using System.Collections.Generic;

public partial class wordle : Control
{
	[Export]
	public string word {get;set;} = "word";
	[Export]
	public PackedScene VBoxContainerScene {get;set;}

	private List<string> _passwordSplit = new List<String>();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		HBoxContainer hBoxContainer = GetNode<HBoxContainer>("guesses");
		for (int i = 0; i < _passwordSplit.Count; i++)
		{
			VBoxContainer vBoxContainer = (VBoxContainer)VBoxContainerScene.Instantiate();
			hBoxContainer.AddChild(vBoxContainer);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void GetPassword(string[] passwordSplit)
	{
		_passwordSplit = new List<string>(passwordSplit);
	}
}
