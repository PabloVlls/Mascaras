using UnityEngine;
using UnityEngine.UI;

public class MagnifyingGlass : MonoBehaviour
{
    [Header("Referencias")]
    public Camera lensCamera;
    public RectTransform toolUI;
    public Camera mainUI_Camera;

    // --- NUEVA VARIABLE ---
    public GameObject backgroundPanel; // Aquí meteremos el [FONDO_NEGRO_LUPA]

    [Header("Configuración de Zoom")]
    public float currentZoom = 2f;
    public float minZoom = 0.5f;
    public float maxZoom = 3f;
    public float scrollSensitivity = 2f;

    [Header("Ajustes Visuales")]
    public Vector3 offsetUI = new Vector3(50, -50, 0);

    private bool isActive = false;

    void Start()
    {
        lensCamera.orthographicSize = currentZoom;
        ToggleTool(false); // Esto apagará todo al inicio
    }

    void Update()
    {
        // YA NO HAY INPUTS AQUÍ. El Manager se encarga.

        if (isActive)
        {
            // Solo mantenemos la lógica de movimiento
            MoveMagnifyingGlass();

            // (Opcional) Puedes dejar el clic derecho aquí como seguridad, 
            // pero el Manager ya lo hace. Mejor bórralo también.
        }
    }

    void MoveMagnifyingGlass()
    {
        Vector2 mousePos = Input.mousePosition;
        toolUI.position = mousePos + (Vector2)offsetUI;

        Vector3 worldPos = mainUI_Camera.ScreenToWorldPoint(mousePos);
        worldPos.z = lensCamera.transform.position.z;
        lensCamera.transform.position = worldPos;
    }

    void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f)
        {
            currentZoom -= scroll * scrollSensitivity;
            currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
            lensCamera.orthographicSize = currentZoom;
        }
    }

    // --- AQUÍ ESTÁ LA MAGIA ---
    public void ToggleTool(bool status)
    {
        isActive = status;

        // 1. Encendemos/Apagamos la Lupa
        toolUI.gameObject.SetActive(status);
        lensCamera.gameObject.SetActive(status);

        // 2. Encendemos/Apagamos el FONDO NEGRO
        if (backgroundPanel != null)
        {
            backgroundPanel.SetActive(status);
        }

        Cursor.visible = !status;

        if (status) lensCamera.orthographicSize = currentZoom;
    }

    public void SwitchState()
    {
        ToggleTool(!isActive);
    }
}