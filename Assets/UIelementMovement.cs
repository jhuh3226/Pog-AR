using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIelementMovement : MonoBehaviour
{
    public GameObject pedestrianArrow;
    public GameObject targetGameObject;

    Vector3 startPosition;
    Vector3 endPosition;

    private void OnEnable()
    {
        StartCoroutine("UIcoroutine");
    }

    private void OnDisable()
    {
        StopCoroutine("UIcoroutine");
    }

    private IEnumerator UIcoroutine()
    {
        while(true)
        {
            //while( Vector3.Distance(pedestrianArrow.transform.position, targetGameObject.transform.position))
            //{
            //    pedestrianArrow.transform.position = Vector3.MoveTowards (pedestrianArrow.transform.position, )
            //}
        }
    }
}
