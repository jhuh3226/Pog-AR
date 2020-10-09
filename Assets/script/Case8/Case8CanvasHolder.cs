using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Case8CanvasHolder : MonoBehaviour
{
    public GameObject car;
    public GameObject CV1;
    public GameObject CV2;
    public GameObject CV3;
    public GameObject CV4;
    public GameObject CVMissionClear;

    public GameObject CVArrow;
    public GameObject ArrowImage;
    public GameObject CVArrow2;
    public GameObject ArrowImage2;

    public GameObject gameObCase8BeizerCurvePogBot;
    public GameObject gameObCase8BeizerCurveCar;

    public Button bt1;
    public Button bt2;

    //store time
    float bt2ClickedTime;

    void Start()
    {
        Button btn1 = bt1.GetComponent<Button>();
        btn1.onClick.AddListener(TaskOnClickBT1);

        Button btn2 = bt2.GetComponent<Button>();
        btn2.onClick.AddListener(TaskOnClickBT2);
    }

    void Update()
    {
        //if pogbot passes point 1 and before turning point 3, activate CV1 and arrow
        Case8BeizerCurvePogBot case8BeizerCurvePogBot = gameObCase8BeizerCurvePogBot.GetComponent<Case8BeizerCurvePogBot>();
        Case8BeizerCurveCar case8BeizerCar = gameObCase8BeizerCurveCar.GetComponent<Case8BeizerCurveCar>();

        if (case8BeizerCurvePogBot.pogBotPassedPoint0)
        {
            CV1.GetComponent<Canvas>().enabled = true;
            CVArrow.GetComponent<Canvas>().enabled = true;
            ArrowImage.GetComponent<Case8MoveArrow>().enabled = true;
        }

        if(case8BeizerCar.carPassedPoint2)
        {
            CV1.GetComponent<Canvas>().enabled = false;
        }

        //if car passed point 3 and two seconds passed, activate CV2
        if (case8BeizerCar.carPassedPoint3)
        {
            if (case8BeizerCar.lastPointTime != 0 && Time.fixedTime - case8BeizerCar.lastPointTime >= 2)
            {
                //disable
                CV1.SetActive(false);
                CVArrow.SetActive(false);

                //enable
                CV2.GetComponent<Canvas>().enabled = true;
            }
        }

        // 2seconds passed after clicking bt2, activate comission complete
        if (bt2ClickedTime != 0 && Time.fixedTime - bt2ClickedTime >= 4)
        {
            //disable
            CV4.SetActive(false);

            //enable
            CVMissionClear.GetComponent<Canvas>().enabled = true;
        }
    }

    //if first bt clicked, activate CV3 and arrow2
    void TaskOnClickBT1()
    {
        Debug.Log("bt1 clicked");

        //disable
        CV2.SetActive(false);

        //enable
        CV3.GetComponent<Canvas>().enabled = true;

        CVArrow2.GetComponent<Canvas>().enabled = true;
        ArrowImage2.GetComponent<Case8Blink>().enabled = true;
    }

    //if second bt clicked, activate CV4
    void TaskOnClickBT2()
    {
        Debug.Log("bt2 clicked");

        //disable
        CV3.SetActive(false);
        CVArrow2.SetActive(false);

        //enable
        CV4.GetComponent<Canvas>().enabled = true;

        //record time
        bt2ClickedTime = Time.fixedTime;
    }
}
