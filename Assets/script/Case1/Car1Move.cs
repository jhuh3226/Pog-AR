using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car1Move : MonoBehaviour
{
  public float speed;
  Vector3 startPosition;
  Vector3 endPosition;

  // Use this for initialization
  void Start()
  {
        //startPostion and endPosition used to be here

  }

  // Update is called once per frame
  void Update()
  {
        Debug.Log(Time.deltaTime);
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);

        startPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        endPosition = new Vector3(2.36f, transform.localPosition.y, transform.localPosition.z);

        transform.localPosition = Vector3.Lerp(startPosition, endPosition, speed * Time.deltaTime);
  }


}
