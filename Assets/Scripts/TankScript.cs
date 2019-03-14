using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private System.Random randomNum;
    private bool playerTurn;
    private float player1Loc = 0;
    private float player2Loc = 0;

    //Arrays the hold post-game numerical stats
    private string[] player1Logs = new string[100];
    private string[] player2Logs = new string[100];

    public float speed;

    //Weapons that the tank can use
    private GameObject weapon;
    public GameObject bullet;
    public GameObject laser;
    public GameObject saw;

    //Types of Tanks
    public GameObject player1;
    public GameObject player2;
    public Rigidbody2D player1RB;
    public Rigidbody2D player2RB;

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
    public Boolean isGrounded = true;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        //Sets a listener to a firebutton
        Button btn = fireButton.GetComponent<Button>();
        btn.onClick.AddListener(ShootBullet);
        btn.interactable = false;

        //Sets a listener to the power-up button
        Button powerBtn = powerUps.GetComponent<Button>();
        powerBtn.onClick.AddListener(PowerUpdate);
        powerBtn.interactable = true;

        //Initalizes the player's Turn and values on the sliders
        log.text = "Player 1's Turn" + "\n" + "Select a Power-Up and Press the 'Submit' Button";
        playerTurn = true;
        xPowerSlider.value = 50;
        yPowerSlider.value = 0;
    }


    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    //Method that adds an upward force to the tank when the "jump" button is clicked
    void Jump()
    {
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space) && playerTurn)
            {
                isGrounded = false;
                player1RB.AddForce(new Vector2(0, 100));
            }
            else if (Input.GetKeyDown(KeyCode.Space) && !playerTurn)
            {
                isGrounded = false;
                player2RB.AddForce(new Vector2(0, 100));
            }
        }
    }

    //Updates the weapon variable to whatever power-up was selected
    void PowerUpdate()
    {
        powerUps.interactable = false;
        fireButton.interactable = true;
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
        catch (Exception e)
        {
            WriteLog("Invalid Weapon: Nothing was selected.");
        }
    }

    //Writes to a textbox on the screen and is displayed
    void WriteLog(string text)
    {
        log.text = text;
    }

    //Creates the 'Weapon' and spawns it with an initial velocity given by the sliders
    void ShootBullet()
    {
        powerUps.interactable = true;
        fireButton.interactable = false;
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
        catch (NullReferenceException e)
        {
            Debug.Log("INPUT A VALID WEAPON THROUGH THE POWER UPS!");
        }
    }

    //Test Method for movement
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }

    //Changes that need to be made on the screen when players change turns
    IEnumerator ProduceBullet()
    {
        if (playerTurn)
        {
            WriteLog("Player 1: \n" +
                      "Bullet shot with an X-Velocity of " + xPowerSlider.value + "\n" +
                      "Bullet shot with a Y-Velocity of " + yPowerSlider.value);
            yield return new WaitForSeconds(2);
            logBackground("Player 1: Bullet shot with an X-Velocity of " + xPowerSlider.value, "Bullet shot with a Y-Velocity of " + yPowerSlider.value);
            log.text = "Player 2's Turn" + "\n" + "Select a Power-Up and Press the 'Submit' Button";
            xPowerSlider.value = -50;
            yPowerSlider.value = 0;
            playerTurn = false;
            log.text = "Player 2's Turn"; 
            playerTurn = false;
        }
        else
        {
            WriteLog("Player 2: \n" +
                      "Bullet shot with an X-Velocity of " + xPowerSlider.value + "\n" +
                      "Bullet shot with a Y-Velocity of " + yPowerSlider.value);
            logBackground(" Player 2: Bullet shot with an X-Velocity of " + xPowerSlider.value, "Bullet shot with a Y-Velocity of " + yPowerSlider.value);
            yield return new WaitForSeconds(2);
            log.text = "Player 1's Turn" + "\n" + "Select a Power-Up and Press the 'Submit' Button";
            xPowerSlider.value = 50;
            yPowerSlider.value = 0;
            log.text = "Player 1's Turn";
            playerTurn = true;
        }
    }

    //Logs Stats when a bullet is shot
    void logBackground(string x, string y)
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
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, areaOfEffect);

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Environment"))
        {
            isGrounded = true;
        }
    }
}