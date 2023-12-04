using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elementchange : MonoBehaviour
{
    public int seasontype = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))           //1 btn: change to spring
        {
            seasontype = 1;
            Debug.Log("Season abilty has been changed to spring.");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))       //2 btn: change to summer
        {
            seasontype = 2;
            Debug.Log("Season abilty has been changed to summer.");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))      //3 btn: change to fall
        {
            seasontype = 3;
            Debug.Log("Season abilty has been changed to fall.");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))      //34 btn: change to winter
        {
            seasontype = 4;
            Debug.Log("Season abilty has been changed to winter.");
        }
    }
}
