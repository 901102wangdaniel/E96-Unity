using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject explosionPrefab; // Reference to the explosion prefab
    public float speed = 10f; // Speed at which the projectile is launched

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody2D component
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        // Check if the Rigidbody2D component exists
        if (rb != null)
        {
            // Disable gravity to ensure the projectile moves in a straight line
            rb.gravityScale = 0f;

            // Set the velocity to move straight horizontally
            rb.velocity = Vector2.right * speed; // Shooting to the right (positive x-axis)
        }
        else
        {
            Debug.LogError("Rigidbody2D component not found on the projectile.");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Instantiate the explosion effect at the collision point
        GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);

        // Optional: Stop emitting particles after a short delay
        ParticleSystem ps = explosion.GetComponent<ParticleSystem>();
        if (ps != null)
        {
            // Destroy the explosion object after the particles finish
            Destroy(explosion, ps.main.duration + ps.main.startLifetime.constantMax);
        }

        // Destroy the wall on collision
        Destroy(collision.gameObject);

        // Destroy the projectile
        Destroy(gameObject);
    }
}
