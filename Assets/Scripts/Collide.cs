using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading;

public class Collide : MonoBehaviour
{

    private Rigidbody2D rb;
    public float crabSpeed = 5f;
    public float vel;

    // Start is called before the first frame update
    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((rb.velocity.x > 0) || (rb.velocity.x < 0))
        {
            vel = rb.velocity.x;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "ExplodeWall")
        {
            Debug.Log("Hit explode ");
            Thread.Sleep(100);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.name == "Wall") 
        {
            
            rb.velocity = new Vector2(-1*vel, rb.velocity.y);
            Debug.Log(rb.velocity);
        }
        else if (collision.gameObject.name == "spritePrefab(Clone)")
        {
            rb.velocity = new Vector2(-1 * vel, rb.velocity.y);
        }
        else if (collision.gameObject.name == "Main")
        {
            rb.velocity = new Vector2(-1 * vel, rb.velocity.y);
        }




    }
}
