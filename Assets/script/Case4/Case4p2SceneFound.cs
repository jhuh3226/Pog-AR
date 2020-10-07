using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case4p2SceneFound : MonoBehaviour
{
    public GameObject gameObContainingefaultTrackableEventHandlerCase2Script;
    //public GameObject eventSystem;

    public GameObject CanvasArrow;
    public GameObject Arrow;

    public GameObject CV1;

    public GameObject truck;

    public bool scriptTurnOnDone = false;

    public GameObject gameObCase4Blink;

    bool pogBotStartedMoving = false;


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

        //turn on the truck script only if "CVArrowLeftText2" is on, which is when arrowLeft blinked more then 3times
        Case4Blink case4Blink = gameObCase4Blink.GetComponent<Case4Blink>();

        if (case4Blink.countBlink >= 7)
        {
            truck.GetComponent<Case4p2BeizerCurveCar>().enabled = true;
            truck.GetComponent<Case4p2CarRotate>().enabled = true;
        }


    }

    public void turnOnScripts()
    {
        CanvasArrow.GetComponent<Canvas>().enabled = true;
        Arrow.GetComponent<Case4p2MoveArrow>().enabled = true;

        CV1.GetComponent<Canvas>().enabled = true;

        //POGCrossing.GetComponent<Case4BeizerCurvePogBot>().enabled = true;

        //eventSystem.GetComponent<Case2CanvasHolder>().enabled = true;

    }
}
