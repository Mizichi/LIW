using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToySystem : MonoBehaviour
{
    //Code by Maggie Rembert

    public TextMeshProUGUI toyText;
    public static int toyValue = 0;

    void Update()
    {
        toyText.GetComponent<TextMeshProUGUI>().text = "Toys : " + toyValue;
    }
}
