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
    int seasontp = 0;
    //float time = 0.0f;
    public GameObject obj;


    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        rigid = GetComponent<Rigidbody2D>();
        PlayerFlip = player.GetComponent<SpriteRenderer>();
        blastFlip = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        anim.SetBool("isStart", true);

        if (PlayerFlip.flipX == false)
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
        seasontp = obj.GetComponent<elementchange>().seasontype;
        if (seasontp == 1)           //spring
        {
            anim.SetBool("isStart", false);
            anim.SetBool("isSpring", true);
            anim.SetBool("isSummer", false);
            anim.SetBool("isFall", false);
            anim.SetBool("isWinter", false);
        }
        else if (seasontp == 2)           //summer
        {
            anim.SetBool("isStart", false);
            anim.SetBool("isSpring", false);
            anim.SetBool("isSummer", true);
            anim.SetBool("isFall", false);
            anim.SetBool("isWinter", false);

        }
        else if (seasontp == 3)           //fall
        {
            anim.SetBool("isStart", false);
            anim.SetBool("isSpring", false);
            anim.SetBool("isSummer", false);
            anim.SetBool("isFall", true);
            anim.SetBool("isWinter", false);
        }
        else if (seasontp == 4)           //winter
        {
            anim.SetBool("isStart", false);
            anim.SetBool("isSpring", false);
            anim.SetBool("isSummer", false);
            anim.SetBool("isFall", false);
            anim.SetBool("isWinter", true);

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" || other.tag == "Land" || other.tag == "field objects")        //when blast hits enemy or land
        {
            Debug.Log("hit");
            //rigid.velocity = new Vector2(0.5f, 0);
            //anim.SetBool("isHit", true);
            rigid.velocity = new Vector2(0,0);
            Destroy(gameObject, 0.3f);
        }

    }
}
