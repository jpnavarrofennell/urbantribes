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


        public static InputItem GetPlayer2Input(KeyCode key)
        {
            switch (key)
            {
                case KeyCode.Joystick3Button2:
                    return InputItem.X;
                case KeyCode.Joystick3Button0:
                    return InputItem.A;
                case KeyCode.Joystick3Button3:
                    return InputItem.Y;
                case KeyCode.Joystick3Button1:
                    return InputItem.B;
            }
            return InputItem.None;
        }

        public static InputItem GetPlayer1Input(KeyCode key)
        {
            switch (key)
            {
                case KeyCode.A:
                case KeyCode.Joystick4Button2:
                
                    return InputItem.X;

                case KeyCode.S:
                case KeyCode.Joystick4Button0:
                    return InputItem.A;

                case KeyCode.W:
                case KeyCode.Joystick4Button3:
                    return InputItem.Y;

                case KeyCode.D:
                case KeyCode.Joystick4Button1:
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