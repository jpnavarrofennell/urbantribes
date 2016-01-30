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

            //Gamepad Buttons
            KeyCode.Joystick1Button0,
            KeyCode.Joystick1Button1,
            KeyCode.Joystick1Button2,
            KeyCode.Joystick1Button3,
            KeyCode.Joystick1Button4,
            KeyCode.Joystick1Button5,
           


            //Keyboard
            KeyCode.A,
            KeyCode.W,
            KeyCode.S,
            KeyCode.D,
            KeyCode.LeftArrow,
            KeyCode.UpArrow,
            KeyCode.DownArrow,
            KeyCode.RightArrow,
             


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


            ProcessInput();

            if (IsImitating)
            {

                if (CompareSequence(OldKeySequence, CurrentKeySequence) == false)
                {
                    Debug.LogError("Eeeeeeeehhhhh!!!!");
                }
                
            }
            

            DisplayText.text = KeySequenseToString();
        
        }

        private void ProcessInput()
        {
            foreach (var key in validKeys)
            {
                if (Input.GetKeyUp(key))
                {
                    AddSequenceItem(SequenceItem.KeyToInputItem(key));
                    return;
                }
            }

            if (Input.GetAxis("DPad X") < 0.1 && 
                Input.GetAxis("DPad X") > -0.1 && 
                Input.GetAxis("DPad Y") < 0.1 &&
                Input.GetAxis("DPad Y") > -0.1)
                isPressingKey = false;


            if (isPressingKey)  return; 

            if (Input.GetAxis("DPad X") > 0.8)
            {
                
                AddSequenceItem(InputItem.Right);
                isPressingKey = true;
                return;
            }

            if (Input.GetAxis("DPad X") < -0.8)
            {
                isPressingKey = true;
                AddSequenceItem(InputItem.Left);
                return;
            }

            if (Input.GetAxis("DPad Y") > 0.8)
            {
                isPressingKey = true;
                AddSequenceItem(InputItem.Up);
                return;
            }

            if (Input.GetAxis("DPad Y") < -0.8)
            {
                isPressingKey = true;
                AddSequenceItem(InputItem.Down);
                return;
            }
        }

        private void AddSequenceItem(InputItem inputItem)
        {
            
            var newKey = new SequenceItem(inputItem, Time.timeSinceLevelLoad - startedRecodingTime);
            CurrentKeySequence.Add(newKey);
            Debug.Log("Size>> " + CurrentKeySequence.Count + "  Max:  " + MaxSequenceSize);
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
