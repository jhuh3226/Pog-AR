using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case4SceneFound : MonoBehaviour
{
    public GameObject gameObContainingefaultTrackableEventHandlerCase2Script;
    public GameObject eventSystem;
    public GameObject POGCrossing;
    public GameObject truck;
    //public GameObject CanvasArrow;
    //public GameObject CV1;

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
                //POGCrossing.GetComponent<Rigidbody>().useGravity = true;

                scriptTurnOnDone = true;
            }
        }
    }

    public void turnOnScripts()
    {
        POGCrossing.GetComponent<Case4BeizerCurvePogBot>().enabled = true;

        truck.GetComponent<Case4BeizerCurveCar>().enabled = true;
        truck.GetComponent<Case4CarRotate>().enabled = true;

        //eventSystem.GetComponent<Case2CanvasHolder>().enabled = true;

        //CVAccidentDetail.GetComponent<Canvas>().enabled = true;
        //CanvasArrow.GetComponent<Canvas>().enabled = true;

    }
}
