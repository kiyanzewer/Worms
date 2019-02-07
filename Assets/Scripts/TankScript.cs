using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankScript : MonoBehaviour
{
    private Rigidbody2D rb2d;

    public float speed;
    public GameObject bullet;
    public Text log;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        log.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(produceBullet());
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }

    void WriteLog(string text)
    {
        log.text = text;
    }

    IEnumerator produceBullet()
    {
        WriteLog("Created Bullet");
        yield return new WaitForSeconds(2);
        WriteLog("");
    }
}
