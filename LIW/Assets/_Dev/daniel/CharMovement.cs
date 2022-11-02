using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    public float speed = 0.02f;
    public AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        //Debug.Log(horizontalAxis);
        transform.Translate(transform.right * horizontalAxis * speed);
        float verticalAxis = Input.GetAxis("Vertical");
        //Debug.Log(verticalAxis);
        transform.Translate(transform.forward * verticalAxis * speed);

        if (horizontalAxis != 0 || verticalAxis != 0)
        {
            //GameObject.Find("SoundManager").GetComponent<SoundManager>().playRandomClip(audioSrc);
        }
    }
}
