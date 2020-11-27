using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case9CarRotate : MonoBehaviour
{
    private float rotationSpeed;

    public GameObject gameObCase9BeizerCurveCar;

    // Use this for initialization
    void Start()
    {
        rotationSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        Case9BeizerCurveCar case9BeizerCurveCar = gameObCase9BeizerCurveCar.GetComponent<Case9BeizerCurveCar>();

        //Debug.Log("rotationSpeed: " + rotationSpeed);

        //rotate the car only before passing vehiclePassedPoint2
        if (case9BeizerCurveCar.vehiclePassedPoint3 != true)
        {
            //rotate car to z axis, z goes bigger
            transform.Rotate(-Vector3.forward * (rotationSpeed * Time.deltaTime));
            Debug.Log("Car rotate");

            rotationSpeed = rotationSpeed + 0.3f;
        }

    }
}
