using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolMovement : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed;
    public Transform player; // Reference to the player's transform

    private int patrolDestination;

    // Reference to the attacking script
    private EnemyShooting enemyShooting;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        // Get the reference to the attacking script
        enemyShooting = GetComponent<EnemyShooting>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the enemy is not attacking before allowing movement

            // Check player position and flip accordingly
        if (player.position.x < transform.position.x)
        {
            // Player is to the left of the enemy
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            // Player is to the right of the enemy
            transform.localScale = new Vector3(-1, 1, 1);
        }
        
        if (!enemyShooting.IsAttacking())
        {
            // Move towards the current patrol point
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[patrolDestination].position, moveSpeed * Time.deltaTime);

            // Check if the enemy has reached the current patrol point
            if (Vector2.Distance(transform.position, patrolPoints[patrolDestination].position) < 0.2f)
            {
                // Switch to the next patrol point
                patrolDestination = (patrolDestination + 1) % patrolPoints.Length;
            }
        }
    }
}
