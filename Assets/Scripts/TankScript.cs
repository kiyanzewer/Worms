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
    public GameObject saw;

    public GameObject player1;
    public GameObject player2;

    public Dropdown powerUpsDropdown;

    public Text log;
    public Slider xPowerSlider;
    public Slider yPowerSlider;
    public Button fireButton;
    public Button powerUps;
    public float areaOfEffect;
    public LayerMask destructible;
    public int damage;
    public GameObject effect;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        Button btn = fireButton.GetComponent<Button>();
        btn.onClick.AddListener(ShootBullet);

        Button powerBtn = powerUps.GetComponent<Button>();
        powerBtn.onClick.AddListener(PowerUpdate);

        log.text = "Player 1's Turn" + "\n" + "Select a Power-Up and Press the 'Submit' Button";
        playerTurn = true;
        xPowerSlider.value = 50;
        yPowerSlider.value = 0;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void PowerUpdate() {
        try
        {
            Debug.Log("Power Up is changed to " + powerUpsDropdown.options[powerUpsDropdown.value].text);
            if (powerUpsDropdown.options[powerUpsDropdown.value].text == "Laser")
            {
                weapon = laser;
                WriteLog("Weapon: Laser");
            }
            else if (powerUpsDropdown.options[powerUpsDropdown.value].text == "Saw")
            {
                weapon = saw;
                WriteLog("Weapon: Saw");
            }
            else
            {
                weapon = bullet;
                WriteLog("Weapon: Bullet");
            }
        }
        catch ( Exception e )
        {
            WriteLog("Invalid Weapon: Nothing was selected.");
        }
    }

    void ShootBullet()
<<<<<<< HEAD
    {
        try
        {
            StartCoroutine(ProduceBullet());
            GameObject tempBullet = new GameObject();
            if (playerTurn)
            {
                    tempBullet = Instantiate(weapon, player1.transform.position, Quaternion.identity);
                    tempBullet.SendMessage("InitialVelocity", new Vector2(xPowerSlider.value * 7, yPowerSlider.value * 7));
            }
            else
            {
                    tempBullet = Instantiate(weapon, player2.transform.position, Quaternion.identity);
                    tempBullet.SendMessage("InitialVelocity", new Vector2(xPowerSlider.value * 7, yPowerSlider.value * 7));
            }
        }
        catch ( NullReferenceException e )
        {
            Debug.Log("INPUT A VALID WEAPON THROUGH THE POWER UPS!");
        }
=======
    { 
        StartCoroutine(ProduceBullet());
        var tempBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        tempBullet.SendMessage("InitialVelocity", new Vector2(powerSlider.value * 5, angleSlider.value * 5));

>>>>>>> KiyanSchool
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
<<<<<<< HEAD
        if (playerTurn)
        {
            WriteLog( "Player 1: \n" +
                      "Bullet shot with an X-Velocity of " + xPowerSlider.value + "\n" +
                      "Bullet shot with a Y-Velocity of " + yPowerSlider.value);
            yield return new WaitForSeconds(2);
            logBackground("Player 1: Bullet shot with an X-Velocity of " + xPowerSlider.value , "Bullet shot with a Y-Velocity of " + yPowerSlider.value);
            log.text = "Player 2's Turn" + "\n" + "Select a Power-Up and Press the 'Submit' Button";
            xPowerSlider.value = -50;
            yPowerSlider.value = 0;
=======
        WriteLog("Bullet shot with the power of " + powerSlider.value + "\n" + 
                 "Bullet shot with the angle of " + angleSlider.value);
        yield return new WaitForSeconds(2);
        if (playerTurn)
        {
            log.text = "Player 2's Turn";
>>>>>>> KiyanSchool
            playerTurn = false;
        }
        else
        {
<<<<<<< HEAD
            WriteLog( "Player 2: \n" + 
                      "Bullet shot with an X-Velocity of " + xPowerSlider.value + "\n" +
                      "Bullet shot with a Y-Velocity of " + yPowerSlider.value);
            logBackground(" Player 2: Bullet shot with an X-Velocity of " + xPowerSlider.value, "Bullet shot with a Y-Velocity of " + yPowerSlider.value);
            yield return new WaitForSeconds(2);
            log.text = "Player 1's Turn" + "\n" + "Select a Power-Up and Press the 'Submit' Button";
            xPowerSlider.value = 50;
            yPowerSlider.value = 0;
=======
            log.text = "Player 1's Turn";
>>>>>>> KiyanSchool
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
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, areaOfEffect);
    }

}
