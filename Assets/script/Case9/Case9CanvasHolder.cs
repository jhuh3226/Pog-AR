using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Case9CanvasHolder : MonoBehaviour
{
    public GameObject CV1;
    public GameObject CV2;

    public GameObject CVArrow;
    public GameObject ArrowImage;


    public GameObject gameObCase9BeizerCurveCar;

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
        Case9BeizerCurveCar case9BeizerCurveCar = gameObCase9BeizerCurveCar.GetComponent<Case9BeizerCurveCar>();

        if (case9BeizerCurveCar.vehiclePassedPoint3)
        {
            if (Time.fixedTime - case9BeizerCurveCar.crashedTime >= 2)
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

        CVArrow.GetComponent<Canvas>().enabled = true;
        ArrowImage.GetComponent<Case9MoveArrow>().enabled = true;
    }
}
