using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerConditions : MonoBehaviour
{
    public bool reload;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            HealthSystem.healthValue = 100;
        }
    }
}
