using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public CharacterController controller;
    public Animator animator;
    private Vector3 direction;

    public Transform groundCheck;
    public Transform character;
    public LayerMask groundLayer;
    public Slider healthBar;

    public TextMeshProUGUI pointsText;

    public float speedVelocity = 10;
    public float jumpVelocity = 5;
    public float gravity = -15;
    public float rotationSpeed = 0.03f;

    public static int points;
    public static int currentHealth = 100;

    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Horizontal Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        setPlayerDirection(horizontalInput * speedVelocity);
        

        // Check if the player is grounded
        bool isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);

        // Set animator values
        animator.SetFloat("speed", Mathf.Abs(horizontalInput));
        animator.SetBool("isGrounded", isGrounded);

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            direction.y = jumpVelocity;
        }

        // Apply gravity
        direction.y += gravity * Time.deltaTime;

        if(horizontalInput != 0)
        {
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(horizontalInput, 0, 0));
            character.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed);
        }

        controller.Move(direction * Time.deltaTime);


        //Update number of points
        pointsText.text = "Points: " + points;

        //Set the health
        healthBar.value = currentHealth;

        //Player dies TODO
        if(currentHealth < 0)
        {
            gameOver = true;
        }
    }

    public Vector3 getPlayerDirection()
    {
        return direction;
    }

    public void setPlayerDirection(float currentDirection)
    {
        direction.x = currentDirection;
    }
}
