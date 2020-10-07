﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case5p2MoveArrow2 : MonoBehaviour
{
    Vector3 startingPosition;

    Vector3 startPosition;
    Vector3 endPosition;
    public float speed;

    int countArrowRepeat;
    bool pedestrianArrowMove;

    public bool countArrowRepeatOver3 = false;


    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.localPosition;

        countArrowRepeat = 0;
        pedestrianArrowMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        print("countArrowRepeat: " + countArrowRepeat);

        MoveArrow();

        if (this.transform.localPosition.z >= 0.55f)
        {
            if (pedestrianArrowMove == true)
            {
                GoBackToOriginalPosition();
            }
        }

        if (countArrowRepeat >= 3)
        {
            //stop moving the arrow
            pedestrianArrowMove = false;

            this.transform.localPosition = new Vector3(0f, 0f, 0f);

            //bool to send info to "Case2CanvasHolder"
            countArrowRepeatOver3 = true;
        }
    }

    void MoveArrow()
    {
        startPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        endPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0.58f);

        transform.localPosition = Vector3.Lerp(startPosition, endPosition, speed * Time.deltaTime);
    }

    void GoBackToOriginalPosition()
    {
        this.transform.localPosition = new Vector3(0f, 0f, 0f);

        startPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        endPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0.58f);

        transform.localPosition = Vector3.Lerp(startPosition, endPosition, speed * Time.deltaTime);

        countArrowRepeat = countArrowRepeat + 1;
    }
}
