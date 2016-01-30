using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {
	// Número de personaje
	public int playerNumber;

	public Sprite[] danceMoves;
	public SpriteRenderer dancerSprite;

    public GameControl GameControl;

	private int _currentSprite = 0;



	// Use this for initialization
	void Start () {
		StartCoroutine (Dancer());	

        if(GameControl == null)
            Debug.LogError("Error, gameControl not set.");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("w")) {}

		if(Input.GetKeyDown("a")) {}

		if(Input.GetKeyDown("s")) {}

		if(Input.GetKeyDown("d")) {}

	    if (Input.GetKeyUp(KeyCode.Joystick1Button7))
	    {
	        GameControl.SwitchPlayer();
            Debug.Log("SwitchPlayer");
	    }
	    if (Input.GetKeyUp(KeyCode.Joystick1Button6))
	    {
            Debug.Log("Start/Stop Recording");
	        GameControl.StartStopRecording();
	    }


	}

	public void SetPlayerNumber (int value) {
		playerNumber = value;
	}

	public int GetPlayerNumber () {
		return playerNumber;
	}

	private IEnumerator Dancer() {
		while (true) {
			if (_currentSprite >= danceMoves.Length)
				_currentSprite = 0;

			yield return new WaitForSeconds (0.5f);
			dancerSprite.sprite = danceMoves[_currentSprite];
			_currentSprite++;
		}
	}
}
