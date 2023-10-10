using Godot;
using System;

public partial class Snd : Node2D {

    public static Snd inst;

	[Export] private AudioStreamPlayer musicPlayer;
    [Export] private AudioStreamPlayer voicePlayer;
    [Export] private AudioStreamPlayer malePlayer;
    [Export] private AudioStreamPlayer femalePlayer;
    [Export] private AudioStreamPlayer[] sfxPlayers;

    private AudioStream testStream;
    private string currentMusicPlaying = string.Empty;

    public bool voiceIsPlaying { get; private set; } = false;

    public override void _Ready() {
        inst = this;
    }

    public override void _Process(double delta) {
        //Update field we are going to share for voice
        voiceIsPlaying = voicePlayer.Playing;
    }
    
    public void PlayMusic(string myPath) {
        if (currentMusicPlaying == myPath) { return; }
        currentMusicPlaying = myPath;
        musicPlayer.Stream = GD.Load<AudioStream>(myPath); ;
        musicPlayer.Play();
    }

    public void StopMusic() {
        musicPlayer.Stop();
    }

    public void PlayVoice(string myPath) {
        voicePlayer.Stream = GD.Load<AudioStream>(myPath);
        voicePlayer.Play();
    }

    public void PlayMale(string myPath) {
        malePlayer.Stream = GD.Load<AudioStream>(myPath);
        malePlayer.Play();
    }

    public void PlayFemale(string myPath) {
        femalePlayer.Stream = GD.Load<AudioStream>(myPath);
        femalePlayer.Play();
    }

    public void PlaySFX(string myPath) {
        //Find an available player to play
        foreach (var player in sfxPlayers) {
            if (player.Playing == false) {
                player.Stream = GD.Load<AudioStream>(myPath);
                player.Play();
            }
        }
    }

}
