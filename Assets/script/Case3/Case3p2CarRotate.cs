using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case3p2CarRotate : MonoBehaviour
{
    private float rotationSpeed;


    public GameObject gameObCase3p2BeizerCurveCar;

    // Use this for initialization
    void Start()
    {
        rotationSpeed = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        Case3p2BeizerCurveCar case3p2BeizerCurveCar = gameObCase3p2BeizerCurveCar.GetComponent<Case3p2BeizerCurveCar>();

        //Debug.Log("rotationSpeed: " + rotationSpeed);

        if (case3p2BeizerCurveCar.vehiclePassedPoint2 == true)
        {
            rotationSpeed = rotationSpeed + 0.1f;
        }

        if (case3p2BeizerCurveCar.vehiclePassedPoint3 == false)
        {
            //rotate car to z axis
            transform.Rotate(Vector3.forward * (rotationSpeed * Time.deltaTime));
            Debug.Log("Car rotate");
        }

    }
}
