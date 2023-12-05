using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    public int HP;
    public int DMG;
    Rigidbody2D rigid;
    Animator anim;
    float time = 0.0f;
    public GameObject obj;
    int seasontp = 0;
    //bool dotdmg = false;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        seasontp = obj.GetComponent<elementchange>().seasontype;
        Debug.Log("updated " + seasontp);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Effect")
        {
            HP -= DMG;                                       //Blast Damage == DMG
            if (HP < 0)                                     //when enemy is dead 
            {
                Debug.Log("Enemy is dead!");
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Enemy remain HP is: " + HP);

                if (seasontp == 1)           //spring   
                {
                    Debug.Log("seasontp == 1");     // on fire - additional dot damage
                    while (time < 1.0f)
                    {
                        time += Time.deltaTime / 0.5f;
                        HP -= 5;
                    }
                    time = 0.0f;

                }
                else if (seasontp == 2)      //summer
                {
                    Debug.Log("seasontp == 2");
                    
                }
                else if (seasontp == 3)     //fall 
                {
                    Debug.Log("seasontp == 3");
                    while (time < 1.0f)
                    {
                        time += Time.deltaTime / 0.5f;
                        rigid.velocity = new Vector2(3.0f, 0);              //pushes enemy back more
                    }
                    time = 0.0f;
                }
                else if (seasontp == 4)     //winter
                {
                    Debug.Log("seasontp == 4");
                    while (time < 1.0f)
                    {
                        time += Time.deltaTime / 0.5f;
                        //make enemy slow
                    }
                    time = 0.0f;
                }

                /* while (time < 1.0f)
                 {
                     time += Time.deltaTime / 0.5f;
                     rigid.velocity = new Vector2(1.0f, 0);
                 }
                 time = 0.0f;*/

            }
        }
    }
}
