using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case4CarRotate : MonoBehaviour
{
    public float rotationSpeed;


    public GameObject gameObCase4BeizerCurveCar;

    // Use this for initialization
    void Start()
    {
        //rotationSpeed = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        Case4BeizerCurveCar case4BeizerCurveCar = gameObCase4BeizerCurveCar.GetComponent<Case4BeizerCurveCar>();

        //Debug.Log("rotationSpeed: " + rotationSpeed);

        if (case4BeizerCurveCar.vehiclePassedPoint3 == false)
        {
            //if (case4BeizerCurveCar.vehiclePassedPoint1 == true)
            //{
                //rotate car to x axis, x goes lower
                transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime));
                Debug.Log("Car rotate");

                rotationSpeed = rotationSpeed + 0.3f;
            //}
        }

    }
}
