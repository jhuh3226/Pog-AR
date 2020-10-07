using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PogAnimationHolder : MonoBehaviour
{
    Animator m_Animator;
    public GameObject pogBot;
    public RuntimeAnimatorController animLookLeft;

    public bool lookLeft;
    //bool positionUpdated = false;

    void Start()
    {
        //Get the Animator, which you attach to the GameObject you intend to animate.
        m_Animator = pogBot.GetComponent<Animator>();

        lookLeft = false;
    }

    void Update()
    {
        Debug.Log(m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        //Debug.Log("2: " + m_Animator.GetCurrentAnimatorStateInfo(0).length);

        //When entering the Jump state in the Animator, output the message in the console


        if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            if (lookLeft == false)
            {
                Debug.Log("lookLeft");

                this.GetComponent<Animator>().runtimeAnimatorController = animLookLeft as RuntimeAnimatorController;

                lookLeft = true;
            }
        }
    }

    void LateUpdate()
    {
        // if the animation is finished and it was started
        //if (pettingStarted == true)
        //{
        //    if (positionUpdated == false)
        //    {
        //        // update the parent position
        //        transform.parent.position = new Vector3(-1.79f, 0f, 0f);
        //        m_Animator.Play("Petting Animal", 0, 0);
        //        // update the box position to zero inside the parent
        //        //transform.localPosition = Vector3.zero;
        //        positionUpdated = true;
        //    }
        //}
    }
}
