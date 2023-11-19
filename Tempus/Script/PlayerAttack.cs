using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttack : MonoBehaviour
{
    public int damage = 5;

    private float curTime;
    public float coolTime = 0.5f; // cooltime
    public GameObject Blast;

    void Attack() //attack
    {
        curTime = coolTime;
        StartCoroutine("Attacking");
    }

    IEnumerator Attacking()
    {
        yield return new WaitForSeconds(0.16f);

        Vector3 posForThrowingATK = new Vector3(transform.position.x + 0.5f, transform.position.y - 0.1f, transform.position.z);
        GameObject go = Instantiate(Blast, posForThrowingATK, transform.rotation) as GameObject; 

        yield return new WaitForSeconds(0.14f);
    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) Attack(); // attack

        if (curTime > 0) curTime -= Time.deltaTime; // cooltime
    }
}
