using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case6CanvasHolder : MonoBehaviour
{
    public GameObject car;

    public GameObject CV1;

    public GameObject gameObCase6BeizerCurvePogBot;

    //store time
    float hitTime = 0;
    bool recordHitTime = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if pogBot pass position2, turn on beizerCurveCar
        Case6BeizerCurvePogBot case6BeizerCurvePogBot = gameObCase6BeizerCurvePogBot.GetComponent<Case6BeizerCurvePogBot>();
        if (case6BeizerCurvePogBot.pogBotPassedPoint2)
        {
            car.GetComponent<Case6BeizerCurveCar>().enabled = true;

            //record the time
            if (recordHitTime)
            {
                hitTime = Time.fixedTime;
                recordHitTime = false;
            }
        }

        //if pogBot pass position and 2seconds passed, turn on CV1
        if(case6BeizerCurvePogBot.pogBotPassedPoint3)
        {
            if (hitTime != 0 && Time.fixedTime - hitTime >= 3)
            {
                CV1.GetComponent<Canvas>().enabled = true;
            }
        }
    }
}
