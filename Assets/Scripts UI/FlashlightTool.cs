using UnityEngine;
using UnityEngine.UI;

public class FlashlightTool : MonoBehaviour
{
    [Header("UI Referencias")]
    public RectTransform flashlightUI; // La imagen de la luz (círculo blanco/amarillo)
    

    [Header("Ajustes")]
    public Vector3 offsetUI = Vector3.zero;

    // Esta variable nos servirá para que los ojos sepan si los estamos alumbrando
    public static bool IsFlashlightActive = false;
    public static Vector3 LightPosition;

    void Start()
    {
        ToggleTool(false);
    }

    void Update()
    {
        // NOTA: Ya no ponemos el Input aquí, lo hará el Manager.

        if (IsFlashlightActive)
        {
            MoveLight();
            // Guardamos la posición para que los ojos la lean
            LightPosition = flashlightUI.position;
        }
    }

    void MoveLight()
    {
        if (flashlightUI != null)
        {
            flashlightUI.position = Input.mousePosition + offsetUI;
        }
    }

    public void ToggleTool(bool status)
    {
        IsFlashlightActive = status;

        if (flashlightUI != null) flashlightUI.gameObject.SetActive(status);
        

        Cursor.visible = !status;
    }
}