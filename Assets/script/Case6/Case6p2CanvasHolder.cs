using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Case6p2CanvasHolder : MonoBehaviour
{
    public Button bt1;

    public GameObject CV1;
    public GameObject CV2;
    public GameObject CV3;
    public GameObject CVMissionClear;

    public GameObject CVArrow1;
    public GameObject ArrowImage;

    public GameObject car;
    public GameObject pogBot;

    public GameObject gameObCase6p2BeizerCurvePogBot;

    //bool to animate
    public bool startAnimating = false;

    // Start is called before the first frame update
    void Start()
    {
        //bt
        Button btn1 = bt1.GetComponent<Button>();
        btn1.onClick.AddListener(TaskOnClick1);
    }

    // Update is called once per frame
    void Update()
    {
        //in the start, activate CV1 and moving arrow
        CV1.GetComponent<Canvas>().enabled = true;
        CVArrow1.GetComponent<Canvas>().enabled = true;
        ArrowImage.GetComponent<Case6p2MoveArrow>().enabled = true;

        //if two seconds passed after the pogBotReaches the last point, activate CV3
        Case6p2BeizerCurvePogBot case6p2BeizerCurvePogBot = gameObCase6p2BeizerCurvePogBot.GetComponent<Case6p2BeizerCurvePogBot>();
        if (case6p2BeizerCurvePogBot.pogBotPassedPoint3)
        {
            if(Time.fixedTime - case6p2BeizerCurvePogBot.lastPointTime > 2)
            {
                //disable
                CV2.SetActive(false);

                //enable
                CV3.GetComponent<Canvas>().enabled = true;
            }
        }

        //if two seconds passed after activating CV3, activate comission complete
        if(case6p2BeizerCurvePogBot.pogBotPassedPoint3)
        {
            if(Time.fixedTime - case6p2BeizerCurvePogBot.lastPointTime > 4)
            {
                //disable
                CV3.SetActive(false);

                //enable
                CVMissionClear.GetComponent<Canvas>().enabled = true;
            }
        }
    }

    void TaskOnClick1()
    {
        Debug.Log("bt clicked");
        //disable cv1 and CanvasArrow1 when bt is clicked
        CV1.SetActive(false);
        CVArrow1.SetActive(false);

        //turn on cv2
        CV2.GetComponent<Canvas>().enabled = true;

        //turn head animation
        startAnimating = true;

        //move the van by turning on the beizercurve script
        car.GetComponent<Case6BeizerCurveCar>().enabled = true;

        //move the pogbot by turning on the beizercurve script
        pogBot.GetComponent<Case6p2BeizerCurvePogBot>().enabled = true;
    }
}
