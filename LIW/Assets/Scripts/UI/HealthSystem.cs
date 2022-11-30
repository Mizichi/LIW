using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthSystem : MonoBehaviour
{
    //Code by Maggie Rembert

    public TextMeshProUGUI healthText;
    public static int healthValue = 50;

    //public static int currectHealth = 5;

    private void Start()
    {
        healthValue = 50;
    }

    void Update()
    {
        healthText.GetComponent<TextMeshProUGUI>().text = "Health : " + healthValue;
    }
}
