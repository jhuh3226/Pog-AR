using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case4BeizerCurvePogBot : MonoBehaviour
{
    [SerializeField]
    private Transform[] routes;

    private int routeToGo;

    private float tParam;

    private Vector3 busPosition;

    public float speedModifier;

    private bool coroutineAllowed;

    public bool pogBotPassedPoint3;

    //collider
    bool collided = false;
    bool recorded = false;
    bool stopBeizerCurve = false;
    float collidedTime  = 0;
    //sound
    public AudioSource crash;
    public AudioSource carDrift1;
    bool played = false;

    private void Start()
    {
        routeToGo = 0;
        tParam = 0f;
        //speedModifier = 0.45f;
        coroutineAllowed = true;

        pogBotPassedPoint3 = false;
    }

    public void Reset()
    {
        routeToGo = 0;
        tParam = 0f;
        speedModifier = 0.37f;
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
            //stop the movement
            if (pogBotPassedPoint3 == false)
            {
                tParam += Time.deltaTime * speedModifier;

                busPosition = Mathf.Pow(1 - tParam, 3) * p0 + 3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 + 3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 + Mathf.Pow(tParam, 3) * p3;

                transform.localPosition = busPosition;
            }

            //stop the pogbot
            if (transform.localPosition.y < p3.y)
            {
                pogBotPassedPoint3 = true;
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
            //If the GameObject has the same tag as specified, output this message in the console
            collided = true;

            if (!recorded)
            {
                collidedTime = Time.fixedTime;
                recorded = !recorded;
            }
            Debug.Log("pogBot collided car "+ collidedTime);

            if(collidedTime!=0 && Time.fixedTime - collidedTime>0.3)
            {
                stopBeizerCurve = true;

                //Change to true to show that there was just a change in the toggle state
                if (!played)
                {
                    crash.Play();
                    carDrift1.Play();
                    played = !played;
                }
            }
            //Debug.Log("stop beizerCurve" + (Time.fixedTime - collidedTime));
        }
    }
}
