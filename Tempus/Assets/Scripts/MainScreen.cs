using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainScreen : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Game");
    }

    public void SettingsButton()
    {
        SceneManager.LoadSceneAsync("Settings");
    }

    public void CreditsButton()
    {
        SceneManager.LoadSceneAsync("Credits");
    }
    public void MenuButton()
    {
        SceneManager.LoadSceneAsync("Menu");
    }
}
