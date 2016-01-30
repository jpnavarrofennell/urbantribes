using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public string creditsSceneName;
	public string mainMenuSceneName;
	public string gameSceneName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DisplayCredts(int scene) {
		switch (scene) {
		case 0:
			SceneManager.LoadScene (creditsSceneName);
			break;
		case 1:
			SceneManager.LoadScene (mainMenuSceneName);
			break;
		case 2:
			SceneManager.LoadScene (gameSceneName);
			break;
		}
	}
}
