using Godot;
using System;

public partial class MainMenu20 : Node2D {

    [ExportGroup("Buttons")]
    [ExportSubgroup("Button Set 1")]
    [Export] public Button new1;
    [Export] public Button load1;
    [Export] public Button delete1;

    [ExportSubgroup("Button Set 2")]
    [Export] public Button new2;
    [Export] public Button load2;
    [Export] public Button delete2;

    [ExportSubgroup("Button Set 3")]
    [Export] public Button new3;
    [Export] public Button load3;
    [Export] public Button delete3;

    [ExportGroup("Labels")]
    [Export] public Label infoLabel1;
    [Export] public Label infoLabel2;
    [Export] public Label infoLabel3;

    public override void _Ready() {
        SetupMenu();
    }

    private void SetupMenu() {
        DisableAllButtons();

        UpdateLabels();

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

    private void UpdateLabels() {
        infoLabel1.Text = "New file: " + GameMaster.loadedPlayerDataSlot1.newFile.ToString() + "     ";
        infoLabel1.Text += "Scene: " + GameMaster.loadedPlayerDataSlot1.savedScene.ToString() + "     ";
        infoLabel1.Text += "Test: " + GameMaster.loadedPlayerDataSlot1.sampleDictionary["test"];


        infoLabel2.Text = "New file: " + GameMaster.loadedPlayerDataSlot2.newFile.ToString() + "     ";
        infoLabel2.Text += "Scene: " + GameMaster.loadedPlayerDataSlot2.savedScene.ToString() + "     ";
        infoLabel2.Text += "Test: " + GameMaster.loadedPlayerDataSlot2.sampleDictionary["test"];


        infoLabel3.Text = "New file: " + GameMaster.loadedPlayerDataSlot3.newFile.ToString() + "     ";
        infoLabel3.Text += "Scene: " + GameMaster.loadedPlayerDataSlot3.savedScene.ToString() + "     ";
        infoLabel3.Text += "Test: " + GameMaster.loadedPlayerDataSlot3.sampleDictionary["test"];
    }


    public void _on_new_load_button_up(int myInt) {
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
        SceneManager.instance.ChangeScene(GameMaster.playerData.savedScene);
    }

   public void _on_delete_button_up(int myInt) {
        if (GameMaster.showDebuggingMessages) { GD.Print("(MainMenu) Slot deleted: " + myInt); }
        GameMaster.DeletePlayerData(myInt);
        SetupMenu();
   }

    public void _on_allreset_button_button_up() {
        if (GameMaster.showDebuggingMessages) { GD.Print("(MainMenu) All Data reset!"); }
        GameMaster.DeleteGameData();
        GameMaster.DeletePlayerData(1);
        GameMaster.DeletePlayerData(2);
        GameMaster.DeletePlayerData(3);
        SetupMenu();
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
