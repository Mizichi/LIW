using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyItem : MonoBehaviour
{
    //Code by Maggie Rembert

    public int toy = 1;

    //varriables for anim
    [SerializeField] float turnSpeed = 90f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ToySystem.toyValue += toy; //adds a value to the ToySystem text value
            Destroy(gameObject);
        }

    }

    void Update()
    {
        //gives the orb a slight turning animation
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
