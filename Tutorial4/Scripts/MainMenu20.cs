using Godot;
using System;

public partial class MainMenu20 : Node2D {

    [Export] public Button new1, load1, delete1, new2, load2, delete2, new3, load3, delete3;

    public override void _Ready() {

        DisableAllButtons();

        if (GameMaster.loadedPlayerDataSlot1.newFile == true) {
            new1.Disabled = false;
            new1.Visible = true;
        } else {
            load1.Disabled = false;
            load1.Visible = true;
            delete1.Disabled = false;
            delete1.Visible = true;
        }

        if (GameMaster.loadedPlayerDataSlot2.newFile == true) {
            new2.Disabled = false;
            new2.Visible = true;
        } else {
            load2.Disabled = false;
            load2.Visible = true;
            delete2.Disabled = false;
            delete2.Visible = true;
        }


        if (GameMaster.loadedPlayerDataSlot3.newFile == true) {
            new3.Disabled = false;
            new3.Visible = true;
        } else {
            load3.Disabled = false;
            load3.Visible = true;
            delete3.Disabled = false;
            delete3.Visible = true;
        }

    }


    public void _on_new_button_up(int myInt) {
        GameMaster.currentSlotNum = myInt;

        if (myInt == 1) {
            GameMaster.playerData = GameMaster.loadedPlayerDataSlot1;
        }
        if (myInt == 2) {
            GameMaster.playerData = GameMaster.loadedPlayerDataSlot2;
        }
        if (myInt == 3) {
            GameMaster.playerData = GameMaster.loadedPlayerDataSlot3;
        }

        GameMaster.playerData.newFile = false;
        GameMaster.playerData.saveFileVersion = GameMaster.gameVersion;

        GameMaster.SavePlayerData(GameMaster.currentSlotNum);

        SceneManager.instance.ChangeScene(eSceneNames.Level1);
    }

   
    public void _on_quit_button_button_up() {
        SceneManager.instance.QuitGame();
    }


    private void DisableAllButtons() {
        new1.Visible = false;
        new1.Disabled = true;
        load1.Visible = false;
        load1.Disabled = true;
        delete1.Visible = false;
        delete1.Disabled = true;

        new2.Visible = false;
        new2.Disabled = true;
        load2.Visible = false;
        load2.Disabled = true;
        delete2.Visible = false;
        delete2.Disabled = true;

        new3.Visible = false;
        new3.Disabled = true;
        load3.Visible = false;
        load3.Disabled = true;
        delete3.Visible = false;
        delete3.Disabled = true;
    }


}
