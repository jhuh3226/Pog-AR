using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case3p2ActivatePogBot : MonoBehaviour
{

    public GameObject gameObCase3p2BeizerCurveCar;
    public GameObject POGCrossing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Case3p2BeizerCurveCar case3p2BeizerCurveCar = gameObCase3p2BeizerCurveCar.GetComponent<Case3p2BeizerCurveCar>();
        if (case3p2BeizerCurveCar.vehiclePassedPoint3 == true)
        {
            Debug.Log("turn on Case3p2BeizerCurvePogBot script");
            POGCrossing.GetComponent<Case3p2BeizerCurvePogBot>().enabled = true;

        }
    }
}
