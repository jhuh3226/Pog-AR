using UnityEngine;
using UnityEngine.UI;
using ImageTool;
class Runner : MonoBehaviour
{
    public int speed;

    Vector3 startPosition;
    Vector3 endPosition;
    int counter = 0;
    public GameObject car;
    public GameObject carPoint0;
    public GameObject carPoint1;
    public GameObject carPoint2;
    public GameObject carPoint3;
    public float carXAdjustValue;
    public float carYAdjustValue;

    public GameObject pogBot;
    public GameObject pogPoint0;
    public GameObject pogPoint1;
    public GameObject pogPoint2;
    public GameObject pogPoint3;
    public float pogXAdjustValue;
    public float pogYAdjustValue;
    public float pogZAdjustValue;

    public bool runnerDone = false;     // var to check deeplearning done or not

    ImageTool.ImageTool i;

    void Start()
    {
        i = new ImageTool.ImageTool();
        i.init();
    }
    void Update()
    {
        if (i.isDone)
        {
            runnerDone = true;      // deeplearning done

            var a = i.GetWorldLine();
            if (counter < a.Count)
            {
                //float newX = a[counter].x - a[0].x + a[0].x + 3.0f;
                //float newY = a[counter].y - a[0].y + a[0].y + 2.0f;

                // original counter value is 5, substituted to 'speed'
                //counter += speed;

                //car.transform.position = new Vector3(newX, newY, a[counter].z);

                // new setting for the Y position, where car is situated on right side(upper line)
                float carNewX = a[a.Count - 1].x + carXAdjustValue;
                float carNewY = a[counter].y + carYAdjustValue;

                float carP0X = carNewX;
                float carP1X = carNewX - (carNewX - a[0].x) * 1/3;
                float carP2X = carNewX - (carNewX - a[0].x) * 2/3;
                float carP3X = a[0].x;

                // setting position of the car beizercarve
                carPoint0.transform.position = new Vector3(carP0X, carNewY, a[counter].z);
                carPoint1.transform.position = new Vector3(carP1X, carNewY, a[counter].z);
                carPoint2.transform.position = new Vector3(carP2X, carNewY, a[counter].z);
                carPoint3.transform.position = new Vector3(carP3X, carNewY, a[counter].z);

                // console out
                //Debug.Log("X position: " + newX);
                //Debug.Log("Y position: " + newY);

                Debug.Log("X length first: " + a[0].x);
                Debug.Log("X length last: " + a[a.Count - 1].x);
                Debug.Log("Y length first: " + a[0].y);
                Debug.Log("Y length last: " + a[a.Count- 1].y);

                float pogNewX = a[(a.Count - 1)/2].x + pogXAdjustValue;
                float pogNewY = a[(a.Count - 1) / 2].y + pogYAdjustValue;
                float pogNewZ = a[(a.Count - 1) / 2].z + pogZAdjustValue;


                // initial pogbot position is relative to the position oof newX and Y
                pogBot.transform.localPosition = new Vector3(pogNewX, pogNewY, pogNewZ);
            }
            else
            {
                counter = 0;
            }
        }
    }
}