using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static event System.Action<string> OnGameOver;
    public static Menu instance;
    private void Awake()
    {
        instance = this;
    }
    public static int sceneCount;
    public void PlayGame(string GameScene)
    {
        SceneManager.LoadScene(GameScene);
        ResumeGame();
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void GameOver()
    {
        if(OnGameOver != null)
        {
            OnGameOver(SceneManager.GetActiveScene().name);
        }
    }
}