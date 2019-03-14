using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bulletScript : MonoBehaviour
{
    // Public variable 
    public Slider powerSlider;
    public Rigidbody2D r2d;
    public float areaOfEffect;
    public LayerMask destructible;
    public int environmentDamage;
    public GameObject effect;


    // Function called once when the bullet is created
    void Start()
    {

    }

    void Update()
    {
    }

    // Function called when the object goes out of the screen
    //void OnBecameInvisible()
    //{
    // Destroy the bullet 
    //  Destroy(gameObject);
    //}
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.CompareTag("Environment"))
        {
            Collider2D[] objectsToDamage = Physics2D.OverlapCircleAll(transform.position, areaOfEffect, destructible);
            for( int i = 0; i < objectsToDamage.Length;i++)
            {
              objectsToDamage[i].GetComponent<Destructable>().health -= environmentDamage;
            }
            Destroy(gameObject);
        }
    }

    void InitialVelocity( Vector2 v )
    {
        r2d.AddForce(v);
    }
}
