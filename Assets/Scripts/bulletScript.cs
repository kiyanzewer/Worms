using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bulletScript : MonoBehaviour
{
    // Public variable 
    public Slider powerSlider;
    private Rigidbody2D r2d;
    private Vector2 movement;

    // Function called once when the bullet is created
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        movement = new Vector2( Mathf.Sqrt(Mathf.Pow(powerSlider.value,2)) / 10 , Mathf.Sqrt(Mathf.Pow(powerSlider.value, 2)) / 10 );
        r2d.velocity = movement;
    }

    void update()
    {
        r2d.AddForce(movement * 1);
    }

    // Function called when the object goes out of the screen
    void OnBecameInvisible()
    {
        // Destroy the bullet 
        Destroy(gameObject);
    }
}
