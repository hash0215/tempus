using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    public GameObject[] hearts;
    public int life;

    void Update()
    {
        if (life < 1)
        {
            Destroy(hearts[0].gameObject);
        }
        else if (life < 2)
        {
            Destroy(hearts[1].gameObject);
        }
        else if (life < 3)
        {
            Destroy(hearts[2].gameObject);
        }
        else if (life < 4)
        {
            Destroy(hearts[3].gameObject);
        }
        else if (life < 5)
        {
            Destroy(hearts[4].gameObject);
        }
        else if (life < 6)
        {
            Destroy(hearts[5].gameObject);
        }
        else if (life < 7)
        {
            Destroy(hearts[6].gameObject);
        }
        else if (life < 8)
        {
            Destroy(hearts[7].gameObject);
        }
        else if (life < 9)
        {
            Destroy(hearts[8].gameObject);
        }
        else if (life < 10)
        {
            Destroy(hearts[9].gameObject);
        }
    }

    
    public void TakeDamage(int d)
    {
        life -= d;
    }
}
