using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Case2p2CanvasHolder : MonoBehaviour
{
    public Canvas CV1;
    public Canvas CV2;
    public Canvas CanvasArrow;
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

    public GameObject gameObContainingCase2p2ActivatePogBot2;
    public GameObject gameObContainingCase2p2MoveArrow;

    public GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        CV1.enabled = true;
        CV2.enabled = false;
        CanvasArrow.enabled = false;
        CVMissionClear.enabled = false;

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
        Case2p2ActivatePogBot2 case2p2ActivatePogBot2 = gameObContainingCase2p2ActivatePogBot2.GetComponent<Case2p2ActivatePogBot2>();
        Case2p2MoveArrow case2p2MoveArrow = gameObContainingCase2p2MoveArrow.GetComponent<Case2p2MoveArrow>();

        if (case2p2ActivatePogBot2.pogCrossingActive2 == true)
        {
            CV1.enabled = false;
            CV2.enabled = true;

            //turn on arrow
            CanvasArrow.enabled = true;
            arrow.GetComponent<Case2p2MoveArrow>().enabled = true;
        }

        else if(case2p2ActivatePogBot2.pogCrossingActive2 == false)
        {
            CV1.enabled = true;
            CV2.enabled = false;
        }

        //if arrow moved three times, disable CV2 and enable CV mission clear
        if (case2p2MoveArrow.arrowMovedThreeTimes == true)
        {
            if (!btSeeMoreClicked)
            {
                CVMissionClear.enabled = true;
                
            }
            CV2.enabled = false;
        }
    }

    void TaskOnClickBtnSeeMore()
    {
        print("bt AcciDetail Clicked");

        btSeeMoreClicked = true;
        CV2.enabled = false;
        CVMissionClear.enabled = false;
        CVUiBT.enabled = true;
    }

    void TaskOnClickBtnSeeMoreCancel()
    {
        CVMissionClear.enabled = true;
        CV2.enabled = false;
        CVUiBT.enabled = false;
    }

    void TaskOnClickBtnAcciDetail()
    {
        print("bt AcciDetail Clicked");

        CVUiBT.enabled = false;
        CV2.enabled = false;
        CVAcciDetail.enabled = true;
    }
    void TaskOnClickBtnAcciDetailCancel()
    {

        CVUiBT.enabled = true;
        CV2.enabled = false;
        CVAcciDetail.enabled = false;
    }

    void TaskOnClickBtnBigData()
    {
        CVUiBT.enabled = false;
        CV2.enabled = false;
        CVBigData.enabled = true;
    }
    void TaskOnClickBtnBigDataCancel()
    {

        CVUiBT.enabled = true;
        CV2.enabled = false;
        CVBigData.enabled = false;
    }
}
