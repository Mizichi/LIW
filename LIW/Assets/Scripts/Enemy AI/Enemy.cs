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
        if(Vector3.Distance(myAgent.destination, transform.position) <= 1) //sets destination to the waypoints
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

            if(Vector3.Distance(transform.position, other.transform.position) <= 2)//heads towards player and plays a "grab" animation when the player is in range
            {
                myAgent.destination = transform.position;
                anim.SetTrigger("Grab");
            }
            else //continues following waypoints
            {
                myAgent.destination = other.transform.position;
            }
        }
    }

}
