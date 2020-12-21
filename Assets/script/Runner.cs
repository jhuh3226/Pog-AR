using UnityEngine;
using UnityEngine.UI;
using ImageTool;
class Runner : MonoBehaviour
{
    public float speed;
    Vector3 startPosition;
    Vector3 endPosition;
    int counter = 0;
    public GameObject ball;
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
            var a = i.GetWorldLine();
            if (counter < a.Count)
            {
                float newX = a[counter].x - a[0].x + a[0].x + 3.0f;
                float newY = a[counter].y - a[0].y + a[0].y + 2.0f;
                ball.transform.position = new Vector3(newX, newY, a[counter].z);
                counter += 5;
            }
            else
            {
                counter = 0;
            }
        }
    }
}