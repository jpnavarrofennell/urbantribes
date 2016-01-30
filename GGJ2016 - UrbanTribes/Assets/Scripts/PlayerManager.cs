using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {
	// Número de personaje
	public int playerNumber;
	public bool isActive;

	public Sprite[] danceMoves;
	public SpriteRenderer dancerSprite;

    public GameControl GameControl;

	private int _currentSprite = 0;



	// Use this for initialization
	void Start () {
		

        if(GameControl == null)
            Debug.LogError("Error, gameControl not set.");
	}
	
	// Update is called once per frame
	void Update () {





	}

	public void SetSprite(int value) {
		dancerSprite.sprite = danceMoves[value];
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
