using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case1point2AnimationHolder : MonoBehaviour
{
    public RuntimeAnimatorController turnBodyLeft90Degrees;
    public RuntimeAnimatorController lookLeftLoop;
    public RuntimeAnimatorController lookRightLoop;

    Animator m_Animator;

    public GameObject pogBotToMove;
    public GameObject gameObContainingScriptBeizerFollow2;
    public GameObject gameObContainingCase1point2CanvasHolderScript;

    bool bodyTurnedLeft;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = pogBotToMove.GetComponent<Animator>();
        bodyTurnedLeft = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime);

        BeizerFollow2 BeizerFollowScript2 = gameObContainingScriptBeizerFollow2.GetComponent<BeizerFollow2>();
        Case1point2CanvasHolder case1point2CanvasHolderScript = gameObContainingCase1point2CanvasHolderScript.GetComponent<Case1point2CanvasHolder>();

        if (BeizerFollowScript2.pogBotPassedPoint3 == true)
        {
            Debug.Log("finished walking so, turn body left");
            if (bodyTurnedLeft == false)
            {
                turnBodyLeft();
                bodyTurnedLeft = true;
            }

        }

        if (bodyTurnedLeft == true)
        {
            if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 3.0f)
            {
                if (case1point2CanvasHolderScript.turnLookRightAnimation == false)
                {
                    turnHeadLeft();
                }

                //else if (case1point2CanvasHolderScript.turnLookRightAnimation == true)
                //{
                //    Debug.Log("turn head right ani triggered");

                //    if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 3.0f)
                //    {
                //        turnHeadRight();
                //    }
                //}

            }

        }

        if (case1point2CanvasHolderScript.turnLookRightAnimation == true)
        {
            Debug.Log("turn head righ0t ani triggered");

            //if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            //{
                turnHeadRight();
            //}
        }
    }

    void turnBodyLeft()
    {
        pogBotToMove.GetComponent<Animator>().runtimeAnimatorController = turnBodyLeft90Degrees as RuntimeAnimatorController;
    }

    void turnHeadLeft()
    {
        pogBotToMove.GetComponent<Animator>().runtimeAnimatorController = lookLeftLoop as RuntimeAnimatorController;
    }

    void turnHeadRight()
    {
        pogBotToMove.GetComponent<Animator>().runtimeAnimatorController = lookRightLoop as RuntimeAnimatorController;
    }
}
