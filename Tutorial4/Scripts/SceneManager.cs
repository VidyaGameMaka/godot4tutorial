using Godot;
using System;
using System.Collections.Generic;

public enum eSceneNames {
    Main = 10,
    Level1 = 20,
    Level2 = 30
}

public partial class SceneManager : Node {

    public static SceneManager instance;

    public Dictionary<eSceneNames, SceneData> sceneDictionary = new Dictionary<eSceneNames, SceneData>() {
        {eSceneNames.Main, new SceneData("res://Scenes/10_Main.tscn", "Main", false) },
        {eSceneNames.Level1, new SceneData("res://Scenes/20_Level1.tscn", "Level One", true) },
        {eSceneNames.Level2, new SceneData("res://Scenes/30_Level2.tscn", "Level Two", true) },
    };

    public override void _Ready() {
        instance = this;

        //This will tell us that SceneManager object was included in autoload.
        GD.Print("SceneManager Ready");
    }

    public void ChangeScene(eSceneNames mySceneName) {
        string myPath = sceneDictionary[mySceneName].path;
        GameMaster.pauseAllowed = sceneDictionary[mySceneName].pauseAllowed;
        GetTree().ChangeSceneToFile(myPath);
    }

    //Todo - Save the current game before the user quits
    public void QuitGame() {
        GameMaster.SaveGameData();
        GameMaster.SavePlayerData(GameMaster.currentSlotNum);
        GetTree().Quit();
    }
}