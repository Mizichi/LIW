using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnlyItems : MonoBehaviour
{
    //Code by Maggie Rembert

    public int health;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            HealthSystem.healthValue += health;
            Destroy(gameObject);
        }

    }
}
