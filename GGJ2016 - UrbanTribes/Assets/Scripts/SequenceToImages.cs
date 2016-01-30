using System;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class SequenceToImages : MonoBehaviour
{

    public GameControl GlobalGameControl;

    public Sprite ButtonA;
    public Sprite ButtonB;
    public Sprite ButtonX;
    public Sprite ButtonY;
    public Sprite ButtonUp;
    public Sprite ButtonDown;
    public Sprite ButtonLeft;
    public Sprite ButtonRight;
    public Sprite None;

    public Image[] InputSpace;


    private SequenceRecorder sequenceRecorder;

	// Use this for initialization
	void Start () {
	    foreach (var image in InputSpace)
	    {
	        image.sprite = None;
	    }
	    sequenceRecorder = GlobalGameControl.GetComponent<SequenceRecorder>();


	}
	
	// Update is called once per frame
	void Update ()
    {
	    FillMoveList(sequenceRecorder.CurrentKeySequence);
	}


    private void FillMoveList(List<SequenceItem> sequenceItems)
    {
        for (int i = 0; i < sequenceItems.Count; i++)
        {
            InputSpace[i].sprite = SequenceItemToSprite(sequenceItems[i]);
        }
    }

    private Sprite SequenceItemToSprite(SequenceItem sequenceItem)
    {
        switch (sequenceItem.KeyPressed)
        {
            case InputItem.None:
                return None;
            case InputItem.Up:
                return ButtonUp;
            case InputItem.Down:
                return ButtonDown;
            case InputItem.Left:
                return ButtonLeft;
            case InputItem.Right:
                return ButtonRight;
            case InputItem.A:
                return ButtonA;
            case InputItem.B:
                return ButtonB;
            case InputItem.X:
                return ButtonX;
            case InputItem.Y:
                return ButtonY;
            default:
                return None;
        }
    }
}
