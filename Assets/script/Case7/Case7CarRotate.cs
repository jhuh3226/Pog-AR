using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case7CarRotate : MonoBehaviour
{
    public float rotationSpeed;
    private float currentAngle;
    private float desiredAngle;

    public GameObject gameObCase7BeizerCurveCar;

    // Use this for initialization
    void Start()
    {
        //rotationSpeed = 20f;

        currentAngle = 0f;
        desiredAngle = 30.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(-90, 90, 50), Time.deltaTime * rotationSpeed);
        //Mathf.LerpAngle
        Case7BeizerCurveCar case7BeizerCurveCar = gameObCase7BeizerCurveCar.GetComponent<Case7BeizerCurveCar>();

        if (case7BeizerCurveCar.carPassedPoint2 == false)
        {
            //rotate car to z axis
            transform.Rotate(-Vector3.forward * (rotationSpeed * Time.deltaTime));
        }
    }
}
