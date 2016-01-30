using UnityEngine;
using Assets.Scripts;

public class GameControl : MonoBehaviour
{

    public int ActivePlayerNumber = 1;
    public int Score = 50;

    public PlayerManager Player1;
    public PlayerManager Player2;


    private SequenceRecorder sequenceRecorder;

	// Use this for initialization
	void Start ()
	{
	    ActivePlayerNumber = 1;
	    sequenceRecorder = GetComponent<SequenceRecorder>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void SwitchPlayer()
    {
        ActivePlayerNumber = ActivePlayerNumber == 1 ? 2 : 1;
    }

    public void StartStopRecording()
    {
        if(sequenceRecorder.IsRecording == false)
            sequenceRecorder.StartRecording();
        else
            sequenceRecorder.StopRecording();
    }



}
