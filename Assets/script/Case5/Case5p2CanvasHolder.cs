using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Case5p2CanvasHolder : MonoBehaviour
{
    public Button bt1;

    public GameObject CV1;
    public GameObject CVArrow1;
    public GameObject CVArrow2;
    public GameObject CVArrow2Image;
    public GameObject arrowLeft;
    public GameObject arrowLeftImage;
    public GameObject CVArrowLeftText;
    public GameObject CVArrowLeftText2;
    public GameObject CVArrowLeftText3;
    public GameObject CVMissionClear;

    public GameObject car;
    public GameObject pogBotCrossing;

    //used to bring other script variables
    public GameObject gameObCase4Blink;
    public GameObject gameObCase5p2BeizerCurveCar;
    public GameObject gameObCase5p2BeizerCurvePogBot;

    float CVArrowLeftText2OnTime  = 0;
    bool recordTime = true;

    //used to send to case5p2AnimatorHolder
    public bool startAnimating  = false;

    // Start is called before the first frame update
    void Start()
    {
        Button btn1 = bt1.GetComponent<Button>();
        btn1.onClick.AddListener(TaskOnClick1);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(pogBotCrossing.transform.localPosition.x);

        //if the blink number goes over 7, disable arrowLeft & CVArrowLeftText, enable CVArrowLeftText2 and beizerCurveCar
        Case4Blink case4Blink = gameObCase4Blink.GetComponent<Case4Blink>();
        if (case4Blink.countBlink >= 11)
        {
            //inactivate
            arrowLeft.SetActive(false);
            CVArrowLeftText.SetActive(false);
            //bool sending to case5p2AnimationHolder
            startAnimating = false;

            //activate
            CVArrowLeftText2.GetComponent<Canvas>().enabled = true;

            //enable car movement
            car.SetActive(true);
            car.GetComponent<Case5p2BeizerCurveCar>().enabled = true;
            car.GetComponent<Case5p2CarRotate>().enabled = true;
        }

        //if car passed the last point enable pogbot beizerCurve and CVArrow2
        Case5p2BeizerCurveCar case5p2BeizerCurveCar = gameObCase5p2BeizerCurveCar.GetComponent<Case5p2BeizerCurveCar>();
        if (case5p2BeizerCurveCar.vehiclePassedPoint3 == true)
        {
            //inactive
            car.SetActive(false);

            Debug.Log("start moving pogBot");
            pogBotCrossing.GetComponent<Case5p2BeizerCurvePogBot>().enabled = true;

            CVArrow2.GetComponent<Canvas>().enabled = true;
            CVArrow2Image.GetComponent<Case5p2MoveArrow2>().enabled = true;
        }

        //if pogBot passed the last point enable CVArrowLeftText3
        Case5p2BeizerCurvePogBot case5p2BeizerCurvePogBot = gameObCase5p2BeizerCurvePogBot.GetComponent<Case5p2BeizerCurvePogBot>();
        if (case5p2BeizerCurvePogBot.pogBotPassedPoint3)
        {
            //inactivate
            CVArrow2.SetActive(false);
            CVArrowLeftText2.SetActive(false);

            //activate
            CVArrowLeftText3.GetComponent<Canvas>().enabled = true;

            //record the time
            if (recordTime)
            {
                CVArrowLeftText2OnTime = Time.fixedTime;
                recordTime = false;
            }

        }

        //if time passed 2, enable missionClear 
        if (CVArrowLeftText2OnTime != 0 && Time.fixedTime - CVArrowLeftText2OnTime >= 3)
        {
            //inactivate
            CVArrowLeftText3.SetActive(false);

            //activate
            CVMissionClear.GetComponent<Canvas>().enabled = true;
        }
    }

    void TaskOnClick1()
    {
        Debug.Log("bt clicked");
        //disable cv1 and CanvasArrow1 when bt is clicked
        CV1.SetActive(false);
        CVArrow1.SetActive(false);

        //turn on arrowLeft and arrowLeftText
        arrowLeft.GetComponent<Canvas>().enabled = true;
        arrowLeftImage.GetComponent<Case4Blink>().enabled = true;

        CVArrowLeftText.GetComponent<Canvas>().enabled = true;

        //bool sending to case5p2AnimationHolder
        startAnimating = true;
    }
}
