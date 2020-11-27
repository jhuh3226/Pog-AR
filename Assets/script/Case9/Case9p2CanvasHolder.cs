using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Case9p2CanvasHolder : MonoBehaviour
{
    public GameObject CVText1;
    public GameObject CVArrowYellow;
    public GameObject CVArrowRed;
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

    public GameObject gameObCase9p2Blink;

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
        //if arrow blinked more than 8 times, activate missionClear canvas
        Case9p2Blink case9p2Blink = gameObCase9p2Blink.GetComponent<Case9p2Blink>();

        if (case9p2Blink.countBlink >= 10)
        {
            //deativate
            CVText1.SetActive(false);
            CVArrowYellow.SetActive(false);
            CVArrowRed.SetActive(false);


            if (!btSeeMoreClicked){ 
                //activate
                CVMissionClear.GetComponent<Canvas>().enabled = true;
            }
        }
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
