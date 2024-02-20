using Godot;
using System;

public partial class test : CanvasLayer {

	[Export] private OptionButton optionBtn;

	public override void _Ready() {

		optionBtn.AddItem("item1", 2);
        optionBtn.AddItem("item2", 3);
        optionBtn.AddItem("item3", 4);

    }

	private void _on_option_button_item_selected(int myInt) {
		GD.Print("Int sent by the signal: " + myInt);

		GD.Print("item id: " + optionBtn.GetItemId(myInt));
	}




}
