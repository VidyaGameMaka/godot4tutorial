using Godot;
using System;

public partial class MainMenu : Node2D {

	public static MainMenu instance;

	[Export] private int defaultLayer;

	[Export] private CanvasLayer[] canvasLayers;

	public override void _Ready() {
		instance = this;

		ShowLayer(defaultLayer);
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
