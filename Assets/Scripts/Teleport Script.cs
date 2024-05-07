using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private Transform destination;
    public bool isWhite;
    public float distance = 0.2f;

    void Start()
    {
        if (isWhite == false)
        {
            destination = GameObject.FindGameObjectWithTag("white").GetComponent<Transform>();
        } else {
            destination = GameObject.FindGameObjectWithTag("grey").GetComponent<Transform>();
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (Vector2.Distance(transform.position, other.transform.position) > distance)
        {
            other.transform.position = new Vector2 (destination.position.x, destination.position.y);
        }
    }
}