using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case2BeizerCurvePogBot : MonoBehaviour
{
    [SerializeField]
    private Transform[] routes;

    private int routeToGo;

    private float tParam;

    private Vector3 busPosition;

    public float speedModifier;

    private bool coroutineAllowed;

    public float rotationSpeed;

    public bool vehiclePassedPoint2;

    public bool pogBotPassedPoint3;

    //collider
    bool stopBeizerCurve = false;
    //sound
    public AudioSource crash;
    public AudioSource carDrift1;
    bool played = false;

    private void Start()
    {
        routeToGo = 0;
        tParam = 0f;
        //speedModifier = 0.5f;
        coroutineAllowed = true;

        vehiclePassedPoint2 = false;
        pogBotPassedPoint3 = false;
    }

    public void Reset()
    {
        routeToGo = 0;
        tParam = 0f;
        speedModifier = 0.5f;
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

        while (tParam < 2 && !stopBeizerCurve)
        {

            if (pogBotPassedPoint3 == false)
            {
                tParam += Time.deltaTime * speedModifier;

                busPosition = Mathf.Pow(1 - tParam, 3) * p0 + 3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 + 3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 + Mathf.Pow(tParam, 3) * p3;

                transform.localPosition = busPosition;
            }

            //rotate bus
            if (transform.localPosition.z > p3.z)
            {

                Debug.Log("PogBot passed last point");
            }

            //if passed p3, then stop the pogBot, and start new pogBot with errors pointing

            yield return new WaitForEndOfFrame();
        }

    }

    //count the timer of when it collided
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "car")
        {
            Debug.Log("crashed with car");
            stopBeizerCurve = true;

            //on crash, pogbot position change to -2 for short time 30/8/0.7
            //this.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -1.8f);

            //Change to true to show that there was just a change in the toggle state
            if (!played)
            {
                crash.Play();
                carDrift1.Play();
                played = !played;
            }
        }
    }
}
