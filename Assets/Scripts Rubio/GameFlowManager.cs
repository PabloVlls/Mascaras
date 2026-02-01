using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
    public GameState currentState;

    public ClockManager clockManager;
    public NightManager nightManager;

    public GameObject nightIntroPanel;


    void Start()
    {
        SetState(GameState.Menu);
    }

    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) GoToMenu();
        if (Input.GetKeyDown(KeyCode.Alpha2)) StartGame();
        if (Input.GetKeyDown(KeyCode.Alpha3)) StartNight();
        if (Input.GetKeyDown(KeyCode.Alpha4)) EndNightWin();
        if (Input.GetKeyDown(KeyCode.Alpha5)) EndNightLose();
    }*/

    void EndGame(bool win)
    {
        if (win)
            SceneFlowManager.Instance.LoadWinDemo();
        else
            SceneFlowManager.Instance.LoadGameOver();
    }

    public void SetState(GameState newState)
    {
        currentState = newState;
        Debug.Log("ESTADO ACTUAL: " + currentState);

        if (currentState == GameState.Menu)
        {
            Debug.Log("?? Mostrando MENU");
        }
        else if (currentState == GameState.NightIntro)
        {
            Debug.Log("?? Pantalla INICIO DE NOCHE");
            
                nightIntroPanel.SetActive(true);
                

            }
        else if (currentState == GameState.Playing)
        {
            
                clockManager.StartClock();
                nightManager.StartNight();
            
                Debug.Log("?? JUGANDO");
        }
        else if (currentState == GameState.NightResult)
            {
                Debug.Log("?? RESULTADO DE NOCHE");
                clockManager.StopClock();

            }
            else if (currentState == GameState.GameOver)
        {
                clockManager.StopClock();

                Debug.Log("?? GAME OVER");
        }
        else if (currentState == GameState.WinDemo)
        {
                clockManager.StopClock();

                Debug.Log("?? GANASTE LA DEMO");
        }
    }

    // ===== BOTONES (simulados por ahora) =====

    public void GoToMenu()
    {
        SetState(GameState.Menu);
    }

    public void StartGame()
    {
        SetState(GameState.NightIntro);
    }

    public void StartNight()
    {
        SetState(GameState.Playing);
       
    }

    public void NextNight()
    {
        SetState(GameState.NightIntro);
    }


    /*public void EndNightWin()
    {
        SetState(GameState.NightResult);
  
    }

    public void EndNightLose()
    {
        SetState(GameState.GameOver);
     
    }*/
}

