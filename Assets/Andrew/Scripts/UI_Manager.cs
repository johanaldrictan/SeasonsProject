using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public Text resources;
    public Text timer;

    void Update()
    {
        resources.text = "$" + Resource.instance.total.ToString();
        timer.text = Season.instance.countdown.ToString("F1");
    }
}
