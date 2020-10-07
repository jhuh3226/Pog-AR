using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enable particle when the bus collide with the robot character

public class TurnOnParticle : MonoBehaviour
{
    public GameObject gameObContainingScript;
    public GameObject particle;

    void Start()
    {
        particle.SetActive(false);
    }

    void Update()
    {
        CollisionDetect collisionDetectScript = gameObContainingScript.GetComponent<CollisionDetect>();

        if (collisionDetectScript.collidedWithBus == true)
        {
            particle.SetActive(true);
            print("particle enabled");
        }

    }
}
