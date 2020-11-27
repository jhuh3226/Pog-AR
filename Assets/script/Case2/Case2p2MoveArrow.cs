using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case2p2MoveArrow : MonoBehaviour
{
    //public Canvas pedestrianArrow;
    public RectTransform pedestrianArrow;
    Vector3 startingPosition;

    Vector3 startPosition;
    Vector3 endPosition;
    public float speed;

    int countArrowRepeat;
    bool pedestrianArrowMove;

    //bool sending to Case2p2CanvasHolder
    public bool arrowMovedThreeTimes;


    // Start is called before the first frame update
    void Start()
    {
        pedestrianArrow = GameObject.Find("CanvasArrow").GetComponent<RectTransform>();
        startingPosition = transform.localPosition;

        countArrowRepeat = 0;
        pedestrianArrowMove = true;

        arrowMovedThreeTimes = false;
    }

    // Update is called once per frame
    void Update()
    {
        MoveArrow();

        if (this.transform.localPosition.z >= 0.7f)
        {
            if (pedestrianArrowMove == true)
            {
                GoBackToOriginalPosition();
            }
        }

        if (countArrowRepeat >= 5)
        {
            //stop moving the arrow
            pedestrianArrowMove = false;

            this.transform.localPosition = new Vector3(1.04f, 0f, 0.19f);

            //bool sending to Case2p2CanvasHolder
            arrowMovedThreeTimes = true;
        }
    }

    void MoveArrow()
    {
        startPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        endPosition = new Vector3(0.73f, transform.localPosition.y, 0.76f);

        transform.localPosition = Vector3.Lerp(startPosition, endPosition, speed * Time.deltaTime);
    }

    void GoBackToOriginalPosition()
    {
        this.transform.localPosition = new Vector3(1.04f, 0f, 0.19f);
        //stopPedestrianArrowMovement = true;

        //Debug.Log(countArrowRepeat);

        //restartArrow = true;

        startPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        endPosition = new Vector3(0.73f, transform.localPosition.y, 0.76f);

        transform.localPosition = Vector3.Lerp(startPosition, endPosition, speed * Time.deltaTime);

        countArrowRepeat = countArrowRepeat + 1;
    }
}
