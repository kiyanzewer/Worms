using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private bool playerTurn;

    public float speed;
    public GameObject bullet;
    public Text log;
    public Slider powerSlider;
    public Slider angleSlider;
    public Button fireButton;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Button btn = fireButton.GetComponent<Button>();
        btn.onClick.AddListener(ShootBullet);
        log.text = "Player 1's Turn";
        playerTurn = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void ShootBullet()
    { 
        StartCoroutine(ProduceBullet());
        var tempBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        tempBullet.SendMessage("InitialVelocity", new Vector2(powerSlider.value * 5, angleSlider.value * 5));

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

    IEnumerator ProduceBullet()
    {
        WriteLog("Bullet shot with the power of " + powerSlider.value + "\n" + 
                 "Bullet shot with the angle of " + angleSlider.value);
        yield return new WaitForSeconds(2);
        if (playerTurn)
        {
            log.text = "Player 2's Turn";
            playerTurn = false;
        }
        else
        {
            log.text = "Player 1's Turn";
            playerTurn = true;
        }
    }
}
