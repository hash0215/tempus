using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    public int HP;
    Rigidbody2D rigid;
    Animator anim;
    float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Effect")
        {
            HP -= 30;                                       //Blast Damage == 30
            if (HP < 0)                                     //when enemy is dead
            {
                Debug.Log("Enemy is dead!");
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Enemy remain HP is: " + HP);
                

                while (time < 1.0f)
                {
                    time += Time.deltaTime / 0.5f;
                    rigid.velocity = new Vector2(1.0f, 0);
                }
                time = 0.0f;

            }
        }
    }
}
