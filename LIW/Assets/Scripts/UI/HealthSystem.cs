using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthSystem : MonoBehaviour
{
    //Code by Maggie Rembert

    public TextMeshProUGUI healthText;
    public static int healthValue = 50;

    private void Start() //makes sure health is the same value at the start of each scene ot reload
    {
        healthValue = 50;
    }

    void Update()
    {
        healthText.GetComponent<TextMeshProUGUI>().text = "Health : " + healthValue; //displays health value
    }
}
