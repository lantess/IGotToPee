using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButton : MonoBehaviour
{
    public void TaskOnClick()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void playAgain()
    {
        SceneManager.LoadScene("AdamTestScene");
    }
}
