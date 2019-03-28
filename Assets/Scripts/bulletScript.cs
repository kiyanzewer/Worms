using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bulletScript : MonoBehaviour
{
    // Public variables 
    public Slider powerSlider;
    public Rigidbody2D r2d;
    public float areaOfEffect;
    public LayerMask destructible;
    public int environmentDamage;
    public GameObject effect;
    public int damagePower;

    //Private Variables
    private bool playerTurn;
    private Vector2 origin;
    private GameObject tank1;
    private GameObject tank2;

    // Function called once when the bullet is created
    void Start()
    {
        tank1 = GameObject.Find("Tank1");
        tank2 = GameObject.Find("Tank2");
        origin = gameObject.transform.position;

        if ( damagePower == 0)
        {
            damagePower = 10;
        }
    }

    void Update()
    {
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player 2" && origin == (Vector2)tank1.transform.position )
        {
            collision.gameObject.SendMessage("takeDamage", damagePower);
            Destroy(gameObject);
        }

        if ( collision.transform.tag == "Player 1" && origin == (Vector2)tank2.transform.position)
        {
            collision.gameObject.SendMessage("takeDamage", damagePower);
            Destroy(gameObject);
        }

        if (collision.CompareTag("Environment"))
        {
            Collider2D[] objectsToDamage = Physics2D.OverlapCircleAll(transform.position, areaOfEffect, destructible);
            for (int i = 0; i < objectsToDamage.Length; i++)
            {
                objectsToDamage[i].GetComponent<Destructable>().health -= environmentDamage;
            }
            Destroy(gameObject);
        }
    }

    void InitialVelocity(Vector2 v)
    {
        r2d.AddForce(v);
    }

}
