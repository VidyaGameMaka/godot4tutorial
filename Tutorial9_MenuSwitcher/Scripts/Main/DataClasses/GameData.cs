using Godot;
using System;

public class GameData {

    //Video Settings
    public DisplayServer.WindowMode WindowMode = DisplayServer.WindowMode.Windowed;
    public DisplayServer.VSyncMode vSync = DisplayServer.VSyncMode.Enabled; 

    //Dialogue UI Settings
    public float dialogueBG_alpha = 0.4f;
    public int fontSizeMax = 11;

    //Audio Volumes
    public float masterVolume = 1;
    public float sfxVolume = 1;
    public float musicVolume = 0.40f;
    public float voiceVolume = 1;  
    public float maleVolume = 1;
    public float femaleVolume = 1;

    //Windowed Resolution Presets
    public Godot.Collections.Dictionary<int, int> windowResolutions = new Godot.Collections.Dictionary<int, int>() {
        { 3840, 2160 },
        { 2560, 1440 },
        { 1920, 1080 },
        { 960, 540 },
        { 480, 270 },
    };

    //Default Audio Volumes
    public const float default_masterMaxVolume = 1;
    public const float default_musicMaxVolume = 0.40f;
    public const float default_soundfxMaxVolume = 1;
    public const float default_voiceMaxVolume = 1;
    public const float default_femaleMaxVolume = 1;
    public const float default_maleMaxVolume = 1;

}