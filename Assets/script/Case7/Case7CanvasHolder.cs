using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Case7CanvasHolder : MonoBehaviour
{
    public GameObject car;
    public GameObject CV1;
    public GameObject CV2;
    public GameObject CV3Text;
    public GameObject CV4Text;
    public GameObject CVMissionClear;
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

    public GameObject CVArrow;
    public GameObject ArrowImage;

    public GameObject gameObCase7BeizerCurvePogBot;

    public Button bt1;
    public Button bt2;

    //store time
    float bt2ClickedTime;

    // Start is called before the first frame update
    void Start()
    {
        Button btn1 = bt1.GetComponent<Button>();
        btn1.onClick.AddListener(TaskOnClickBT1);

        Button btn2 = bt2.GetComponent<Button>();
        btn2.onClick.AddListener(TaskOnClickBT2);

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
        //if pogBot crashed car
        Case7BeizerCurvePogBot case7BeizerCurvePogBot = gameObCase7BeizerCurvePogBot.GetComponent<Case7BeizerCurvePogBot>();
        if (case7BeizerCurvePogBot.stopBeizerCurve)
        {
            if (case7BeizerCurvePogBot.lastPointTime != 0 && Time.fixedTime - case7BeizerCurvePogBot.lastPointTime >= 2)
            {
                CV1.GetComponent<Canvas>().enabled = true;
            }
        }

        // 2seconds passed after clicking bt2, activate CV4Text and image 
        if (bt2ClickedTime != 0 && Time.fixedTime - bt2ClickedTime >= 3)
        {
            //disable
            CV3Text.SetActive(false);

            //enable
            CV4Text.GetComponent<Canvas>().enabled = true;
        }

        // 4seconds passed after clicking bt2, activate comission complete
        if (bt2ClickedTime != 0 && Time.fixedTime - bt2ClickedTime >= 5)
        {
            //disable
            CV4Text.SetActive(false);

            //enable
            if (!btSeeMoreClicked)
            {
                CVMissionClear.GetComponent<Canvas>().enabled = true;
            }
        }
    }

    void TaskOnClickBT1()
    {
        Debug.Log("bt1 clicked");

        //disable
        CV1.SetActive(false);

        //enable
        CV2.GetComponent<Canvas>().enabled = true;

        CVArrow.GetComponent<Canvas>().enabled = true;
        ArrowImage.GetComponent<Case7MoveArrow>().enabled = true;
    }

    void TaskOnClickBT2()
    {
        //disable
        CV2.SetActive(false);
        CVArrow.SetActive(false);

        //enable
        CV3Text.GetComponent<Canvas>().enabled = true;

        bt2ClickedTime = Time.fixedTime;
    }

    void TaskOnClickBtnSeeMore()
    {
        print("bt AcciDetail Clicked");

        btSeeMoreClicked = true;
        CVMissionClear.SetActive(false);
        CVUiBT.enabled = true;
    }

    void TaskOnClickBtnSeeMoreCancel()
    {
        CVMissionClear.SetActive(true);
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