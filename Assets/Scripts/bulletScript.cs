using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    // Public variable 
    public float speed;
    private Rigidbody2D r2d;

    // Function called once when the bullet is created
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }

    void update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);
        r2d.AddForce(movement * speed);
    }

    // Function called when the object goes out of the screen
    void OnBecameInvisible()
    {
        // Destroy the bullet 
        Destroy(gameObject);
    }
}
