using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockManager : MonoBehaviour
{
    [Header("References")]
    public NightManager nightManager;

    [Header("Debug")]
    public bool debugLogTime = true;

    float elapsedTime = 0f;
    bool clockRunning = false;

    void Update()
    {
        if (!clockRunning) return;

        elapsedTime += Time.deltaTime;

        float progress = Mathf.Clamp01(elapsedTime / nightManager.CurrentNight.nightDuration);
        float hoursPassed = progress * 6f;

        int hour = 12 + Mathf.FloorToInt(hoursPassed);
        int minutes = Mathf.FloorToInt((hoursPassed % 1f) * 60f);

        if (hour >= 13) hour -= 12;

        if (debugLogTime)
        {
            Debug.Log($"?? {hour}:{minutes.ToString("00")} AM");
        }
    }

    public void StartClock()
    {
        elapsedTime = 0f;
        clockRunning = true;
    }

    public void StopClock()
    {
        clockRunning = false;
    }
}
