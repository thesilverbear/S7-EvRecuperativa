using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    private bool gameOverActive = false;

    public void ActivateGameOver()
    {
        gameOverActive = true;
    }

    void Update()
    {
        if (gameOverActive && Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
