using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class SequenceRecorder : MonoBehaviour
    {

        public List<SequenceItem> SequenceItems;

        private bool isRecording = false;
        private bool isPressingKey = false;
        private float startedRecodingTime;

        public Text DisplayText;


        private static KeyCode[] validKeys =
        {
            KeyCode.Joystick1Button0,
            KeyCode.Joystick1Button1,
            KeyCode.Joystick1Button2,
            KeyCode.Joystick1Button3,
            KeyCode.Joystick1Button4
        };
	
        // Use this for initialization
        public void Start ()
        {
	        SequenceItems = new List<SequenceItem>();
            isRecording = false;
            isPressingKey = false;
            startedRecodingTime = 0;
        }
	
        // Update is called once per frame
        public void Update ()
        {

            if(isRecording) return;
            

            foreach (var key in validKeys)
            {
                if (Input.GetKeyUp(key))
                {
                    isPressingKey = true;
                    var newKey = new SequenceItem(key, Time.timeSinceLevelLoad - startedRecodingTime);
                    SequenceItems.Add(newKey);
                }
            }

            DisplayText.text = KeySequenseToString();


        }

        public void StopRecording()
        {
            isRecording = false;
        }

        public void StartRecording()
        {
            isRecording = true;
            startedRecodingTime = Time.timeSinceLevelLoad;
        }

        private string KeySequenseToString()
        {
            var sequence = "";
            foreach (var key in SequenceItems)
            {
                sequence += key.KeyPressed.ToString() + "\n" ;
            }

            return sequence;
        }

    }
}
