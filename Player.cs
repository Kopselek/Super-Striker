using Godot;

namespace SuperStriker {
    class Player : KinematicBody {
        public void Move(Vector3 direction) {
            GlobalTranslation += direction;
        }
    }
}
