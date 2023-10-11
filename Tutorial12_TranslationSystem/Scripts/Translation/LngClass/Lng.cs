using System.Collections.Generic;

public enum Languages { en,  sp }

public enum baseDicts { 
    mainMenu = 10, 
    audioMenu = 20, 
    saveLoadMenu = 30, 
    videoMenu = 40, 
    languages = 50
}

public class Lng {

    #region Base Dictionaries (baseDicts)
    public static Dictionary<int, string> mainMenu = new Dictionary<int, string>();
    public static Dictionary<int, string> audioMenu = new Dictionary<int, string>();
    public static Dictionary<int, string> saveLoadMenu = new Dictionary<int, string>();
    public static Dictionary<int, string> videoMenu = new Dictionary<int, string>();
    public static Dictionary<int, string> languages = new Dictionary<int, string>();
    #endregion

    public void Run() => ImplementationRun();

    // Stub virtual method to be overriden in child classes
    protected virtual void ImplementationRun() {

        //Languages Dictionary is the same in all data sets
        languages[0] = "English";
        languages[1] = "Espanol";
    
    }
}
