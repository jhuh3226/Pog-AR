using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideCar : MonoBehaviour
{
    public GameObject pogBot;
    public bool collidedWithCar;

    public float positionSpeed;
    public float rotationSpeed;

    Vector3 startPosition;
    Vector3 endPosition;
    Quaternion startRotation;
    Quaternion endRotation;


    // Use this for initialization
    void Start()
    {
        collidedWithCar = false;
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter(Collider other)
    {

        startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        endPosition = new Vector3(transform.position.x, 0.8f, transform.position.z);


        //startRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        //endRotation = Quaternion.Euler(transform.rotation.x, 0.5f, 60f);


        if (other.gameObject.tag == "car")
        {
            collidedWithCar = true;
            Debug.Log("collided with car");
        }

        //if (collidedWithCar == true)
        //{
        //    //transform.localPosition = new Vector3(transform.position.x, 0.5f, transform.position.z);
        //    //transform.localRotation = Quaternion.Euler(-19f, transform.rotation.y,47f);


        //    transform.localPosition = Vector3.Lerp(startPosition, endPosition, positionSpeed * Time.deltaTime);

        //    //transform.localRotation = Quaternion.Lerp(startRotation, endRotation, rotationSpeed * Time.deltaTime);

        //    collidedWithCar = false;
        //}

        //if (pogBot.transform.localRotation.z >= 20.0f)
        //{

        //    Debug.Log("locationRotation.z is 18f");
        //    //collidedWithCar = false;
        //}
    }
}