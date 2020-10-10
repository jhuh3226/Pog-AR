using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case9p2CanvasHolder : MonoBehaviour
{
    public GameObject CVText1;
    public GameObject CVArrowYellow;
    public GameObject CVArrowRed;
    public GameObject CVMissionClear;

    public GameObject gameObCase9p2Blink;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if arrow blinked more than 8 times, activate missionClear canvas
        Case9p2Blink case9p2Blink = gameObCase9p2Blink.GetComponent<Case9p2Blink>();

        if (case9p2Blink.countBlink >=10)
        {
            //deativate
            CVText1.SetActive(false);
            CVArrowYellow.SetActive(false);
            CVArrowRed.SetActive(false);


            //activate
            CVMissionClear.GetComponent<Canvas>().enabled = true;
        }
    }
}
