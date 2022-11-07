using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private float startTime = 180f;
    public Text timerText;

    // Update is called once per frame
    public void Update()
    {
        startTime -= Time.deltaTime;
        float minutes = Mathf.FloorToInt(startTime / 60);
        float seconds = Mathf.FloorToInt(startTime % 60);

        timerText.text = string.Format("Time to Die: {0:00}:{1:00}", minutes, seconds);
    }

    //public float AddTime() //cumulative timer
    //{
    //    return startTime + GetComponent<GameManager>().TotalTime();
    //}
}