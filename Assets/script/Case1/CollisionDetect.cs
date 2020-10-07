using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    public bool collidedWithBus;

    public float speed;
    Vector3 startPosition;
    Vector3 endPosition;

    // Use this for initialization
    void Start()
    {
        collidedWithBus = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bus")
        {
            collidedWithBus = true;
            print("collided with bus");

            //startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            //endPosition = new Vector3(transform.position.x, transform.position.y, -0.41f);

            //transform.localPosition = Vector3.Lerp(startPosition, endPosition, speed * Time.deltaTime);
        }
    }
}
