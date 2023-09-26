using Godot;
using System;

public partial class MainMenu20 : Node2D {

	[Export] public Label myLabel;

	private int count = 0;

	public override void _Ready() {

		myLabel.Text = "Changed the label on Ready in C# !";

	}

	
	public override void _Process(double delta) { }

	public void _on_button_1_button_up() {
		
		count++;
		myLabel.Text = "The button changed the text. It has been clicked: " + count;

	}
}
