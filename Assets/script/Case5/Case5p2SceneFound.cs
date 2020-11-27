using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case5p2SceneFound : MonoBehaviour
{
    public GameObject gameObContainingefaultTrackableEventHandlerCase2Script;
    public GameObject eventSystem;

    public GameObject CV1;
    public GameObject CVArrow1;
    public GameObject CVArrow1Image;

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

                scriptTurnOnDone = true;
            }
        }
    }

    public void turnOnScripts()
    {
        CV1.GetComponent<Canvas>().enabled = true;
        CVArrow1.GetComponent<Canvas>().enabled = true;
        CVArrow1Image.GetComponent<Case5p2MoveArrow>().enabled = true;
    }
}