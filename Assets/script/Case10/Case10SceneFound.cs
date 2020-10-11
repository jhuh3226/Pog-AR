using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case10SceneFound : MonoBehaviour
{
    public GameObject gameObContainingefaultTrackableEventHandlerCase2Script;
    public GameObject POGCrossing;
    public GameObject car;

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

    //when the scene starts, enable pogbot movement and car movement
    public void turnOnScripts()
    {
        POGCrossing.GetComponent<Case10BeizerCurvePogBot>().enabled = true;

        car.GetComponent<Case10BeizerCurveCar>().enabled = true;
    }
}
