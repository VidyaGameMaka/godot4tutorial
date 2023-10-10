using System.Collections.Generic;

public class PlayerData {

    public bool newFile = true;
    public string saveFileVersion = GameMaster.gameVersion;
    public int checkpoint = 0;
    public int overworldCheckpoint = 0;
    public eSceneNames savedScene = eSceneNames.Level1;

    public Dictionary<string, string> sampleDictionary = new Dictionary<string, string>() {
        { "zero", "0" },
        { "one", "1" },
        { "two", "2" },
        { "test", "original test" },
    };

}
