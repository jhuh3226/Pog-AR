using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DLTool;

public class DlCase7CanvasHolder : MonoBehaviour
{
    public Button btRunnerStart;
    // runner script
    public GameObject eventSystem;
    // canvas
    public Canvas CVStartRunner;

    // script DlCase2BeizerCurveCar
    public GameObject car;
    // script DlCase2BeizerCurvePogBot
    public GameObject pogBot;

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
        DLTool.DlCase2p3Runner runner = gameObRunner.GetComponent<DLTool.DlCase2p3Runner>();
        if (runner.runnerDone)
        {
            car.GetComponent<Case7BeizerCurveCar>().enabled = true;
            car.GetComponent<Case7CarRotate>().enabled = true;
            pogBot.GetComponent<Case7BeizerCurvePogBot>().enabled = true;
        }
    }

    void TaskOnClickBtRunnerStart()
    {
        print("bt runnerStart Clicked");

        // disable CVStartRunner
        CVStartRunner.enabled = false;

        // enable runner script
        eventSystem.GetComponent<DLTool.DlCase2p3Runner>().enabled = true;
    }
}
