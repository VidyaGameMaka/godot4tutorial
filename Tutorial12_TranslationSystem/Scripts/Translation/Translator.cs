using Godot;
using System;

public partial class Translator : Node {

	public static Translator instance;

    public static Lng runLang;

    public override void _Ready() {
	    ChangeLanguage();
	}

    public void ChangeLanguage() {
        switch (GameMaster.gameData.language) {
            case Languages.en:
                runLang = new en();
                break;
            case Languages.sp:
                runLang = new sp();
                break;
            default:
                break;
        }

        runLang.Run();

        GD.Print("(Translator) Language Selected: " + GameMaster.gameData.language);
    }


}
