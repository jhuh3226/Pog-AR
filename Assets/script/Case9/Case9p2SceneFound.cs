using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case9p2SceneFound : MonoBehaviour
{
    public GameObject gameObContainingefaultTrackableEventHandlerCase2Script;
    public GameObject POGCrossing;
    public GameObject car;

    public GameObject CVText1;

    public GameObject CVArrowYellow;
    public GameObject ArrowYelloowImage;


    public GameObject CVArrowRed;
    public GameObject ArrowRedImage;

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
        POGCrossing.GetComponent<Case9BeizerCurvePogBot>().enabled = true;

        car.GetComponent<Case9BeizerCurveCar>().enabled = true;
        car.GetComponent<Case9CarRotate>().enabled = true;

        CVText1.GetComponent<Canvas>().enabled = true;

        CVArrowYellow.GetComponent<Canvas>().enabled = true;
        ArrowYelloowImage.GetComponent<Case9p2MoveArrow>().enabled = true;

        CVArrowRed.GetComponent<Canvas>().enabled = true;
        ArrowRedImage.GetComponent<Case9p2Blink>().enabled = true;
    }
}
