using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class SequenceRecorder : MonoBehaviour
    {

        public List<SequenceItem> CurrentKeySequence;
        public List<SequenceItem> OldKeySequence;
        
        public Text DisplayText;
        public int MaxSequenceSize = 10;
        public float CoolDownInSeconds = 0.2f;


        private bool isRecording = false;
        private bool isImitating = false;


        private bool isPressingKey = false;
        private float startedRecodingTime;
        
        

        private static KeyCode[] validKeys =
        {
            KeyCode.Joystick1Button0,
            KeyCode.Joystick1Button1,
            KeyCode.Joystick1Button2,
            KeyCode.Joystick1Button3,
            KeyCode.Joystick1Button4,
            KeyCode.Joystick1Button5,
            KeyCode.Joystick1Button6,
            KeyCode.Joystick1Button7

        };
	
        // Use this for initialization
        public void Start ()
        {
	        CurrentKeySequence = new List<SequenceItem>();
            isRecording = false;
            isPressingKey = false;
            startedRecodingTime = 0;
            MaxSequenceSize = 10;
        }
	
        // Update is called once per frame
        public void Update ()
        {

            //if(isRecording == false) return;

            if (CurrentKeySequence.Count >= MaxSequenceSize) return;


            foreach (var key in validKeys)
            {
                if (Input.GetKeyUp(key))
                {
                    isPressingKey = true;
                    var newKey = new SequenceItem(key, Time.timeSinceLevelLoad - startedRecodingTime);
                    CurrentKeySequence.Add(newKey);
                    Debug.Log("Size>> "+CurrentKeySequence.Count   + "  Max:  " + MaxSequenceSize);
                }
            }

            if (isImitating)
            {
                if (CompareSequence(OldKeySequence, CurrentKeySequence) == false)
                {
                    // Fin de round bajar puntos
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
            isImitating = false;
            startedRecodingTime = Time.timeSinceLevelLoad;
        }

        public void StartImitating()
        {
            isImitating = true;
            isRecording = false;
            startedRecodingTime = Time.timeSinceLevelLoad;
        }

        public void ClearSequence()
        {
            CurrentKeySequence.Clear();
            MaxSequenceSize = 10;
        }


        private string KeySequenseToString()
        {
            var sequence = "";
            foreach (var key in CurrentKeySequence)
            {
                sequence += key.KeyPressed.ToString() + " - " + key.TimePressed  + "\n" ;
            }

            return sequence;
        }


        public bool CompareSequence(List<SequenceItem> baseSequence, List<SequenceItem> resultSequence)
        {

            if (baseSequence.Count > resultSequence.Count)
                return false;


            for (int i = 0; i < resultSequence.Count; i++)
            {
                if (resultSequence[i].KeyPressed != baseSequence[i].KeyPressed) return false;
            }


            return true;
        }



    }

}
