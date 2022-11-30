using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //Code by Maggie Rembert

    //Learned from MJ's Patrolling Enemy doc

    public GameObject[] waypoints;
    private NavMeshAgent myAgent;
    private int currentWaypoint;

    private Animator anim;

    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        myAgent.destination = waypoints[currentWaypoint].transform.position;

        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if(Vector3.Distance(myAgent.destination, transform.position) <= 1)
        {
            currentWaypoint++;
            if(currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }
            myAgent.destination = waypoints[currentWaypoint].transform.position;
        }

    }

    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {

            if(Vector3.Distance(transform.position, other.transform.position) <= 2)
            {
                myAgent.destination = transform.position;
                anim.SetTrigger("Grab");
            }
            else
            {
                myAgent.destination = other.transform.position;
            }
        }
    }

}
