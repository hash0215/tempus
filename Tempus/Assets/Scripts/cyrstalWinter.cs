using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cyrstalWinter : MonoBehaviour
{
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //obj.GetComponent<elementchange>().WinterOn = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Effect")        //
        {
            obj.GetComponent<elementchange>().WinterOn = true;
        }
    }
}
