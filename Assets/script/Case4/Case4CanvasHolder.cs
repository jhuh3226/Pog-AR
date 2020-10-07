using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Case4CanvasHolder : MonoBehaviour
{
    public Canvas CV1;
    //public Canvas CVAccidentDetail;

    //public Canvas CanvasArrow;
    //public GameObject Arrow;

    public Button btCheckAccidentPoint;

    //bool CVAccidentDetailOn;

    //float currentTime;

    //get elements from other script
    //get info from Case2BeizerCurveCar, checking whether car passed point3
    public GameObject gameObCase4BeizerCurveCar;

    ////get info from Case2MoveArrow
    //public GameObject gameObCase3MoveArrow;

    // Start is called before the first frame update
    void Start()
    {
        CV1.enabled = false;
        //CVAccidentDetail.enabled = false;

        //CVAccidentDetailOn = false;

        //CanvasArrow.enabled = false;

        //control button CheckAccidentPoint, when clicked inactivate CVAccidentHappened and activate CVAccidentDetail
        Button btn1 = btCheckAccidentPoint.GetComponent<Button>();
        btn1.onClick.AddListener(TaskOnClick1);
    }

    // Update is called once per frame
    void Update()
    {
        Case4BeizerCurveCar case4BeizerCurveCar = gameObCase4BeizerCurveCar.GetComponent<Case4BeizerCurveCar>();

        //Debug.Log("difference: " + (Time.fixedTime - case2BeizerCurveCar.crashedTime));
        //Debug.Log("crashedTime: " + case2BeizerCurveCar.crashedTime);

        //if 2 seconds passed after car passed point3
        if (case4BeizerCurveCar.vehiclePassedPoint3 == true)
        {

            if (Time.fixedTime - case4BeizerCurveCar.crashedTime >= 2)
            {
                //if (CVAccidentDetailOn == false)
                //{
                    Debug.Log("turn on CVAccidentHappened canvas");
                    CV1.enabled = true;
                //}

                //else
                //{
                //    CV1.enabled = false;
                //}
            }

        }

        //Case3MoveArrow case3MoveArrow = gameObCase3MoveArrow.GetComponent<Case3MoveArrow>();
        //if (case3MoveArrow.countArrowRepeatOver3 == true)
        //{
        //    Debug.Log("turn on CVAccidentDetail");
        //    //CVAccidentDetail.enabled = true;
        //}

    }

    //after btn1 is clicked 1) turn on Case2MoveArrow 2) and after certain count, turn on CVAccidentDetail
    void TaskOnClick1()
    {
        //CanvasArrow.enabled = true;
        //Arrow.GetComponent<Case3MoveArrow>().enabled = true;

        //CVAccidentDetailOn = true;

    }
}
