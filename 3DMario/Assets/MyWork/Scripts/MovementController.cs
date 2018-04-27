using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovementController : MonoBehaviour
{
    public bool isGrounded;
    private float speed;
    public float rotSpeed;
    public float jumpHeight;
    //walk speed
    private float w_speed = 0.2f;
    //rotation speed
    private float rot_speed = 0.5f;
    Rigidbody rb;
    Animator anim;

    // Flag For the character if it has the key
    private bool HasKey;

    // The coins which the character have
    private int NumOfCoins;

    // Score
    private int Score;

    // Score text
    public Text ScoreText;

    // Coins text
    public Text CoinsText;

    // Key image
    public Image KeyImage;

    // Key text
    public Text KeyText;

    // Key Found Color
    //Color KeyColor = new Color(99f, 32f, 255f, 255f);

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        isGrounded = true; //indicate that we are in the ground
        HasKey = true;
        NumOfCoins = 0;
        Score = 0;
        ScoreText.text = "Score: " + Score.ToString();
        CoinsText.text = "Coins: " + NumOfCoins.ToString();
        KeyText.text = "Find The Key!";
    }

    void movementControl(string state)
    {
        switch (state)
        {
            case "WalkingForward":
                anim.SetBool("isRunning", false);
                anim.SetBool("isWalkingForward", true);
                anim.SetBool("isWalkingBackward", false);
                anim.SetBool("isIdle", false);
                break;
            case "WalkingBackward":
                anim.SetBool("isRunning", false);
                anim.SetBool("isWalkingForward", false);
                anim.SetBool("isWalkingBackward", true);
                anim.SetBool("isIdle", false);
                break;
            case "Running":
                anim.SetBool("isRunning",true);
                anim.SetBool("isWalkingForward", false);
                anim.SetBool("isWalkingBackward", false);
                anim.SetBool("isIdle", false);
                break;
            case "idle":
                anim.SetBool("isRunning", false);
                anim.SetBool("isWalkingForward", false);
                anim.SetBool("isWalkingBackward", false);
                anim.SetBool("isIdle", true);
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            //moving forward and backward
            if (Input.GetKey(KeyCode.W))
            {
                speed = w_speed;
                movementControl("Running");
            }
            else if (Input.GetKey(KeyCode.S))
            {
                speed = w_speed;
                movementControl("WalkingBackward");
            }
            else
            {
                movementControl("idle");
            }
            //moving right and left
            if (Input.GetKey(KeyCode.A))
            {
                rotSpeed = rot_speed;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                rotSpeed = rot_speed;
            }
            else
            {
                rotSpeed = 0;
            }
        }
        var z = Input.GetAxis("Vertical") * speed;
        var y = Input.GetAxis("Horizontal") * rotSpeed;
        transform.Translate(0, 0, z);
        transform.Rotate(0, y, 0);
        //jumping function
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            anim.SetTrigger("isJumping");
            rb.AddForce(0, jumpHeight, 0);
            isGrounded = false;
        }
    }

    void OnCollisionEnter()
    {
        isGrounded = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("key"))
        {
            other.gameObject.SetActive(false);
            HasKey = true;
            KeyImage.color = Color.blue;
            KeyText.text = "You Have Found The Key";
        }
        if (other.gameObject.CompareTag("coin"))
        {
            other.gameObject.SetActive(false);
            NumOfCoins += 1;
            CoinsText.text = "Coins: " + NumOfCoins.ToString();
        }
        if (other.gameObject.CompareTag("uplevel") && HasKey)
        {
            SceneManager.LoadScene("level2");
        }
    }
}
