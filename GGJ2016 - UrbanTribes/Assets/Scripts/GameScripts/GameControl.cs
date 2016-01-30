using UnityEngine;
using Assets.Scripts;

public class GameControl : MonoBehaviour
{

    public int ActivePlayerNumber = 1;
    public int Score = 50;

    public PlayerManager Player1;
    public PlayerManager Player2;
	public MoveBox moveBox;


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
        if (Input.GetKeyUp(KeyCode.F5))
        {
            SwitchPlayer();
            Debug.Log("SwitchPlayer>> "  + ActivePlayerNumber);
        }
        if (Input.GetKeyUp(KeyCode.Joystick1Button6))
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
			sequenceRecorder.StopRecording ();
			sequenceRecorder.StartImitating ();
		} else {
			moveBox.GoRight ();
			sequenceRecorder.StopRecording ();
			sequenceRecorder.StartImitating ();
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
