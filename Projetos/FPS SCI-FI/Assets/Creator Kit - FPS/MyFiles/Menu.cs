using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Episodio1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}