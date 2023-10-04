using Godot;
using System;

public partial class AudioMenu : CanvasLayer {

    //Labels
    private Label master_label, music_label, sfx_label, voice_label, male_label, female_label;

    //Bus Indexes
    private int master_index, music_index, sfx_index, voice_index, male_index, female_index;

    //Sliders
    private HSlider master_hslider, music_hslider, sfx_hslider, voice_hslider, male_hslider, female_hslider;

	public override void _Ready() {
        //Assign Labels
        master_label = GetNode<Label>("master_label");
        music_label = GetNode<Label>("music_label");
        sfx_label = GetNode<Label>("sfx_label");
        voice_label = GetNode<Label>("voice_label");
        male_label = GetNode<Label>("male_label");
        female_label = GetNode<Label>("female_label");

        //Assign Bus Indexes
        master_index = AudioServer.GetBusIndex("Master");
        music_index = AudioServer.GetBusIndex("Music");
        sfx_index = AudioServer.GetBusIndex("SFX");
        voice_index = AudioServer.GetBusIndex("Voice");
        male_index = AudioServer.GetBusIndex("Male");
        female_index = AudioServer.GetBusIndex("Female");

        //Set Initial Slider Values
        master_hslider = GetNode<HSlider>("master_hslider");
        music_hslider = GetNode<HSlider>("music_hslider");
        sfx_hslider = GetNode<HSlider>("sfx_hslider");
        voice_hslider = GetNode<HSlider>("voice_hslider");
        male_hslider = GetNode<HSlider>("male_hslider");
        female_hslider = GetNode<HSlider>("female_hslider");

        master_hslider.Value = GameMaster.gameData.masterVolume;
        music_hslider.Value = GameMaster.gameData.musicVolume;
        sfx_hslider.Value = GameMaster.gameData.sfxVolume;
        voice_hslider.Value = GameMaster.gameData.voiceVolume;
        male_hslider.Value = GameMaster.gameData.maleVolume;
        female_hslider.Value = GameMaster.gameData.femaleVolume;
;    }

	
	public void _on_slider_value_changed(float myFloat, string myString) {
        switch (myString) {
            case "Master":
                master_label.Text = "Master: " + myFloat.ToString();
                AudioServer.SetBusVolumeDb(master_index, Mathf.LinearToDb(myFloat));
                GameMaster.gameData.masterVolume = myFloat;
                break;
            case "Music":
                music_label.Text = "Music: " + myFloat.ToString();
                AudioServer.SetBusVolumeDb(music_index, Mathf.LinearToDb(myFloat));
                GameMaster.gameData.musicVolume = myFloat;
                break;
            case "SFX":
                sfx_label.Text = "SFX: " + myFloat.ToString();
                AudioServer.SetBusVolumeDb(sfx_index, Mathf.LinearToDb(myFloat));
                GameMaster.gameData.sfxVolume = myFloat;
                break;
            case "Voice":
                voice_label.Text = "Voice: " + myFloat.ToString();
                AudioServer.SetBusVolumeDb(voice_index, Mathf.LinearToDb(myFloat));
                GameMaster.gameData.voiceVolume = myFloat;
                break;
            case "Male":
                male_label.Text = "Male: " + myFloat.ToString();
                AudioServer.SetBusVolumeDb(male_index, Mathf.LinearToDb(myFloat));
                GameMaster.gameData.maleVolume = myFloat;
                break;
            case "Female":
                female_label.Text = "Female: " + myFloat.ToString();
                AudioServer.SetBusVolumeDb(female_index, Mathf.LinearToDb(myFloat));
                GameMaster.gameData.femaleVolume = myFloat;
                break;
            default:
                GD.Print("Requested Slider not specified: " + myString);
                break;
        }


        

    }
}
