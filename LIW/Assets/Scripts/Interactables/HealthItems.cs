using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItems : MonoBehaviour
{
    //Code by Maggie Rembert

    public int health;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            HealthSystem.healthValue += health;
            Destroy(gameObject);
            ItemSpawner.itemCount--;
        }

    }
}
