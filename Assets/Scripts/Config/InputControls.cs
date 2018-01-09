using UnityEngine;

namespace Panzer
{
    [System.Serializable]
    public class InputControl
    {
        [SerializeField]
        KeyCode key;
        public KeyCode Key { get { return key; } }
    }
    [CreateAssetMenu(fileName = "Inputs", menuName = "Input controls")]
    public class InputControls : ScriptableObject
    {
        [SerializeField]
        InputControl turnLeft;
        [SerializeField]
        InputControl turnRight;
        [SerializeField]
        InputControl driveForward;
        [SerializeField]
        InputControl driveBackward;
        [SerializeField]
        InputControl prevGun;
        [SerializeField]
        InputControl nextGun;
        [SerializeField]
        InputControl attack;

        public InputControl TurnLeft { get { return turnLeft; } }
        public InputControl TurnRight { get { return turnRight; } }
        public InputControl DriveForward { get { return driveForward; } }
        public InputControl DriveBackward { get { return driveBackward; } }
        public InputControl PrevGun { get { return prevGun; } }
        public InputControl NextGun { get { return nextGun; } }
        public InputControl Attack { get { return attack; } }
    }
}