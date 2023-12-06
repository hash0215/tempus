using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage;

    private float curTime;
    public float coolTime = 0.5f; // cooltime
    public GameObject Blast;
    SpriteRenderer PlayerFlip;
    Camera mainCamera;

    // Add this line to define the projectile speed
    public float projectileSpeed = 5f;

    void Attack(Vector3 targetPosition)
    {
        curTime = coolTime;
        StartCoroutine(Attacking(targetPosition));
    }

    IEnumerator Attacking(Vector3 targetPosition)
    {
        yield return new WaitForSeconds(0.16f);

        Vector3 posForThrowingATK = transform.position;

        // Calculate direction vector towards the mouse click position
        Vector3 direction = (targetPosition - posForThrowingATK).normalized;

        // Instantiate the projectile and set its initial position and velocity
        GameObject go = Instantiate(Blast, posForThrowingATK, Quaternion.identity) as GameObject;
        go.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;

        yield return new WaitForSeconds(0.14f);
    }

    void Start()
    {
        // Assign the main camera to the variable
        mainCamera = Camera.main;
        PlayerFlip = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0; // Set the z-coordinate to a fixed value or adjust as needed

            Attack(mousePos);
        }

        if (curTime > 0) curTime -= Time.deltaTime; // cooltime
    }
}
