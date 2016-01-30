using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {
	// Número de personaje
	public int playerNumber;

	public Sprite[] danceMoves;
	public SpriteRenderer dancerSprite;

	private int _currentSprite = 0;


	// Use this for initialization
	void Start () {
		StartCoroutine (Dancer());	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("w")) {}

		if(Input.GetKeyDown("a")) {}

		if(Input.GetKeyDown("s")) {}

		if(Input.GetKeyDown("d")) {}
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
