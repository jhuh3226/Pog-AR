using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PogBotMoveForward : MonoBehaviour
{
    public GameObject pogBot1;
    public GameObject pogBot2;
    public float speed;
    Vector3 startPosition;
    Vector3 endPosition;

    bool stopMoving;

    // bool to control sceneFound script
    public bool pogBot2Activated;

    //controlling car
    public GameObject car1;

    //animation
    Animator m_Animator;
    public RuntimeAnimatorController animLookLeft;
    bool lookLeft;

    //get collision with car1
    public GameObject gameObContainingScript;

    // Use this for initialization
    void Start()
    {
        stopMoving = false;

        //Get the Animator, which you attach to the GameObject you intend to animate.
        m_Animator = this.GetComponent<Animator>();
        lookLeft = false;

        //controlling car
        car1.SetActive(false);

        pogBot2Activated = false;
    }

    // Update is called once per frame
    void Update()
    {
        CollideCar CollideCarScript = gameObContainingScript.GetComponent<CollideCar>();

        //Debug.Log(this.transform.localPosition.z);
        startPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        endPosition = new Vector3(transform.localPosition.x, -1.3f, transform.localPosition.z);

        //if (this.transform.localPosition.z <= -0.7f)
        //{
        //    transform.localPosition = Vector3.Lerp(startPosition, endPosition, speed * Time.deltaTime);
        //}

        //if pogBot already looked left or collided with car1, then stop the move forward movement

        MovepogBot();

        //if (CollideCarScript.collidedWithCar == true && stopMoving == true)
        //{
        //    transform.localPosition = new Vector3(-0.6001308f, 0.0001156926f, -0.2341481f);
        //    stopMoving = true;
        //}

        //animationn
        //Debug.Log(m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime);

        //When entering the lookLeft state in the Animator, output the message in the console
        if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f && m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1.15f)
        {
            Debug.Log("lookLeft");
            this.GetComponent<Animator>().runtimeAnimatorController = animLookLeft as RuntimeAnimatorController;

            //stop moving the pogBot
            stopMoving = true;

            car1.SetActive(true);
        }

        if (stopMoving == true)
        {
            if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5f)

            {
                pogBot1.SetActive(false);
                pogBot2.SetActive(true);

                pogBot2Activated = true;

            }

        }  
        
    }

    void MovepogBot()
    {
        if (stopMoving == false)
        {
            transform.localPosition = Vector3.Lerp(startPosition, endPosition, speed * Time.deltaTime);
        }
    }

}
