using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rigid;

    public GameObject obj;
    int seasontp = 0;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        seasontp = obj.GetComponent<elementchange>().seasontype;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Effect")        //
        {
            Debug.Log("effect detacted");
            if (seasontp == 2)           //spring
            {
                Debug.Log("summer effect detacted");
                Destroy(gameObject);
            }
        }
    }
}
