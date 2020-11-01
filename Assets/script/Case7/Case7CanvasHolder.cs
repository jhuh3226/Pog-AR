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
            CVMissionClear.GetComponent<Canvas>().enabled = true;
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
}