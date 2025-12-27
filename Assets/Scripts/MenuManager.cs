using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayClassic()
    {
        SceneManager.LoadScene("FlappyClassic");
    }

    public void PlayTimeAttack()
    {
        SceneManager.LoadScene("FlappyTimeAttack");
    }
     public void GoToMainMenu()
    {
        Time.timeScale = 1f; // important if TimeAttack paused the game
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Exit button clicked");
        Application.Quit(); // Won't do anything in the editor, but works in a build
    }
}
