using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case7SceneFound : MonoBehaviour
{
    public GameObject gameObContainingefaultTrackableEventHandlerCase2Script;
    public GameObject POGCrossing;
    public GameObject car;
    public GameObject bus;

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

                //turn on gravity
                POGCrossing.GetComponent<Rigidbody>().useGravity = true;

                scriptTurnOnDone = true;
            }
        }
    }

    public void turnOnScripts()
    {
        POGCrossing.GetComponent<Case7BeizerCurvePogBot>().enabled = true;
        car.GetComponent<Case7BeizerCurveCar>().enabled = true;
        car.GetComponent<Case7CarRotate>().enabled = true;

        //eventSystem.GetComponent<Case2CanvasHolder>().enabled = true;

        //CVAccidentDetail.GetComponent<Canvas>().enabled = true;
        //CanvasArrow.GetComponent<Canvas>().enabled = true;

    }
}
