using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthSystem : MonoBehaviour
{
    //Code by Maggie Rembert

    public TextMeshProUGUI healthText;
    public static int healthValue = 50;

    public static int currectHealth = 50;

    private void Start()
    {
        currectHealth = healthValue;
    }

    void Update()
    {
        healthText.GetComponent<TextMeshProUGUI>().text = "Health : " + healthValue;
    }
}
