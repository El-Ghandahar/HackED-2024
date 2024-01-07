using Godot;
using System;
using System.Collections.Generic;

public partial class wordle : Control
{
	[Export]
	public string word {get;set;} = "word";
	[Export]
	public PackedScene VBoxContainerScene {get;set;}

	private List<string> _passwordSplit = new List<String>() {"Banana", "Dog", "Pizza"};
	private List<VBoxContainer> _letterContainers = new List<VBoxContainer>();
	private LineEdit textField;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		HBoxContainer hBoxContainer = GetNode<HBoxContainer>("guesses");
		textField = GetNode<LineEdit>("TextField");
		textField.MaxLength = _passwordSplit.Count;
		for (int i = 0; i < _passwordSplit.Count; i++)
		{
			VBoxContainer vBoxContainer = (VBoxContainer)VBoxContainerScene.Instantiate();
			_letterContainers.Add(vBoxContainer);
			hBoxContainer.AddChild(vBoxContainer);
			vBoxContainer.GetNode<Label>("%Label").Text = "";
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

	private void OnTextFieldChanged(string newText)
	{
		GD.Print(newText);
		_letterContainers[newText.Length - 1].GetNode<Label>("%Label").Text = newText[newText.Length - 1].ToString();
	}

	private void OnTextFieldSubmit(string newText)
	{
		GD.Print(newText);
	}
}
