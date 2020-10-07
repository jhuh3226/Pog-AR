using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeizerFollow2 : MonoBehaviour
{

    [SerializeField]
    private Transform[] routes;

    private int routeToGo;

    private float tParam;

    private Vector3 busPosition;

    private float speedModifier;

    private bool coroutineAllowed;

    public float rotationSpeed;

    public bool vehiclePassedPoint2;

    public bool pogBotPassedPoint3;

    private void Start()
    {
        routeToGo = 0;
        tParam = 0f;
        speedModifier = 0.4f;
        coroutineAllowed = true;
        //rotationSpeed = 3.0f;

        vehiclePassedPoint2 = false;
        pogBotPassedPoint3 = false;

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

        //transform.rotation = Quaternion.Slerp(Quaternion.Euler(-90, 90, 0), Quaternion.Euler(-90, 130, 0), 10);
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(-90, 170, 0), Time.deltaTime * rotationSpeed);

        //print(vehiclePassedPoint2);
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

            if (pogBotPassedPoint3 == false)
            {
                tParam += Time.deltaTime * speedModifier;

                busPosition = Mathf.Pow(1 - tParam, 3) * p0 + 3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 + 3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 + Mathf.Pow(tParam, 3) * p3;

                transform.localPosition = busPosition;
            }

            //rotate bus
            if (transform.localPosition.x > p3.x)
            {
                //print(transform.rotation);
                //print("start rotating");
                //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(-90, 170, 0), Time.deltaTime * rotationSpeed);
                vehiclePassedPoint2 = true;
                pogBotPassedPoint3 = true;

                //this.transform.localPosition = new Vector3(6.08f, 0f, -3.9f);

                Debug.Log("PogBot passed last point");
            }

            //if passed p3, then stop the pogBot, and start new pogBot with errors pointing

            yield return new WaitForEndOfFrame();
        }



        //tParam = 0f;


        // if there's new routine then it follows new route
        //routeToGo += 1;

        //if (routeToGo > routes.Length - 1)
        //    routeToGo = 0;

        //coroutineAllowed = true;

    }

}
