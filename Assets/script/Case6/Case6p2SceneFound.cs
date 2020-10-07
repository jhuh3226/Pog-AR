using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case6p2SceneFound : MonoBehaviour
{
    public GameObject gameObContainingefaultTrackableEventHandlerCase2Script;
    public bool scriptTurnOnDone = false;

    public GameObject CV1;

    public GameObject CVArrow1;

    // Start is called before the first frame update
    void Start()
    {
        CV1.SetActive(false);
        CVArrow1.SetActive(false);
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
        CV1.SetActive(true);
        CVArrow1.SetActive(true);

    }
}
