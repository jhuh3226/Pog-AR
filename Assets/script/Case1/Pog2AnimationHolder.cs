using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pog2AnimationHolder : MonoBehaviour
{
    public RuntimeAnimatorController armShake;

    Animator m_Animator;

    //turn on canvas
    public bool canvas1;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = this.GetComponent<Animator>();
        canvas1 = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime);

        if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 2.0f)
        {
            AnimatePogBot();
        }

        if (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 2.2)
        {
            canvas1 = true;
        }
    }

    void AnimatePogBot()
    {
        this.GetComponent<Animator>().runtimeAnimatorController = armShake as RuntimeAnimatorController;
    }
}
