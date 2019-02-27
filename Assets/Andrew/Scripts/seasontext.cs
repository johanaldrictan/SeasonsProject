using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class seasontext : MonoBehaviour
{
    TextMeshProUGUI SI_meshProUGUI;
    public static Season seasoninstance;
    // Start is called before the first frame update
    void Start()
    {
        SI_meshProUGUI = this.GetComponent<TextMeshProUGUI>();
        seasoninstance = new Season();
    }

    // Update is called once per frame
    void Update()
    {
        SI_meshProUGUI.text = string.Format("Season: {0}", seasoninstance.season);
    }
}
