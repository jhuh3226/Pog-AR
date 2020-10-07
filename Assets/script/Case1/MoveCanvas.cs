using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCanvas : MonoBehaviour
{
    //public Canvas pedestrianArrow;
    public RectTransform pedestrianArrow;
    Vector3 startingPosition;

    Vector3 startPosition;
    Vector3 endPosition;
    public float speed;

    int countArrowRepeat;
    bool pedestrianArrowMove;

    //bool to connect to the pogbotObject
    public bool movePogBot;


    // Start is called before the first frame update
    void Start()
    {
        pedestrianArrow = GameObject.Find("CanvasArrow").GetComponent<RectTransform>();
        startingPosition = transform.localPosition;

        countArrowRepeat = 0;
        pedestrianArrowMove = true;

        movePogBot = false;
    }

    // Update is called once per frame
    void Update()
    {
        MoveArrow();

        if (this.transform.localPosition.z >= 0.4f)
        {
            if (pedestrianArrowMove == true)
            {
                GoBackToOriginalPosition();
            }
        }

        if (countArrowRepeat >=3)
        {
            //stop moving the arrow
            pedestrianArrowMove = false;

            this.transform.localPosition = new Vector3(5.98f, 0f, -1.32f);

            //send bool to pogBotMovement
            movePogBot = true;
        }
    }

    void MoveArrow()
    {
        startPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        endPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0.5f);

        transform.localPosition = Vector3.Lerp(startPosition, endPosition, speed * Time.deltaTime);
    }

    void GoBackToOriginalPosition()
    {
        this.transform.localPosition = new Vector3(5.98f, 0f, -1.32f);
        //stopPedestrianArrowMovement = true;

        //Debug.Log(countArrowRepeat);

        //restartArrow = true;

        startPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        endPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0.5f);

        transform.localPosition = Vector3.Lerp(startPosition, endPosition, speed * Time.deltaTime);

        countArrowRepeat = countArrowRepeat + 1;
    }

}
