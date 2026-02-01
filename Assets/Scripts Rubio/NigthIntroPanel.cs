using UnityEngine;
using TMPro;

public class NightIntroPanel : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI nightTitleText;
    public TextMeshProUGUI nightInfoText;

    [Header("References")]
    public NightManager nightManager;
    public GameFlowManager gameFlow;

    void OnEnable()
    {
        UpdateInfo();
    }

    void UpdateInfo()
    {
        NightConfig night = nightManager.CurrentNight;

        nightTitleText.text = $"NOCHE {night.nightNumber}";
        nightInfoText.text =
            $"Objetivo: {night.entriesGoal} deben entrar\n" +
            $"Strikes permitidos: {night.maxStrikes}";
    }

    public void OnStartNightPressed()
    {

        gameObject.SetActive(false);
        gameFlow.StartNight();
    }
}

