using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    [Header("Referencias UI")]
    public TextMeshProUGUI strikesTextHUD;
    public TextMeshProUGUI queueTextHUD; // <--- NUEVO: Arrastra el texto de la cola aquí

    [Header("Managers")]
    public NightManager nightManager;

    void Update()
    {
        // 1. Actualizar Strikes
        if (nightManager != null && strikesTextHUD != null)
        {
            strikesTextHUD.text = $"{nightManager.currentStrikes} / {nightManager.CurrentNight.maxStrikes}";
        }

        // 2. Actualizar Cola de Invitados (NUEVO)
        if (nightManager != null && queueTextHUD != null)
        {
          
            queueTextHUD.text = $"{nightManager.CurrentNight.entriesGoal}";

            
        }
    }
}