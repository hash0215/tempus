using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantGrow : MonoBehaviour
{
    Rigidbody2D rigid;
    public Sprite img1;
    public Sprite img2;
    public Sprite img3;
    public Sprite img4;
    SpriteRenderer PlantSR;
    int hit_counter = 0;
    float plantGrowth = 0.5f;
    public GameObject Plant;
    int i = 0;
    float time = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        PlantSR = GetComponent<SpriteRenderer>();
        Debug.Log("plant start");

    }

    // Update is called once per frame
    void Update()
    {

    }




    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Effect")        //
        {

            Debug.Log("hit");
            hit_counter++;
            if(hit_counter == 1)
            {
                PlantSR.sprite = img2;
            }
            else if (hit_counter == 2)
            {
                PlantSR.sprite = img3;
            }
            else if (hit_counter == 3)
            {
                PlantSR.sprite = img4;
            }
           else if (hit_counter > 3)
            {
                Vector3 plant_loc = new Vector3(transform.position.x, transform.position.y + plantGrowth, transform.position.z);
                GameObject go = Instantiate(Plant, plant_loc, transform.rotation) as GameObject;
                plantGrowth += 0.5f;
                Debug.Log("new plant");
            }
        }
    }
}
