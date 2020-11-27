using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Case4p2CanvasHolder : MonoBehaviour
{
    public GameObject CV1;
    public GameObject CanvasArrow1;

    public Button bt1;

    public GameObject arrowLeft;
    public GameObject arrowLeftImage;
    public GameObject CVArrowLeftText;
    public GameObject CVArrowLeftText2;
    public GameObject CVArrowLeftText3;
    public Canvas CVMissionClear;
    public Canvas CVUiBT;
    public Canvas CVAcciDetail;
    public Canvas CVBigData;

    public Button btSeeMore;
    public Button btSeeMoreCancel;
    bool btSeeMoreClicked = false;
    public Button btAcciDetail;
    public Button btAcciDetailCancel;
    public Button btBigData;
    public Button btBigDataCancel;

    //used in update
    public GameObject gameObCase4Blink;

    public GameObject gameObCase4p2BeizerCurveCar;
    public GameObject gameObCase4p2BeizerCurvePogBot;

    public GameObject pogBotCrossing;

    bool case4BlinkOver3 = false;

    float CVArrowLeftText3On = 0;
    bool recordTime = true;

    public bool startAnimating = false;

    // Start is called before the first frame update
    void Start()
    {
        Button btn1 = bt1.GetComponent<Button>();
        btn1.onClick.AddListener(TaskOnClick1);

        //UI buttons
        //bt acci detail
        Button btnSeeMore = btSeeMore.GetComponent<Button>();
        btnSeeMore.onClick.AddListener(TaskOnClickBtnSeeMore);
        Button btnSeeMoreCancel = btSeeMoreCancel.GetComponent<Button>();
        btnSeeMoreCancel.onClick.AddListener(TaskOnClickBtnSeeMoreCancel);


        Button btnAcciDetail = btAcciDetail.GetComponent<Button>();
        btnAcciDetail.onClick.AddListener(TaskOnClickBtnAcciDetail);
        Button btnAcciDetailCancel = btAcciDetailCancel.GetComponent<Button>();
        btAcciDetailCancel.onClick.AddListener(TaskOnClickBtnAcciDetailCancel);

        Button btnBigData = btBigData.GetComponent<Button>();
        btnBigData.onClick.AddListener(TaskOnClickBtnBigData);
        Button btnBigDataCancel = btBigDataCancel.GetComponent<Button>();
        btnBigDataCancel.onClick.AddListener(TaskOnClickBtnBigDataCancel);

    }

    // Update is called once per frame
    void Update()
    {
        //if arrowLeftImage blinked more than 3times, deactivate CVArrowLeftText, arrowLeft and activate CVArrowLeftText2
        Case4Blink case4Blink = gameObCase4Blink.GetComponent<Case4Blink>();
        if (case4Blink.countBlink >= 7)
        {
            case4BlinkOver3 = true;

            arrowLeft.SetActive(false);
            CVArrowLeftText.SetActive(false);
            CVArrowLeftText2.GetComponent<Canvas>().enabled = true;

            //turn off animation "look left loop"
            startAnimating = false;

        }

        //if truck passed the last point, then move the pogBot
        Case4p2BeizerCurveCar case4p2BeizerCurveCar = gameObCase4p2BeizerCurveCar.GetComponent<Case4p2BeizerCurveCar>();
        if (case4p2BeizerCurveCar.vehiclePassedPoint3 == true)
        {
                Debug.Log("start moving pogBot");
                pogBotCrossing.GetComponent<Case4p2BeizerCurvePogBot>().enabled = true;

        }

        //if pogBot passes the last position, turn off CVArrowLeftText2 and turn on CVArrowLeftText3
        Case4p2BeizerCurvePogBot case4p2BeizerCurvePogBot = gameObCase4p2BeizerCurvePogBot.GetComponent<Case4p2BeizerCurvePogBot>();
        if (case4p2BeizerCurvePogBot.pogBotPassedPoint3 == true)
        {
            CVArrowLeftText2.GetComponent<Canvas>().enabled = false;
            CVArrowLeftText3.GetComponent<Canvas>().enabled = true;

            if (recordTime)
            {
                CVArrowLeftText3On = Time.fixedTime;
                recordTime = false;
            }
        }

        //if time passed _, turn off CVArrowLeftText3 and turn on CVArrowLeftText3
        if(CVArrowLeftText3On != 0 && Time.fixedTime - CVArrowLeftText3On >= 2)
        {
            if (!btSeeMoreClicked)
            {
                CVArrowLeftText3.GetComponent<Canvas>().enabled = false;
                CVMissionClear.GetComponent<Canvas>().enabled = true;
            }
        }
    }

    void TaskOnClick1()
    {
        if (case4BlinkOver3 == false)
        {
            Debug.Log("bt clicked");
            //disable cv1 and CanvasArrow1 when bt is clicked
            CV1.SetActive(false);
            CanvasArrow1.SetActive(false);

            //turn on arrowLeft and 
            arrowLeft.GetComponent<Canvas>().enabled = true;
            arrowLeftImage.GetComponent<Case4Blink>().enabled = true;

            CVArrowLeftText.GetComponent<Canvas>().enabled = true;

            //turn on animation "look left loop"
            startAnimating = true;
        }
    }

    void TaskOnClickBtnSeeMore()
    {
        print("bt AcciDetail Clicked");

        CVArrowLeftText3.GetComponent<Canvas>().enabled = false;
        CVArrowLeftText3.SetActive(false);

        btSeeMoreClicked = true;
        CVMissionClear.enabled = false;
        CVUiBT.enabled = true;
    }

    void TaskOnClickBtnSeeMoreCancel()
    {
        CVMissionClear.enabled = true;
        CVUiBT.enabled = false;
    }

    void TaskOnClickBtnAcciDetail()
    {
        print("bt AcciDetail Clicked");

        CVUiBT.enabled = false;
        CVAcciDetail.enabled = true;
    }
    void TaskOnClickBtnAcciDetailCancel()
    {

        CVUiBT.enabled = true;
        CVAcciDetail.enabled = false;
    }

    void TaskOnClickBtnBigData()
    {
        CVUiBT.enabled = false;
        CVBigData.enabled = true;
    }
    void TaskOnClickBtnBigDataCancel()
    {

        CVUiBT.enabled = true;
        CVBigData.enabled = false;
    }
}
