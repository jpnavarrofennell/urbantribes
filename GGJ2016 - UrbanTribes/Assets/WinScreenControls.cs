using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenControls : MonoBehaviour
{

    public string MainMenuSceneName;

	// Use this for initialization
	void Start () {
	    
	}

	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetKeyUp(KeyCode.JoystickButton1))
	    {
            SceneManager.LoadScene(MainMenuSceneName);
        }
	}
}
