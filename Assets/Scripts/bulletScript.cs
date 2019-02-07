using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    // Public variable 
    public float speed;
    private Rigidbody2D r2d;
    private Vector2 movement;

    // Function called once when the bullet is created
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        movement = new Vector2(10,5);
        r2d.velocity = movement;
    }

    void update()
    {
        r2d.AddForce(movement * speed);
    }

    // Function called when the object goes out of the screen
    void OnBecameInvisible()
    {
        // Destroy the bullet 
        Destroy(gameObject);
    }
}
