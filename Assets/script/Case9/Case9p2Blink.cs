using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Case9p2Blink : MonoBehaviour
{
    public MaskableGraphic pointArrow;

    public float interval = 0.4f;
    public float startDelay = 0f;
    public bool currentState = true;
    public bool defaultState = true;
    bool isBlinking = false;

    public int countBlink;
    public int countBlinkLookRightArrow;

    //public AudioClip clip;

    void Start()
    {
        pointArrow.enabled = defaultState;

        StartBlink();

        countBlink = 0;
        countBlinkLookRightArrow = 0;
    }

    private void Update()
    {
        Debug.Log("count look  blink number is: " + countBlink);
        Debug.Log("count look right blink number is: " + countBlinkLookRightArrow);
    }

    public void StartBlink()
    {
        // do not invoke the blink twice - needed if you need to start the blink from an external object
        if (isBlinking)
            return;

        if (pointArrow != null)
        {
            isBlinking = true;
            InvokeRepeating("ToggleStateLookLeftArrow", startDelay, interval);
        }

    }


    public void ToggleStateLookLeftArrow()
    {
        pointArrow.enabled = !pointArrow.enabled;

        countBlink = countBlink + 1;
    }
}
