using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	private float amp;
	private float[] smooth = new float[2];

	public static AudioManager instance;

	void Start () {
		

		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this.gameObject);
		} else {
			Debug.Log("El Audio Manager ya existe");
			Destroy (this.gameObject);
		}

		for (int i = 0; i < 2; i++) {
			smooth [i] = 0.0f;	
		}
	}

	public float GetAmp() {
		return amp;
	}

	void OnAudioFilterRead (float[] data, int channels)
	{		
		for (var i = 0; i < data.Length; i = i + channels) {
			float absInput = Mathf.Abs(data[i]);
			smooth[0] = ((0.01f * absInput) + (0.99f * smooth[1]));
			amp = smooth[0]*7;
			smooth[1] = smooth[0];
		}
	}
}