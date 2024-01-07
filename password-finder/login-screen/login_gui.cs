using Godot;
using System;
using System.Collections.Generic;
using System.Text;

public partial class login_gui : Control
{
	[Signal]
	public delegate void PasswordEventHandler(string[] passwordSplit);
	[Signal]
	public delegate void StartGameEventHandler();

	[Export]
	public int wordCount {get;set;} = 3;

	private const string _USER_NAME = "HackED-Participant";
	private List<string> passwordSplit = new List<string>();
	private string password = String.Empty;

	private List<string> wordList = new List<string>();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetWordList();
		GeneratePassword();
		password = String.Join("", passwordSplit);
		GD.Print(password);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void GeneratePassword()
	{
		var random = new RandomNumberGenerator();
		random.Randomize();
		for (int i = 0; i < wordCount; i++)
		{
			int tempNum = random.RandiRange(0, wordList.Count - 1);
			passwordSplit.Add($"{Char.ToUpper(wordList[tempNum][0])}{wordList[tempNum][1..]}");
		}
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

	private void UsernameFocusEntered()
	{
		Timer usernameTimer = GetNode<Timer>("UsernameTimer");
		usernameTimer.Start();
	}

	private void LineEnter(string new_text)
	{
		LoginSubmit();
	}

	private void LoginSubmit()
	{
		LineEdit usernameInput = GetNode<LineEdit>("%UsernameInput");
		LineEdit passwordInput = GetNode<LineEdit>("%PasswordInput");
		Label feedbackLabel = GetNode<Label>("%FeedbackLabel");

		if (usernameInput.Text != _USER_NAME || passwordInput.Text != password)
		{
			feedbackLabel.Text = "Incorrect username or password";
		}
		else
		{
			feedbackLabel.Text = "Correct!";
		}
	}

	private void ForgotPassword()
	{
		EmitSignal(nameof(StartGame));
	}

	private void OnUsernameTimerTimeout()
	{
		LineEdit usernameInput = GetNode<LineEdit>("%UsernameInput");
		if (usernameInput.Text != _USER_NAME)
		{
			usernameInput.Text += _USER_NAME[usernameInput.Text.Length];
		}
		else
		{
			Timer usernameTimer = GetNode<Timer>("UsernameTimer");
			usernameTimer.Stop();
		}
	}
}
