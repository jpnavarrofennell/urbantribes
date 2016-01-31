using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountDown : MonoBehaviour
{
	public float timeLeft = 300.0f;

	public Text text;

	void Update()
	{
		timeLeft -= Time.deltaTime;
		text.text = Mathf.Round(timeLeft).ToString();
		if(timeLeft < 0)
		{
			//Application.LoadLevel("gameOver");
		}
	}
}