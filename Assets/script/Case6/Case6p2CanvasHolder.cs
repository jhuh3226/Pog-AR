using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Case6p2CanvasHolder : MonoBehaviour
{
    public Button bt1;

    public GameObject CV1;
    public GameObject CV2;

    public GameObject CVArrow1;
    public GameObject ArrowImage;

    public GameObject car;

    // Start is called before the first frame update
    void Start()
    {
        //bt
        Button btn1 = bt1.GetComponent<Button>();
        btn1.onClick.AddListener(TaskOnClick1);
    }

    // Update is called once per frame
    void Update()
    {
        //in the start, activate CV1 and moving arrow
        CV1.GetComponent<Canvas>().enabled = true;
        CVArrow1.GetComponent<Canvas>().enabled = true;
        ArrowImage.GetComponent<Case6p2MoveArrow>().enabled = true;

        //
    }

    void TaskOnClick1()
    {
        Debug.Log("bt clicked");
        //disable cv1 and CanvasArrow1 when bt is clicked
        CV1.SetActive(false);
        CVArrow1.SetActive(false);

        //turn on cv2
        CV2.GetComponent<Canvas>().enabled = true;
        //arrowLeftImage.GetComponent<Case4Blink>().enabled = true;

        //CVArrowLeftText.GetComponent<Canvas>().enabled = true;

        ////bool sending to case5p2AnimationHolder
        //startAnimating = true;
    }
}
