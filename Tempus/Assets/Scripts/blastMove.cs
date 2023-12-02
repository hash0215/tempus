using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class blastMove : MonoBehaviour
{
    public float Speed;
    Rigidbody2D rigid;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" || other.tag == "Land")        //when blast hits enemy or land
        {
            rigid.velocity = new Vector2(0.5f, 0);
            anim.SetBool("isHit", true);
            rigid.velocity = new Vector2(0,0);
            Destroy(gameObject, 0.3f);
        }
    }
}
