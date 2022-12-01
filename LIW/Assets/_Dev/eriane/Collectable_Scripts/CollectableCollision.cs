using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    //FIX WHICH SCRIPT FOR MOVEMENT public PlayerMovement movement;
    public Rigidbody2D rb;
    public int collectable;

    //destroy collectable and add to count upon collision

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "collectible")
        {
            collectable += 1;
            Destroy(other.gameObject);
        }
    }
}
