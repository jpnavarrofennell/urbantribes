using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NextLevel : MonoBehaviour {

	public int timer;
	public string nextLevelName;

	// Use this for initialization
	void Start () {
		StartCoroutine (NextLevelTimer ());
	}

	private IEnumerator NextLevelTimer () {
		yield return new WaitForSeconds (timer);
		SceneManager.LoadScene (nextLevelName);
	}
}
