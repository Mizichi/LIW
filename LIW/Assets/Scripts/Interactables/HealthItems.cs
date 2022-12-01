using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItems : MonoBehaviour
{
    //Code by Maggie Rembert

    public int health;

    //varriables for anim
    [SerializeField] float turnSpeed = 90f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            HealthSystem.healthValue += health; //adds a value to the HealthSystem text value
            Destroy(gameObject);
            ItemSpawner.itemCount--; //removes an item value from ItemSpawner itemCount so it can know to spawn in a new object
        }

    }

    void Update()
    {
        //gives the orb a slight turning animation
        transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
    }
}
