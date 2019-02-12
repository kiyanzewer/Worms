using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bulletScript : MonoBehaviour
{
    // Public variable 
    public Slider powerSlider;
    public Rigidbody2D r2d;
    private Vector2 movement;


    // Function called once when the bullet is created
    void Start()
    {

    }

    void Update()
    {
    }

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
}
