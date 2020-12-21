using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DlCase2CanvasHolder : MonoBehaviour

{
    public Button btRunnerStart;
    // runner script
    public GameObject eventSystem;
    // canvas
    public Canvas CVStartRunner;

    // script DlCase2BeizerCurveCar
    public GameObject newCar;

    // get info from runner
    public GameObject gameObRunner;

    // Start is called before the first frame update
    void Start()
    {
        Button btnRunnerStart = btRunnerStart.GetComponent<Button>();
        btnRunnerStart.onClick.AddListener(TaskOnClickBtRunnerStart);
    }

    // Update is called once per frame
    void Update()
    {
        // move car according to the beizercurve only after deeplearning
        Runner runner = gameObRunner.GetComponent<Runner>();
        if(runner.runnerDone)
        {
            newCar.GetComponent<DlCase2BeizerCurveCar>().enabled = true;
        }
    }

    void TaskOnClickBtRunnerStart()
    {
        print("bt runnerStart Clicked");

        // disable CVStartRunner
        CVStartRunner.enabled = false;

        // enable runner script
        eventSystem.GetComponent<Runner>().enabled = true;
    }
}