using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class GuiConttroller : MonoBehaviour {
	
	public Text LeftCombo;
	public Text RightCombo;

	public Text LeftFail;
	public Text RightFail;

	public Text LeftPoint;
	public Text RightPoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void FailedImitation(int value) {
		Sequence fadeCosito = DOTween.Sequence ();
		if (value == 0) {
			fadeCosito.Insert (0, LeftFail.DOFade(1f,0f));
			fadeCosito.Insert (1, LeftFail.DOFade(0f,1f));
		}
		if (value == 1) {
			fadeCosito.Insert (0, RightFail.DOFade(1f,0f));
			fadeCosito.Insert (1, RightFail.DOFade(0f,1f));
		}
	}

	public void ComboSucceded(int value) {
		Sequence fadeCosito = DOTween.Sequence ();
		if (value == 0) {
			fadeCosito.Insert (0, LeftCombo.DOFade(1f,0f));
			fadeCosito.Insert (1, LeftCombo.DOFade(0f,1f));
		}
		if (value == 1) {
			fadeCosito.Insert (0, LeftCombo.DOFade(1f,0f));
			fadeCosito.Insert (1, LeftCombo.DOFade(0f,1f));
		}
	}
}
