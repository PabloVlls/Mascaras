using UnityEngine;
using UnityEngine.SceneManagement; // ¡IMPORTANTE! Sin esto no funciona

public class SceneController : MonoBehaviour
{
    // Función 1: Cargar escena por su NOMBRE exacto
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Función 2: Cargar escena por su NÚMERO (Índice en Build Settings)
    public void LoadSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    // Función 3: Reiniciar la escena actual (Botón "Reintentar")
    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Función 4: Salir del juego (Botón "Quit")
    public void QuitGame()
    {
        Debug.Log("¡Saliendo del juego! (Esto solo funciona en la Build final)");
        Application.Quit();
    }
}
