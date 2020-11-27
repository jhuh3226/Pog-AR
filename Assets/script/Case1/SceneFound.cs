using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SceneFound : MonoBehaviour
{
    public GameObject gameObContainingScript;
    public GameObject gameObContainingPogBotMoveForwardScript;
    public GameObject Car1;
    public GameObject pogBot;
    public GameObject eventSystem;

    //canvas back QR
    public Canvas CVGoBackQR;

    //timer
    float targetFoundTime = 0;
    float currentTime = 0;
    bool recorded = false;

    bool scriptTurnOnDone;

    public void Start()
    {
        scriptTurnOnDone = false;

        Car1.SetActive(false);
        pogBot.SetActive(false);
    }


    public void Update()
    {
        DefaultTrackableEventHandlerCase1 script = gameObContainingScript.GetComponent<DefaultTrackableEventHandlerCase1>();
        PogBotMoveForward pogBotMoveForwardScript = gameObContainingPogBotMoveForwardScript.GetComponent<PogBotMoveForward>();

        if (script.targetFound == true)
        {
            if (!recorded)
            {
                targetFoundTime = Time.fixedTime;

                print(targetFoundTime);
                recorded = true;
            }

            //Car1.SetActive(true);
            if (pogBotMoveForwardScript.pogBot2Activated == false)
            {
                pogBot.SetActive(true);
            } else
            {
                pogBot.SetActive(false);
            }

            if (scriptTurnOnDone == false)
            {
                print("target found");
                print(Time.fixedTime);

                //if (targetFoundTime > 0 && Time.fixedTime - targetFoundTime > 2)
                //{
                    print("turn on script");
                    turnOnScripts();

                    CVGoBackQR.enabled = true;

                    scriptTurnOnDone = true;
                //}
            }

        }
    }

    // when imageTarget is detected,turn on following scripts 
    public void turnOnScripts()
    {
        //Car1pogBotMoveForwardScriptSetActive(true);/
        //Car1.GetComponent<BeizerFollow>().enabled = true;
        //Car1.GetComponent<Car1Move>().enabled = true;

        pogBot.GetComponent<PogBotMoveForward>().enabled = true;
        eventSystem.GetComponent<CanvasAppear>().enabled = true;
    }

    //protected override void OnTrackingFound()
    //{
    //    base.OnTrackingFound();
    //    // extra behaviour here
    //    Debug.Log("target found");
    //    car1.SetActive(true);
    //    car1.GetComponent<BeizerFollow>().enabled = true;
    //}

    //protected override void OnTrackingLost()
    //{
    //    base.OnTrackingLost();
    //    // extra behaviour here
    //}

}

