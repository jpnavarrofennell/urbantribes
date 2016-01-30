using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoveBox : MonoBehaviour {

	public Animator box;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GoLeft() {
		box.SetInteger ("estado",0);
	}

	public void GoRight() {
		box.SetInteger ("estado",2);
	}

	private IEnumerator AnimSwitch() {
		int i = 0;
		while (true) {
			yield return new WaitForSeconds (1f);
			box.SetInteger ("estado",i);

			i++;
			if (i > 3) {
				i = 0;
			}
		
		}
	}
}
