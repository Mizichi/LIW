using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoothCameraFollow : MonoBehaviour
{
    public GameObject Player;
    public GameObject offset;
    public float speed;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        offset = Player.transform.Find("CenterFocus").gameObject;
    }

    private void FixedUpdate()
    {
        follow();
    }

    private void follow()
    {
        gameObject.transform.position = Vector3.Lerp(transform.position, offset.transform.position, Time.deltaTime * speed);
        gameObject.transform.LookAt(Player.gameObject.transform.position);
    }
}
