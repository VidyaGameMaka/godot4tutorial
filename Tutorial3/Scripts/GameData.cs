using Godot;
using System;

public class GameData {

    //Video Settings
    public bool fullScreen = true;
    public bool vsync = true;

    //Dialogue UI Settings
    public float dialogueBG_alpha = 0.4f;
    public int fontSizeMax = 11;

    //Audio Volumes
    public float masterMaxVolume = 1;
    public float musicMaxVolume = 0.40f;
    public float soundfxMaxVolume = 1;
    public float voiceMaxVolume = 1;
    public float femaleMaxVolume = 1;
    public float maleMaxVolume = 1;

    //Default Audio Volumes
    public const float default_masterMaxVolume = 1;
    public const float default_musicMaxVolume = 0.40f;
    public const float default_soundfxMaxVolume = 1;
    public const float default_voiceMaxVolume = 1;
    public const float default_femaleMaxVolume = 1;
    public const float default_maleMaxVolume = 1;

}