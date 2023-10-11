using Godot;
using System;

public partial class AutoLoadMusic : Node {
	
	public override void _Ready() {
        ChangeMusic();
	}

    public void ChangeMusic() {
        string scenePath = GetTree().CurrentScene.SceneFilePath;
        foreach (var item in MusicData.musicDic) {
            if (item.Key == GetTree().CurrentScene.SceneFilePath) {
                Snd.inst.PlayMusic(item.Value);
                GD.Print("(AutoloadMusic): " + scenePath + " Playing: " + item.Value);
            }
        }
    }


}
