using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case4p2CarRotate : MonoBehaviour
{
    private float rotationSpeed;

    public GameObject gameObCase4p2BeizerCurveCar;

    // Use this for initialization
    void Start()
    {
        rotationSpeed = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        Case4p2BeizerCurveCar case4Bp2eizerCurveCar = gameObCase4p2BeizerCurveCar.GetComponent<Case4p2BeizerCurveCar>();

        //Debug.Log("rotationSpeed: " + rotationSpeed);


        if (case4Bp2eizerCurveCar.vehiclePassedPoint3 == false)
        {
            //if (case4BeizerCurveCar.vehiclePassedPoint1 == true)
            //{
                //rotate car to x axis, x goes lower
                transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime));
                Debug.Log("Car rotate");

                rotationSpeed = rotationSpeed + 0.1f;
            //}
        }

    }
}
