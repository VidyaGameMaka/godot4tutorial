using Godot;
using System;

public partial class DinoPlayerCtrl : CharacterBody2D {

	private Sprite2D mySprite;
	private AnimationPlayer myAnimationPlayer;

	private string currentAnimation = "idle";

	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;

	private Vector2 direction;

    // Get the gravity from the project settings to be synced with RigidBody nodes.
    public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

    public override void _Ready() {
		//Examples of assigning the fields to manipulate

		//Calling GetNode and sending the string "Sprite2D" then casting the type as a Sprite2D. C# requires type to specified
		//since GetNode doesn't automatically return the type we want just by the string arument sent.
		//If a type is not specified or casted, the default returned type from GetNode is Node.
        mySprite = GetNode("Sprite2D") as Sprite2D;

		//"Unity" style assignment. Similar to Unity's GetComponent<Animator>(). Godot requires a node path argument.
		myAnimationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
    }

    public override void _Process(double delta) {
		DoGfx();
    }

    public override void _PhysicsProcess(double delta) {
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
			velocity.Y = JumpVelocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero) {
			velocity.X = direction.X * Speed;
		} else {
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	public void DoGfx() {
		if (direction.X > 0.1f) { mySprite.FlipH = false; }
        if (direction.X < -0.1f) { mySprite.FlipH = true; }

        //Animations for when the player is touching the floor
        if (IsOnFloor() == true) {
			if (MathF.Abs(direction.X) >= 0.1f) { ChangeAnimation("run"); }
            if (MathF.Abs(direction.X) < 0.1f) { ChangeAnimation("idle"); }
        }
	}


    private void ChangeAnimation(string requestedAnimation) {
		if (currentAnimation == requestedAnimation) { return; }

		myAnimationPlayer.Play(requestedAnimation);
		currentAnimation = requestedAnimation;
	}

}
