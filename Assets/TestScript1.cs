using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript1 : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Q");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("W");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R");
        }
    }
}
