using UnityEngine;

namespace Character
{
    public class Player : MonoBehaviour
    {
        private static Player _ins;

        public static Player Ins
        {
            get
            {
                if (_ins == null)
                    _ins = FindObjectOfType<Player>();

                return _ins;
            }
        }

        public Transform player;
        public Transform playerBody;

        [Header("Comps")]
        public VariableJoystick joystick;

        [Header("Player Comps")]
        public PlayerMovement movement = new PlayerMovement();

        private int _score;

        private void Start()
        {
            movement.follower.followSpeed = movement.forwardSpeed;
        }

        private void Update()
        {
            movement.Move();
        }

        public void SetScore(int val)
        {
            _score = Mathf.Clamp(_score + val, 0, 100);
        }

        public int Score()
        {
            return _score;
        }
    }
}

