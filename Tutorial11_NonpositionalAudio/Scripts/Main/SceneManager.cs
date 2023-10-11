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

    /// <summary>
    /// Use this Dictionary whenever you add or change a scene you want included in the Scene Manager.
    /// Scene Enum, Scene Path, Pretty Scene Name, pauseAllowed
    /// </summary>
    public Dictionary<eSceneNames, SceneCstr> sceneDictionary = new Dictionary<eSceneNames, SceneCstr>() {
        {eSceneNames.Main, new SceneCstr("res://Scenes/10_Main.tscn", "Main", false) },
        {eSceneNames.Level1, new SceneCstr("res://Scenes/20_Level1.tscn", "Level One", true) },
        {eSceneNames.Level2, new SceneCstr("res://Scenes/30_Level2.tscn", "Level Two", true) },
    };

    public override void _Ready() {
        instance = this;

        //This will tell us that SceneManager object was included in autoload.
        GD.Print("(SceneManager) SceneManager Ready");
    }

    public void ChangeScene(eSceneNames mySceneName) {
        string myPath = sceneDictionary[mySceneName].path;
        GameMaster.pauseAllowed = sceneDictionary[mySceneName].pauseAllowed;
        GameMaster.playerData.savedScene = mySceneName;
        GetTree().ChangeSceneToFile(myPath);
    }

    //Receive notification from the Operating System's Window Manager
    public override void _Notification(int what) {
        if (what == NotificationWMCloseRequest) {
            GD.Print("(SceneManager) Quit Requested by Window Manager.");

            //Save the Current Game on SceneManager and Quit
            QuitGame();
        }
    }

    //Save GameData and PlayerData then Quit
    public void QuitGame() {
        GD.Print("(SceneManager) Saving and Quitting");
        GameMaster.SaveGameData();
       
        GameMaster.SavePlayerData(GameMaster.currentSlotNum);
        GetTree().Quit();
    }
}