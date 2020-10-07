using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Case5CanvasHolder : MonoBehaviour
{
    public GameObject CV1;

    public GameObject gameObCase5BeizerCurveCar;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //if car passes the lastpoint and 2seconds passed, then enable CV1
        Case5BeizerCurveCar case5BeizerCurveCar = gameObCase5BeizerCurveCar.GetComponent<Case5BeizerCurveCar>();
        if (case5BeizerCurveCar.vehiclePassedPoint3 == true)
        {

            if (Time.fixedTime - case5BeizerCurveCar.crashedTime >= 2)
            {
                Debug.Log("turn on CVAccidentHappened canvas");
                CV1.GetComponent<Canvas>().enabled = true;
            }

        }
    }
}
