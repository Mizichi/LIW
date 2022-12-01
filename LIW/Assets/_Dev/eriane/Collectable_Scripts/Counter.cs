using UnityEngine;
using UnityEngine.UI;

public class count : MonoBehaviour
{
    public Text scoreText;
    public PlayerCollision playercollision;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = playercollision.collectable.ToString("Duckies Collected: 0");
    }
}
