using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PogBotMoveRight : MonoBehaviour
{
    public GameObject pogBotStable;
    public GameObject pogBotToMove;
    public GameObject pogBotCrossingStreet;

    public GameObject gameObContainingScript;
    public GameObject gameObContainingCase1point2CanvasHolderScript;

    public bool turnOnCanvasMissionComplete;

    // pogBot crossing street
    public float speed;
    Vector3 startPosition;
    Vector3 endPosition;

    // Start is called before the first frame update
    void Start()
    {
        pogBotStable.SetActive(true);
        pogBotToMove.SetActive(false);
        pogBotCrossingStreet.SetActive(false);

        turnOnCanvasMissionComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCanvas moveCanvasScript = gameObContainingScript.GetComponent<MoveCanvas>();
        Case1point2CanvasHolder case1point2CanvasHolderScript = gameObContainingCase1point2CanvasHolderScript.GetComponent<Case1point2CanvasHolder>();

        if (moveCanvasScript.movePogBot == true)
        {
            pogBotStable.SetActive(false);
            pogBotToMove.SetActive(true);
            pogBotToMove.GetComponent<BeizerFollow2>().enabled = true;
        }

        if(case1point2CanvasHolderScript.turnOffPogBotToMove == true)
        {
            pogBotToMove.SetActive(false);
            pogBotCrossingStreet.SetActive(true);

            // pogBot crossing street
            startPosition = new Vector3(pogBotCrossingStreet.transform.localPosition.x, pogBotCrossingStreet.transform.localPosition.y, pogBotCrossingStreet.transform.localPosition.z);
            endPosition = new Vector3(4.15f, -8.0f, 0.3f);

            pogBotCrossingStreet.transform.localPosition = Vector3.Lerp(startPosition, endPosition, speed * Time.deltaTime);
        }

        if(pogBotCrossingStreet.transform.localPosition.y <= -2.0f)
        {

            turnOnCanvasMissionComplete = true;
        }
    }
}
