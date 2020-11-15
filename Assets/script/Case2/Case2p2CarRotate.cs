using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case2p2CarRotate : MonoBehaviour
{
    private float rotationSpeed;
    private float currentAngle;
    private float desiredAngle;


    public GameObject gameObCase2p2BeizerCurveCar;

    // Use this for initialization
    void Start()
    {
        /*y angle should be rotated*/

        //rotationSpeed = 0.002f;
        //currentAngle = 0.0f;
        //desiredAngle = 50.0f;
        rotationSpeed = 30f;
        //currentAngle = 90.0f;
        //desiredAngle = 150.0f;
        currentAngle = 0f;
        desiredAngle = 30.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(-90, 90, 50), Time.deltaTime * rotationSpeed);
        //Mathf.LerpAngle
        Case2p2BeizerCurveCar case2p2BeizerCurveCar = gameObCase2p2BeizerCurveCar.GetComponent<Case2p2BeizerCurveCar>();

        if (case2p2BeizerCurveCar.vehiclePassedPoint2 == false)
        {
            //rotate car to z axis
            transform.Rotate(-Vector3.forward * (rotationSpeed * Time.deltaTime));

            //currentAngle = Mathf.Lerp(currentAngle, desiredAngle, Time.deltaTime * rotationSpeed);
            //currentAngle = Mathf.Lerp(currentAngle, desiredAngle, rotationSpeed);
            //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, currentAngle);
            //transform.Rotate(Vector3.forward * (rotationSpeed * Time.deltaTime));
        }

        /*Move the object upward in world space 1 unit/second.*/
        //transform.Rotate(-Vector3.forward * (rotationSpeed * Time.deltaTime));
        //print(transform.rotation.z);
    }
}
