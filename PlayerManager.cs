using Godot;

namespace SuperStriker {
    interface IPlayerManager {
        void DestroyPlayer();
    }

    sealed class PlayerManager : Node, IPlayerManager {

        public static IPlayerManager Instance {get; private set;}

        [Export] private readonly NodePath playerController_p;

        private Player playerController;

        public override void _Ready() {
            base._Ready();
            Instance = this;
            playerController = GetNode<Player>(playerController_p);
        }

        public override void _Process(float delta) {
            var moveDir = new Vector3(0,0,0);
            if (Input.IsActionPressed("move_up")) {
                moveDir = new Vector3(0,0,-1);
            }
            if (Input.IsActionPressed("move_down")) {
                moveDir = new Vector3(0,0,1);
            }
            if (Input.IsActionPressed("move_left")) {
                moveDir = new Vector3(-1,0,0);
            }
            if (Input.IsActionPressed("move_right")) {
                moveDir = new Vector3(1,0,0);
            }
            playerController.Move(moveDir);
        }

        public void DestroyPlayer() {
            playerController.QueueFree();
        }
    }
}
