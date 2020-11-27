using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Case1point2CanvasHolder : MonoBehaviour
{
    public Canvas pedestrianArrow;
    public Canvas textPedestrianArrow;
    public Canvas lookLeftArrow;
    public Canvas textLookLeftArrow;
    public Canvas lookRightArrow;
    public Canvas textLookRightrrow;

    public Canvas canvasMissionComplete;
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

    public GameObject gameObContainingBeizerFollowScript;
    public GameObject gameObContainingBlinkScript;
    public GameObject gameObContainingPogBotMoveRightScript;

    public bool turnLookRightAnimation;

    //sending signal to script "PogBotMoveRight"
    public bool turnOffPogBotToMove;

 
    // Start is called before the first frame update
    void Start()
    {
        pedestrianArrow.enabled = true;
        textPedestrianArrow.enabled = true;
        lookLeftArrow.enabled = false;
        textLookLeftArrow.enabled = false;
        //textLookLeftArrow.enabled = false;

        lookRightArrow.enabled = false;
        textLookRightrrow.enabled = false;
        //textLookRightrrow.enabled = false;
        canvasMissionComplete.enabled = false;

        turnLookRightAnimation = false;

        turnOffPogBotToMove = false;

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

        BeizerFollow2 beizerFollowScript2 = gameObContainingBeizerFollowScript.GetComponent<BeizerFollow2>();
        Blink blinkScript = gameObContainingBlinkScript.GetComponent<Blink>();
        PogBotMoveRight pogBotMoveRightScript = gameObContainingPogBotMoveRightScript.GetComponent<PogBotMoveRight>();

        if (beizerFollowScript2.pogBotPassedPoint3)
        {
            pedestrianArrow.enabled = false;
            textPedestrianArrow.enabled = false;
            lookLeftArrow.enabled = true;
            textLookLeftArrow.enabled = true;
            //textLookLeftArrow.enabled = true;
        }

        //if leftArrow blinked more then 3 times(in here more than 13), than trigger lookRightCanvas
        if(blinkScript.countBlinkLookRightArrow >= 13)
        {
            Debug.Log("disable lookLeftArrow canvas");

            lookLeftArrow.enabled = false;
            textLookLeftArrow.enabled = false;
            //textLookLeftArrow.enabled = false;
            //textLookRightrrow.enabled = true;
            lookRightArrow.enabled = true;
            textLookRightrrow.enabled = true;

            turnLookRightAnimation = true;

        }

        if(blinkScript.countBlinkLookRightArrow >= 19)
        {
            lookLeftArrow.enabled = false;
            textLookLeftArrow.enabled = false;
            lookRightArrow.enabled = false;
            textLookRightrrow.enabled = false;
            //textLookRightrrow.enabled = false;

            turnOffPogBotToMove = true;
        }

        if(pogBotMoveRightScript.turnOnCanvasMissionComplete == true)
        {
            if (!btSeeMoreClicked)
            {
                canvasMissionComplete.enabled = true;
            }

        }
    }

    void TaskOnClickBtnSeeMore()
    {
        print("bt AcciDetail Clicked");

        btSeeMoreClicked = true;
        canvasMissionComplete.enabled = false;
        CVUiBT.enabled = true;
    }

    void TaskOnClickBtnSeeMoreCancel()
    {
        canvasMissionComplete.enabled = true;
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
