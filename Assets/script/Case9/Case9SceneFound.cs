﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case9SceneFound : MonoBehaviour
{
    public GameObject gameObContainingefaultTrackableEventHandlerCase2Script;
    public GameObject POGCrossing;
    public GameObject car;

    //canvas back QR
    public Canvas CVGoBackQR;

    public bool scriptTurnOnDone = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DefaultTrackableEventHandlerCase2 script = gameObContainingefaultTrackableEventHandlerCase2Script.GetComponent<DefaultTrackableEventHandlerCase2>();

        if (script.targetFound == true)
        {

            if (scriptTurnOnDone == false)
            {
                turnOnScripts();
                CVGoBackQR.enabled = true;

                //turn on gravity
                POGCrossing.GetComponent<Rigidbody>().useGravity = true;

                scriptTurnOnDone = true;
            }
        }
    }

    public void turnOnScripts()
    {
        POGCrossing.GetComponent<Case9BeizerCurvePogBot>().enabled = true;

        car.GetComponent<Case9BeizerCurveCar>().enabled = true;
        car.GetComponent<Case9CarRotate>().enabled = true;
    }
}
