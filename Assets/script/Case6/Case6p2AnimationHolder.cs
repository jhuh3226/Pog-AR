using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case6p2AnimationHolder : MonoBehaviour
{
    public RuntimeAnimatorController lookLeft;

    Animator m_Animator;

    public GameObject POGCrossing;
    public GameObject gameObCase6p2CanvasHolder;


    // Start is called before the first frame update
    void Start()
    {
        m_Animator = POGCrossing.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Case6p2CanvasHolder case6p2CanvasHolder = gameObCase6p2CanvasHolder.GetComponent<Case6p2CanvasHolder>();

        if (case6p2CanvasHolder.startAnimating)
        {
            turnHeadLeftAnimation();

            case6p2CanvasHolder.startAnimating = !case6p2CanvasHolder.startAnimating;
        }
    }

    void turnHeadLeftAnimation()
    {
        POGCrossing.GetComponent<Animator>().runtimeAnimatorController = lookLeft as RuntimeAnimatorController;
    }
}
