using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyObjAfTime : MonoBehaviour
{
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyObject", timer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
