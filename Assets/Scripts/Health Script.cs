using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int health = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void changeHealth( int healthDeficit )
    {
        health -= healthDeficit;
        Debug.Log("Health was lowered by " + healthDeficit + "\nCurrent Health is " + health );
    }
}
