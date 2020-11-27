using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFoundCase1point2 : MonoBehaviour
{
    public GameObject gameObContainingScript;
    public GameObject eventSystem;
    public GameObject CanvasArrowImage;

    //canvas back QR
    public Canvas CVGoBackQR;

    public bool scriptTurnOnDone = false;

    // Start is called before the first frame update
    public void Start()
    {
   
    }

    // Update is called once per frame
    public void Update()
    {
        DefaultTrackableEventHandlerCase1 script = gameObContainingScript.GetComponent<DefaultTrackableEventHandlerCase1>();

        if (script.targetFound == true)
        { 

            if (scriptTurnOnDone == false)
            {
                turnOnScripts();

                scriptTurnOnDone = true;
                CVGoBackQR.enabled = true;
            }
        }
    }

    public void turnOnScripts()
    {
        eventSystem.GetComponent<PogBotMoveRight>().enabled = true;
        eventSystem.GetComponent<Case1point2AnimationHolder>().enabled = true;
        eventSystem.GetComponent<Blink>().enabled = true;
        eventSystem.GetComponent<Case1point2CanvasHolder>().enabled = true;
        CanvasArrowImage.GetComponent<MoveCanvas>().enabled = true;
        
    }

}

