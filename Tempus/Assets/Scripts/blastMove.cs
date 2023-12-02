using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class blastMove : MonoBehaviour
{
    public float Speed;
    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer PlayerFlip;
    SpriteRenderer blastFlip;
    float time = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        rigid = GetComponent<Rigidbody2D>();
        PlayerFlip = player.GetComponent<SpriteRenderer>();
        blastFlip = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        if(PlayerFlip.flipX == false)
        {
            blastFlip.flipX = false;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, 0);
        }
        else if(PlayerFlip.flipX == true)
        {
            blastFlip.flipX = true;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-1*Speed, 0);
        }
        


    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" || other.tag == "Land" || other.tag == "objects")        //when blast hits enemy or land
        {
            rigid.velocity = new Vector2(0.5f, 0);
            anim.SetBool("isHit", true);
            rigid.velocity = new Vector2(0,0);
            Destroy(gameObject, 0.3f);
        }

    }
}
