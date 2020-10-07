using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case5CarRotate : MonoBehaviour
{
    private float rotationSpeed;

    public GameObject gameObCase5BeizerCurveCar;

    // Use this for initialization
    void Start()
    {
        rotationSpeed = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        Case5BeizerCurveCar case5BeizerCurveCar = gameObCase5BeizerCurveCar.GetComponent<Case5BeizerCurveCar>();

        //Debug.Log("rotationSpeed: " + rotationSpeed);

        //rotate the car only before passing vehiclePassedPoint2
        if (case5BeizerCurveCar.vehiclePassedPoint2 != true)
        {
                //rotate car to z axis, z goes bigger
                transform.Rotate(Vector3.forward * (rotationSpeed * Time.deltaTime));
                Debug.Log("Car rotate");

                rotationSpeed = rotationSpeed + 0.5f;
        }

    }
}
