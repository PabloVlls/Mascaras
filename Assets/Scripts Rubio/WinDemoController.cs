using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinDemoController : MonoBehaviour
{
    public void OnBackToMenuPressed()
    {
        SceneFlowManager.Instance.LoadMenu();
    }

    public void OnExitPressed()
    {
        Application.Quit();
    }
}
