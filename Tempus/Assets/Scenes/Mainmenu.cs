using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    // Start is called before the first frame update
    void PlayGameStart()
    {
        SceneManager.LoadSceneAsync(1);
    }

    
}
