using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DlCase2BeizerCurvePogBot : MonoBehaviour
{
    [SerializeField]
    private Transform[] routes;

    private int routeToGo;

    private float tParam;

    private Vector3 pogBotPosition;

    public float speedModifier;

    private bool coroutineAllowed;

    public float rotationSpeed;

    public bool pogBotPassedPoint1;
    public bool pogBotPassedPoint3;

    //save time when car reaching point3
    public float crashedTime;
    bool crashTimeChecked = false;

    //collider
    bool stopBeizerCurve = false;

    private void Start()
    {
        routeToGo = 0;
        tParam = 0f;
        //speedModifier = 0.4f;
        coroutineAllowed = true;
        //rotationSpeed = 3.0f;

        pogBotPassedPoint1 = false;
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
    }

    private IEnumerator GoByTheRoute(int routeNumber)
    {
        coroutineAllowed = false;

        Vector3 p0 = routes[routeNumber].GetChild(0).localPosition;
        Vector3 p1 = routes[routeNumber].GetChild(1).localPosition;
        Vector3 p2 = routes[routeNumber].GetChild(2).localPosition;
        Vector3 p3 = routes[routeNumber].GetChild(3).localPosition;

        //move it along the beizer curver unless pogBot hits car/truck
        while (tParam < 2 && !stopBeizerCurve)
        {

            //move the car only before reaching point3 and stop the car when it reaches point3
            if (pogBotPassedPoint3 == false)
            {
                tParam += Time.deltaTime * speedModifier;

                pogBotPosition = Mathf.Pow(1 - tParam, 3) * p0 + 3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 + 3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 + Mathf.Pow(tParam, 3) * p3;

                transform.localPosition = pogBotPosition;
            }

            //stop the car
            if (transform.localPosition.z > p3.z)
            {
                pogBotPassedPoint3 = true;

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

    //count the timer of when it collided
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "car")
        {
            stopBeizerCurve = true;

            //Change to true to show that there was just a change in the toggle state
            //if (!played)
            //{
            //    crash.Play();
            //    carDrift1.Play();
            //    played = !played;
            //}
        }
    }
}
