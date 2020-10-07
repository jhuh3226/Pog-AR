using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case3p2CanvasHolder : MonoBehaviour
{
    public Canvas CV1;
    public Canvas CV2;

    public Canvas CanvasArrow;
    public GameObject Arrow;

    public Canvas CVMissionClear;

    bool CVAccidentDetailOn;
    bool timeRecorded = false;

    public GameObject gameObCase3p2BeizerCurveCar;

    float arrowEndingTime;

    //get elements from other script
    //get info from Case2BeizerCurveCar, checking whether car passed point3
    //public GameObject gameObCase3BeizerCurveCar;

    ////get info from Case2MoveArrow
    public GameObject gameObCase3p2MoveArrow;

    // Start is called before the first frame update
    void Start()
    {
        CV1.enabled = true;

        //cv2 only shows up in certain condition
        CV2.enabled = false;

        CanvasArrow.enabled = false;

        CVMissionClear.enabled = false;

        //control button CheckAccidentPoint, when clicked inactivate CVAccidentHappened and activate CVAccidentDetail
        //Button btn1 = btCheckAccidentPoint.GetComponent<Button>();
        //btn1.onClick.AddListener(TaskOnClick1);
    }

    // Update is called once per frame
    void Update()
    {
        //Case3BeizerCurveCar case3BeizerCurveCar = gameObCase3BeizerCurveCar.GetComponent<Case3BeizerCurveCar>();

        //Debug.Log("difference: " + (Time.fixedTime - case2BeizerCurveCar.crashedTime));
        //Debug.Log("crashedTime: " + case2BeizerCurveCar.crashedTime);

        //if 2 seconds passed after car passed point3
        //if (case3BeizerCurveCar.vehiclePassedPoint3 == true)
        //{

        //    if (Time.fixedTime - case3BeizerCurveCar.crashedTime >= 2)
        //    {
        //        if (CVAccidentDetailOn == false)
        //        {
        //            Debug.Log("turn on CVAccidentHappened canvas");
        //            CV1.enabled = true;
        //        }

        //        else
        //        {
        //            CV1.enabled = false;
        //        }
        //    }

        //}

        //turn on the Case3p2MoveArrow(arrow movement) script when car passes the last point
        Case3p2BeizerCurveCar case3p2BeizerCurveCar = gameObCase3p2BeizerCurveCar.GetComponent<Case3p2BeizerCurveCar>();
        if (case3p2BeizerCurveCar.vehiclePassedPoint3 == true)
        {
            CanvasArrow.enabled = true;
            Arrow.GetComponent<Case3p2MoveArrow>().enabled = true;

        }

        //if arrow moved three times, then turn on CV2 and turn off CV1
        Case3p2MoveArrow case3p2MoveArrow = gameObCase3p2MoveArrow.GetComponent<Case3p2MoveArrow>();
        if (case3p2MoveArrow.arrowMovedThreeTimes == true)
        {
            if (timeRecorded == false)
            {
                Debug.Log("turn on CV2");

                CV1.enabled = false;
                CV2.enabled = true;

                //record the current time when CV2 is turned on
                arrowEndingTime = Time.fixedTime;
                timeRecorded = true;
            }
        }

        if (Time.fixedTime - arrowEndingTime >= 2)
        {
            if (timeRecorded == true)
            {
                CVMissionClear.enabled = true;
            }
            CV2.enabled = false;
        }

    }

    //after btn1 is clicked 1) turn on Case2MoveArrow 2) and after certain count, turn on CVAccidentDetail
    void TaskOnClick1()
    {
        //CanvasArrow.enabled = true;
        //Arrow.GetComponent<Case3MoveArrow>().enabled = true;

        //CVAccidentDetailOn = true;

    }
}
