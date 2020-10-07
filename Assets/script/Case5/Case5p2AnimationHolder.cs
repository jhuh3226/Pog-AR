using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case5p2AnimationHolder : MonoBehaviour
{
    public RuntimeAnimatorController lookLeftLoop;

    Animator m_Animator;

    public GameObject POGCrossing;
    public GameObject gameObCase5p2CanvasHolder;


    // Start is called before the first frame update
    void Start()
    {
        m_Animator = POGCrossing.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Case5p2CanvasHolder case5p2CanvasHolder = gameObCase5p2CanvasHolder.GetComponent<Case5p2CanvasHolder>();

        if(case5p2CanvasHolder.startAnimating)
        {
            turnHeadLeftAnimation();
        }
    }

    void turnHeadLeftAnimation()
    {
        POGCrossing.GetComponent<Animator>().runtimeAnimatorController = lookLeftLoop as RuntimeAnimatorController;
    }
}
