using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionCompletedManager : MonoBehaviour
{
    // Función para reiniciar el nivel
    public void PlayAgain()
    {
        Time.timeScale = 1f;

        // Cargar la misma escena 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Función para volver al menú principal
    public void BackToMenu()
    {
        Time.timeScale = 1f;

        // pantalla de titulo
        SceneManager.LoadScene("TitleScene");
    }
}