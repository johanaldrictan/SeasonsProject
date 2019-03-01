using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawnScript : MonoBehaviour
{
    public GameObject Bag;

    void Start()
    {
        Debug.Log(Bag.transform.childCount);
        Debug.Log(Bag.transform.GetChild(0).name);
    }
}
