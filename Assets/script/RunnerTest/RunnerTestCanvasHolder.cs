using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLTool;

public class RunnerTestCanvasHolder : MonoBehaviour
{
    public Canvas Canvas;
    public GameObject gameObRunnerTest;

    // Start is called before the first frame update
    void Start()
    {
        
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
}
