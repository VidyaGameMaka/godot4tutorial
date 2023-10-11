using Godot;
using System;

public partial class MainMenu : Node2D {

	public static MainMenu instance;

	[Export] private int defaultLayer;

	[Export] private CanvasLayer[] canvasLayers;

    [ExportGroup("Main Menu Buttons")]
    [Export] private Button startButton;
    [Export] private Button audioButton;
    [Export] private Button videoButton;
    [Export] private Button quitButton;

    public override void _Ready() {
		instance = this;

		SetupButtons();

		ShowLayer(defaultLayer);
	}

	private void SetupButtons() {
		startButton.Text = Lng.mainMenu[0]; //start
		audioButton.Text = Lng.mainMenu[1]; //audio
		videoButton.Text = Lng.mainMenu[2]; //video
		quitButton.Text = Lng.mainMenu[3]; //quit
	}

	public void ShowLayer(int myInt) {
		HideAllLayers();
		canvasLayers[myInt].Show();
	}

	private void HideAllLayers() {
		foreach (var layer in canvasLayers) {
			layer.Hide();
		}
	}

    public void _on_quit_button_button_up() {
        SceneManager.instance.QuitGame();
    }

}
