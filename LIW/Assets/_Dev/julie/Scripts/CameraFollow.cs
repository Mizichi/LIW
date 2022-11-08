using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float rotationX = 0;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        transform.position = player.position + offset;
        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }
}
