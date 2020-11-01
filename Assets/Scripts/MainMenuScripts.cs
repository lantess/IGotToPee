using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScripts : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("AdamTestScene");
    }

    public void Credits()
    {
        Debug.Log("KUPA");
    }

    public void Controls()
    {
        Debug.Log("KUPA");
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
