using UnityEngine;
using System.Collections;

public class ScaleMixer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.localScale = new Vector3 (
			1f, 
			AudioManager.instance.GetAmp (), 
			1f);
		
		this.transform.localScale = this.transform.localScale.normalized;
	}
}
