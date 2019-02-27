using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int speed = 1;
    private float TimeToLive = 0;

    void Update()
    {
        //move bullet

        TimeToLive += Time.deltaTime;
        if (TimeToLive > 3f)
            //gameObject.SetActive(false);
            Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            collider.GetComponent<Enemy>().Health--;
        }
    }
}
