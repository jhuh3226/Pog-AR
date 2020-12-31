using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DLTool;

public class RunnerTestBtCanvasHolder : MonoBehaviour
{
    public Button btRunnerStart;
    // runner script
    public GameObject eventSystem;
    // canvas
    public Canvas CVStartRunner;
    public Canvas Canvas;

    // get info from runner
    public GameObject gameObRunnerTest;

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
        DLTool.RunnerTest runner = gameObRunnerTest.GetComponent<DLTool.RunnerTest>();
        if (runner.runnerDone)
        {
            Canvas.enabled = true;
        }
    }

    void TaskOnClickBtRunnerStart()
    {
        print("bt runnerStart Clicked");

        // disable CVStartRunner
        CVStartRunner.enabled = false;

        // enable runner script
        eventSystem.GetComponent<DLTool.RunnerTest>().enabled = true;
    }
}
