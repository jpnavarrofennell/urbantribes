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

	public AudioSource audioFail;
	public AudioSource audioWin;

    public GameControl GameControl;

	// Use this for initialization
	void Start ()
    {
	    if (GameControl == null)
	    {
	        Debug.LogError("Invalid Game Control Game Object");
	    }	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void FailedImitation(int value) {
		Sequence fadeCosito = DOTween.Sequence ();
		if (value == 1) {
			fadeCosito.Insert (0, LeftFail.DOFade(1f,0f));
			fadeCosito.Insert (1, LeftFail.DOFade(0f,1f));
		    fadeCosito.OnComplete(OnFailAnimationComplete);
		}
		if (value == 2) {
			fadeCosito.Insert (0, RightFail.DOFade(1f,0f));
			fadeCosito.Insert (1, RightFail.DOFade(0f,1f));
            fadeCosito.OnComplete(OnFailAnimationComplete);
        }

		audioFail.Play ();
	}

	public void ComboSucceded(int value) {
		Sequence fadeCosito = DOTween.Sequence ();
		if (value == 1) {
			fadeCosito.Insert (0, LeftCombo.DOFade(1f,0f));
			fadeCosito.Insert (1, LeftCombo.DOFade(0f,1f));
            
		}
		if (value == 2) {
			fadeCosito.Insert (0, RightCombo.DOFade(1f,0f));
			fadeCosito.Insert (1, RightCombo.DOFade(0f,1f));
		}
		audioWin.Play ();
	}

    private void OnFailAnimationComplete()
    {
        Debug.Log("AnimationComplete");
        GameControl.ResetDancersPoses();
    }



}
