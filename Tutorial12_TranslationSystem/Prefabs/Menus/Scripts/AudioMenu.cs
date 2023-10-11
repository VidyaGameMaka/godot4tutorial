using Godot;
using System;

public partial class AudioMenu : CanvasLayer {

    //Bus Indexes are configured in GameMaster.SetupAudioBusIndexes()

    //Labels
    private Label master_label, music_label, sfx_label, voice_label, male_label, female_label;

    //Sliders
    private HSlider master_hslider, music_hslider, sfx_hslider, voice_hslider, male_hslider, female_hslider;

    //Buttons
    private Button backButton;

	public override void _Ready() {
        //Assign Labels
        master_label = GetNode<Label>("master_label");
        music_label = GetNode<Label>("music_label");
        sfx_label = GetNode<Label>("sfx_label");
        voice_label = GetNode<Label>("voice_label");
        male_label = GetNode<Label>("male_label");
        female_label = GetNode<Label>("female_label");      

        //Assign Slider Nodes
        master_hslider = GetNode<HSlider>("master_hslider");
        music_hslider = GetNode<HSlider>("music_hslider");
        sfx_hslider = GetNode<HSlider>("sfx_hslider");
        voice_hslider = GetNode<HSlider>("voice_hslider");
        male_hslider = GetNode<HSlider>("male_hslider");
        female_hslider = GetNode<HSlider>("female_hslider");

        //Set the initial slider values
        master_hslider.Value = GameMaster.gameData.masterVolume;
        music_hslider.Value = GameMaster.gameData.musicVolume;
        sfx_hslider.Value = GameMaster.gameData.sfxVolume;
        voice_hslider.Value = GameMaster.gameData.voiceVolume;
        male_hslider.Value = GameMaster.gameData.maleVolume;
        female_hslider.Value = GameMaster.gameData.femaleVolume;

        //Buttons
        backButton = GetNode<Button>("backButton");
        backButton.Text = Lng.mainMenu[4]; //Back
    }


	public void _on_slider_value_changed(float myFloat, string myString) {
        switch (myString) {
            case "Master":
                master_label.Text = Lng.audioMenu[0] + ": " + (int)(myFloat * 100) + "%"; //Master
                AudioServer.SetBusVolumeDb(GameMaster.master_index, Mathf.LinearToDb(myFloat));
                GameMaster.gameData.masterVolume = myFloat;
                break;
            case "Music":
                music_label.Text = Lng.audioMenu[1] + ": " + (int)(myFloat * 100) + "%"; //Music
                AudioServer.SetBusVolumeDb(GameMaster.music_index, Mathf.LinearToDb(myFloat));
                GameMaster.gameData.musicVolume = myFloat;
                break;
            case "SFX":
                sfx_label.Text = Lng.audioMenu[2] + ": " + (int)(myFloat * 100) + "%"; //SFX
                AudioServer.SetBusVolumeDb(GameMaster.sfx_index, Mathf.LinearToDb(myFloat));
                GameMaster.gameData.sfxVolume = myFloat;
                break;
            case "Voice":
                voice_label.Text = Lng.audioMenu[3] + ": " + (int)(myFloat * 100) + "%"; //Voice
                AudioServer.SetBusVolumeDb(GameMaster.voice_index, Mathf.LinearToDb(myFloat));
                GameMaster.gameData.voiceVolume = myFloat;
                break;
            case "Male":
                male_label.Text = Lng.audioMenu[4] + ": " + (int)(myFloat * 100) + "%"; //Male
                AudioServer.SetBusVolumeDb(GameMaster.male_index, Mathf.LinearToDb(myFloat));
                GameMaster.gameData.maleVolume = myFloat;
                break;
            case "Female":
                female_label.Text = Lng.audioMenu[5] + ": " + (int)(myFloat * 100) + "%"; //Female
                AudioServer.SetBusVolumeDb(GameMaster.female_index, Mathf.LinearToDb(myFloat));
                GameMaster.gameData.femaleVolume = myFloat;
                break;
            default:
                GD.Print("Requested Slider not specified: " + myString);
                break;
        }
    }

    public void _on_back_button_button_up() {
        GameMaster.SaveGameData();
        MainMenu.instance.ShowLayer(0);
    }

}
