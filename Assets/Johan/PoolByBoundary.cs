using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolByBoundary : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        ////check if bullet
        //Bullet b = collision.gameObject.GetComponent<Bullet>();
        //if (b != null)
        //{
        //    //pool to player
        //    b.gameObject.SetActive(false);
        //}
    }
}
