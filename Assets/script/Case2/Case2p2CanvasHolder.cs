using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Case2p2CanvasHolder : MonoBehaviour
{
    public Canvas CV1;
    public Canvas CV2;
    public Canvas CanvasArrow;
    public Canvas CVMissionClear;

    public GameObject gameObContainingCase2p2ActivatePogBot2;
    public GameObject gameObContainingCase2p2MoveArrow;

    public GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        CV1.enabled = true;
        CV2.enabled = false;
        CanvasArrow.enabled = false;
        CVMissionClear.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Case2p2ActivatePogBot2 case2p2ActivatePogBot2 = gameObContainingCase2p2ActivatePogBot2.GetComponent<Case2p2ActivatePogBot2>();
        Case2p2MoveArrow case2p2MoveArrow = gameObContainingCase2p2MoveArrow.GetComponent<Case2p2MoveArrow>();

        if (case2p2ActivatePogBot2.pogCrossingActive2 == true)
        {
            CV1.enabled = false;
            CV2.enabled = true;

            //turn on arrow
            CanvasArrow.enabled = true;
            arrow.GetComponent<Case2p2MoveArrow>().enabled = true;
        }

        else if(case2p2ActivatePogBot2.pogCrossingActive2 == false)
        {
            CV1.enabled = true;
            CV2.enabled = false;
        }

        //if arrow moved three times, disable CV2 and enable CV mission clear
        if (case2p2MoveArrow.arrowMovedThreeTimes == true)
        {
            CVMissionClear.enabled = true;
            CV2.enabled = false;
        }
    }
}
