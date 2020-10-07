using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasAppear : MonoBehaviour
{

    public Canvas accidentHappend;
    public Canvas checkAccidentPoint;
    public Canvas arrow1;
    public GameObject gameObContainingScript;

    public Button bt1;
    public Button bt2;

    bool accidentHappendOn;

    //sending script to "BlinkCase1"
    public bool enableTiltedArrow;

    //elements for time count
    float currentTime;
    bool enableCheckAccidentPoint;

    // Use this for initialization
    void Start()
    {
        //enableScriptAppear = false;
        accidentHappend.enabled = false;
        checkAccidentPoint.enabled = false;
        arrow1.enabled = false;

        accidentHappendOn = true;

        Button btn1= bt1.GetComponent<Button>();
        btn1.onClick.AddListener(TaskOnClick);

        Button btn2 = bt2.GetComponent<Button>();
        btn2.onClick.AddListener(TaskOnClick2);

        enableCheckAccidentPoint = false;

        enableTiltedArrow = false;
    }

    // Update is called once per frame
    void Update()
    {
        Pog2AnimationHolder Pog2AnimationHolderscript = gameObContainingScript.GetComponent<Pog2AnimationHolder>();

        if (Pog2AnimationHolderscript.canvas1 == true && accidentHappendOn == true)
        {
            //enableScriptAppear = true;
            accidentHappend.enabled = true;
            print("accidentHappend canvas enabled");
        }

        //Debug.Log("current time: " + currentTime + " fixed time: " + Time.fixedTime);

        if (Time.fixedTime - currentTime >= 1.5 && currentTime > 0)
        {
            Debug.Log("enable AccidentPoint");
            enableCheckAccidentPoint = true;

            accidentHappendOn = false;
            accidentHappend.enabled = false;
            checkAccidentPoint.enabled = true;
            arrow1.enabled = true;

            enableTiltedArrow = true;
        }
    }

    void TaskOnClick()
    { 
        print("btClicked");

        currentTime = Time.fixedTime;

        //after first button is clicked, enable "checkAccidentPoint" canvas
        if (enableCheckAccidentPoint == false)
        {
            accidentHappendOn = false;
            accidentHappend.enabled = false;
            checkAccidentPoint.enabled = true;
            arrow1.enabled = false;
        }

        //after some seconds, enable "checkAccidentPoint"

        //else if (enableCheckAccidentPoint == true)
        //{

        //}

    }

    void TaskOnClick2()
    {
        accidentHappendOn = false;
        accidentHappend.enabled = false;
        checkAccidentPoint.enabled = false;
        arrow1.enabled = true;
        print("bt2Clicked");
    }



    //private void OnTriggerEnter(Collider other)
    //{
    //    if (enableScriptAppear == true)
    //    {
    //        watchOut.enabled = true;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    watchOut.enabled = false;
    //}
}