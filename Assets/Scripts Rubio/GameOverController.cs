using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public void OnRetryPressed()
    {
        SceneFlowManager.Instance.LoadMenu();
    }

    public void OnExitPressed()
    {
        Application.Quit();
    }
}
