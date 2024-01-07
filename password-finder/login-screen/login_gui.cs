using Godot;
using System;
using System.Collections.Generic;

public partial class login_gui : Control
{
	[Signal]
	public delegate void PasswordEventHandler(string password);

	private const string _USER_NAME = "HackED-Participant";
	private string password = String.Empty;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void GeneratePassword()
	{
		
	}
}
