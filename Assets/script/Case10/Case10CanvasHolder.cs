using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Case10CanvasHolder : MonoBehaviour
{
    public GameObject CV1;
    public GameObject CV2;

    public GameObject CVArrow2;
    public GameObject ArrowImage2;

    public GameObject gameObCase10BeizerCurveCar;

    public Button bt1;

    // Start is called before the first frame update
    void Start()
    {
        Button btn1 = bt1.GetComponent<Button>();
        btn1.onClick.AddListener(TaskOnClickBT1);
    }

    // Update is called once per frame
    void Update()
    {
        //if car passed the last point and some seconds passed, activate canvas1
        Case10BeizerCurveCar case10BeizerCurveCar = gameObCase10BeizerCurveCar.GetComponent<Case10BeizerCurveCar>();
        if (case10BeizerCurveCar.vehiclePassedPoint3)
        {
            if (Time.fixedTime - case10BeizerCurveCar.crashedTime >= 1.5)
            {
                Debug.Log("turn on CVAccidentHappened canvas");
                CV1.GetComponent<Canvas>().enabled = true;
            }
        }
    }

    //if first bt clicked, activate CV3 and arrow2
    void TaskOnClickBT1()
    {
        Debug.Log("bt1 clicked");

        //disable
        CV1.SetActive(false);

        //enable
        CV2.GetComponent<Canvas>().enabled = true;

        CVArrow2.GetComponent<Canvas>().enabled = true;
        ArrowImage2.GetComponent<Case10MoveArrow2>().enabled = true;
    }
}
