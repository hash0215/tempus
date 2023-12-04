using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantgrow1 : MonoBehaviour
{

    public Sprite img1;
    public Sprite img2;
    public Sprite img3;
    public Sprite img4;
    public float Speed = 0.3f;
    float timer = 0.0f;
    SpriteRenderer PlantSR;

    // Start is called before the first frame update
    void Start()
    {
        PlantSR = GetComponent<SpriteRenderer>();
        PlantSR.sprite = img1;
        Vector3 Target = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, Target, Speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.2f && timer <= 0.4f)
        {
            PlantSR.sprite = img2;
        }
        else if (timer > 0.4f && timer <= 0.6f)
        {
            PlantSR.sprite = img3;
        }
        else if (timer > 0.6f && timer <= 0.8f)
        {
            PlantSR.sprite = img4;
        }
    }
}
