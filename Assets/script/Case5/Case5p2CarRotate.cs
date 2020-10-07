using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case5p2CarRotate : MonoBehaviour
{
    private float rotationSpeed;

    public GameObject gameObCase5p2BeizerCurveCar;

    // Use this for initialization
    void Start()
    {
        rotationSpeed = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        Case5p2BeizerCurveCar case5p2BeizerCurveCar = gameObCase5p2BeizerCurveCar.GetComponent<Case5p2BeizerCurveCar>();

        //Debug.Log("rotationSpeed: " + rotationSpeed);

        //rotate the car only before passing vehiclePassedPoint2
        if (case5p2BeizerCurveCar.vehiclePassedPoint2 != true)
        {
            //rotate car to z axis, z goes bigger
            transform.Rotate(Vector3.forward * (rotationSpeed * Time.deltaTime));
            Debug.Log("Car rotate");

            rotationSpeed = rotationSpeed + 0.3f;
        }

    }
}
