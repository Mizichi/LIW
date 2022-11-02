using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FerretCharacterController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpHeight = 2.4f;
    public float gravityMultiplier = 1f;

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (Input.GetButtonDown("Jump") && characterController.isGrounded)//Jump
        {

            move.y = jumpHeight;

        }

        
        if (characterController.isGrounded == false)
        {

            move.y += Physics.gravity.y * gravityMultiplier;

        }
        

        characterController.Move(move * Time.deltaTime * speed);//Moves
    }
}
