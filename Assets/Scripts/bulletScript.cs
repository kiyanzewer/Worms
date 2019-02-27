using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bulletScript : MonoBehaviour
{
    // Public variable 
    public Slider powerSlider;
    public Rigidbody2D r2d;
    // Public variable 
    public float speed;
    private Vector2 movement;
 // Function called when the object goes out of the screen
    void OnBecameInvisible()
    {
        // Destroy the bullet 
        Destroy(gameObject);
    }

    void InitialVelocity( Vector2 v )
    {
        r2d.AddForce(v);
    }
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
}
