using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SeasonText : MonoBehaviour
{
    TextMeshProUGUI SI_meshProUGUI;
    // Start is called before the first frame update
    void Start()
    {
        SI_meshProUGUI = this.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        SI_meshProUGUI.text = string.Format("{0}", Season.instance.season);
        //Debug.Log(Season.instance.season)
    }
}
