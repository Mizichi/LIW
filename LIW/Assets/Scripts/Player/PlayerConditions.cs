using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerConditions : MonoBehaviour
{
    //Code by Maggie Rembert

    public bool reload;

    public static bool IsCaptured = false;
    public GameObject capturedUI;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            if (IsCaptured)
            {
                Resume();
            }
            else
            {
                Pause();
            }
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

    public void Resume()
    {
        capturedUI.SetActive(false);
        Time.timeScale = 1f;
        IsCaptured = false;
    }

    public void Pause()
    {
        capturedUI.SetActive(true);
        Time.timeScale = 0f;
        IsCaptured = true;
    }
}
