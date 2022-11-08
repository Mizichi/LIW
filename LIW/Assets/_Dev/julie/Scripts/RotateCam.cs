using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveWithArrow();
    }

    void moveWithArrow()
    {
        moveCamera(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), camSpeed);
    }

    public float camSpeed = 1.0f;
    float mouseX;
    float mouseY;
    Quaternion localRotation;
    private float rotY = 0.0f;
    private float rotX = 0.0f;

    void moveCamera(float horizontal, float verticle, float moveSpeed)
    {
        mouseX = horizontal;
        mouseY = -verticle;

        rotY += mouseX * moveSpeed;
        rotX += mouseY * moveSpeed;

        localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;
    }
}
