using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkCase1 : MonoBehaviour
{
    public MaskableGraphic tiltedArrow;

    public float interval;
    public float startDelay = 0f;
    public bool currentState = true;
    public bool defaultState = true;
    bool isBlinking = false;

    public int countBlink;
    public int countBlinkLookRightArrow;

    public GameObject gameObContainingCanvasAppearScript;

    bool startBlink;

    //public AudioClip clip;

    void Start()
    {
        tiltedArrow.enabled = defaultState;

        StartBlink();

        countBlink = 0;
        countBlinkLookRightArrow = 0;

        startBlink = false;

    }

    private void Update()
    {
        //Debug.Log("count look right blink number is: " + countBlinkLookRightArrow);

    }

    public void StartBlink()
    {
        // do not invoke the blink twice - needed if you need to start the blink from an external object
        if (isBlinking)
            return;

        CanvasAppear canvasAppearHolderscript = gameObContainingCanvasAppearScript.GetComponent<CanvasAppear>();

        if (canvasAppearHolderscript.enableTiltedArrow == true)
        {
            startBlink = true;
        }

        if (tiltedArrow != null)
        {
            //if (startBlink == true)
            //{
                isBlinking = true;
                InvokeRepeating("ToggleStateTiltedArrow", startDelay, interval);
            //}
        }
    }


    public void ToggleStateTiltedArrow()
    {
        tiltedArrow.enabled = !tiltedArrow.enabled;

        countBlinkLookRightArrow = countBlinkLookRightArrow + 1;
    }
}
