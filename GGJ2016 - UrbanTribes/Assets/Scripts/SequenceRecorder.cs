using System;
using System.Collections.Generic;
using System.Linq;
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

        private PlayerManager player1;
        private PlayerManager player2;


        private static KeyCode[] validKeysP1 =
        {

            //Gamepad Buttons
            KeyCode.Joystick4Button0,
            KeyCode.Joystick4Button1,
            KeyCode.Joystick4Button2,
            KeyCode.Joystick4Button3,
            KeyCode.Joystick4Button4,
            KeyCode.Joystick4Button5,

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

        private static KeyCode[] validKeysP2 =
        {

            //Gamepad Buttons
            KeyCode.Joystick3Button0,
            KeyCode.Joystick3Button1,
            KeyCode.Joystick3Button2,
            KeyCode.Joystick3Button3,
            KeyCode.Joystick3Button4,
            KeyCode.Joystick3Button5,

        };
	
        // Use this for initialization
        public void Start ()
        {
	        CurrentKeySequence = new List<SequenceItem>();
            IsRecording = false;
            isPressingKey = false;
            startedRecodingTime = 0;
            MaxSequenceSize = 10;

            var gameControl = GetComponentInParent<GameControl>();

            if(gameControl == null)
            {
                Debug.LogError("Invalid GameControl Set");
                return;
            }

            player1 = gameControl.Player1;
            player2 = gameControl.Player2;

        }
	
        // Update is called once per frame
        public void Update ()
        {
            

            if (CurrentKeySequence.Count >= MaxSequenceSize) return;

            if(player1.isActive)
                ProcessPlayer1Input();
            else
                ProcessPlayer2Input();
            
            if (IsImitating)
            {

                if (CompareSequence(OldKeySequence, CurrentKeySequence) == false)
                {
                    Debug.LogError("Eeeeeeeehhhhh!!!!");
                }
                
            }
            

            DisplayText.text = KeySequenseToString();
        
        }

        private void ProcessPlayer1Input()
        {
            foreach (var key in validKeysP1)
            {
                if (Input.GetKeyUp(key))
                {
                    AddSequenceItem(SequenceItem.GetPlayer1Input(key));
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

            if(CurrentKeySequence.Count> 0)
                ChangeDancer(CurrentKeySequence.Last().KeyPressed);
        }

        private void ProcessPlayer2Input()
        {
            foreach (var key in validKeysP2)
            {
                if (Input.GetKeyUp(key))
                {
                    AddSequenceItem(SequenceItem.GetPlayer2Input(key));
                    return;
                }
            }

            if (Input.GetAxis("DPad X2") < 0.1 && 
                Input.GetAxis("DPad X2") > -0.1 && 
                Input.GetAxis("DPad Y2") < 0.1 &&
                Input.GetAxis("DPad Y2") > -0.1)
                isPressingKey = false;


            if (isPressingKey)  return; 

            if (Input.GetAxis("DPad X2") > 0.8)
            {
                
                AddSequenceItem(InputItem.Right);
                isPressingKey = true;
                return;
            }

            if (Input.GetAxis("DPad X2") < -0.8)
            {
                isPressingKey = true;
                AddSequenceItem(InputItem.Left);
                return;
            }

            if (Input.GetAxis("DPad Y2") > 0.8)
            {
                isPressingKey = true;
                AddSequenceItem(InputItem.Up);
                return;
            }

            if (Input.GetAxis("DPad Y2") < -0.8)
            {
                isPressingKey = true;
                AddSequenceItem(InputItem.Down);
                return;
            }

            if(CurrentKeySequence.Count> 0)
                ChangeDancer(CurrentKeySequence.Last().KeyPressed);
        }

        private void AddSequenceItem(InputItem inputItem)
        {
            
            var newKey = new SequenceItem(inputItem, Time.timeSinceLevelLoad - startedRecodingTime);
            CurrentKeySequence.Add(newKey);
            Debug.Log("Size>> " + CurrentKeySequence.Count + "  Max:  " + MaxSequenceSize);
        }


        private void ChangeDancer(InputItem key)
        {

            switch (key)

            {
                case InputItem.None:
                    if(player1.isActive)
                        player1.SetSprite(0);
                    else
                        player2.SetSprite(0);
                    break;
                case InputItem.Up:
                    if (player1.isActive)
                        player1.SetSprite(1);
                    else
                        player2.SetSprite(1);
                    break;
                case InputItem.Down:
                    if (player1.isActive)
                        player1.SetSprite(2);
                    else
                        player2.SetSprite(2);
                    break;
                case InputItem.Left:
                    if (player1.isActive)
                        player1.SetSprite(3);
                    else
                        player2.SetSprite(3);
                    break;
                case InputItem.Right:
                    if (player1.isActive)
                        player1.SetSprite(4);
                    else
                        player2.SetSprite(4);
                    break;
                case InputItem.A:
                    if (player1.isActive)
                        player1.SetSprite(5);
                    else
                        player2.SetSprite(5);
                    break;
                case InputItem.B:
                    if (player1.isActive)
                        player1.SetSprite(6);
                    else
                        player2.SetSprite(6);
                    break;
                case InputItem.X:
                    if (player1.isActive)
                        player1.SetSprite(7);
                    else
                        player2.SetSprite(7);
                    break;
                case InputItem.Y:
                    if (player1.isActive)
                        player1.SetSprite(8);
                    else
                        player2.SetSprite(8);
                    break;

            }
        }


        public void StopRecording()
        {
            IsRecording = false;
            IsImitating = true;
            OldKeySequence = new List<SequenceItem>(CurrentKeySequence);
            CurrentKeySequence.Clear();

            Debug.Log("Old>" + OldKeySequence.Count + "  -  new>" + CurrentKeySequence.Count);
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
                sequence += key.KeyPressed.ToString() + " - " + key.TimePressed + "\n";
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
