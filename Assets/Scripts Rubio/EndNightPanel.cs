using UnityEngine;
using TMPro;

public class EndNightPanel : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI resultTitleText;
    public TextMeshProUGUI statsText;
    public GameObject continueButton;

    [Header("References")]
    public NightManager nightManager;
    public GameFlowManager gameFlow;

    bool lastNightWon = false;



    public void Show(bool success)
    {
        lastNightWon = success;
        gameObject.SetActive(true);

        if (success)
        {
            resultTitleText.text = "NOCHE SUPERADA";
        }
        else
        {
            resultTitleText.text = "NOCHE FALLIDA";
        }

        statsText.text =
    $"Entraron: {nightManager.lastNightEntries}\n" +
    $"Strikes: {nightManager.lastNightStrikes} / {nightManager.lastNightMaxStrikes}";


    }

    public void OnContinuePressed()
    {
        gameObject.SetActive(false);

        if (lastNightWon)
        {
            gameFlow.NextNight();
        }
        else
        {
            SceneFlowManager.Instance.LoadGameOver();
        }
    }

}
