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

    public void QuitGame()
    {
        Application.Quit();
        // Won't do anything in the editor, but works in a build
    }
}
