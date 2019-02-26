using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public Text resources;

    void Update()
    {
        resources.text = Resource.total.ToString();
    }
}
