using Godot;
using System;

public partial class PlayerDataTest : Node {

	[Export] public Label myLabel;

	public override void _Ready() {

		myLabel.Text = "GetTree().CurrentScene.SceneFilePath: " + GetTree().CurrentScene.SceneFilePath + "\n";
		myLabel.Text += "GameMaster Current Slot " + GameMaster.currentSlotNum + "\n";
		myLabel.Text += "Sample Dictionary Text: " + GameMaster.playerData.sampleDictionary["test"];


    }

	
}
