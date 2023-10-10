using Godot;
using System;
using System.Linq;

public partial class VideoMenu : CanvasLayer {

    [ExportGroup("Window")]
    [Export] private Label winLabel;
    [Export] private CheckButton winCheckButton;

    [ExportGroup("Resolution")]
    [Export] private Label resLabel;
    [Export] private OptionButton resOptionsButton;

    private int mySelectedRez = 0;


    public override void _Ready() {
        //Set the check button's toggle mode to match the window's setting
        if (DisplayServer.WindowGetMode() == DisplayServer.WindowMode.Fullscreen) {
            winCheckButton.ButtonPressed = true;
        } else {
            winCheckButton.ButtonPressed = false;
        }

        //Set Initial Value for the Window Label
        SetWindowLabel(winCheckButton.ButtonPressed);

        //Add the defined resolutions above to the options button
        AddResolutionsToButton();
	}

    private void SetWindowLabel(bool isSet) {
        if (isSet == true) {
            winLabel.Text = "Full Screen";
        } else {
            winLabel.Text = "Windowed";
        }
    }

    private void AddResolutionsToButton() {
        //List of Resolutions is stored in GameData.cs
        //Iterate through each entry in resolutionList array and add them as strings to the button       
        foreach (var item in GameMaster.gameData.windowResolutions) {           
            string myString = item.Key + "x" + item.Value;
            resOptionsButton.AddItem(myString);
        }
    }

    public void _on_back_button_button_up() {
        GameMaster.SaveGameData();
        MainMenu.instance.ShowLayer(0);
    }

    public void _on_windowmode_check_button_toggled(bool toggled) {
        GameMaster.gameData.isFullScreen = toggled;
        SetWindowLabel(toggled);
    }

    public void _on_resolution_options_button_item_selected(int argRez) {
        mySelectedRez = argRez;        
    }

    public void _on_apply_button_button_up() {
        GameMaster.gameData.resolutionIndex = mySelectedRez;
        //Actual application of the Video Settins are in GameMaster so that the code is only written once and
        //can be run at the start of the game when GameMaster initalizes on autoload
        GameMaster.ApplyGameDataVideoSettings();
    }

}
