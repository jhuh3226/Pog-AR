using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case2BeizerCurveCar : MonoBehaviour
{
    [SerializeField]
    private Transform[] routes;

    private int routeToGo;

    private float tParam;

    private Vector3 busPosition;

    public float speedModifier;

    private bool coroutineAllowed;

    public float rotationSpeed;

    public bool vehiclePassedPoint1;
    public bool vehiclePassedPoint3;

    //save time when car reaching point3
    public float crashedTime;
    bool crashTimeChecked = false;

    private void Start()
    {
        routeToGo = 0;
        tParam = 0f;
        //speedModifier = 0.4f;
        coroutineAllowed = true;
        //rotationSpeed = 3.0f;

        vehiclePassedPoint1 = false;
        vehiclePassedPoint3 = false;
    }

    public void Reset()
    {
        routeToGo = 0;
        tParam = 0f;
        speedModifier = 0.4f;
        coroutineAllowed = true;
    }

    private void Update()
    {
        if (coroutineAllowed)
        {
            StartCoroutine(GoByTheRoute(routeToGo));
        }
    }

    private IEnumerator GoByTheRoute(int routeNumber)
    {
        coroutineAllowed = false;

        Vector3 p0 = routes[routeNumber].GetChild(0).localPosition;
        Vector3 p1 = routes[routeNumber].GetChild(1).localPosition;
        Vector3 p2 = routes[routeNumber].GetChild(2).localPosition;
        Vector3 p3 = routes[routeNumber].GetChild(3).localPosition;

        while (tParam < 2)
        {

            //move the car only before reaching point3 and stop the car when it reaches point3
            if (vehiclePassedPoint3 == false)
            {
                tParam += Time.deltaTime * speedModifier;

                busPosition = Mathf.Pow(1 - tParam, 3) * p0 + 3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 + 3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 + Mathf.Pow(tParam, 3) * p3;

                transform.localPosition = busPosition;
            }

            //rotate bus
            if (transform.localPosition.x < p1.x)
            {
                vehiclePassedPoint1 = true;
                Debug.Log("Car rotate");
            }

            //stop the car
            if (transform.localPosition.x < p3.x)
            {
                vehiclePassedPoint3 = true;
                Debug.Log("PogBot passed last point");

                if (crashTimeChecked == false)
                {
                    crashedTime = Time.fixedTime;
                    crashTimeChecked = true;
                }
            }


            yield return new WaitForEndOfFrame();
        }

    }
}
