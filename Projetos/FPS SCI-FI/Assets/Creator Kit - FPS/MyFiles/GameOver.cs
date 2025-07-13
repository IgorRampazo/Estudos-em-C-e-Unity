using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public string menuSceneName = "Menu";

    void Start()
    {
        Invoke(nameof(LoadMenu), 4f);
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene(menuSceneName);
    }
}