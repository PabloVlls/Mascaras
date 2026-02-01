using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFlowManager : MonoBehaviour
{
    public static SceneFlowManager Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // =========================
    // CAMBIOS DE ESCENA
    // =========================

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadGameplay()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void LoadWinDemo()
    {
        SceneManager.LoadScene("WinDemo");
    }
}

