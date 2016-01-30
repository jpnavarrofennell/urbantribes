using UnityEngine;

namespace Assets.Scripts
{
    public class SequenceItem
    {
        public KeyCode KeyPressed;
        public float TimePressed;

        public SequenceItem(KeyCode key, float timePressed)
        {
            KeyPressed = key;
            TimePressed = timePressed;
        }
    }
}