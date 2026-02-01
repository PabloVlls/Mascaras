using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightManager : MonoBehaviour
{
    [Header("Config")]

    [Header("Nights")]
    public List<NightConfig> nights;
    int currentNightIndex = 0;

    public NightConfig CurrentNight => nights[currentNightIndex];

    public GameFlowManager gameFlow;

    public EndNightPanel endNightPanel;

    public ClockManager clockManager;


    // Snapshot de la noche terminada
    public int lastNightEntries;
    public int lastNightStrikes;
    public int lastNightMaxStrikes;


    [Header("State")]
    public int currentEntries = 0;
    public int currentStrikes = 0;
    float timer;

    bool nightActive = false;

    void Start()
    {
        StartNight();
    }

    void Update()
    {
        if (!nightActive) return;

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            EndNight(false);
        }
    }

    public void StartNight()
    {
        NightConfig night = CurrentNight;

        currentEntries = 0;
        currentStrikes = 0;
        timer = night.nightDuration;
        nightActive = true;

        Debug.Log($"?? Noche {night.nightNumber} iniciada");

        FindObjectOfType<QueueManager>().SetupNightPool();

    }

    /// <summary>
    /// Llamado cuando el jugador toma una decisión
    /// </summary>
    public void RegisterDecision(bool approved, MaskedCharacterData character)
    {
        if (!nightActive) return;

        bool isDemon = character.race == CharacterRace.Demon;

        if (approved)
        {
            currentEntries++;

            if (!isDemon)
            {
                AddStrike(); // Entró un humano
            }
        }
        else
        {
            if (isDemon)
            {
                AddStrike(); // Rechazaste un demonio
            }
        }


        CheckNightState();
    }

    void AddStrike()
    {
        currentStrikes++;
        Debug.Log($"?? Strike {currentStrikes}/{CurrentNight.maxStrikes}");

        if (currentStrikes >= CurrentNight.maxStrikes)
        {
            EndNight(false);
        }
    }

    void CheckNightState()
    {
        if (currentEntries >= CurrentNight.entriesGoal)
        {
            EndNight(true);
        }
    }

    void EndNight(bool success)
    {
        Debug.Log("?? END NIGHT");
        Debug.Log("?? Antes de incrementar | currentNightIndex = " + currentNightIndex);

        nightActive = false;
        clockManager.StopClock();

        if (!success)
        {
            SceneFlowManager.Instance.LoadGameOver();
            return;
        }

        // Guardar datos de la noche que termina
        lastNightEntries = currentEntries;
        lastNightStrikes = currentStrikes;
        lastNightMaxStrikes = CurrentNight.maxStrikes;


        currentNightIndex++;

        Debug.Log("?? Después de incrementar | currentNightIndex = " + currentNightIndex);
        Debug.Log("?? Total noches = " + nights.Count);

        if (currentNightIndex >= nights.Count)
        {
            SceneFlowManager.Instance.LoadWinDemo();
            return;
        }

        endNightPanel.Show(true);
    }




}

