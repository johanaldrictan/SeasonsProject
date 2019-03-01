using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Town : MonoBehaviour
{
    [SerializeField]private int health;
    private void Start()
    {
        //health = 10;
    }

    private void Update()
    {
        if (health == 0)
        {
            Debug.Log("--GAME OVER--");
        }

        //Debug.Log(health);
    }
  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("test");
        if (collision.collider.CompareTag("Enemy"))
        {
            health = health - collision.collider.GetComponent<Enemy>().GetDmg();
            //Destroy(collider);
        }
    }
}
