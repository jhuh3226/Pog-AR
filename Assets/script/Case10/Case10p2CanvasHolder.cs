using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case10p2CanvasHolder : MonoBehaviour
{
    public GameObject pogBot1;
    public GameObject pogBot2;

    public GameObject CV1Text;
    public GameObject CVArrowRed;
    public GameObject ArrowRedImage;
    public GameObject missionClear;

    public GameObject gameObCase10p2BeizerCurvePogBot;
    public GameObject gameObCase10p2BeizerCurveCar;

    //timer
    float recordTime;
    bool recorded = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if pogbot passes the last point, turn on red arroow
        Case10p2BeizerCurvePogBot case10p2BeizerCurvePogBot = gameObCase10p2BeizerCurvePogBot.GetComponent<Case10p2BeizerCurvePogBot>();
        if (case10p2BeizerCurvePogBot.pogBotPassedPoint3)
        {
            CVArrowRed.GetComponent<Canvas>().enabled = true;
            ArrowRedImage.GetComponent<Case10p2Blink>().enabled = true;
        }

        //if car passed the last point and some seconds passed, turn on pogbot
        Case10p2BeizerCurveCar case10p2BeizerCurveCar = gameObCase10p2BeizerCurveCar.GetComponent<Case10p2BeizerCurveCar>();
        if (case10p2BeizerCurveCar.vehiclePassedPoint3)
        {
            if (Time.fixedTime - case10p2BeizerCurveCar.crashedTime >= 0.5)
            {
                //deactivate
                pogBot1.SetActive(false);
                CVArrowRed.SetActive(false);
                CV1Text.SetActive(false);

                //activate
                pogBot2.SetActive(true);
                pogBot2.GetComponent<Case10p2BeizerCurvePogBot>().enabled = true;

                if (!recorded)
                {
                    recordTime = Time.fixedTime;
                    recorded = !recorded;
                }
            }
        }

        //if 2seconds passed after turning on the pogBot2, activate missionClear canvas
        if (recordTime != 0 && Time.fixedTime- recordTime >=2.5)
        {
            missionClear.GetComponent<Canvas>().enabled = true;

        }
    }
}
