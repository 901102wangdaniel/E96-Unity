using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading;

public class Collide : MonoBehaviour
{

    private Rigidbody2D rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Wall")
        {
            Debug.Log("Hit: " + collision.transform.name);
            Thread.Sleep(2000);
            Destroy(this.gameObject);
        }
    }
}
