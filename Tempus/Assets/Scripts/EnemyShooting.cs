using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject snowball;
    public Transform snowballPos;

    private float timer;
    private GameObject player;
    private Animator animator;

    // Reference to the movement script
    private PatrolMovement patrolMovement;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();

        // Get the reference to the movement script
        patrolMovement = GetComponent<PatrolMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < 10)
        {
            timer += Time.deltaTime;

            if (timer > 1)
            {
                timer = 0;
                shoot();

                // Set the "IsAttacking" parameter to true when attacking
                animator.SetBool("isAttacking", true);
            }
        }
        else
        {
            // Set the "IsAttacking" parameter to false when not attacking
            animator.SetBool("isAttacking", false);
        }
    }

    void shoot()
    {
        Instantiate(snowball, snowballPos.position, Quaternion.identity);
    }

    // Public method to get the value of isAttacking
    public bool IsAttacking()
    {
        return animator.GetBool("isAttacking");
    }
}
