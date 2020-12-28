using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case2SceneFound : MonoBehaviour
{
    public GameObject gameObContainingefaultTrackableEventHandlerCase2Script;
    public GameObject eventSystem;
    public GameObject POGCrossing;
    public GameObject Car;
    public GameObject CanvasArrow;
    public GameObject CVAccidentDetail;

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

        //if (script.targetFound == true)
        //{

            if (scriptTurnOnDone == false)
            {
                turnOnScripts();
                CVGoBackQR.enabled = true;

                //turn on gravity
                //POGCrossing.GetComponent<Rigidbody>().useGravity = true;

                scriptTurnOnDone = true;
            }
        //}
    }

    public void turnOnScripts()
    {
        //POGCrossing.GetComponent<Case2BeizerCurvePogBot>().enabled = true;

        //Car.GetComponent<Case2BeizerCurveCar>().enabled = true;
        //Car.GetComponent<Case2CarRotate>().enabled = true;

        eventSystem.GetComponent<Case2CanvasHolder>().enabled = true;

        CVAccidentDetail.GetComponent<Canvas>().enabled = true;
        CanvasArrow.GetComponent<Canvas>().enabled = true;
 

        //eventSystem.GetComponent<PogBotMoveRight>().enabled = true;
        //eventSystem.GetComponent<Case1point2AnimationHolder>().enabled = true;
        //eventSystem.GetComponent<Blink>().enabled = true;
        //eventSystem.GetComponent<Case1point2CanvasHolder>().enabled = true;
        // CanvasArrowImage.GetComponent<MoveCanvas>().enabled = true;

    }
}