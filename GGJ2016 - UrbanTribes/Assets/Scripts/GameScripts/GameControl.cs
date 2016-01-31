using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class GameControl : MonoBehaviour
{
	
    public int ActivePlayerNumber = 1;
    public int Score = 50;

    public PlayerManager Player1;
    public PlayerManager Player2;
	public MoveBox moveBox;

	public int player1Points = 0;
	public int player2Points = 0;

	public GuiConttroller guiCon;

    private SequenceRecorder sequenceRecorder;

	// Use this for initialization
	void Start ()
	{
	    ActivePlayerNumber = 1;
	    Player1.isActive = true;
	    sequenceRecorder = GetComponent<SequenceRecorder>();
		sequenceRecorder.StartRecording ();
	}
	
	// Update is called once per frame
	void Update ()
    {
		guiCon.LeftPoint.text = player1Points.ToString();
		guiCon.RightPoint.text = player2Points.ToString();

		if (Input.GetKeyUp(KeyCode.F5))
        {
            //SwitchPlayer();
            Debug.Log("SwitchPlayer>> "  + ActivePlayerNumber);
        }
        if (Input.GetKeyUp(KeyCode.JoystickButton6))
        {
            Debug.Log("Start/Stop Recording");
            StartStopRecording();
        }
    }


	public void SwitchPlayer()
    {
		ActivePlayerNumber = ActivePlayerNumber == 1 ? 2 : 1;

		Player1.isActive = (ActivePlayerNumber == 1);
        Player2.isActive = (ActivePlayerNumber == 2);

		if (ActivePlayerNumber == 1) {
			moveBox.GoLeft ();
			StartCoroutine(Reset(ActivePlayerNumber));
			//sequenceRecorder.StopRecording ();
			//sequenceRecorder.StartImitating ();
		} else {
			moveBox.GoRight ();
			StartCoroutine(Reset(ActivePlayerNumber));
			//sequenceRecorder.StopRecording ();
			//sequenceRecorder.StartImitating ();
		}
    }

	private IEnumerator Reset(int value) { 
		yield return new WaitForSeconds (0.1f);
		if (value == 1) {
			Player2.SetSprite (0);
		} else {
			Player1.SetSprite (0);
		}
	}

    public void StartStopRecording()
    {
        if(sequenceRecorder.IsRecording == false)
            sequenceRecorder.StartRecording();
        else
            sequenceRecorder.StopRecording();
    }



}
