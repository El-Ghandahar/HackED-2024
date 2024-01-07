using Godot;
using System;
using System.Collections.Generic;
using System.Text;

public partial class login_gui : Control
{
	[Signal]
	public delegate void PasswordEventHandler(string password);

	private const string _USER_NAME = "HackED-Participant";
	private string password = String.Empty;

	private List<string> wordList = new List<string>();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetWordList();
		for (int i = 0; i < wordList.Count; i++)
		{
			GD.Print(wordList[i]);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void GeneratePassword()
	{
		
	}

	private void GetWordList()
	{
		using var file = FileAccess.Open("res://assets/all.json", FileAccess.ModeFlags.Read);
		string content = file.GetAsText();
		List<string> tempList = new List<string>(content[2..^2].Split("\",\""));
		for (int i = 0; i < tempList.Count; i++)
		{
			if (tempList[i].Length == 5)
			{
				wordList.Add(tempList[i]);
			}
		}
	}
}
