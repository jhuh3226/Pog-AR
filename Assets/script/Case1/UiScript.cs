using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiScript : MonoBehaviour
{
    public Canvas accidentHappend;
    public Canvas checkAccidentPoint;

    public Button bt1;

    void Start()
    {
        checkAccidentPoint.enabled = false;

        Button btn = bt1.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        accidentHappend.enabled = false;
        checkAccidentPoint.enabled = true;
        print("btClicked");
    }
}
