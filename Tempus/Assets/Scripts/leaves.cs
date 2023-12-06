using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leaves : MonoBehaviour
{
    public Sprite img1;
    public Sprite img2;
    public Sprite img3;
    public Sprite img4;
    public Sprite img5;

    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer LeafSR;
    float time = 0.0f;
    public GameObject obj;
    int seasontp = 0;
    int hit_counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

        LeafSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        seasontp = obj.GetComponent<elementchange>().seasontype;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Effect")
        {
            if (seasontp == 3)           //spring
            {
                Debug.Log("is hit on leaf");

                hit_counter++;
                if (hit_counter == 1)
                {
                    LeafSR.sprite = img2;
                    while (time < 1.0f)
                    {
                        time += Time.deltaTime / 0.5f;
                        rigid.velocity = new Vector2(1.0f, 0);
                    }
                    time = 0.0f;
                }
                else if (hit_counter == 2)
                {
                    LeafSR.sprite = img3;
                    while (time < 1.0f)
                    {
                        time += Time.deltaTime / 0.5f;
                        rigid.velocity = new Vector2(1.0f, 0);
                    }
                    time = 0.0f;
                }
                else if (hit_counter == 3)
                {
                    LeafSR.sprite = img4;
                    while (time < 1.0f)
                    {
                        time += Time.deltaTime / 0.5f;
                        rigid.velocity = new Vector2(1.0f, 0);
                    }
                    time = 0.0f;
                }
                else if (hit_counter == 4)
                {
                    LeafSR.sprite = img5;
                    Destroy(gameObject);
                }
            }
        }
    }
}
