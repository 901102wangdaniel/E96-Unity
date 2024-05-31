using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{

    [SerializeField] public GameObject explosionEffect;  // Assign an explosion effect prefab in the Unity Inspector

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Do nothing if the player collides with the wall
        }
        else if (collision.gameObject.CompareTag("Crab"))
        {
            // If a crab collides, perform the following:

            // Instantiate the explosion effect at the wall's position
            if (explosionEffect != null)
            {
                Instantiate(explosionEffect, transform.position, Quaternion.identity);
            }

            // Destroy the crab
            Destroy(collision.gameObject);

            // Destroy the wall
            Destroy(gameObject);
        }
    }
}





