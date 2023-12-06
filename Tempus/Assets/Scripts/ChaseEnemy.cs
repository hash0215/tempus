using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseEnemy : MonoBehaviour
{
    public GameObject Player;
    private Transform playerPos;
    private Vector2 initialPos;

    [SerializeField]
    private float distance = 4f; // Default distance value

    [SerializeField]
    private float enemySpeed = 2f; // Default enemy speed value

    [SerializeField]
    private float bounceForce = 300f; // Force to apply to player on collision

    void Start()
    {
        playerPos = Player.GetComponent<Transform>();
        initialPos = transform.position; // Store the initial position
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, playerPos.position);

        if (distanceToPlayer < distance)
        {
            // Chase the player
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, enemySpeed * Time.deltaTime);

            // Check if the player is to the right of the enemy, then flip to face right
            if (playerPos.position.x > transform.position.x)
            {
                FlipToFaceRight();
            }
            else
            {
                FlipToFaceLeft(); // Otherwise, face left
            }
        }
        else
        {
            // Return to initial position if not close to the player
            transform.position = Vector2.MoveTowards(transform.position, initialPos, enemySpeed * Time.deltaTime);

            // Flip to face left when returning to initial position
            FlipToFaceLeft();
        }
    }

    void FlipToFaceRight()
    {
        transform.localScale = new Vector3(-1, 1, 1); // Flip to face right
    }

    void FlipToFaceLeft()
    {
        transform.localScale = new Vector3(1, 1, 1); // Face left
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Calculate the direction from the player to the enemy
            Vector2 bounceDirection = (collision.transform.position - transform.position).normalized;

            // Apply force to the player in the opposite direction
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(bounceDirection * bounceForce);
        }
    }
}
