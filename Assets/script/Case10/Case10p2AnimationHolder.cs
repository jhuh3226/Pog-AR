using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case10p2AnimationHolder : MonoBehaviour
{
    public RuntimeAnimatorController lookLeft;

    Animator m_Animator;

    public GameObject POGCrossing;
    public GameObject gameObCase10p2BeizerCurvePogBot;


    // Start is called before the first frame update
    void Start()
    {
        m_Animator = POGCrossing.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Case10p2BeizerCurvePogBot case10p2BeizerCurvePogBot = gameObCase10p2BeizerCurvePogBot.GetComponent<Case10p2BeizerCurvePogBot>();

        if (case10p2BeizerCurvePogBot.pogBotPassedPoint3)
        {
            turnHeadLeftAnimation();

        }
    }

    void turnHeadLeftAnimation()
    {
        POGCrossing.GetComponent<Animator>().runtimeAnimatorController = lookLeft as RuntimeAnimatorController;
    }
}
