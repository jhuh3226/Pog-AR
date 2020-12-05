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
                ball.transform.position = new Vector3((a[counter].x - a[0].x) * 3.8f + a[0].x, a[counter].y, a[counter].z);
                counter += 3;
            }
            else
            {
                counter = 0;
            }
        }
    }
}