using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case2p2ActivatePogBot2 : MonoBehaviour
{
    //check pogbot2 activation status
    public bool pogBot2Activated;

    public GameObject POGCrossing;
    public GameObject POGCrossing2;

    public GameObject gameObContainingCase2p2BeizerCurvePogBot;
    public GameObject gameObContainingCase2p2AnimationHolder;


    Animator m_Animator;

    //boolean used in Case2p2CanvasHolder
    public bool pogCrossingActive2 = false;

    // Start is called before the first frame update
    void Start()
    {
        pogBot2Activated = false;

        m_Animator = POGCrossing.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if _seconds after the animation deactivate pogbot and activate pogbot2
        Case2p2BeizerCurvePogBot case2p2BeizerCurvePogBot = gameObContainingCase2p2BeizerCurvePogBot.GetComponent<Case2p2BeizerCurvePogBot>();

        if (case2p2BeizerCurvePogBot.pogBotPassedPoint3 == true)
        {
            if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.5f)
            {
                POGCrossing.SetActive(false);
                POGCrossing2.SetActive(true);

                pogCrossingActive2 = true;
            }
        }

        Debug.Log("time now: " + m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
    }
}
