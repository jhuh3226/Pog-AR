using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case3p2SceneFound : MonoBehaviour
{
    public GameObject gameObContainingefaultTrackableEventHandlerCase2Script;
    public GameObject gameObCase3p2BeizerCurveCar;
    public GameObject eventSystem;
    public GameObject POGCrossing;
    public GameObject Car;
    public GameObject CV1;
    //public GameObject CVAccidentDetail;


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

                scriptTurnOnDone = true;
            }
        }
    }

    public void turnOnScripts()
    {
        Car.GetComponent<Case3p2BeizerCurveCar>().enabled = true;
        Car.GetComponent<Case3p2CarRotate>().enabled = true;

        //eventSystem.GetComponent<Case2CanvasHolder>().enabled = true;

        CV1.GetComponent<Canvas>().enabled = true;
        CV1.SetActive(true);
        //CanvasArrow.GetComponent<Canvas>().enabled = true;

    }
}
