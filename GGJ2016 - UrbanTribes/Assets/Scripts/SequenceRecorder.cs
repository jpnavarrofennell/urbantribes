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
        public int MaxSequenceSize;
        public float CoolDownInSeconds = 0.2f;
        public bool IsRecording = false;
        public bool IsImitating = false;

        private bool isPressingKey = false;
        private float startedRecodingTime;
        private PlayerManager player1;
        private PlayerManager player2;
        public GameControl gmcontrl;

		public Text information;

        private static KeyCode[] validKeys =
        {

            //Gamepad Buttons
            KeyCode.JoystickButton0,
            KeyCode.JoystickButton1,
            KeyCode.JoystickButton2,
            KeyCode.JoystickButton3,
            KeyCode.JoystickButton4,
            KeyCode.JoystickButton5,

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
        public void Start()
        {
            CurrentKeySequence = new List<SequenceItem>();
            IsRecording = false;
            isPressingKey = false;
            startedRecodingTime = 0;
            var gameControl = GetComponentInParent<GameControl>();
            if (gameControl == null)
            {
                Debug.LogError("Invalid GameControl Set");
                return;
            }
            player1 = gameControl.Player1;
            player2 = gameControl.Player2;
        }

        // Update is called once per frame
        public void Update()
        {
            if (CurrentKeySequence.Count >= MaxSequenceSize) 
				return;

            ProcessPlayerInput();

			if (IsImitating) {
				information.text = "Imitate";
				if (CompareSequence (OldKeySequence, CurrentKeySequence) == false) {
					//Debug.LogError("LUser fails");

					gmcontrl.SwitchPlayer (); 
				}
			} else if(IsRecording) {
				//CurrentKeySequence = new List<SequenceItem>();
				information.text = "Challenge Player " + ((gmcontrl.ActivePlayerNumber == 1)? "2" : "1");

			}
        }

        private void ProcessPlayerInput()
        {
            // Control de teclas validas
			foreach (var key in validKeys)
            {
                if (Input.GetKeyUp(key))
                {
                    AddSequenceItem(SequenceItem.GetPlayerInput(key));
                    return;
                }
            }

			// DPad se matiene apretado
            if (Input.GetAxis("DPad X") < 0.1 &&
                Input.GetAxis("DPad X") > -0.1 &&
                Input.GetAxis("DPad Y") < 0.1 &&
                Input.GetAxis("DPad Y") > -0.1)
                isPressingKey = false;

			// Detiene el input si el input esta fijo
            if (isPressingKey) return;

			// Input Derecho
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

            if (CurrentKeySequence.Count > 0)
                ChangeDancer(CurrentKeySequence.Last().KeyPressed);
        }



        private void AddSequenceItem(InputItem inputItem)
        {

            var newKey = new SequenceItem(inputItem, Time.timeSinceLevelLoad - startedRecodingTime);
            CurrentKeySequence.Add(newKey);

			information.text = "Challenge Him";

            Debug.Log("Size>> " + CurrentKeySequence.Count + "  Max:  " + MaxSequenceSize);

            if (CurrentKeySequence.Count == MaxSequenceSize)
            {
				gmcontrl.SwitchPlayer(); 
            }
        }

        private void ChangeDancer(InputItem key)
        {
            switch (key)
            {
                case InputItem.None:
                    if (player1.isActive)
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
            CurrentKeySequence = new List<SequenceItem>();
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

        public bool CompareSequence(List<SequenceItem> baseSequence, List<SequenceItem> resultSequence)
        {
            for (int i = 0; i < resultSequence.Count; i++)
            {
				if(resultSequence.Count == i) {
					if (resultSequence [i].KeyPressed != baseSequence [i].KeyPressed) {
						StartRecording ();
						return true;
					}
				}

				if (resultSequence[i].KeyPressed != baseSequence[i].KeyPressed) 
					return false;
            }
            return true;
        }
    }
}
