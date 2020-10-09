using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case8BeizerCurvePogBot : MonoBehaviour
{
    [SerializeField]
    private Transform[] routes;

    private int routeToGo;

    private float tParam;

    private Vector3 busPosition;

    private float speedModifier;

    private bool coroutineAllowed;

    public bool pogBotPassedPoint0;
    public bool pogBotPassedPoint2;
    public bool pogBotPassedPoint3;

    private void Start()
    {
        routeToGo = 0;
        tParam = 0f;
        speedModifier = 0.37f;
        coroutineAllowed = true;

        pogBotPassedPoint0 = false;
        pogBotPassedPoint2 = false;
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

        while (tParam < 2)
        {
            //stop the movement
            if (pogBotPassedPoint3 == false)
            {
                tParam += Time.deltaTime * speedModifier;

                busPosition = Mathf.Pow(1 - tParam, 3) * p0 + 3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 + 3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 + Mathf.Pow(tParam, 3) * p3;

                transform.localPosition = busPosition;
            }

            //stop the pogbot
            if (transform.localPosition.x > p0.x)
            {
                pogBotPassedPoint0 = true;
            }

            if (transform.localPosition.x > p2.x)
            {
                pogBotPassedPoint2 = true;
            }

            if (transform.localPosition.x > p3.x)
            {
                pogBotPassedPoint3 = true;
            }

            //if passed p3, then stop the pogBot, and start new pogBot with errors pointing

            yield return new WaitForEndOfFrame();
        }

    }
}
