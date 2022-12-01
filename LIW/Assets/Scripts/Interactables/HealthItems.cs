using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItems : MonoBehaviour
{
    //Code by Maggie Rembert 
    //Julie Added Animation for Eating

    public int health;

    //varriables for anim
    [SerializeField] float turnSpeed = 90f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Animator>().SetTrigger("Eat");//animate ferret eat

            //freeze ferret when eating
            GameObject parentGameObject = other.transform.parent.gameObject;
            Rigidbody temprb = parentGameObject.GetComponent<Rigidbody>();
            temprb.constraints = RigidbodyConstraints.FreezeAll;//slows down ferret

            HealthSystem.healthValue += health; //adds a value to the HealthSystem text value
            Destroy(gameObject);
            ItemSpawner.itemCount--; //removes an item value from ItemSpawner itemCount so it can know to spawn in a new object
            
            other.GetComponent<Animator>().SetTrigger("Eat");//disable trigger
            temprb.constraints = RigidbodyConstraints.None;
            temprb.constraints = RigidbodyConstraints.FreezeRotation;
        }

    }

    void Update()
    {
        //gives the orb a slight turning animation
        transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
    }
}
