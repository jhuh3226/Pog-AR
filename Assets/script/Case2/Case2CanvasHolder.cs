using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Case2CanvasHolder : MonoBehaviour
{

    public Canvas CVAccidentHappened;
    public Canvas CVAccidentDetail;

    public Canvas CanvasArrow;
    public GameObject Arrow;

    public Button btCheckAccidentPoint;

    bool CVAccidentDetailOn;

    float currentTime;

    //get elements from other script
    //get info from Case2BeizerCurveCar, checking whether car passed point3
    public GameObject gameObCase2BeizerCurveCar;

    ////get info from Case2MoveArrow
    public GameObject gameObCase2MoveArrow;

    // Start is called before the first frame update
    void Start()
    {
        CVAccidentHappened.enabled = false;
        CVAccidentDetail.enabled = false;

        CVAccidentDetailOn = false;

        CanvasArrow.enabled = false;

        //control button CheckAccidentPoint, when clicked inactivate CVAccidentHappened and activate CVAccidentDetail
        Button btn1 = btCheckAccidentPoint.GetComponent<Button>();
        btn1.onClick.AddListener(TaskOnClick1);
    }

    // Update is called once per frame
    void Update()
    {
        Case2BeizerCurveCar case2BeizerCurveCar = gameObCase2BeizerCurveCar.GetComponent<Case2BeizerCurveCar>();

        //Debug.Log("difference: " + (Time.fixedTime - case2BeizerCurveCar.crashedTime));
        //Debug.Log("crashedTime: " + case2BeizerCurveCar.crashedTime);

        //if 2 seconds passed after car passed point3
        if (case2BeizerCurveCar.vehiclePassedPoint3 == true)
        {

            if (Time.fixedTime - case2BeizerCurveCar.crashedTime >= 2)
            {
                if (CVAccidentDetailOn == false)
                {
                    Debug.Log("turn on CVAccidentHappened canvas");
                    CVAccidentHappened.enabled = true;
                }

                else
                {
                    CVAccidentHappened.enabled = false;
                }
            }

        }

        Case2MoveArrow case2MoveArrow = gameObCase2MoveArrow.GetComponent<Case2MoveArrow>();
        if (case2MoveArrow.countArrowRepeatOver3 == true)
        {
            Debug.Log("turn on CVAccidentDetail");
            CVAccidentDetail.enabled = true;
        }

        //if (Time.fixedTime - currentTime >= 1.5 && currentTime > 0)
        //{
        //    Debug.Log("CVAccidentHappened");
        //    enableCheckAccidentPoint = true;

        //    accidentHappendOn = false;
        //    accidentHappend.enabled = false;
        //    checkAccidentPoint.enabled = true;
        //    arrow1.enabled = true;

        //    enableTiltedArrow = true;
        //}
    }

    //after btn1 is clicked 1) turn on Case2MoveArrow 2) and after certain count, turn on CVAccidentDetail
    void TaskOnClick1()
    {
        CanvasArrow.enabled = true;
        Arrow.GetComponent<Case2MoveArrow>().enabled = true;

        CVAccidentDetailOn = true;
    }
}
