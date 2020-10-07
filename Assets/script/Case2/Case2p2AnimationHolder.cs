using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case2p2AnimationHolder : MonoBehaviour
{
    public RuntimeAnimatorController turnHeadRight;

    Animator m_Animator;

    public GameObject POGCrossing;
    public GameObject gameObContainingCase2p2BeizerCurvePogBot;

    bool turnedHeadRight;


    // Start is called before the first frame update
    void Start()
    {
        m_Animator = POGCrossing.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Case2p2BeizerCurvePogBot case2p2BeizerCurvePogBot = gameObContainingCase2p2BeizerCurvePogBot.GetComponent<Case2p2BeizerCurvePogBot>();
       

        if (case2p2BeizerCurvePogBot.pogBotPassedPoint3 == true)
        {
            if (turnedHeadRight == false)
            {
                turnHeadRightAnimation();
                turnedHeadRight = true;
            }
        }

    }

    void turnHeadRightAnimation()
    {
        POGCrossing.GetComponent<Animator>().runtimeAnimatorController = turnHeadRight as RuntimeAnimatorController;
    }
}
