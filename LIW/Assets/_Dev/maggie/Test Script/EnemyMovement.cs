using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    States enemyState = States.idle;
    int walkRadius = 10;
    private float nextActionTime = 0.0f;
    public float period = 5f;

    public Transform player;
    float chaseDistance = 8f;
    float shootDistance = 18f;

    //[SerializeField] public Rigidbody projectile;

    [SerializeField]public int speed;

    private float lastAttackTime = 0f;
    private float fireRate = 0.5f;

    private NavMeshAgent navMeshAgent;

    enum States
    {
        idle,
        shoot,
        chase
    }

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distance = Vector2.Distance(this.transform.position, player.transform.position);

        if (chaseDistance > distance)
        {
            enemyState = States.chase;
        }
        if (shootDistance > distance && chaseDistance < distance)
        {
            enemyState = States.shoot;
        }
        if (distance > 18)
        {
            enemyState = States.idle;
        }

        if (enemyState == States.chase)
        {
            navMeshAgent.GetComponent<NavMeshAgent>().speed = 4;
            transform.LookAt(player);
            navMeshAgent.SetDestination(player.position);
        }

        if (Time.time > nextActionTime && enemyState == States.idle)
        {
            navMeshAgent.GetComponent<NavMeshAgent>().speed = 1;
            nextActionTime = Time.time + period;

            Vector3 randomDirection = Random.insideUnitSphere * walkRadius;
            randomDirection += transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 1);
            Vector3 finalPosition = hit.position;
            navMeshAgent.SetDestination(finalPosition);
        }

        if (enemyState == States.shoot)
        {
            RaycastHit hit;
            Vector3 rayDirection = player.position - transform.position;
            transform.LookAt(player);

            if (Physics.Raycast(transform.position, rayDirection, out hit))
            {
                Debug.DrawLine(transform.position, hit.point, Color.red);
                if (hit.transform == player)
                {
                    if (Time.time - lastAttackTime >= 1f / fireRate)
                    {
                        shoot();
                        lastAttackTime = Time.time;
                    }
                }
            }

            navMeshAgent.GetComponent<NavMeshAgent>().speed = 0;
        }
    }

    public void shoot()
    {
        //Rigidbody projectileRB = Instantiate(projectile, transform.position, transform.rotation);
        //projectileRB.velocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SetActive(false);
        }
    }
}
