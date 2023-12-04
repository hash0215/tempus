using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed;
    public float jumpPower;
    bool isright = true;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        //jump
        if (rigid.velocity.normalized.y == 0)
        {
            if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W))
                rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }

        //isJump animation trigger
        if (rigid.velocity.normalized.y == 0)
            anim.SetBool("isJump", false);
        else
            anim.SetBool("isJump", true);


        // it left/right input is gone reduce the speed immediately
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * (0.5f), rigid.velocity.y);       //rigid.velocity.normalized.x = x axis vector
        }

   


        //Flip x
        /* filp character to its moving side*/
        if (Input.GetAxisRaw("Horizontal") < 0)
            isright = false;
        else if(Input.GetAxisRaw("Horizontal") > 0) 
            isright = true;

        if(isright == false)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }

   
        //isWalking animation trigger
        if (rigid.velocity.normalized.x == 0)
            anim.SetBool("isWalk", false);
        else
            anim.SetBool("isWalk", true);


    }
        
    void seasonChange()
    {
        /*if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Spring ability activated");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Summer ability activated");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("Fall ability activated");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("Winter ability activated");
        }*/
    }

    // Update is called once per frame

    //moving
    void FixedUpdate()
    {
      /*  if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W))
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);*/

        float h = Input.GetAxisRaw("Horizontal");
            rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);
        if (rigid.velocity.x > maxSpeed)
        {
            //right max speed
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
            //spriteRenderer.flipX = false;
        }
        else if (rigid.velocity.x < maxSpeed * (-1))              //left max speed
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
    }
}
