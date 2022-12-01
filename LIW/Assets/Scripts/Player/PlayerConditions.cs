using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerConditions : MonoBehaviour
{
    //Code by Maggie Rembert

    public bool reload;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            HealthSystem.healthValue = 50;
        }
    }

    private void Update()
    {
        if(HealthSystem.healthValue == 0)
        {
            int index = SceneManager.GetActiveScene().buildIndex;
            if (!reload)
            {
                index += 1;
                if (index == SceneManager.sceneCountInBuildSettings) { index = 0; }
            }
            SceneManager.LoadScene(index);
        }
    }
}
