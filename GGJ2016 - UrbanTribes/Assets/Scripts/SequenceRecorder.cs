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


        public bool IsRecording = false;
        public bool IsImitating = false;


        private bool isPressingKey = false;
        private float startedRecodingTime;
        
        

        private static KeyCode[] validKeys =
        {
            KeyCode.Joystick1Button0,
            KeyCode.Joystick1Button1,
            KeyCode.Joystick1Button2,
            KeyCode.Joystick1Button3,
            KeyCode.Joystick1Button4,
            KeyCode.Joystick1Button5

        };
	
        // Use this for initialization
        public void Start ()
        {
	        CurrentKeySequence = new List<SequenceItem>();
            IsRecording = false;
            isPressingKey = false;
            startedRecodingTime = 0;
            MaxSequenceSize = 10;
        }
	
        // Update is called once per frame
        public void Update ()
        {
            

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

            if (IsImitating)
            {

                if (CompareSequence(OldKeySequence, CurrentKeySequence) == false)
                {
                    Debug.LogError("Eeeeeeeehhhhh!!!!");
                }
                
            }
            

            DisplayText.text = KeySequenseToString();
        
        }

        public void StopRecording()
        {
            IsRecording = false;
            IsImitating = true;
            OldKeySequence = new List<SequenceItem>(CurrentKeySequence);
            CurrentKeySequence.Clear();

            Debug.Log("Old>" + OldKeySequence.Count + "  -  new>"+ CurrentKeySequence.Count);
        }

        public void StartRecording()
        {
            IsRecording = true;
            IsImitating = false;
            MaxSequenceSize += 1;
            startedRecodingTime = Time.timeSinceLevelLoad;
        }

        public void StartImitating()
        {
            IsImitating = true;
            IsRecording = false;
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

            for (int i = 0; i < resultSequence.Count; i++)
            {
                if (resultSequence[i].KeyPressed != baseSequence[i].KeyPressed) return false;
            }


            return true;
        }
    }
}
