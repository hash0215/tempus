using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    private float timer;

    // Reference to the HeartSystem script
    private HeartSystem heartSystem;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        // Get reference to the HeartSystem script
        heartSystem = player.GetComponent<HeartSystem>();

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 5)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Use the TakeDamage function from the HeartSystem script
            if (heartSystem != null)
            {
                heartSystem.TakeDamage(1);
            }

            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Land"))
        {
            Destroy(gameObject);
        }
    }
}
