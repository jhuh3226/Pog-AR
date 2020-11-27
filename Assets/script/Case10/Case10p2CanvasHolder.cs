using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Case10p2CanvasHolder : MonoBehaviour
{
    public GameObject pogBot1;
    public GameObject pogBot2;

    public GameObject CV1Text;
    public GameObject CVArrowRed;
    public GameObject ArrowRedImage;
    public GameObject missionClear;
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

    public GameObject gameObCase10p2BeizerCurvePogBot;
    public GameObject gameObCase10p2BeizerCurveCar;

    //timer
    float recordTime;
    bool recorded = false;

    // Start is called before the first frame update
    void Start()
    {
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
            if (!btSeeMoreClicked)
            {
                missionClear.GetComponent<Canvas>().enabled = true;
            }

        }
    }

    void TaskOnClickBtnSeeMore()
    {
        print("bt AcciDetail Clicked");

        btSeeMoreClicked = true;
        missionClear.SetActive(false);
        CVUiBT.enabled = true;
    }

    void TaskOnClickBtnSeeMoreCancel()
    {
        missionClear.SetActive(true);
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
