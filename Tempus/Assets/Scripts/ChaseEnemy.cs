using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseEnemy : MonoBehaviour
{
    public GameObject player;
    private Transform playerPos;
    private Vector2 initialPos;

    [SerializeField]
    private float distance = 4f; // Default distance value

    [SerializeField]
    private float enemySpeed = 2f; // Default enemy speed value

    void Start()
    {
        playerPos = player.GetComponent<Transform>();
        initialPos = transform.position; // Store the initial position
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, playerPos.position);

        if (distanceToPlayer < distance)
        {
            // Chase the player
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, enemySpeed * Time.deltaTime);
        }
        else
        {
            // Return to initial position if not close to the player
            transform.position = Vector2.MoveTowards(transform.position, initialPos, enemySpeed * Time.deltaTime);
        }
    }
}
