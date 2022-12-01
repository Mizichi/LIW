using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyItem : MonoBehaviour
{
    //Code by Maggie Rembert

    public int toy = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ToySystem.toyValue += toy;
            Destroy(gameObject);
        }

    }
}
