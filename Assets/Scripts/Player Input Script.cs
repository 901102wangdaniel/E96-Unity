using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    // public bool disabled = false;

    private Rigidbody2D rb;
    bool isGrounded = false;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpHeight = 5f;
    [SerializeField] public float crabSpeed = 5f;

    // private float movement = 0f;
    private Vector2 direction = Vector2.zero;

    private bool facingRight = true;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //collect the player's Rigidbody2D
        animator = GetComponent<Animator>();
    }

    void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
        // Debug.Log(direction);

    // sprite flip
        if (direction.x < 0 && facingRight == true)
        {
            Flip();
        }

        if (direction.x > 0 && facingRight == false)
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
        Move(direction.x, direction.y);
        animator.SetFloat("Speed", Mathf.Abs(speed*direction.x)); 

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


    //         //animator.SetBool("isJumping", false);
    //     }
    // }

    void OnSpawn()
    {


        Spawn();



    }


    void Spawn()
    {

        if (facingRight == true)
        {
            Vector3 spawnPosition = transform.position + Vector3.right * 1.0f; // Adjust 1.0f to your needs for spacing
            spawnPosition.y -= 0.25f;
            crabclone = Instantiate(spritePrefab, spawnPosition, Quaternion.identity);
        }
        if (facingRight == false)
        {
            Vector3 spawnPosition = transform.position + Vector3.left * 1.0f;
            spawnPosition.y -= 0.25f;
            crabclone = Instantiate(spritePrefab, spawnPosition, Quaternion.identity);
        }



        rb2 = crabclone.GetComponent<Rigidbody2D>();
        rb2.velocity = new Vector2(dir * crabSpeed, rb2.velocity.y);



        Debug.Log(rb2.velocity);


    }

}