using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    private int Health = 10;            //has 10 health
    private int Damage = 1;             //does 1 damage per pellet
    private float TimeToLive = 60f;     //lives for 60 seconds

    private float shootTickValue = 0f;  //value for tracking time between shots
    private float shootTickRate = 1f;

    void Update()
    {
        TimeToLive -= Time.deltaTime;
        shootTickValue += Time.deltaTime;

        if (shootTickValue > shootTickRate)
        {
            Shoot();
            shootTickValue = 0f;
        }
    }

    void Shoot()
    {
        //instatiate a bullet at the plant's current location
    }
}
