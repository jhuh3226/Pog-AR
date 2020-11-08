using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case1Crash : MonoBehaviour
{
    //sound
    public AudioSource crash;
    public AudioSource carDrift1;
    bool played = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "car")
        {
            Debug.Log("crashed with car");

            //on crash, pogbot position change to -2 for short time 30/8/0.7
            //this.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -1.8f);

            //Change to true to show that there was just a change in the toggle state
            if (!played)
            {
                crash.Play();
                carDrift1.Play();
                played = !played;
            }

            ////record crashTime
            //if (recorded == false)
            //{
            //    lastPointTime = Time.fixedTime;
            //    recorded = !recorded;
            //}
        }
    }
}
