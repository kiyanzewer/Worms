using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private GameObject weapon;
    private System.Random randomNum;
    private bool playerTurn;
    private float player1Loc = 0;
    private float player2Loc = 0;
    private string[] player1Logs = new string[100];
    private string[] player2Logs = new string[100];

    public float speed;
    public GameObject bullet;
    public GameObject laser;

    public GameObject player1;
    public GameObject player2;

    public Dropdown powerUpsDropdown;

    public Text log;
    public Slider xPowerSlider;
    public Slider yPowerSlider;
    public Button fireButton;
    public Button powerUps;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        Button btn = fireButton.GetComponent<Button>();
        btn.onClick.AddListener(ShootBullet);

        Button powerBtn = powerUps.GetComponent<Button>();
        powerBtn.onClick.AddListener(PowerUpdate);

        log.text = "Player 1's Turn";
        playerTurn = true;
        xPowerSlider.value = 50;
        yPowerSlider.value = 0;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void PowerUpdate() {
        Debug.Log("Power Up is changed to " + powerUpsDropdown.options[powerUpsDropdown.value].text);
        if (powerUpsDropdown.options[powerUpsDropdown.value].text == "Laser")
        {
            weapon = laser;
        }
        else
        {
            weapon = bullet;
        }
    }

    void ShootBullet()
    {
        try
        {
            StartCoroutine(ProduceBullet());
            GameObject tempBullet = new GameObject();
            if (playerTurn)
            {
                if (powerUpsDropdown.options[powerUpsDropdown.value].text == "Bullet Mirage")
                {
                    BulletMirage(player1.transform.position);
                }
                else
                {
                    tempBullet = Instantiate(weapon, player1.transform.position, Quaternion.identity);
                    tempBullet.SendMessage("InitialVelocity", new Vector2(xPowerSlider.value * 7, yPowerSlider.value * 7));
                }
            }
            else
            {
                if (powerUpsDropdown.options[powerUpsDropdown.value].text == "Bullet Mirage")
                {
                    BulletMirage(player2.transform.position);
                }
                else
                {
                    tempBullet = Instantiate(weapon, player2.transform.position, Quaternion.identity);
                    tempBullet.SendMessage("InitialVelocity", new Vector2(xPowerSlider.value * 7, yPowerSlider.value * 7));
                }
            }
        }
        catch ( NullReferenceException e )
        {
            Debug.Log("INPUT A VALID WEAPON THROUGH THE POWER UPS!");
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

    IEnumerator ProduceBullet()
    {
        if (playerTurn)
        {
            WriteLog( "Player 1: \n" +
                      "Bullet shot with an X-Velocity of " + xPowerSlider.value + "\n" +
                      "Bullet shot with a Y-Velocity of " + yPowerSlider.value);
            yield return new WaitForSeconds(2);
            logBackground("Player 1: Bullet shot with an X-Velocity of " + xPowerSlider.value , "Bullet shot with a Y-Velocity of " + yPowerSlider.value);
            log.text = "Player 2's Turn";
            xPowerSlider.value = -50;
            yPowerSlider.value = 0;
            playerTurn = false;
        }
        else
        {
            WriteLog( "Player 2: \n" + 
                      "Bullet shot with an X-Velocity of " + xPowerSlider.value + "\n" +
                      "Bullet shot with a Y-Velocity of " + yPowerSlider.value);
            logBackground(" Player 2: Bullet shot with an X-Velocity of " + xPowerSlider.value, "Bullet shot with a Y-Velocity of " + yPowerSlider.value);
            yield return new WaitForSeconds(2);
            log.text = "Player 1's Turn";
            xPowerSlider.value = 50;
            yPowerSlider.value = 0;
            playerTurn = true;
        }
    }

    void logBackground( string x , string y )
    {
        if (playerTurn)
        {
            Debug.Log(x + "\n" + y);
            player1Logs[(int)player1Loc] = x + " " + y;
        }
        else
        {
            Debug.Log(x + "\n" + y);
            player2Logs[(int)player2Loc] = x + " " + y;
        }
    }

    void BulletMirage( Vector2 position )
    {
        GameObject bulletMirage = new GameObject();
        int temp = 0;
            for (int i = 0; i < 10; i++)
            {
                bulletMirage = Instantiate(weapon, position, Quaternion.identity);
                temp = randomNum.Next(-20, 20);
                bulletMirage.SendMessage("InitialVelocity", new Vector2((xPowerSlider.value + temp) * 7, (yPowerSlider.value + temp) * 7));
            }
        
    }
}
