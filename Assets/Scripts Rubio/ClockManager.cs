using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ClockManager : MonoBehaviour
{
    [Header("References")]
    public NightManager nightManager;

    [Header("Debug")]
    public bool debugLogTime = true;

    [Header("UI")]
    public TextMeshProUGUI clockText;

    [Header("Sunrise Light")]
    public Light sunriseLight;
    public float maxLightIntensity = 1.5f;


    [Header("Clock Colors")]
    public Color startColor = Color.white;
    public Color endColor = Color.red;


    float elapsedTime = 0f;
    bool clockRunning = false;

    void Update()
    {
        if (!clockRunning) return;

        elapsedTime += Time.deltaTime;

        float progress = Mathf.Clamp01(elapsedTime / nightManager.CurrentNight.nightDuration);

        if (progress >= 1f)
        {
            clockRunning = false;
            if (clockText != null)
            {
                clockText.text = "6:00 AM";
            }
            return;
        }

        float hoursPassed = progress * 6f;
        int hour = 12 + Mathf.FloorToInt(hoursPassed);
        int minutes = Mathf.FloorToInt((hoursPassed % 1f) * 60f);

        if (hour >= 13) hour -= 12;

        if (clockText != null)
        {
            clockText.text = $"{hour}:{minutes.ToString("00")} AM";
        }

        if (clockText != null)
        {
            clockText.text = $"{hour}:{minutes.ToString("00")} AM";
            clockText.color = Color.Lerp(startColor, endColor, progress);
        }

        if (sunriseLight != null)
        {
            float sunriseStart = 5f / 6f; // ? 0.83
            float sunriseProgress = Mathf.InverseLerp(sunriseStart, 1f, progress);

            sunriseLight.intensity = Mathf.Lerp(0f, maxLightIntensity, sunriseProgress);
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
