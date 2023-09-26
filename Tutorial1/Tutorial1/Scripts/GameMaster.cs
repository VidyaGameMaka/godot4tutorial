using Godot;
using System;

public partial class GameMaster : Node {

    //Release.Features.Patch
    public static string gameVersion = "0.1.1 Build Date: 9/24/2023";

    //The slot number that the game will save and load to by default
    public static int currentSlotNum = 0;

    public static bool paused = false;
    public static bool ignoreUserInput = false;

    //Base Player Data
    public static PlayerData playerData = new PlayerData();

    //Game Data
    public static GameData gameData = new GameData();

    //Data Types Enum
    public enum SaveTypes { playerDat, gameDat }

    //Save Slots
    public static PlayerData loadedPlayerDataSlot1 = null;
    public static PlayerData loadedPlayerDataSlot2 = null;
    public static PlayerData loadedPlayerDataSlot3 = null;

    public override void _Ready() {
        GD.Print("Gamemaster Ready");

        //Populate Dictionary of Base Player Data
        playerData.init();

        //Load Game System Data
        LoadGameData();

        //Load saved Player Data into seperate fields so they can be displayed / manipulated on the save/load menu
        LoadPlayerDataSlot(1);
        LoadPlayerDataSlot(2);
        LoadPlayerDataSlot(3);

        //Set full screen
        //DisplayServer.WindowSetMode(DisplayServer.WindowMode.Fullscreen);
    }


    public static void SavePlayerData(int slotNum) { Save(SaveTypes.playerDat, slotNum); }
    public static void LoadPlayerData(int slotNum) { Load(SaveTypes.playerDat, slotNum, false); }

    public static void LoadPlayerDataSlot(int slotNum) { Load(SaveTypes.playerDat, slotNum, true); }
    public static void DeletePlayerData(int slotNum) { Delete(SaveTypes.playerDat, slotNum); }


    public static void SaveGameData() { Save(SaveTypes.gameDat, 1); }
    public static void LoadGameData() { Load(SaveTypes.gameDat, 1); }
    public static void DeleteGameData() { Save(SaveTypes.gameDat, 1); }


    private static void Save(SaveTypes mySaveType, int slotNum) {
        string myFilePath = "user://" + mySaveType.ToString() + slotNum + ".sav";

        //Save File Object
        using var saveGame = FileAccess.Open(myFilePath, FileAccess.ModeFlags.Write);

        string jsonString = string.Empty;

        //Convert entire class to json string.
        if (mySaveType == SaveTypes.playerDat) {
            jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(playerData);
        }
        if (mySaveType == SaveTypes.gameDat) {
            jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(gameData);
        }


        //Write String to File
        saveGame.StoreLine(jsonString);
    }


    private static void Load(SaveTypes mySaveType, int slotNum, bool loadToSlot = false) {
        string myFilePath = "user://" + mySaveType.ToString() + slotNum + ".sav";

        //Can't open file
        if (FileAccess.FileExists(myFilePath) == false) {
            GD.Print("File doesnt exist: " +  myFilePath);
            initializeSlot(mySaveType, slotNum);
            return;
        }

        // Open File
        var saveGame = FileAccess.Open(myFilePath, FileAccess.ModeFlags.Read);

        //Read File Contents. File is only one line, so it does not need to be iterated.
        var jsonString = saveGame.GetLine();

        GD.Print(jsonString);

        if (mySaveType == SaveTypes.playerDat) {
            if (loadToSlot == false) {
                Newtonsoft.Json.JsonConvert.PopulateObject(jsonString, playerData);
            } else {
                if (slotNum == 1) { Newtonsoft.Json.JsonConvert.PopulateObject(jsonString, loadedPlayerDataSlot1); }
                if (slotNum == 2) { Newtonsoft.Json.JsonConvert.PopulateObject(jsonString, loadedPlayerDataSlot2); }
                if (slotNum == 3) { Newtonsoft.Json.JsonConvert.PopulateObject(jsonString, loadedPlayerDataSlot3); }
            }
        }

        if (mySaveType == SaveTypes.gameDat) {
            Newtonsoft.Json.JsonConvert.PopulateObject(jsonString, gameData);
        }
    }


    private static void Delete(SaveTypes mySaveType, int slotNum) {
        string myFilePath = "user://" + mySaveType.ToString() + slotNum + ".sav";

        //Overwrite Player Data for Specified Slot
        if (mySaveType == SaveTypes.playerDat) {
            initializeSlot(SaveTypes.gameDat, slotNum);
        }

        //Overwrite Default Game Data for Specified Slot
        if (mySaveType == SaveTypes.gameDat) { initializeSlot(SaveTypes.gameDat, 1); }

        //Save to file
        Save(mySaveType, slotNum);
    }

    private static void initializeSlot(SaveTypes mySaveType, int slotNum) {
        if (mySaveType == SaveTypes.playerDat) {
            if (slotNum == 0) { playerData = new PlayerData(); playerData.init(); }
            if (slotNum == 1) { loadedPlayerDataSlot1 = new PlayerData(); loadedPlayerDataSlot1.init(); SavePlayerData(slotNum); }
            if (slotNum == 2) { loadedPlayerDataSlot2 = new PlayerData(); loadedPlayerDataSlot2.init(); SavePlayerData(slotNum); }
            if (slotNum == 3) { loadedPlayerDataSlot3 = new PlayerData(); loadedPlayerDataSlot3.init(); SavePlayerData(slotNum); }
        }
        if (mySaveType == SaveTypes.gameDat) { gameData = new GameData(); SaveGameData(); }
    }

}
