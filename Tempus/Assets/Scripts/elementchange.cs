using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elementchange : MonoBehaviour
{
    public int seasontype = 0;
    public bool SpringOn = false;
    public bool SummerOn = false;
    public bool FallOn = false;
    public bool WinterOn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(SpringOn + " " + SummerOn + " " + FallOn + " " + WinterOn);
        if (Input.GetKeyDown(KeyCode.Alpha1) && SpringOn)           //1 btn: change to spring
        {
            seasontype = 1;
            Debug.Log("Season abilty has been changed to spring.");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2) && SummerOn)       //2 btn: change to summer
        {
            seasontype = 2;
            Debug.Log("Season abilty has been changed to summer.");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && FallOn)      //3 btn: change to fall
        {
            seasontype = 3;
            Debug.Log("Season abilty has been changed to fall.");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && WinterOn)      //34 btn: change to winter
        {
            seasontype = 4;
            Debug.Log("Season abilty has been changed to winter.");
        }
    }
}
