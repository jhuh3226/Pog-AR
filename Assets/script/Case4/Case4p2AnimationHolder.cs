using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case4p2AnimationHolder : MonoBehaviour
{
    public RuntimeAnimatorController lookLeftLoop;

    Animator m_Animator;

    public GameObject POGCrossing;
    public GameObject gameObCase4p2CanvasHolder;


    // Start is called before the first frame update
    void Start()
    {
        m_Animator = POGCrossing.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Case4p2CanvasHolder case4p2CanvasHolder = gameObCase4p2CanvasHolder.GetComponent<Case4p2CanvasHolder>();

        if (case4p2CanvasHolder.startAnimating)
        {
            turnHeadLeftAnimation();
        }
    }

    void turnHeadLeftAnimation()
    {
        POGCrossing.GetComponent<Animator>().runtimeAnimatorController = lookLeftLoop as RuntimeAnimatorController;
    }
}
