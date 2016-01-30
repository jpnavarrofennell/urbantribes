using UnityEngine;

namespace Assets.Scripts
{
    public class SequenceItem
    {
        public InputItem KeyPressed;
        public float TimePressed;

        public SequenceItem(InputItem key, float timePressed)
        {
            KeyPressed = key;
            TimePressed = timePressed;
        }

        public static InputItem KeyToInputItem(KeyCode key)
        {
            switch (key)
            {
                case KeyCode.A:
                case KeyCode.Joystick1Button2:
                    return InputItem.X;

                case KeyCode.S:
                case KeyCode.Joystick1Button0:
                    return InputItem.A;

                case KeyCode.W:
                case KeyCode.Joystick1Button3:
                    return InputItem.Y;

                case KeyCode.D:
                case KeyCode.Joystick1Button1:
                    return InputItem.B;

                case KeyCode.UpArrow:
                    return InputItem.Up;

                case KeyCode.DownArrow:
                    return InputItem.Down;
                case KeyCode.LeftArrow:
                    return InputItem.Left;
                case KeyCode.RightArrow:
                    return InputItem.Right;

            }
            return InputItem.None;
        }

    }


    public enum InputItem
    {
        None,
        Up,
        Down,
        Left,
        Right,
        A,
        B,
        X,
        Y
    }
}