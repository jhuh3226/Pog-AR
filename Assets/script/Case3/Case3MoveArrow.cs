using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case3MoveArrow : MonoBehaviour
{
    //public Canvas pedestrianArrow;
    //public RectTransform arrowPointingRoadSign;
    Vector3 startingPosition;

    Vector3 startPosition;
    Vector3 endPosition;
    public float speed;

    int countArrowRepeat;
    bool pedestrianArrowMove;

    public bool countArrowRepeatOver3 = false;

    //bool to connect to the pogbotObject
    //public bool movePogBot;


    // Start is called before the first frame update
    void Start()
    {
        //arrowPointingRoadSign = GameObject.Find("CanvasArrow").GetComponent<RectTransform>();

        startingPosition = transform.localPosition;

        countArrowRepeat = 0;
        pedestrianArrowMove = true;

        //movePogBot = false;
    }

    // Update is called once per frame
    void Update()
    {
        print("countArrowRepeat: " + countArrowRepeat);

        MoveArrow();

        if (this.transform.localPosition.y <= 1.98f)
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

            this.transform.localPosition = new Vector3(0.54f, 2.39f, 0.38f);

            //bool to send info to "Case2CanvasHolder"
            countArrowRepeatOver3 = true;
        }
    }

    void MoveArrow()
    {
        startPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        endPosition = new Vector3(transform.localPosition.x, 1.96f, transform.localPosition.z);

        transform.localPosition = Vector3.Lerp(startPosition, endPosition, speed * Time.deltaTime);
    }

    void GoBackToOriginalPosition()
    {
        this.transform.localPosition = new Vector3(0.54f, 2.39f, 0.38f);

        startPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        endPosition = new Vector3(transform.localPosition.x, 1.96f, transform.localPosition.z);

        transform.localPosition = Vector3.Lerp(startPosition, endPosition, speed * Time.deltaTime);

        countArrowRepeat = countArrowRepeat + 1;
    }
}
