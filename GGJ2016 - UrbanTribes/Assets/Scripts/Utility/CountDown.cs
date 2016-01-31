using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class CountDown : MonoBehaviour
{
	public float timeLeft = 300.0f;

	public GameControl gmeCtrl;

	public Text text;

    public void Start()
    {
        if(gmeCtrl == null)
            Debug.LogError("Invalid Game Control on CountDown GameObject");
    }


	void Update()
	{
		timeLeft -= Time.deltaTime;
		text.text = Mathf.Round(timeLeft).ToString();
		if(timeLeft < 0)
		{
			if(gmeCtrl.player1Points > gmeCtrl.player2Points)
            {
                AudioManager.instance.GetComponent<AudioSource>().Stop();
				SceneManager.LoadScene ("P1Win");
			}
			else if (gmeCtrl.player1Points < gmeCtrl.player2Points)
            {
                AudioManager.instance.GetComponent<AudioSource>().Stop();
                SceneManager.LoadScene ("P2Win");
			}
			else
            {
                AudioManager.instance.GetComponent<AudioSource>().Stop();
                SceneManager.LoadScene ("Draw");
			}
		}
	}
}