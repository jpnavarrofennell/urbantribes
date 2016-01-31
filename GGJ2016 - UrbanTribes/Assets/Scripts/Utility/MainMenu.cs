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
	void Update ()
    {
	    if (Input.GetKeyDown(KeyCode.JoystickButton0))
	    {
	        GoToScene(2);
	    }
        if (Input.GetKeyDown(KeyCode.JoystickButton3))
	    {
	        GoToScene(0);
	    }
	}

	public void GoToScene(int scene) {
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
