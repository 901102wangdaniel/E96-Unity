using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    // public bool disabled = false;

    private Rigidbody2D rb;
    bool isGrounded = false;
    public Transform spritePrefab;
    private Rigidbody2D rb2;
    public Transform crabclone;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpHeight = 5f;
    [SerializeField] public float crabSpeed = 5f;

    // private float movement = 0f;
    private float direction = 0f;

    private bool facingRight = true;
    public float dir = 1f;
    private Animator animator;

    private int keyCount = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //collect the player's Rigidbody2D
        animator = GetComponent<Animator>();
    }

    void OnMove(InputValue value)
    {
        direction = value.Get<float>();
        // Debug.Log(direction);

    // sprite flip
        if (direction < 0 && facingRight == true)
        {
            Flip();
        }

        if (direction > 0 && facingRight == false)
        {
            Flip();
        }
    }

    void Flip(){
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }


    void Update()
    {
        
        if (direction > 0)
        {
            dir = 1f;
        }

        if (direction < 0)
        {
            dir = -1f;
        }
        Move(direction);
        //animator.SetFloat("Speed", Mathf.Abs(speed*direction.x));
        // Debug.Log(direction);

    }

    private void Move(float x) // Move on X and Y
    {
        rb.velocity = new Vector2(x * speed, rb.velocity.y);
    }

    void OnJump()
    {
        if (isGrounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        // Debug.Log(rb.velocity);
        animator.SetBool("isJumping", true);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
        // Debug.Log("Player is grounded");
        animator.SetBool("isJumping", false);
    }


    void OnSpawn()
    {

        Spawn();
    }


    void Spawn()
    {

        if (facingRight == true)
        {
            Vector3 spawnPosition = transform.position + Vector3.right * 0.5f; // Adjust 1.0f to your needs for spacing
            spawnPosition.y -= 0.15f;
            crabclone = Instantiate(spritePrefab, spawnPosition, Quaternion.identity);
        }
        if (facingRight == false)
        {
            Vector3 spawnPosition = transform.position + Vector3.left * 0.5f;
            spawnPosition.y -= 0.15f;
            crabclone = Instantiate(spritePrefab, spawnPosition, Quaternion.identity);
        }



        rb2 = crabclone.GetComponent<Rigidbody2D>();
        rb2.velocity = new Vector2(dir * crabSpeed, rb2.velocity.y);



        Debug.Log(rb2.velocity);


    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("key"))
        {
            keyCount++;  // Increase the key count
            Destroy(other.gameObject);  // Destroy the key GameObject
            Debug.Log("grabbed key!");

            CheckKeys();  // Call a method to check if something should happen
        }
    }

    private void CheckKeys()
    {
        if (keyCount >= 6)  // Replace X with the number of keys needed
        {
            // Do something special
            Debug.Log("Collected all required keys!");
        }
    }

}